using GastoSmart.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using GastoSmart.Models;

namespace GastoSmart.Formularios
{
    public partial class FrmReportes : Form
    {
        // Servicios que proveen acceso central a transacciones y categorías
        private readonly TransaccionService _transaccionService = AppServices.TransaccionService;
        private readonly CategoriaService _categoriaService = AppServices.CategoriaService;

        // BindingSource que conecta la lista filtrada con el DataGridView
        private readonly BindingSource _bindingSource = new();

        // Clase interna usada para mostrar datos “formateados” en el reporte
        // (permite mostrar nombres de categoría en lugar de IDs y ajustar la vista)
        private class TransaccionReporteView
        {
            public DateTime Fecha { get; set; }
            public string Tipo { get; set; } = string.Empty;
            public string Categoria { get; set; } = string.Empty;
            public decimal Monto { get; set; }
            public string Descripcion { get; set; } = string.Empty;
        }

        public FrmReportes()
        {
            InitializeComponent();

            // Configuración inicial al abrir el formulario
            InicializarFiltros();   // Fechas y tipo
            ConfigurarGrid();       // Columnas del DataGridView
            CargarCategorias();     // Categorías en el combo
            AplicarFiltros();       // Mostrar datos iniciales
        }

        /// <summary>
        /// Devuelve la lista actualmente mostrada en el reporte.
        /// </summary>
        private List<TransaccionReporteView> ObtenerDatosReporte()
        {
            return _bindingSource.DataSource as List<TransaccionReporteView>
                   ?? new List<TransaccionReporteView>();
        }

        //------------------------------------------------------------------------
        // Inicializa los filtros del formulario (fechas y tipo de transacción)
        //------------------------------------------------------------------------
        private void InicializarFiltros()
        {
            // Fechas por defecto: del primer día del mes hasta hoy
            var hoy = DateTime.Today;
            var primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);

            dtpDesde.Value = primerDiaMes;
            dtpHasta.Value = hoy;

            // Configurar ComboBox de tipos: Todos, Ingreso, Gasto
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Todos");
            cboTipo.Items.Add("Ingreso");
            cboTipo.Items.Add("Gasto");
            cboTipo.SelectedIndex = 0; // Seleccionar "Todos"
        }

        //------------------------------------------------------------------------
        // Carga las categorías activas en el combo de selección para filtrar
        //------------------------------------------------------------------------
        private void CargarCategorias()
        {
            var categorias = _categoriaService.ObtenerTodo()
                .Where(c => c.Activa)
                .OrderBy(c => c.Nombre)
                .ToList();

            var listaCboCategorias = new List<Categoria>();

            // Se agrega la opción "Todas" con ID 0
            listaCboCategorias.Add(new Categoria
            {
                IdCategoria = 0,
                Nombre = "Todas"
            });

            listaCboCategorias.AddRange(categorias);

            cboCategoria.DataSource = listaCboCategorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";

            cboCategoria.SelectedValue = 0; // Selección inicial = Todas
        }

