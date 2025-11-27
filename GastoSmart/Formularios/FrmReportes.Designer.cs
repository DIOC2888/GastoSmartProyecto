namespace GastoSmart.Formularios
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            cboTipo = new ComboBox();
            cboCategoria = new ComboBox();
            btnLimpiarFiltros = new Button();
            btnAplicarFiltros = new Button();
            dgvReporte = new DataGridView();
            lblTotalIngresos = new Label();
            lblTotalGastos = new Label();
            lblBalance = new Label();
            btnExportarCSV = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 104);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 232);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Categorias:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 190);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 2;
            label3.Text = "Tipo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(105, 142);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(172, 96);
            dtpDesde.Margin = new Padding(3, 4, 3, 4);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(234, 27);
            dtpDesde.TabIndex = 4;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(172, 134);
            dtpHasta.Margin = new Padding(3, 4, 3, 4);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(234, 27);
            dtpHasta.TabIndex = 5;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(172, 186);
            cboTipo.Margin = new Padding(3, 4, 3, 4);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(144, 28);
            cboTipo.TabIndex = 6;
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(172, 232);
            cboCategoria.Margin = new Padding(3, 4, 3, 4);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(144, 28);
            cboCategoria.TabIndex = 7;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(112, 336);
            btnLimpiarFiltros.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(117, 31);
            btnLimpiarFiltros.TabIndex = 8;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.Location = new Point(112, 284);
            btnAplicarFiltros.Margin = new Padding(3, 4, 3, 4);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(117, 31);
            btnAplicarFiltros.TabIndex = 9;
            btnAplicarFiltros.Text = "Aplicar Filtros";
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            btnAplicarFiltros.Click += btnAplicarFiltros_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(483, 96);
            dgvReporte.Margin = new Padding(3, 4, 3, 4);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowHeadersWidth = 51;
            dgvReporte.Size = new Size(381, 200);
            dgvReporte.TabIndex = 10;
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.Location = new Point(483, 313);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(104, 20);
            lblTotalIngresos.TabIndex = 11;
            lblTotalIngresos.Text = "Total Ingresos:";
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.Location = new Point(483, 353);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(93, 20);
            lblTotalGastos.TabIndex = 12;
            lblTotalGastos.Text = "Total Gastos:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(483, 385);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(64, 20);
            lblBalance.TabIndex = 13;
            lblBalance.Text = "Balance:";
            // 
            // btnExportarCSV
            // 
            btnExportarCSV.Location = new Point(483, 422);
            btnExportarCSV.Margin = new Padding(3, 4, 3, 4);
            btnExportarCSV.Name = "btnExportarCSV";
            btnExportarCSV.Size = new Size(150, 31);
            btnExportarCSV.TabIndex = 14;
            btnExportarCSV.Text = "Exportar CSV";
            btnExportarCSV.UseVisualStyleBackColor = true;
            btnExportarCSV.Click += button1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(112, 385);
            button1.Name = "button1";
            button1.Size = new Size(117, 29);
            button1.TabIndex = 15;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button1);
            Controls.Add(btnExportarCSV);
            Controls.Add(lblBalance);
            Controls.Add(lblTotalGastos);
            Controls.Add(lblTotalIngresos);
            Controls.Add(dgvReporte);
            Controls.Add(btnAplicarFiltros);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(cboCategoria);
            Controls.Add(cboTipo);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmReportes";
            Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private ComboBox cboTipo;
        private ComboBox cboCategoria;
        private Button btnLimpiarFiltros;
        private Button btnAplicarFiltros;
        private DataGridView dgvReporte;
        private Label lblTotalIngresos;
        private Label lblTotalGastos;
        private Label lblBalance;
        private Button btnExportarCSV;
        private Button button1;
    }
}