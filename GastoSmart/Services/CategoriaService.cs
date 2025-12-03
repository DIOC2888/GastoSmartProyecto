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
            // Definimos la ruta del archivo JSON
            _rutaArchivo = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "categorias.json");

            CargarDesdeArchivo();

            // Si no hay categorías, agregamos unos datos por defecto
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
        // Carga las categorías desde el archivo JSON.
        private void CargarDesdeArchivo()
        {
            // Si el archivo no existe, no hacemos nada
            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                // Leer y deserializar la lista de categorías desde el archivo
                var json = File.ReadAllText(_rutaArchivo);
                var lista = JsonSerializer.Deserialize<List<Categoria>>(json);

                // Si se deserializó correctamente, actualizamos la lista en memoria
                if (lista != null)
                {
                    // Limpiamos y cargamos la lista
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
            // Configuramos opciones para formato legible
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            // Serializamos la lista de categorías a JSON para guardarla
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
        // Devuelve una categoría por su ID.
        public Categoria? ObtenerPorId(int id)
        {
            return _categorias.FirstOrDefault(c => c.IdCategoria == id);
        }
        // Agrega una nueva categoría.
        public void Agregar(Categoria categoria)
        {
            categoria.IdCategoria = _nextId++;

            // Si no tiene usuario asignado, se le pone el usuario actual
            if (categoria.IdUsuario == 0 && AppServices.UsuarioActual != null)
                categoria.IdUsuario = AppServices.UsuarioActual.IdUsuario;

            _categorias.Add(categoria);
            GuardarEnArchivo();
        }
        // Actualiza una categoría existente.
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
        // Elimina una categoría por su ID.
        public void Eliminar(int id)
        {
            _categorias.RemoveAll(c => c.IdCategoria == id);
            GuardarEnArchivo();
        }
        // Verifica si existe una categoría con el mismo nombre.
        public bool NombreExiste(string nombre)
        {
            var idUsuario = AppServices.UsuarioActual?.IdUsuario ?? 0;

            return _categorias.Any(c =>
                (c.IdUsuario == 0 || c.IdUsuario == idUsuario) &&
                c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
        // Verifica si existe una categoría con el mismo nombre, excluyendo una categoría específica por su ID.
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
