using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GastoSmart.Services
{
    // Servicio para gestionar transacciones (ingresos y gastos).
    // Incluye persistencia en JSON.
    public class TransaccionService
    {
        private readonly List<Transaccion> _transacciones = new();
        private int _nextId = 1;

        private readonly string _rutaArchivo;
        // Constructor que inicializa el servicio y carga las transacciones desde el archivo JSON.
        public TransaccionService()
        {
            // Definimos la ruta del archivo JSON
            _rutaArchivo = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "transacciones.json");
            // Cargar las transacciones desde el archivo al iniciar el servicio
            CargarDesdeArchivo();
            
            if (_transacciones.Count > 0)
            {
                _nextId = _transacciones.Max(t => t.IdTransaccion) + 1;
            }
        }

        // Carga las transacciones desde el archivo JSON.
        private void CargarDesdeArchivo()
        {
            // Si el archivo no existe, no hacemos nada
            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                // Leer y deserializar la lista de transacciones desde el archivo
                var json = File.ReadAllText(_rutaArchivo);
                var lista = JsonSerializer.Deserialize<List<Transaccion>>(json);

                // Si se cargaron transacciones, las asignamos a la lista interna
                if (lista != null)
                {
                    _transacciones.Clear();
                    _transacciones.AddRange(lista);
                }
            }
            catch
            {
                // Ignoramos errores de carga para no romper la app.
            }
        }
        // Guarda las transacciones en el archivo JSON.
        private void GuardarEnArchivo()
        {
            // Configuramos opciones para formato legible.
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(_transacciones, opciones);
            File.WriteAllText(_rutaArchivo, json);
        }

        // Devuelve SOLO las transacciones del usuario logueado.
        public List<Transaccion> ObtenerTodo()
        {
            var idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            return _transacciones
                .Where(t => t.IdUsuario == idUsuario)
                .OrderBy(t => t.Fecha)
                .ToList();
        }
        // Agrega una nueva transacción.
        public void Agregar(Transaccion t)
        {
            // Asignar un Id único si no tiene uno.
            if (t.IdTransaccion == 0)
                t.IdTransaccion = _nextId++;

            // Amarrar la transacción al usuario actual
            if (t.IdUsuario == 0 && AppServices.UsuarioActual != null)
                t.IdUsuario = AppServices.UsuarioActual.IdUsuario;

            _transacciones.Add(t);
            GuardarEnArchivo();
        }
        // Actualiza una transacción existente.
        public void Actualizar(Transaccion editada)
        {
            // Buscar la transacción por Id y actualizarla.
            var index = _transacciones.FindIndex(x => x.IdTransaccion == editada.IdTransaccion);
            if (index >= 0)
            {
                // Reemplazar la transacción en la lista.
                _transacciones[index] = editada;
                GuardarEnArchivo();
            }
        }

        public void Eliminar(int id)
        {
            _transacciones.RemoveAll(t => t.IdTransaccion == id);
            GuardarEnArchivo();
        }
    }
}
