using GastoSmart.Models;
using System;
using System.IO;
using System.Linq;

namespace GastoSmart.Services
{
    public enum EstadoPresupuesto
    {
        Ok,
        SuperaUmbralMensual,
        SuperaUmbralDiario,
        SuperaPresupuesto
    }

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

        // Presupuesto en memoria para el usuario actual
        private PresupuestoGlobal _presupuesto = new();

        public PresupuestoService(TransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        private string ObtenerRutaArchivo()
        {
            int idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            // Si no hay usuario, usamos un archivo general (opcional)
            string nombreArchivo = (idUsuario == 0)
                ? "presupuesto_global.json"
                : $"presupuesto_{idUsuario}.json";

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);
        }

        private void CargarDesdeArchivo()
        {
            string ruta = ObtenerRutaArchivo();

            if (!File.Exists(ruta))
                return;

            try
            {
                var json = File.ReadAllText(ruta);
                var p = System.Text.Json.JsonSerializer.Deserialize<PresupuestoGlobal>(json);
                if (p != null)
                    _presupuesto = p;
            }
            catch
            {
                // Ignoramos errores de carga.
            }
        }

        private void GuardarEnArchivo()
        {
            string ruta = ObtenerRutaArchivo();

            var opciones = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize(_presupuesto, opciones);
            File.WriteAllText(ruta, json);
        }

        public PresupuestoGlobal ObtenerPresupuesto()
        {
            // Siempre que se pida el presupuesto, intentamos cargar
            // el del usuario actual desde archivo.
            CargarDesdeArchivo();
            return _presupuesto;
        }

        public void Configurar(decimal montoMensual, decimal umbralAlerta, decimal umbralDiario)
        {
            _presupuesto.MontoMensual = montoMensual;
            _presupuesto.UmbralAlertaPorcentaje = umbralAlerta;
            _presupuesto.UmbralDiarioPorcentaje = umbralDiario;

            GuardarEnArchivo();
        }

        public ResultadoPresupuesto ValidarGasto(Transaccion gasto)
        {
            if (!string.Equals(gasto.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase))
            {
                return new ResultadoPresupuesto { Estado = EstadoPresupuesto.Ok };
            }

            // Aseguramos que el presupuesto en memoria esté sincronizado con el archivo.
            CargarDesdeArchivo();

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
