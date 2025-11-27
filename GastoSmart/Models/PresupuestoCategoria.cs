using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    // Modelo que representa un presupuesto asignado a una categoría
    // (por ejemplo: Alimentación = 1500 C$ en octubre de 2025).
    public class PresupuestoCategoria
    {
        // Identificador único del presupuesto
        public int IdPresupuesto { get; set; }

        // Usuario dueño del presupuesto (para expansión futura con múltiples usuarios)
        public int IdUsuario { get; set; }

        // Categoría a la que pertenece este presupuesto
        public int IdCategoria { get; set; }

        // Periodo al que aplica el presupuesto
        public int Anio { get; set; }
        public int Mes { get; set; }

        // Monto límite asignado a esa categoría en ese mes
        public decimal MontoLimite { get; set; }
    }
}