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

        public TransaccionService()
        {
            _rutaArchivo = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "transacciones.json");

            CargarDesdeArchivo();

            if (_transacciones.Count > 0)
            {
                _nextId = _transacciones.Max(t => t.IdTransaccion) + 1;
            }
        }

        private void CargarDesdeArchivo()
        {
            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                var lista = JsonSerializer.Deserialize<List<Transaccion>>(json);

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

        private void GuardarEnArchivo()
        {
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

        public void Agregar(Transaccion t)
        {
            if (t.IdTransaccion == 0)
                t.IdTransaccion = _nextId++;

            // Amarrar la transacción al usuario actual
            if (t.IdUsuario == 0 && AppServices.UsuarioActual != null)
                t.IdUsuario = AppServices.UsuarioActual.IdUsuario;

            _transacciones.Add(t);
            GuardarEnArchivo();
        }

        public void Actualizar(Transaccion editada)
        {
            var index = _transacciones.FindIndex(x => x.IdTransaccion == editada.IdTransaccion);
            if (index >= 0)
            {
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
