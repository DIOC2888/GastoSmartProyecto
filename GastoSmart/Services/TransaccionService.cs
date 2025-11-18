using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Services
{
    public class TransaccionService
    {
        private readonly List<Transaccion> _transacciones = new();
        private int _nextId = 1;

        public TransaccionService()
        {
            // Semillas de prueba (opcional)
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
        }

        public List<Transaccion> ObtenerTodo()
        {
            return _transacciones;
        }

        public void Agregar(Transaccion t)
        {
            if (t.IdTransaccion == 0)
                t.IdTransaccion = _nextId++;

            if (t.IdUsuario == 0)
                t.IdUsuario = 1; // por ahora usuario fijo

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
    }
}
