using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GastoSmart.Models
{
    // MODELO: Categoria
    // Este modelo representa una categoría que el usuario puede asignar
    // a sus transacciones (por ejemplo: "Comida", "Salario", "Transporte").
    //
    // Los modelos son CLASES que únicamente guardan datos.
    // No tienen lógica compleja ni validaciones. Solo representan "cosas".
    //
    // En este caso, una Categoría almacena:
    // - Nombre
    // - Tipo (Ingreso / Gasto)
    // - Descripción opcional
    // - Estado (Activa / Inactiva)

    public class Categoria
    {
        // Identificador único de la categoría (sirve para editar, eliminar o relacionarla con transacciones)
        public int IdCategoria { get; set; }

        // Id del usuario dueño de la categoría.
        // En este proyecto no estamos manejando usuarios múltiples,
        // pero dejamos el campo para expansión futura.
        public int IdUsuario { get; set; }

        // Nombre visible de la categoría
        // Ejemplo: "Comida", "Salario", "Transporte"
        public string Nombre { get; set; } = string.Empty;

        // Descripción opcional para ampliar información
        public string Descripcion { get; set; } = string.Empty;

        // Determina si esta categoría sirve para "Ingreso" o para "Gasto"
        // Esto permite que solo aparezcan categorías válidas según el tipo de transacción
        public string Tipo { get; set; } = string.Empty;

        // Indica si la categoría está activa.
        // Si está en false, no permite seleccionarla para nuevas transacciones.
        // Esto evita borrar categorías que ya fueron usadas en el historial.
        public bool Activa { get; set; } = true;

        // Este método sobrescribe la conversión de la categoría a texto.
        // Es útil para mostrarla en ComboBox, listas o depuración.
        public override string ToString()
        {
            return $"{Nombre} ({Tipo})";
        }
    }
}
