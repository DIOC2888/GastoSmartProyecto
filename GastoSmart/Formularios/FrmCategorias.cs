using GastoSmart.Models;
using GastoSmart.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GastoSmart.Formularios
{
    public partial class FrmCategorias : Form
    {
        //Servicio que gestiona la lógica de negocio para las categorías (CRUD)
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;

        //BindingSource para enlazar listas al DataGridView de forma automática
        private readonly BindingSource _bindingSource = new();

        public FrmCategorias()
        {
            InitializeComponent();

            //Configura el DataGridView al abrir el formulario
            ConfigurarGrid();

            //Carga los datos existentes al iniciar
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            //Desactivamos la generación automática de columnas porque queremos definirlas manualmente
            dgvCategorias.AutoGenerateColumns = false;

            //Limpiamos cualquier columna existente
            dgvCategorias.Columns.Clear();

            //Columna: Nombre de la categoría
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",       //Propiedad del modelo que se enlaza
                HeaderText = "Nombre",             //Texto visible en la tabla
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            //Columna: Tipo (Ingreso o Gasto)
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 80
            });

            //Columna: Estado Activa/Inactiva (checkbox)
            dgvCategorias.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Activa",
                HeaderText = "Activa",
                Width = 60
            });

            //Columna: Descripción de la categoría
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CargarDatos()
        {
            //Obtenemos la lista de categorías desde el servicio
            var lista = _categoriaService.ObtenerTodo();

            //Asignamos los datos al BindingSource
            _bindingSource.DataSource = lista;
            //El DataGridView mostrará automáticamente lo que contiene el BindingSource
            dgvCategorias.DataSource = _bindingSource;
        }


        private Categoria? ObtenerSeleccionada()
        {
            //Si no hay fila seleccionada, devolvemos null
            if (dgvCategorias.CurrentRow == null)
                return null;

            //DataBoundItem devuelve el objeto real enlazado a esa fila
            return (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
        }

        // Evento Click del botón "Nueva Categoría" 
        private void btnNueva_Click(object sender, EventArgs e)
        {
            //Abrimos el formulario de detalle en modo creación
            using var frm = new FrmCategoriasDetalle();

            //Si el usuario cancela, no hacemos nada
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var categoria = frm.Categoria;
            // Verificamos si ya existe una categoría con el mismo nombre
            if (_categoriaService.NombreExiste(categoria.Nombre))
            {
                // Mostrar mensaje de advertencia
                MessageBox.Show("Ya existe una categoría con ese nombre.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Agregamos la nueva categoría
            _categoriaService.Agregar(categoria);

            // ANTES: _bindingSource.ResetBindings(false);
            CargarDatos();
        }

        // Evento Click del botón "Editar Categoría"
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la categoría seleccionada en el DataGridView
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                //Si no hay selección, mostramos un aviso
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Creamos una copia de la categoría para editar
            var copia = new Categoria
            {
                IdCategoria = seleccionada.IdCategoria,
                IdUsuario = seleccionada.IdUsuario,
                Nombre = seleccionada.Nombre,
                Descripcion = seleccionada.Descripcion,
                Tipo = seleccionada.Tipo,
                Activa = seleccionada.Activa
            };
            //Abrimos el formulario de detalle en modo edición
            using var frm = new FrmCategoriasDetalle(copia);

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            //Obtenemos la categoría editada desde el formulario
            var editada = frm.Categoria;

            // Verificamos si ya existe otra categoría con el mismo nombre
            if (_categoriaService.NombreExiste(editada.Nombre, editada.IdCategoria))
            {
                MessageBox.Show("Ya existe otra categoría con ese nombre.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Actualizamos la categoría en el servicio
            _categoriaService.Actualizar(editada);

            // ANTES: _bindingSource.ResetBindings(false);
            CargarDatos();
        }

        // Evento Click del botón "Eliminar Categoría"
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Obtenemos la categoría seleccionada en el DataGridView
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                //Si no hay selección, mostramos un aviso
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Pedimos confirmación antes de eliminar
            var respuesta = MessageBox.Show(
                $"¿Desea eliminar la categoría \"{seleccionada.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            //Si el usuario no confirma, salimos
            if (respuesta != DialogResult.Yes)
                return;
            //Eliminamos la categoría desde el servicio
            _categoriaService.Eliminar(seleccionada.IdCategoria);

            // ANTES: _bindingSource.ResetBindings(false);
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Cierra este formulario (regresa al menú principal)
            Close();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}