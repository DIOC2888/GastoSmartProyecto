using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    // Configuración del presupuesto global del usuario.
    public class PresupuestoGlobal
    {
        // Monto máximo que el usuario quiere gastar en el mes.
        public decimal MontoMensual { get; set; } = 0m;

        // Umbral de alerta mensual (porcentaje del presupuesto, ej: 90).
        public decimal UmbralAlertaPorcentaje { get; set; } = 90m;

        // Umbral de alerta diaria (porcentaje del presupuesto, ej: 20).
        public decimal UmbralDiarioPorcentaje { get; set; } = 20m;
    }

}
