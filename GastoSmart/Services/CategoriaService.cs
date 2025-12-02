using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GastoSmart.Services
{
    // Servicio para gestionar las categorías (en memoria + JSON).
    public class CategoriaService
    {
        private readonly List<Categoria> _categorias = new();
        private int _nextId = 1;

        // Archivo donde se guardan TODAS las categorías
        private readonly string _rutaArchivo;

        public CategoriaService()
        {
            _rutaArchivo = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "categorias.json");

            CargarDesdeArchivo();

            // Si no hay categorías, agregamos unas semillas
            if (_categorias.Count == 0)
            {
                Agregar(new Categoria
                {
                    Nombre = "Alimentación",
                    Descripcion = "Comidas, snacks, etc.",
                    Tipo = "Gasto",
                    Activa = true
                });

                Agregar(new Categoria
                {
                    Nombre = "Beca",
                    Descripcion = "Ingresos por beca",
                    Tipo = "Ingreso",
                    Activa = true
                });
            }

            if (_categorias.Count > 0)
            {
                _nextId = _categorias.Max(c => c.IdCategoria) + 1;
            }
        }

        private void CargarDesdeArchivo()
        {
            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                var lista = JsonSerializer.Deserialize<List<Categoria>>(json);

                if (lista != null)
                {
                    _categorias.Clear();
                    _categorias.AddRange(lista);
                }
            }
            catch
            {
                // En un proyecto real se loguearía el error.
            }
        }

        private void GuardarEnArchivo()
        {
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(_categorias, opciones);
            File.WriteAllText(_rutaArchivo, json);
        }

        // Devuelve solo las categorías del usuario actual o globales (IdUsuario = 0)
        public List<Categoria> ObtenerTodo()
        {
            var idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            return _categorias
                .Where(c => c.IdUsuario == 0 || c.IdUsuario == idUsuario)
                .ToList();
        }

        public Categoria? ObtenerPorId(int id)
        {
            return _categorias.FirstOrDefault(c => c.IdCategoria == id);
        }

        public void Agregar(Categoria categoria)
        {
            categoria.IdCategoria = _nextId++;

            // Si no tiene usuario asignado, se le pone el usuario actual
            if (categoria.IdUsuario == 0 && AppServices.UsuarioActual != null)
                categoria.IdUsuario = AppServices.UsuarioActual.IdUsuario;

            _categorias.Add(categoria);
            GuardarEnArchivo();
        }

        public void Actualizar(Categoria categoriaEditada)
        {
            var existente = _categorias.FirstOrDefault(c => c.IdCategoria == categoriaEditada.IdCategoria);
            if (existente == null) return;

            existente.Nombre = categoriaEditada.Nombre;
            existente.Descripcion = categoriaEditada.Descripcion;
            existente.Tipo = categoriaEditada.Tipo;
            existente.Activa = categoriaEditada.Activa;

            GuardarEnArchivo();
        }

        public void Eliminar(int id)
        {
            _categorias.RemoveAll(c => c.IdCategoria == id);
            GuardarEnArchivo();
        }

        public bool NombreExiste(string nombre)
        {
            var idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            return _categorias.Any(c =>
                (c.IdUsuario == 0 || c.IdUsuario == idUsuario) &&
                c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public bool NombreExiste(string nombre, int idExcluir)
        {
            var idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            return _categorias.Any(c =>
                c.IdCategoria != idExcluir &&
                (c.IdUsuario == 0 || c.IdUsuario == idUsuario) &&
                c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
