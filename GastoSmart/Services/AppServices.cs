using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Services
{
    public static class AppServices
    {
        public static CategoriaService CategoriaService { get; } = new CategoriaService();
        public static TransaccionService TransaccionService { get; } = new TransaccionService();
        public static PresupuestoService PresupuestoService { get; } = new PresupuestoService(TransaccionService);
    }

}
