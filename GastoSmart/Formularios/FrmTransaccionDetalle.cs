using GastoSmart.Models;
using GastoSmart.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GastoSmart.Formularios
{
    public partial class FrmTransaccionDetalle : Form
    {
        public Transaccion Transaccion { get; private set; } = null!;

        private readonly bool _esEdicion;
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;

        // NUEVA
        public FrmTransaccionDetalle()
        {
            InitializeComponent();
            _esEdicion = false;
            InicializarControles();
        }

        // EDITAR
        public FrmTransaccionDetalle(Transaccion existente) : this()
        {
            _esEdicion = true;
            Transaccion = existente;
            CargarDatos();
        }

        private void InicializarControles()
        {
            // Tipo
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Ingreso");
            cboTipo.Items.Add("Gasto");
            cboTipo.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Today;

            // Categorías activas
            var categorias = _categoriaService.ObtenerTodo()
                                              .Where(c => c.Activa)
                                              .ToList();

            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";

            if (categorias.Count == 0)
            {
                MessageBox.Show("No hay categorías activas. Cree al menos una en el menú de Categorías.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarDatos()
        {
            if (Transaccion == null) return;

            dtpFecha.Value = Transaccion.Fecha;
            cboTipo.SelectedItem = Transaccion.Tipo;
            txtMonto.Text = Transaccion.Monto.ToString("0.00");
            txtDescripcion.Text = Transaccion.Descripcion;

            if (Transaccion.IdCategoria > 0)
            {
                cboCategoria.SelectedValue = Transaccion.IdCategoria;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas())
                return;

            if (Transaccion == null)
            {
                Transaccion = new Transaccion();
            }

            Transaccion.Fecha = dtpFecha.Value.Date;
            Transaccion.Tipo = cboTipo.SelectedItem?.ToString() ?? "Gasto";
            Transaccion.Monto = decimal.Parse(txtMonto.Text, CultureInfo.InvariantCulture);
            Transaccion.Descripcion = txtDescripcion.Text.Trim();

           
            if (cboCategoria.SelectedItem is Categoria categoriaSeleccionada)
            {
                Transaccion.IdCategoria = categoriaSeleccionada.IdCategoria;
                Transaccion.NombreCategoria = categoriaSeleccionada.Nombre;
            }
            else
            {
                Transaccion.IdCategoria = 0;
                Transaccion.NombreCategoria = string.Empty;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Ingrese un monto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, NumberStyles.Number,
                CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número mayor que 0.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }

            if (cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoria.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmTransaccionDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}

