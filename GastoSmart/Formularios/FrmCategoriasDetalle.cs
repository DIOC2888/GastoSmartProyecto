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
        //Objeto Categoría que será devuelto al formulario padre
        //Se usa en modo "Nueva" y "Editar"
        public Categoria Categoria { get; private set; } = null!;

        //Indica si el formulario está en modo edición
        private readonly bool _esEdicion;

        public FrmCategoriasDetalle()
        {
            InitializeComponent();

            //Este formulario está siendo usado para crear una nueva categoría
            _esEdicion = false;

            //Inicializa los valores de los controles (combos, checks, etc.)
            InicializarControles();
        }

        //Constructor que recibe una categoría ya existente para editarla
        //Se llama desde FrmCategorias al presionar "Editar"
        public FrmCategoriasDetalle(Categoria categoriaExistente) : this()
        {
            _esEdicion = true;
            Categoria = categoriaExistente;

            //Carga los datos existentes en los controles del formulario
            CargarDatos();
        }

        //Configura valores iniciales para los controles del formulario
        private void InicializarControles()
        {
            //Cargar opciones disponibles del tipo de categoría
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Ingreso");
            cboTipo.Items.Add("Gasto");

            //Por defecto, se selecciona "Gasto"
            cboTipo.SelectedIndex = 1;

            //Por defecto, toda categoría se crea como activa
            chkActiva.Checked = true;
        }

        //Cargar los valores de la categoría para edición
        private void CargarDatos()
        {
            if (Categoria == null)
                return;

            //Se asignan las propiedades al formulario
            txtNombre.Text = Categoria.Nombre;
            txtDescripcionCategoria.Text = Categoria.Descripcion;
            cboTipo.SelectedItem = Categoria.Tipo;
            chkActiva.Checked = Categoria.Activa;
        }

        //Botón que guarda los datos ingresados y los retorna al formulario padre
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Si alguna validación falla, detener el proceso
            if (!ValidarEntradas()) return;

            //Si es nueva categoría, creamos una instancia
            if (Categoria == null)
                Categoria = new Categoria();

            //Asignamos los valores del formulario al objeto de categoría
            Categoria.Nombre = txtNombre.Text.Trim();
            Categoria.Descripcion = txtDescripcionCategoria.Text.Trim();
            Categoria.Tipo = cboTipo.SelectedItem?.ToString() ?? "Gasto"; //Valor por defecto
            Categoria.Activa = chkActiva.Checked;

            //Indicamos al formulario padre que todo salió bien
            DialogResult = DialogResult.OK;

            //Cerramos esta ventana
            Close();
        }

        //Validaciones simples de campos obligatorios
        private bool ValidarEntradas()
        {
            //Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNombre.Focus();
                return false;
            }

            //Validar que el usuario seleccione un tipo
            if (cboTipo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de categoría.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboTipo.Focus();
                return false;
            }

            return true; //Todo está correcto
        }

        //Botón que cancela la operación sin guardar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; //Indica al padre que no se guardó nada
            Close();
        }


    }
}