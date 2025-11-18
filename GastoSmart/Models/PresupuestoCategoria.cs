using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    public class PresupuestoCategoria
    {
        public int IdPresupuesto { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }

        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal MontoLimite { get; set; }
    }
}
