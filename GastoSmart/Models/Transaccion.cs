using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    // Representa un movimiento financiero registrado por el usuario.
    public class Transaccion
    {
        // Identificador único de la transacción.
        public int IdTransaccion { get; set; }

        // Usuario dueño de la transacción.
        public int IdUsuario { get; set; }

        // Categoría asociada (ej: Alimentación, Transporte).
        public int IdCategoria { get; set; }

        // Fecha en la que se realizó la transacción.
        public DateTime Fecha { get; set; }

        // Tipo: "Ingreso" o "Gasto".
        public string Tipo { get; set; } = string.Empty;

        // Monto económico de la transacción.
        public decimal Monto { get; set; }

        // Descripción opcional escrita por el usuario.
        public string Descripcion { get; set; } = string.Empty;

        // Nombre de la categoría (guardado para mostrar en la UI).
        public string NombreCategoria { get; set; } = string.Empty;

        // Representación corta de la transacción para depuración o listados simples.
        public override string ToString()
        {
            return $"{Fecha.ToShortDateString()} - {Tipo} - {Monto:C}";
        }
    }
}
