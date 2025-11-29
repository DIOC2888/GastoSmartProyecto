using GastoSmart.Models;
using GastoSmart.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GastoSmart.Services
{
    public class CategoriaService
    {
        private readonly List<Categoria> _categorias = new();
        private int _nextId = 1;

        public CategoriaService()
        {
            // Semillas de ejemplo (pueden quitarse si quieren)
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

        // Devuelve solo las categorías del usuario actual (o globales sin IdUsuario)
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
        }

        public void Actualizar(Categoria categoriaEditada)
        {
            var existente = _categorias.FirstOrDefault(c => c.IdCategoria == categoriaEditada.IdCategoria);
            if (existente == null) return;

            existente.Nombre = categoriaEditada.Nombre;
            existente.Descripcion = categoriaEditada.Descripcion;
            existente.Tipo = categoriaEditada.Tipo;
            existente.Activa = categoriaEditada.Activa;
        }

        public void Eliminar(int id)
        {
            _categorias.RemoveAll(c => c.IdCategoria == id);
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
