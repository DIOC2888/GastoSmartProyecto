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

        private void btnNueva_Click(object sender, EventArgs e)
        {
            //Abrimos el formulario de detalles en modo "Nueva Categoría"
            using var frm = new FrmCategoriasDetalle();

            //Si el usuario cierra con Cancelar, salimos y no hacemos nada
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            //Recibimos la categoría llena desde el formulario hijo
            var categoria = frm.Categoria;

            //Validación: nombre duplicado
            if (_categoriaService.NombreExiste(categoria.Nombre))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Agregamos la nueva categoría al servicio
            _categoriaService.Agregar(categoria);

            //Actualizamos la tabla
            _bindingSource.ResetBindings(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la categoría seleccionada
            var seleccionada = ObtenerSeleccionada();

            //Si el usuario no seleccionó nada, mostramos aviso
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Creamos una copia para evitar modificar la categoría original
            //hasta que el usuario confirme los cambios
            var copia = new Categoria
            {
                IdCategoria = seleccionada.IdCategoria,
                IdUsuario = seleccionada.IdUsuario,
                Nombre = seleccionada.Nombre,
                Descripcion = seleccionada.Descripcion,
                Tipo = seleccionada.Tipo,
                Activa = seleccionada.Activa
            };

            //Abrimos el formulario de edición con la categoría clonada
            using var frm = new FrmCategoriasDetalle(copia);

            //Si cancela, no se hace nada
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var editada = frm.Categoria;

            //Validación: nombre duplicado (excepto si es la misma categoría)
            if (_categoriaService.NombreExiste(editada.Nombre, editada.IdCategoria))
            {
                MessageBox.Show("Ya existe otra categoría con ese nombre.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Aplicamos los cambios reales al servicio
            _categoriaService.Actualizar(editada);

            //Actualizamos pantalla
            _bindingSource.ResetBindings(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Obtenemos categoría seleccionada
            var seleccionada = ObtenerSeleccionada();

            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Mensaje de confirmación
            var respuesta = MessageBox.Show(
                $"¿Desea eliminar la categoría \"{seleccionada.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            //Eliminar categoría desde el servicio
            _categoriaService.Eliminar(seleccionada.IdCategoria);

            //Actualizar tabla
            _bindingSource.ResetBindings(false);
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