using GastoSmart.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GastoSmart.Services;

namespace GastoSmart
{
    public partial class FrmMenuPrincipal : Form
    {
        //Servicio centralizado que administra las transacciones (agregar, editar, eliminar, obtener)
        private readonly TransaccionService _transaccionService = AppServices.TransaccionService;

        //Servicio encargado del presupuesto global y validaciones del gasto
        private readonly PresupuestoService _presupuestoService = AppServices.PresupuestoService;

        public FrmMenuPrincipal()
        {
            InitializeComponent();

            //Al iniciar el menú principal se calculan los totales actuales (Saldo, Presupuesto, Gastos)
            ActualizarTotales();
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            FrmTransacciones frm = new FrmTransacciones();

            //Suscripción al evento FormClosed del formulario FrmTransacciones
            //Explicación:
            //Cuando el formulario de transacciones se cierre, se volverán a calcular los totales del menú principal.
            //Esto permite que si se agrega, edita o elimina una transacción, el saldo actual se actualice automáticamente.
            frm.FormClosed += (s, args) => ActualizarTotales();

            frm.ShowDialog(); //Abre el formulario como ventana modal
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            //Uso de "using" para asegurar que el formulario se cierre y libere recursos correctamente
            using (var frm = new FrmCategorias())
            {
                frm.ShowDialog();
            }
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            //Formulario de configuración del presupuesto mensual global
            using var frm = new FrmPresupuestoGlobal();

            //Si el presupuesto se modifica, también actualizamos el resumen del menú principal
            frm.FormClosed += (s, args) => ActualizarTotales();

            frm.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            //Formulario donde se generan reportes y exportaciones (CSV, PDF, XLSX según lo que agreguemos)
            using var frm = new FrmReportes();
            frm.ShowDialog();
        }

        //Método central que calcula el estado financiero del usuario
        private void ActualizarTotales()
        {
            //Obtener todas las transacciones almacenadas en memoria
            var transacciones = _transaccionService.ObtenerTodo();

            //Calcular el total de ingresos: filtrando por tipo "Ingreso"
            decimal totalIngresos = transacciones
                .Where(t => t.Tipo == "Ingreso")
                .Sum(t => t.Monto);

            //Calcular el total de gastos: filtrando por tipo "Gasto"
            decimal totalGastos = transacciones
                .Where(t => t.Tipo == "Gasto")
                .Sum(t => t.Monto);

            //El balance es ingresos - gastos
            //Si es positivo, hay saldo disponible; si es negativo, significa déficit
            decimal balance = totalIngresos - totalGastos;

            //Obtener el monto mensual del presupuesto configurado por el usuario
            var presupuesto = _presupuestoService.ObtenerPresupuesto().MontoMensual;

            //Actualizar textos visibles en el formulario principal con formato monetario (C2 → moneda con 2 decimales)
            lblSaldoActual.Text = $"Saldo Actual: {balance:C2}";
            lblPresupuesto.Text = $"Presupuesto: {presupuesto:C2}";
            lblMontoGastado.Text = $"Monto Gastado: {totalGastos:C2}";
        }
    }
}