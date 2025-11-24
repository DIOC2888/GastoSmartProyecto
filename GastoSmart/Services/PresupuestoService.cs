using GastoSmart.Models;
using System;
using System.Linq;

namespace GastoSmart.Services
{
    /// Estados posibles al evaluar un nuevo gasto contra el presupuesto.
    public enum EstadoPresupuesto
    {
        Ok,                 // Todo bien, no hay problema.
        SuperaUmbralMensual,// No se pasa del presupuesto, pero se pasa del porcentaje de alerta mensual (ej. 90%).
        SuperaUmbralDiario, // En un solo día se pasa del porcentaje diario (ej. 20% del presupuesto).
        SuperaPresupuesto   // Se pasa por completo del presupuesto mensual.
    }
    /// Resultado de la validación de un gasto contra el presupuesto.
    /// Contiene datos numéricos y el estado general.
    public class ResultadoPresupuesto
    {
        // Estado final del análisis (OK, supera umbral, etc.).
        public EstadoPresupuesto Estado { get; set; } = EstadoPresupuesto.Ok;

        // Total gastado en el mes si se registra este gasto.
        public decimal TotalMensualConGasto { get; set; }

        // Porcentaje del presupuesto mensual utilizado con este gasto incluido.
        public decimal PorcentajeMensual { get; set; }

        // Total gastado en el día si se registra este gasto.
        public decimal TotalDiarioConGasto { get; set; }

        // Porcentaje del presupuesto mensual que se consume solo con el gasto del día.
        public decimal PorcentajeDiario { get; set; }
    }

    /// Servicio encargado de:
    ///  - Guardar la configuración del presupuesto global.
    ///  - Revisar si un nuevo gasto respeta o no el presupuesto.
    public class PresupuestoService
    {
        // Necesitamos las transacciones para saber cuánto se ha gastado.
        private readonly TransaccionService _transaccionService;

        // Presupuesto actual (solo manejamos uno global en memoria).
        private readonly PresupuestoGlobal _presupuesto = new();

        public PresupuestoService(TransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }


        /// Devuelve el presupuesto actual (para mostrarlo o editarlo en formularios).
        public PresupuestoGlobal ObtenerPresupuesto() => _presupuesto;


        /// Configura el presupuesto:
        ///  - montoMensual: cuánto puede gastar en el mes.
        ///  - umbralAlerta: porcentaje donde se dispara la alerta mensual (ej. 90).
        ///  - umbralDiario: porcentaje para la alerta de gasto diario (ej. 20).
        public void Configurar(decimal montoMensual, decimal umbralAlerta, decimal umbralDiario)
        {
            _presupuesto.MontoMensual = montoMensual;
            _presupuesto.UmbralAlertaPorcentaje = umbralAlerta;
            _presupuesto.UmbralDiarioPorcentaje = umbralDiario;
        }

        /// Valida un GASTO contra el presupuesto global.
        /// No modifica nada, solo calcula cómo quedaría si se registra.
        public ResultadoPresupuesto ValidarGasto(Transaccion gasto)
        {
            // Si no es "Gasto", no aplican reglas de presupuesto.
            if (!string.Equals(gasto.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase))
            {
                return new ResultadoPresupuesto { Estado = EstadoPresupuesto.Ok };
            }

            var resultado = new ResultadoPresupuesto();

            // Si no hay presupuesto configurado, no podemos calcular porcentajes útiles.
            if (_presupuesto.MontoMensual <= 0)
            {
                // Se devuelve con Estado Ok pero sin datos significativos.
                return resultado;
            }

            // 1) Obtenemos todas las transacciones del MES que sean GASTO.
            var transaccionesMes = _transaccionService.ObtenerTodo()
                .Where(t => string.Equals(t.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase)
                            && t.Fecha.Year == gasto.Fecha.Year
                            && t.Fecha.Month == gasto.Fecha.Month)
                .ToList();

            // Gasto acumulado en el mes antes del nuevo gasto.
            decimal gastoAcumulado = transaccionesMes.Sum(t => t.Monto);

            // Gasto acumulado si incluimos el nuevo gasto.
            decimal gastoAcumuladoConNuevo = gastoAcumulado + gasto.Monto;
            resultado.TotalMensualConGasto = gastoAcumuladoConNuevo;

            // Porcentaje del presupuesto usado en el mes con este gasto.
            resultado.PorcentajeMensual =
                (gastoAcumuladoConNuevo / _presupuesto.MontoMensual) * 100m;

            // 2) Gasto del día del nuevo gasto.
            var gastosDelDia = transaccionesMes
                .Where(t => t.Fecha.Date == gasto.Fecha.Date) // comparar Date con Date
                .Sum(t => t.Monto);

            decimal gastosDelDiaConNuevo = gastosDelDia + gasto.Monto;
            resultado.TotalDiarioConGasto = gastosDelDiaConNuevo;

            // Porcentaje del presupuesto que se consume en ese día.
            resultado.PorcentajeDiario =
                (gastosDelDiaConNuevo / _presupuesto.MontoMensual) * 100m;

            // Empezamos asumiendo que todo está OK.
            resultado.Estado = EstadoPresupuesto.Ok;

            // 3) Evaluar umbrales en orden de gravedad.

            // 3.1) ¿Se pasa del presupuesto total del mes?
            if (gastoAcumuladoConNuevo > _presupuesto.MontoMensual)
            {
                resultado.Estado = EstadoPresupuesto.SuperaPresupuesto;
                return resultado; // esto es lo más grave, salimos directo.
            }

            // 3.2) ¿Se pasa del umbral mensual (90%)?
            if (resultado.PorcentajeMensual >= _presupuesto.UmbralAlertaPorcentaje)
            {
                resultado.Estado = EstadoPresupuesto.SuperaUmbralMensual;
            }

            // 3.3) ¿Se pasa del umbral diario (20%)?
            if (resultado.PorcentajeDiario >= _presupuesto.UmbralDiarioPorcentaje
                && resultado.Estado == EstadoPresupuesto.Ok)
            {
                // Solo cambiamos a diario si no había alerta mensual ya.
                resultado.Estado = EstadoPresupuesto.SuperaUmbralDiario;
            }

            return resultado;
        }
    }
}
