using GastoSmart.Models;
using System;
using System.Linq;

namespace GastoSmart.Services
{
    // Estados posibles al evaluar un nuevo gasto contra el presupuesto global.
    public enum EstadoPresupuesto
    {
        Ok,                 // No hay problema.
        SuperaUmbralMensual,// Llega o supera el % de alerta mensual (ej. 90%).
        SuperaUmbralDiario, // Llega o supera el % diario permitido (ej. 20%).
        SuperaPresupuesto   // Supera el presupuesto mensual total.
    }

    // Resultado de la validación de un gasto contra el presupuesto.
    public class ResultadoPresupuesto
    {
        // Estado final del análisis.
        public EstadoPresupuesto Estado { get; set; } = EstadoPresupuesto.Ok;

        // Total gastado en el mes considerando el nuevo gasto.
        public decimal TotalMensualConGasto { get; set; }

        // Porcentaje del presupuesto mensual usado con ese gasto.
        public decimal PorcentajeMensual { get; set; }

        // Total gastado en el día considerando el nuevo gasto.
        public decimal TotalDiarioConGasto { get; set; }

        // Porcentaje del presupuesto mensual gastado solo en ese día.
        public decimal PorcentajeDiario { get; set; }
    }

    // Maneja la configuración del presupuesto global y sus validaciones.
    public class PresupuestoService
    {
        // Servicio de transacciones para leer el historial de gastos.
        private readonly TransaccionService _transaccionService;

        // Presupuesto global actual (en memoria).
        private readonly PresupuestoGlobal _presupuesto = new();

        public PresupuestoService(TransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        // Devuelve el presupuesto actual.
        public PresupuestoGlobal ObtenerPresupuesto() => _presupuesto;

        // Configura el presupuesto global del usuario.
        public void Configurar(decimal montoMensual, decimal umbralAlerta, decimal umbralDiario)
        {
            _presupuesto.MontoMensual = montoMensual;
            _presupuesto.UmbralAlertaPorcentaje = umbralAlerta;
            _presupuesto.UmbralDiarioPorcentaje = umbralDiario;
        }

        // Valida un gasto contra el presupuesto:
        // calcula cómo quedaría el mes y el día si se registra ese gasto.
        public ResultadoPresupuesto ValidarGasto(Transaccion gasto)
        {
            // Si no es un "Gasto", no se aplican reglas de presupuesto.
            if (!string.Equals(gasto.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase))
            {
                return new ResultadoPresupuesto { Estado = EstadoPresupuesto.Ok };
            }

            var resultado = new ResultadoPresupuesto();

            // Si no hay presupuesto configurado, no se pueden calcular porcentajes útiles.
            if (_presupuesto.MontoMensual <= 0)
            {
                return resultado;
            }

            // 1) Gastos del mes de la transacción.
            var transaccionesMes = _transaccionService.ObtenerTodo()
                .Where(t => string.Equals(t.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase)
                            && t.Fecha.Year == gasto.Fecha.Year
                            && t.Fecha.Month == gasto.Fecha.Month)
                .ToList();

            decimal gastoAcumulado = transaccionesMes.Sum(t => t.Monto);
            decimal gastoAcumuladoConNuevo = gastoAcumulado + gasto.Monto;

            resultado.TotalMensualConGasto = gastoAcumuladoConNuevo;
            resultado.PorcentajeMensual =
                (gastoAcumuladoConNuevo / _presupuesto.MontoMensual) * 100m;

            // 2) Gastos del día específico.
            var gastosDelDia = transaccionesMes
                .Where(t => t.Fecha.Date == gasto.Fecha.Date)
                .Sum(t => t.Monto);

            decimal gastosDelDiaConNuevo = gastosDelDia + gasto.Monto;
            resultado.TotalDiarioConGasto = gastosDelDiaConNuevo;
            resultado.PorcentajeDiario =
                (gastosDelDiaConNuevo / _presupuesto.MontoMensual) * 100m;

            resultado.Estado = EstadoPresupuesto.Ok;

            // 3) Evaluar los umbrales.

            // 3.1) Supera el presupuesto mensual total.
            if (gastoAcumuladoConNuevo > _presupuesto.MontoMensual)
            {
                resultado.Estado = EstadoPresupuesto.SuperaPresupuesto;
                return resultado;
            }

            // 3.2) Llega o supera el umbral mensual.
            if (resultado.PorcentajeMensual >= _presupuesto.UmbralAlertaPorcentaje)
            {
                resultado.Estado = EstadoPresupuesto.SuperaUmbralMensual;
            }

            // 3.3) Llega o supera el umbral diario, solo si no hay alerta mensual.
            if (resultado.PorcentajeDiario >= _presupuesto.UmbralDiarioPorcentaje
                && resultado.Estado == EstadoPresupuesto.Ok)
            {
                resultado.Estado = EstadoPresupuesto.SuperaUmbralDiario;
            }

            return resultado;
        }
    }
}
