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
        // Servicio central de transacciones (CRUD en memoria)
        private readonly TransaccionService _transaccionService = AppServices.TransaccionService;

        // Servicio de categorías (para resolver nombres de categoría, etc.)
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;

        // Servicio de presupuesto global (para validar los gastos)
        private readonly PresupuestoService _presupuestoService = AppServices.PresupuestoService;

        // BindingSource que conecta la lista de transacciones con el DataGridView
        private readonly BindingSource _bindingSource = new();

        public FrmTransacciones()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarDatos();
        }

        // Configuración de columnas del DataGridView
        private void ConfigurarGrid()
        {
            dgvTransacciones.AutoGenerateColumns = false;
            dgvTransacciones.Columns.Clear();

            // MUY IMPORTANTE: nada de AutoSizeColumnsMode = Fill
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

            // ANTES: AutoSizeMode = Fill  → eso es lo que da problemas
            dgvTransacciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Width = 250 // un ancho fijo razonable
            });

            dgvTransacciones.DataSource = _bindingSource;
        }

        // Carga la lista de transacciones y rellena el nombre de la categoría
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

        // Devuelve la transacción actualmente seleccionada en el grid
        private Transaccion? ObtenerSeleccionada()
        {
            if (dgvTransacciones.CurrentRow == null)
                return null;

            return (Transaccion)dgvTransacciones.CurrentRow.DataBoundItem;
        }
        // Método central: valida el gasto contra el presupuesto
        // y pregunta al usuario qué hacer según el resultado.
        // Devuelve true si se debe continuar con el guardado.
        private bool ConfirmarSegunPresupuesto(Transaccion t)
        {
            // Solo aplicamos reglas si es un GASTO
            var resultado = _presupuestoService.ValidarGasto(t);

            // Si está todo bien: no hay alertas
            if (resultado.Estado == EstadoPresupuesto.Ok)
                return true;

            var presupuesto = _presupuestoService.ObtenerPresupuesto();

            switch (resultado.Estado)
            {
                case EstadoPresupuesto.SuperaPresupuesto:
                    {
                        // Mensaje cuando el gasto rompe el presupuesto mensual total
                        string mensaje =
                            $"Con este gasto, el total gastado en el mes sería: {resultado.TotalMensualConGasto:C2}\n" +
                            $"Tu presupuesto mensual actual es: {presupuesto.MontoMensual:C2}\n\n" +
                            "Opciones:\n" +
                            "  - Sí: Registrar el gasto de todos modos.\n" +
                            "  - No: Aumentar el presupuesto justo para cubrir este gasto.\n" +
                            "  - Cancelar: No registrar el gasto.\n";

                        var r = MessageBox.Show(
                            mensaje,
                            "Presupuesto excedido",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (r == DialogResult.Yes)
                        {
                            // Registrar el gasto sin cambios de presupuesto
                            return true;
                        }
                        else if (r == DialogResult.No)
                        {
                            // Aumentar el presupuesto al mínimo necesario
                            var nuevoMonto = resultado.TotalMensualConGasto;

                            _presupuestoService.Configurar(
                                nuevoMonto,
                                presupuesto.UmbralAlertaPorcentaje,
                                presupuesto.UmbralDiarioPorcentaje
                            );

                            MessageBox.Show(
                                $"Se actualizó tu presupuesto mensual a {nuevoMonto:C2}.",
                                "Presupuesto actualizado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            return true;
                        }
                        else
                        {
                            // Cancelar el registro del gasto
                            return false;
                        }
                    }

                case EstadoPresupuesto.SuperaUmbralMensual:
                    {
                        // Advertencia cuando se cruza el umbral mensual (ej. 90%)
                        string mensaje =
                            $"Con este gasto habrías usado aproximadamente el {resultado.PorcentajeMensual:F1}% " +
                            $"de tu presupuesto mensual ({presupuesto.MontoMensual:C2}).\n\n" +
                            "¿Deseás registrar el gasto de todos modos?";

                        var r = MessageBox.Show(
                            mensaje,
                            "Alerta de presupuesto mensual",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        return r == DialogResult.Yes;
                    }

                case EstadoPresupuesto.SuperaUmbralDiario:
                    {
                        // Advertencia cuando en un solo día se gasta demasiado
                        string mensaje =
                            $"Solo en este día estarías usando aproximadamente el {resultado.PorcentajeDiario:F1}% " +
                            $"de tu presupuesto mensual ({presupuesto.MontoMensual:C2}).\n\n" +
                            "¿Deseás registrar el gasto de todos modos?";

                        var r = MessageBox.Show(
                            mensaje,
                            "Alerta de gasto diario",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        return r == DialogResult.Yes;
                    }
            }

            // Caso por defecto: continuar
            return true;
        }


        // Botón NUEVA transacción

        private void btnNueva_Click(object sender, EventArgs e)
        {
            using var frm = new FrmTransaccionDetalle();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var transaccion = frm.Transaccion;

            // Antes de guardar, validamos contra el presupuesto
            if (!ConfirmarSegunPresupuesto(transaccion))
                return;

            _transaccionService.Agregar(transaccion);
            _bindingSource.ResetBindings(false);
        }

        // Botón EDITAR transacción
        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionada = ObtenerSeleccionada();
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una transacción.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Creamos una copia para edición
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

        // Botón ELIMINAR transacción
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
            // Verificamos si la columna actual es la columna especial "colCategoria".
            // Esta columna no muestra directamente el IdCategoria, sino el nombre.
            if (dgvTransacciones.Columns[e.ColumnIndex].Name == "colCategoria")
            {
                // Obtenemos la fila asociada al evento.
                var fila = dgvTransacciones.Rows[e.RowIndex];

                // DataBoundItem es el objeto real (Transaccion) enlazado a la fila.
                if (fila.DataBoundItem is Transaccion trans)
                {
                    // Buscamos en el servicio la categoría correspondiente al IdCategoria.
                    var cat = _categoriaService.ObtenerPorId(trans.IdCategoria);

                    // Si existe, mostramos su nombre; si no, mostramos un texto por defecto.
                    e.Value = cat?.Nombre ?? "(Sin categoría)";

                    // Indicamos que ya aplicamos el formato y no es necesario que el grid lo modifique.
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTransacciones_Load(object sender, EventArgs e)
        {

        }
    }
}
