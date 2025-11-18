using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GastoSmart.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // "Ingreso" o "Gasto"
        public string Tipo { get; set; } = string.Empty;

        // Para evitar borrar categorías en uso
        public bool Activa { get; set; } = true;

        public override string ToString()
        {
            return $"{Nombre} ({Tipo})";
        }
    }
}

