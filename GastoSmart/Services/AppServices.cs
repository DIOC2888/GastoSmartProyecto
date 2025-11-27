using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Services
{
    // Clase estática que actúa como contenedor global de servicios.
    // Permite que cualquier formulario o componente use las mismas instancias,
    // manteniendo los datos centralizados en toda la aplicación.
    public static class AppServices
    {
        // Servicio encargado de gestionar categorías (crear, editar, eliminar, listar).
        public static CategoriaService CategoriaService { get; } = new CategoriaService();

        // Servicio encargado de manejar las transacciones financieras.
        public static TransaccionService TransaccionService { get; } = new TransaccionService();

        // Servicio que controla el presupuesto global y las validaciones del gasto.
        // Se le pasa la misma instancia de TransaccionService para analizar el historial de gastos.
        public static PresupuestoService PresupuestoService { get; } =
            new PresupuestoService(TransaccionService);
    }
}