        //------------------------------------------------------------------------
        // Configuración manual de las columnas del DataGridView
        //------------------------------------------------------------------------
        private void ConfigurarGrid()
        {
            dgvReporte.AutoGenerateColumns = false;
            dgvReporte.Columns.Clear();

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 90,
                DefaultCellStyle = { Format = "d" } // fecha corta
            });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 70
            });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Categoria",
                HeaderText = "Categoría",
                Width = 120
            });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Monto",
                HeaderText = "Monto",
                Width = 90,
                DefaultCellStyle = { Format = "C2" } // formato monetario
            });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvReporte.DataSource = _bindingSource;
        }

        //------------------------------------------------------------------------
        // Aplica los filtros seleccionados por el usuario y refresca el reporte
        //------------------------------------------------------------------------
        private void AplicarFiltros()
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date;

            // Validación: la fecha final no puede ser menor a la inicial
            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoSeleccionado = cboTipo.SelectedItem?.ToString() ?? "Todos";
            int idCategoriaSeleccionada = (int)(cboCategoria.SelectedValue ?? 0);

            // Obtenemos TODAS las transacciones
            var transacciones = _transaccionService.ObtenerTodo();

            // Filtro por fecha
            var filtradas = transacciones
                .Where(t => t.Fecha.Date >= desde && t.Fecha.Date <= hasta);

            // Filtro por tipo (Ingreso / Gasto)
            if (tipoSeleccionado != "Todos")
            {
                filtradas = filtradas
                    .Where(t => string.Equals(t.Tipo, tipoSeleccionado, StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por categoría
            if (idCategoriaSeleccionada != 0)
            {
                filtradas = filtradas.Where(t => t.IdCategoria == idCategoriaSeleccionada);
            }

            var listaFiltrada = filtradas.ToList();

            // Diccionario rápido para obtener el nombre de la categoría
            var categoriasPorId = _categoriaService.ObtenerTodo()
                .ToDictionary(c => c.IdCategoria, c => c.Nombre);

            // Proyección a la clase de vista (para mostrar datos "bonitos" en el reporte)
            var vista = listaFiltrada
                .Select(t => new TransaccionReporteView
                {
                    Fecha = t.Fecha,
                    Tipo = t.Tipo,
                    Categoria = categoriasPorId.ContainsKey(t.IdCategoria)
                                ? categoriasPorId[t.IdCategoria]
                                : "(Sin categoría)",
                    Monto = t.Monto,
                    Descripcion = t.Descripcion
                })
                .OrderBy(v => v.Fecha)   // Ordenar de manera ascendente por fecha
                .ToList();

            // Enlazar al DataGridView
            _bindingSource.DataSource = vista;

            // Calcular totales según los datos filtrados
            CalcularTotales(listaFiltrada);
        }


        // Calcula totales del reporte: ingresos, gastos y balance
        private void CalcularTotales(List<Transaccion> lista)
        {
            // Suma de todas las transacciones cuyo Tipo es "Ingreso".
            // Se usa StringComparison.OrdinalIgnoreCase para ignorar mayúsc/minúsc.
            decimal totalIngresos = lista
                //Filtra la lista. Solo deja las transacciones que sean Ingresos.
                .Where(t => string.Equals(t.Tipo, "Ingreso", StringComparison.OrdinalIgnoreCase))
                .Sum(t => t.Monto);

            // Suma de todas las transacciones cuyo Tipo es "Gasto".
            decimal totalGastos = lista
                //Filtra la lista. Solo deja las transacciones que sean Gastos
                .Where(t => string.Equals(t.Tipo, "Gasto", StringComparison.OrdinalIgnoreCase))
                .Sum(t => t.Monto);

            // Diferencia entre ingresos y gastos.
            decimal balance = totalIngresos - totalGastos;

            // Actualizamos las etiquetas del formulario con formato monetario.
            lblTotalIngresos.Text = $"Ingresos: {totalIngresos:C2}";
            lblTotalGastos.Text = $"Gastos: {totalGastos:C2}";
            lblBalance.Text = $"Balance: {balance:C2}";
        }


        // Exportación del Reporte a formato CSV compatible con Excel
        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener datos mostrados en el grid
            var datos = ObtenerDatosReporte();

            if (datos == null || datos.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.",
                    "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cuadro de diálogo para elegir dónde guardar el archivo
            using var sfd = new SaveFileDialog
            {
                Title = "Exportar reporte a CSV",
                Filter = "Archivo CSV (*.csv)|*.csv",
                FileName = $"Reporte_{DateTime.Today:yyyyMMdd}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            // Construir contenido del archivo CSV
            var sb = new StringBuilder();

            // Encabezados
            sb.AppendLine("Fecha,Tipo,Categoría,Monto,Descripción");

            foreach (var r in datos)
            {
                // Limpia comillas dobles para evitar errores en CSV
                string descripcionLimpia = (r.Descripcion ?? string.Empty)
                    .Replace("\"", "\"\"");

                // Formato correcto del CSV
                string linea = string.Format(
                    "{0},{1},{2},{3},\"{4}\"",
                    r.Fecha.ToString("yyyy-MM-dd"),
                    r.Tipo,
                    r.Categoria,
                    r.Monto.ToString("0.00"),
                    descripcionLimpia
                );

                sb.AppendLine(linea);
            }

            // Guardar archivo
            try
            {
                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Reporte exportado correctamente a CSV.",
                    "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el archivo:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            InicializarFiltros();
            cboCategoria.SelectedValue = 0; // "Todas"
            AplicarFiltros();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

        }
    }
}