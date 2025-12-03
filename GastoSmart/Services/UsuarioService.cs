using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GastoSmart.Services
{
    // Servicio responsable de manejar usuarios:
    // - Registro
    // - Login (autenticación)
    // - Persistencia en archivo JSON
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new();
        private int _nextId = 1;

        // Ruta del archivo donde se guardan los usuarios
        private readonly string _rutaArchivo;

        public UsuarioService()
        {
            // Carpeta donde está corriendo la app + archivo usuarios.json
            _rutaArchivo = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "usuarios.json");

            // 1) Intentar cargar usuarios desde archivo
            CargarDesdeArchivo();

            // 2) Si no había usuarios en el archivo, podemos crear uno de prueba
            if (_usuarios.Count == 0)
            {
                _usuarios.Add(new Usuario
                {
                    IdUsuario = _nextId++,
                    Nombre = "Demo",
                    Email = "demo@gastosmart.com",
                    HashPassword = "1234",
                    FechaCreacion = DateTime.Now
                });

                GuardarEnArchivo();
            }
            else
            {
                // Ajustamos el siguiente Id según el usuario con mayor Id
                _nextId = _usuarios.Max(u => u.IdUsuario) + 1;
            }
        }

        // Lee el archivo JSON y carga la lista _usuarios
        private void CargarDesdeArchivo()
        {
            if (!File.Exists(_rutaArchivo))
                return;

            try
            {
                // Leer y deserializar la lista de usuarios desde el archivo
                var json = File.ReadAllText(_rutaArchivo);
                var lista = JsonSerializer.Deserialize<List<Usuario>>(json);

                if (lista != null)
                {
                    _usuarios.Clear();
                    _usuarios.AddRange(lista);
                }
            }
            catch
            {
                // En un proyecto real, podrías registrar el error en un log.
                // Aquí simplemente ignoramos el error para que la app siga funcionando.
            }
        }

        // Escribe la lista completa de usuarios en el archivo JSON
        private void GuardarEnArchivo()
        {
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true // para que el JSON sea legible
            };

            var json = JsonSerializer.Serialize(_usuarios, opciones);
            File.WriteAllText(_rutaArchivo, json);
        }

        // LOGIN: busca un usuario cuyo email y password coincidan
        public Usuario? Autenticar(string email, string password)
        {
            return _usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.HashPassword == password);
        }

        // Verifica si ya existe un usuario con ese correo
        public bool ExisteEmail(string email)
        {
            return _usuarios.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // REGISTRO: crea un nuevo usuario, lo agrega a la lista y guarda en archivo
        public Usuario Registrar(string nombre, string email, string password)
        {
            // Asumimos que ya se verificó que el email no existe
            var nuevo = new Usuario
            {
                IdUsuario = _nextId++,
                Nombre = nombre,
                Email = email,
                HashPassword = password,
                FechaCreacion = DateTime.Now
            };
            // Agregar a la lista en memoria
            _usuarios.Add(nuevo);

            // Muy importante guardar cambios en disco
            GuardarEnArchivo();

            return nuevo;
        }
        // Devuelve todos los usuarios (útil para administración)
        public List<Usuario> ObtenerTodos()
        {
            return _usuarios.ToList();
        }
    }
}
