using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    public class Transaccion
    {
        public int IdTransaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }

        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty;// "Ingreso" o "Gasto"
        public decimal Monto { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public string NombreCategoria { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Fecha.ToShortDateString()} - {Tipo} - {Monto:C}";
        }
    }
}
