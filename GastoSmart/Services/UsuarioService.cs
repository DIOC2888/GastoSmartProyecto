using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GastoSmart.Services
{
    // Servicio responsable de manejar usuarios en memoria:
    // registro, búsqueda y autenticación (login).
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new();
        private int _nextId = 1;

        public UsuarioService()
        {
            // Usuario de prueba (pueden cambiarlo o agregar más)
            _usuarios.Add(new Usuario
            {
                IdUsuario = _nextId++,
                Nombre = "Demo",
                Email = "demo@gastosmart.com",
                HashPassword = "1234" // por ahora en texto plano
            });
        }

        // Devuelve el usuario si email+password son correctos; si no, null.
        public Usuario? Autenticar(string email, string password)
        {
            return _usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.HashPassword == password);
        }

        //Registrar un nuevo usuario
        public Usuario Registrar(string nombre, string email, string password)
        {
            var usuario = new Usuario
            {
                IdUsuario = _nextId++,
                Nombre = nombre,
                Email = email,
                HashPassword = password,
                FechaCreacion = DateTime.Now
            };

            _usuarios.Add(usuario);
            return usuario;
        }

        public bool ExisteEmail(string email)
        {
            return _usuarios.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

    }
}
