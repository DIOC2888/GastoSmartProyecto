using GastoSmart.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GastoSmart.Services
{
    // Estados posibles al evaluar un nuevo gasto contra el presupuesto.
    public enum EstadoPresupuesto
    {
        Ok,
        SuperaUmbralMensual,
        SuperaUmbralDiario,
        SuperaPresupuesto
    }

    // Resultado de la validación de un gasto contra el presupuesto.
    public class ResultadoPresupuesto
    {
        public EstadoPresupuesto Estado { get; set; } = EstadoPresupuesto.Ok;
        public decimal TotalMensualConGasto { get; set; }
        public decimal PorcentajeMensual { get; set; }
        public decimal TotalDiarioConGasto { get; set; }
        public decimal PorcentajeDiario { get; set; }
    }

    public class PresupuestoService
    {
        private readonly TransaccionService _transaccionService;

        // Presupuesto actual en memoria
        private readonly PresupuestoGlobal _presupuesto = new();

        // Archivo donde se guarda la config del presupuesto
        private readonly string _rutaArchivo = "presupuesto.txt";

        public PresupuestoService(TransaccionService transaccionService)
        {
            _transaccionService = transaccionService;

            // Al crear el servicio, intentamos cargar la configuración previa
            CargarDesdeArchivo();
        }

        // Devuelve el presupuesto actual (para formularios)
        public PresupuestoGlobal ObtenerPresupuesto() => _presupuesto;

        // Configura y guarda el presupuesto en disco
        public void Configurar(decimal montoMensual, decimal umbralAlerta, decimal umbralDiario)
        {
            _presupuesto.MontoMensual = montoMensual;
            _presupuesto.UmbralAlertaPorcentaje = umbralAlerta;
            _presupuesto.UmbralDiarioPorcentaje = umbralDiario;

            GuardarEnArchivo();
        }

        // ------------------ PERSISTENCIA DEL PRESUPUESTO ------------------

        private void GuardarEnArchivo()
        {
            try
            {
                // Guardamos en una sola línea: monto|umbralMensual|umbralDiario
                string linea = string.Join("|",
                    _presupuesto.MontoMensual.ToString(CultureInfo.InvariantCulture),
                    _presupuesto.UmbralAlertaPorcentaje.ToString(CultureInfo.InvariantCulture),
                    _presupuesto.UmbralDiarioPorcentaje.ToString(CultureInfo.InvariantCulture)
                );

                File.WriteAllText(_rutaArchivo, linea);
            }
            catch (Exception ex)
            {
                // Para no romper la app, solo lo mostramos en consola
                Console.WriteLine($"Error al guardar presupuesto: {ex.Message}");
            }
        }

        private void CargarDesdeArchivo()
        {
            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                var contenido = File.ReadAllText(_rutaArchivo);
                if (string.IsNullOrWhiteSpace(contenido))
                    return;

                var partes = contenido.Split('|');
                if (partes.Length < 3)
                    return;

                if (decimal.TryParse(partes[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var monto))
                    _presupuesto.MontoMensual = monto;

                if (decimal.TryParse(partes[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var umbralMensual))
                    _presupuesto.UmbralAlertaPorcentaje = umbralMensual;

                if (decimal.TryParse(partes[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var umbralDiario))
                    _presupuesto.UmbralDiarioPorcentaje = umbralDiario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar presupuesto: {ex.Message}");
            }
        }

        // ------------------- ValidarGasto (igual que ya tenías) -------------------

        public ResultadoPresupuesto ValidarGasto(Transaccion gasto)
        {
            if (!string.Equals(gasto.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase))
            {
                return new ResultadoPresupuesto { Estado = EstadoPresupuesto.Ok };
            }

            var resultado = new ResultadoPresupuesto();

            if (_presupuesto.MontoMensual <= 0)
            {
                return resultado;
            }

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

            var gastosDelDia = transaccionesMes
                .Where(t => t.Fecha.Date == gasto.Fecha.Date)
                .Sum(t => t.Monto);

            decimal gastosDelDiaConNuevo = gastosDelDia + gasto.Monto;
            resultado.TotalDiarioConGasto = gastosDelDiaConNuevo;

            resultado.PorcentajeDiario =
                (gastosDelDiaConNuevo / _presupuesto.MontoMensual) * 100m;

            resultado.Estado = EstadoPresupuesto.Ok;

            if (gastoAcumuladoConNuevo > _presupuesto.MontoMensual)
            {
                resultado.Estado = EstadoPresupuesto.SuperaPresupuesto;
                return resultado;
            }

            if (resultado.PorcentajeMensual >= _presupuesto.UmbralAlertaPorcentaje)
            {
                resultado.Estado = EstadoPresupuesto.SuperaUmbralMensual;
            }

            if (resultado.PorcentajeDiario >= _presupuesto.UmbralDiarioPorcentaje
                && resultado.Estado == EstadoPresupuesto.Ok)
            {
                resultado.Estado = EstadoPresupuesto.SuperaUmbralDiario;
            }

            return resultado;
        }
    }
}
