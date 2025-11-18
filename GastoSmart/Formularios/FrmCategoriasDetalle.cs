using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GastoSmart.Models;
using System.Globalization;

namespace GastoSmart.Formularios
{
    public partial class FrmCategoriasDetalle : Form
    {
        public Categoria Categoria { get; private set; } = null!;

        private readonly bool _esEdicion;

        public FrmCategoriasDetalle()
        {
            InitializeComponent();
            _esEdicion = false;
            InicializarControles();
        }

        public FrmCategoriasDetalle(Categoria categoriaExistente) : this()
        {
            _esEdicion = true;
            Categoria = categoriaExistente;
            CargarDatos();
        }

        private void InicializarControles()
        {
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Ingreso");
            cboTipo.Items.Add("Gasto");
            cboTipo.SelectedIndex = 1;
            chkActiva.Checked = true;
        }

        private void CargarDatos()
        {
            if (Categoria == null)
                return;
            txtNombre.Text = Categoria.Nombre;
            txtDescripcionCategoria.Text = Categoria.Descripcion;
            cboTipo.SelectedItem = Categoria.Tipo;
            chkActiva.Checked = Categoria.Activa;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas()) return;

            if (Categoria == null)
                Categoria = new Categoria();

            Categoria.Nombre = txtNombre.Text.Trim();
            Categoria.Descripcion = txtDescripcionCategoria.Text.Trim();
            Categoria.Tipo = cboTipo.SelectedItem?.ToString() ?? "Gasto";
            Categoria.Activa = chkActiva.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (cboTipo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipo.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtDescripcionCategoria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
