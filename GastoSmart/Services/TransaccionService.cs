using GastoSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastoSmart.Services
{
    // Servicio encargado de administrar todas las transacciones del sistema.
    // Guarda los datos en memoria y ofrece operaciones CRUD.
    public class TransaccionService
    {
        // Lista interna de transacciones (actúa como una base de datos temporal).
        private readonly List<Transaccion> _transacciones = new();

        // Contador interno para generar IDs autoincrementales.
        private int _nextId = 1;

        public TransaccionService()
        {

        }

        // Devuelve todas las transacciones registradas.
        public List<Transaccion> ObtenerTodo()
        {
            return _transacciones;
        }

        // Agrega una nueva transacción al sistema.
        public void Agregar(Transaccion t)
        {
            // Si no tiene Id, se le asigna uno nuevo.
            if (t.IdTransaccion == 0)
                t.IdTransaccion = _nextId++;

            // Usuario fijo por ahora (en una futura versión será dinámico).
            if (t.IdUsuario == 0)
                t.IdUsuario = 1;

            _transacciones.Add(t);
        }

        // Actualiza los datos de una transacción existente.
        public void Actualizar(Transaccion editada)
        {
            var index = _transacciones.FindIndex(x => x.IdTransaccion == editada.IdTransaccion);

            if (index >= 0)
            {
                _transacciones[index] = editada;
            }
        }

        // Elimina una transacción según su Id.
        public void Eliminar(int id)
        {
            _transacciones.RemoveAll(t => t.IdTransaccion == id);
        }
    }
}
