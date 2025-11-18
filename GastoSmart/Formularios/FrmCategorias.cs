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
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;
        private readonly BindingSource _bindingSource = new();

        public FrmCategorias()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.Columns.Clear();

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 80
            });

            dgvCategorias.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Activa",
                HeaderText = "Activa",
                Width = 60
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CargarDatos()
        {
            var lista = _categoriaService.ObtenerTodo();
            _bindingSource.DataSource = lista;
            dgvCategorias.DataSource = _bindingSource;
        }

        private Categoria? ObtenerSeleccionada()
        {
            if (dgvCategorias.CurrentRow == null)
                return null;

            return (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            using var frm = new FrmCategoriasDetalle();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var categoria = frm.Categoria;

            
            if (_categoriaService.NombreExiste(categoria.Nombre))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _categoriaService.Agregar(categoria);
            _bindingSource.ResetBindings(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Clonamos para no tocar el original hasta que presione Aceptar
            var copia = new Categoria
            {
                IdCategoria = seleccionada.IdCategoria,
                IdUsuario = seleccionada.IdUsuario,
                Nombre = seleccionada.Nombre,
                Descripcion = seleccionada.Descripcion,
                Tipo = seleccionada.Tipo,
                Activa = seleccionada.Activa
            };

            using var frm = new FrmCategoriasDetalle(copia);

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var editada = frm.Categoria;

            if (_categoriaService.NombreExiste(editada.Nombre, editada.IdCategoria))
            {
                MessageBox.Show("Ya existe otra categoría con ese nombre.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _categoriaService.Actualizar(editada);
            _bindingSource.ResetBindings(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Desea eliminar la categoría \"{seleccionada.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            
            _categoriaService.Eliminar(seleccionada.IdCategoria);
            _bindingSource.ResetBindings(false);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
