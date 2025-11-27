using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Models
{
    // Representa un usuario registrado en el sistema.
    public class Usuario
    {
        // Identificador único del usuario.
        public int IdUsuario { get; set; }

        // Nombre del usuario.
        public string Nombre { get; set; } = string.Empty;

        // Correo único asociado al usuario.
        public string Email { get; set; } = string.Empty;

        // Contraseña almacenada como hash (nunca en texto plano).
        public string HashPassword { get; set; } = string.Empty;

        // Fecha en la que se registró el usuario en el sistema.
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
internal class Usuario
    {
    }
