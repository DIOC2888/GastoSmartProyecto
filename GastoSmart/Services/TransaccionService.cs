using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GastoSmart.Services
{
    // Servicio que administra todas las transacciones del sistema (CRUD + CSV)
    public class TransaccionService
    {
        // Lista en memoria de transacciones
        private readonly List<Transaccion> _transacciones = new();

        // Siguiente Id disponible
        private int _nextId = 1;

        // Archivo donde se guardan las transacciones
        private readonly string _rutaArchivo = "transacciones.csv";

        public TransaccionService()
        {
            // Intentamos cargar desde archivo
            CargarDesdeArchivo();

            // Si no había datos, agregamos semillas de prueba (opcional)
            if (_transacciones.Count == 0)
            {
                _transacciones.Add(new Transaccion
                {
                    IdTransaccion = _nextId++,
                    IdUsuario = 1,
                    IdCategoria = 1,
                    Fecha = DateTime.Today,
                    Tipo = "Gasto",
                    Monto = 120.50m,
                    Descripcion = "Almuerzo"
                });

                _transacciones.Add(new Transaccion
                {
                    IdTransaccion = _nextId++,
                    IdUsuario = 1,
                    IdCategoria = 2,
                    Fecha = DateTime.Today,
                    Tipo = "Ingreso",
                    Monto = 3000m,
                    Descripcion = "Beca"
                });

                GuardarEnArchivo();
            }
            else
            {
                // Si había datos, calculamos el siguiente Id
                _nextId = _transacciones.Max(t => t.IdTransaccion) + 1;
            }
        }

        public List<Transaccion> ObtenerTodo()
        {
            var idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            return _transacciones
                .Where(t => t.IdUsuario == idUsuario)
                .ToList();
        }

        public void Agregar(Transaccion t)
        {
            if (t.IdTransaccion == 0)
                t.IdTransaccion = _nextId++;

            // Si no se asignó usuario, se usa el usuario actual.
            if (t.IdUsuario == 0 && AppServices.UsuarioActual != null)
                t.IdUsuario = AppServices.UsuarioActual.IdUsuario;

            _transacciones.Add(t);
        }

        public void Actualizar(Transaccion editada)
        {
            var index = _transacciones.FindIndex(x => x.IdTransaccion == editada.IdTransaccion);
            if (index >= 0)
            {
                _transacciones[index] = editada;
            }
        }

        public void Eliminar(int id)
        {
            _transacciones.RemoveAll(t => t.IdTransaccion == id);
        }
        //  PERSISTENCIA: Guardar y cargar desde transacciones.cs
        private void GuardarEnArchivo()
        {
            try
            {
                var lineas = new List<string>();

                // Encabezado opcional
                lineas.Add("IdTransaccion|IdUsuario|IdCategoria|Fecha|Tipo|Monto|Descripcion");

                foreach (var t in _transacciones)
                {
                    string linea = string.Join("|",
                        t.IdTransaccion,
                        t.IdUsuario,
                        t.IdCategoria,
                        t.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        t.Tipo,
                        t.Monto.ToString(CultureInfo.InvariantCulture),
                        t.Descripcion
                    );

                    lineas.Add(linea);
                }

                File.WriteAllLines(_rutaArchivo, lineas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar transacciones: {ex.Message}");
            }
        }

        private void CargarDesdeArchivo()
        {
            _transacciones.Clear();

            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                var lineas = File.ReadAllLines(_rutaArchivo);

                bool primera = true;
                foreach (var linea in lineas)
                {
                    if (primera)
                    {
                        primera = false;
                        if (linea.StartsWith("IdTransaccion|"))
                            continue; // saltar encabezado
                    }

                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    var partes = linea.Split('|');
                    if (partes.Length < 7)
                        continue;

                    if (!int.TryParse(partes[0], out int idTransaccion))
                        continue;

                    int.TryParse(partes[1], out int idUsuario);
                    int.TryParse(partes[2], out int idCategoria);

                    DateTime fecha;
                    if (!DateTime.TryParseExact(
                            partes[3],
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out fecha))
                    {
                        fecha = DateTime.Today;
                    }

                    decimal monto;
                    if (!decimal.TryParse(partes[5], NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
                    {
                        monto = 0m;
                    }

                    var trans = new Transaccion
                    {
                        IdTransaccion = idTransaccion,
                        IdUsuario = idUsuario,
                        IdCategoria = idCategoria,
                        Fecha = fecha,
                        Tipo = partes[4],
                        Monto = monto,
                        Descripcion = partes[6]
                    };

                    _transacciones.Add(trans);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar transacciones: {ex.Message}");
            }
        }
    }
}
