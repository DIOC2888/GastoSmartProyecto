using GastoSmart.Models;

namespace GastoSmart.Services
{
    public static class AppServices
    {
        public static UsuarioService UsuarioService { get; } = new UsuarioService();

        public static CategoriaService CategoriaService { get; } = new CategoriaService();
        public static TransaccionService TransaccionService { get; } = new TransaccionService();
        public static PresupuestoService PresupuestoService { get; } =
            new PresupuestoService(TransaccionService);

        // Aquí guardamos quién está logueado actualmente
        public static Usuario? UsuarioActual { get; set; }
    }
}
