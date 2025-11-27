using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Servicio encargado de operaciones básicas para guardar y leer archivos CSV.
// Centraliza estas funciones para que puedan usarse en distintos formularios.
namespace GastoSmart.Services
{
    public class CsvService
    {
        // Guarda una lista de líneas en un archivo CSV.
        // "ruta" es la ubicación donde se guardará el archivo.
        // "lineas" contiene cada fila ya formateada como texto.
        public void Guardar(string ruta, List<string> lineas)
        {
            File.WriteAllLines(ruta, lineas);
        }

        // Lee un archivo CSV línea por línea.
        // Si el archivo no existe, devuelve una lista vacía para evitar errores.
        public List<string> Leer(string ruta)
        {
            if (!File.Exists(ruta))
                return new List<string>();

            return File.ReadAllLines(ruta).ToList();
        }
    }
}
