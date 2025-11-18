using GastoSmart.Services;
using GastoSmart.Models;
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
    public partial class FrmTransacciones : Form
    {
        private readonly TransaccionService _transaccionService = AppServices.TransaccionService;
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;
        private readonly BindingSource _bindingSource = new();

        public FrmTransacciones()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvTransacciones.AutoGenerateColumns = false;
            dgvTransacciones.Columns.Clear();
            dgvTransacciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            dgvTransacciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 90
            });

            dgvTransacciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 80
            });

            dgvTransacciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Monto",
                HeaderText = "Monto",
                Width = 90,
                DefaultCellStyle = { Format = "C2" }
            });


            dgvTransacciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCategoria",
                HeaderText = "Categoría",
                Width = 140
            });

            dgvTransacciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CargarDatos()
        {
            var lista = _transaccionService.ObtenerTodo();
            var categorias = AppServices.CategoriaService.ObtenerTodo();

            foreach (var t in lista)
            {
                var cat = categorias.FirstOrDefault(c => c.IdCategoria == t.IdCategoria);
                t.NombreCategoria = cat?.Nombre ?? string.Empty;
            }

            _bindingSource.DataSource = lista;
            dgvTransacciones.DataSource = _bindingSource;
        }

        private Transaccion? ObtenerSeleccionada()
        {
            if (dgvTransacciones.CurrentRow == null)
                return null;

            return (Transaccion)dgvTransacciones.CurrentRow.DataBoundItem;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            using var frm = new FrmTransaccionDetalle();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var transaccion = frm.Transaccion;

            _transaccionService.Agregar(transaccion);
            _bindingSource.ResetBindings(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una transacción.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            var copia = new Transaccion
            {
                IdTransaccion = seleccionada.IdTransaccion,
                IdUsuario = seleccionada.IdUsuario,
                IdCategoria = seleccionada.IdCategoria,
                Fecha = seleccionada.Fecha,
                Tipo = seleccionada.Tipo,
                Monto = seleccionada.Monto,
                Descripcion = seleccionada.Descripcion
            };

            using var frm = new FrmTransaccionDetalle(copia);

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var editada = frm.Transaccion;

            _transaccionService.Actualizar(editada);
            _bindingSource.ResetBindings(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una transacción.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Desea eliminar la transacción \"{seleccionada.Descripcion}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            _transaccionService.Eliminar(seleccionada.IdTransaccion);
            _bindingSource.ResetBindings(false);
        }

        private void dgvTransacciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransacciones.Columns[e.ColumnIndex].Name == "colCategoria")
            {
                var fila = dgvTransacciones.Rows[e.RowIndex];
                if (fila.DataBoundItem is Transaccion trans)
                {
                    var cat = _categoriaService.ObtenerPorId(trans.IdCategoria);
                    e.Value = cat?.Nombre ?? "(Sin categoría)";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTransacciones_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
