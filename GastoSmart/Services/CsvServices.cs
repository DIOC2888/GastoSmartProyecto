using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Servicio para manejar operaciones de lectura y escritura de archivos CSV
namespace GastoSmart.Services
{
    public class CsvService
    {
        public void Guardar(string ruta, List<string> lineas)
        {
            File.WriteAllLines(ruta, lineas);
        }

        public List<string> Leer(string ruta)
        {
            if (!File.Exists(ruta))
                return new List<string>();

            return File.ReadAllLines(ruta).ToList();
        }
    }
}
