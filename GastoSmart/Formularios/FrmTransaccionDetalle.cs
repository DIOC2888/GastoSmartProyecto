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
        // Transacción que se va a crear o editar.
        // Se devuelve al formulario padre cuando el usuario presiona Aceptar.
        public Transaccion Transaccion { get; private set; } = null!;

        // Servicio para obtener las categorías y mostrarlas en el combo.
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;

        // Constructor para crear una NUEVA transacción.
        public FrmTransaccionDetalle()
        {
            InitializeComponent();

            // Inicializamos las listas y valores por defecto de los controles.
            InicializarControles();
        }

        // Constructor para EDITAR una transacción existente.
        // Recibe una transacción que ya tiene datos.
        public FrmTransaccionDetalle(Transaccion existente) : this()
        {
            Transaccion = existente;

            // Carga los datos de la transacción en los controles del formulario.
            CargarDatos();
        }

        // Configura los controles del formulario con valores iniciales:
        // - Carga los tipos (Ingreso / Gasto)
        // - Coloca la fecha de hoy
        // - Llena el combo de categorías activas
        private void InicializarControles()
        {
            // Tipo de transacción
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Ingreso");
            cboTipo.Items.Add("Gasto");
            cboTipo.SelectedIndex = 0; // Por defecto, "Ingreso"

            // Fecha por defecto = hoy
            dtpFecha.Value = DateTime.Today;

            // Cargar categorías activas desde el servicio
            var categorias = _categoriaService.ObtenerTodo()
                                              .Where(c => c.Activa)
                                              .ToList();

            // Enlazar la lista de categorías al ComboBox
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";       // Lo que muestra
            cboCategoria.ValueMember = "IdCategoria";    // Valor interno

            // Si no hay categorías activas, se avisa al usuario
            if (categorias.Count == 0)
            {
                MessageBox.Show("No hay categorías activas. Cree al menos una en el menú de Categorías.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Carga los datos de una transacción existente en los controles,
        // solo se usa en modo edición.
        private void CargarDatos()
        {
            if (Transaccion == null) return;

            dtpFecha.Value = Transaccion.Fecha;
            cboTipo.SelectedItem = Transaccion.Tipo;
            txtMonto.Text = Transaccion.Monto.ToString("0.00");
            txtDescripcion.Text = Transaccion.Descripcion;

            // Selecciona la categoría correspondiente en el combo
            if (Transaccion.IdCategoria > 0)
            {
                cboCategoria.SelectedValue = Transaccion.IdCategoria;
            }
        }

        // Botón Aceptar:
        // - Valida la información
        // - Copia los datos de los controles al objeto Transaccion
        // - Devuelve DialogResult.OK al formulario padre
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Si falla alguna validación, detenemos el proceso.
            if (!ValidarEntradas())
                return;

            // Si es nueva transacción, creamos la instancia.
            if (Transaccion == null)
            {
                Transaccion = new Transaccion();
            }

            // Transferimos los valores desde los controles al objeto Transaccion.
            Transaccion.Fecha = dtpFecha.Value.Date;
            Transaccion.Tipo = cboTipo.SelectedItem?.ToString() ?? "Gasto";
            Transaccion.Monto = decimal.Parse(txtMonto.Text, CultureInfo.InvariantCulture);
            Transaccion.Descripcion = txtDescripcion.Text.Trim();

            // Obtener categoría seleccionada desde el ComboBox
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

            // Indicamos que todo salió bien
            DialogResult = DialogResult.OK;
            Close();
        }


        // Validación básica de campos:
        // - El monto debe existir, ser numérico y mayor que 0
        // - Debe haberse seleccionado una categoría
        private bool ValidarEntradas()
        {
            // Validar monto vacío
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Ingrese un monto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }

            // Validar formato y valor del monto
            if (!decimal.TryParse(txtMonto.Text, NumberStyles.Number,
                CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número mayor que 0.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return false;
            }

            // Validar que el usuario haya seleccionado una categoría
            if (cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoria.Focus();
                return false;
            }

            return true; // Todo correcto
        }

        // Botón Cancelar:
        // - Cierra el formulario sin guardar cambios.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // El formulario padre sabrá que se canceló
            Close();
        }

        private void FrmTransaccionDetalle_Load(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }
    }
}