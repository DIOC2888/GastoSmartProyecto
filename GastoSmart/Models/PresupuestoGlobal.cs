using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    // Modelo que guarda la configuración del presupuesto global mensual del usuario.
    public class PresupuestoGlobal
    {
        // Límite total de gasto permitido en el mes.
        public decimal MontoMensual { get; set; } = 0m;

        // Porcentaje del presupuesto mensual en el que debe aparecer una alerta.
        public decimal UmbralAlertaPorcentaje { get; set; } = 90m;

        // Porcentaje del presupuesto mensual que, si se gasta en un solo día, genera alerta.
        public decimal UmbralDiarioPorcentaje { get; set; } = 20m;
    }
}
