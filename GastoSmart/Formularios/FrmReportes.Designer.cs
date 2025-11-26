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
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 161);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 257);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Categorias:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 226);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Tipo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(132, 190);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(191, 155);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(205, 23);
            dtpDesde.TabIndex = 4;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(191, 184);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(205, 23);
            dtpHasta.TabIndex = 5;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(191, 223);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(48, 23);
            cboTipo.TabIndex = 6;
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(191, 257);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(48, 23);
            cboCategoria.TabIndex = 7;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(138, 335);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(102, 23);
            btnLimpiarFiltros.TabIndex = 8;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.Location = new Point(138, 296);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(102, 23);
            btnAplicarFiltros.TabIndex = 9;
            btnAplicarFiltros.Text = "Aplicar Filtros";
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(505, 122);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(240, 150);
            dgvReporte.TabIndex = 10;
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.Location = new Point(505, 285);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(83, 15);
            lblTotalIngresos.TabIndex = 11;
            lblTotalIngresos.Text = "Total Ingresos:";
            lblTotalIngresos.Click += label5_Click;
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.Location = new Point(505, 315);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(74, 15);
            lblTotalGastos.TabIndex = 12;
            lblTotalGastos.Text = "Total Gastos:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(505, 339);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(51, 15);
            lblBalance.TabIndex = 13;
            lblBalance.Text = "Balance:";
            // 
            // btnExportarCSV
            // 
            btnExportarCSV.Location = new Point(505, 367);
            btnExportarCSV.Name = "btnExportarCSV";
            btnExportarCSV.Size = new Size(114, 23);
            btnExportarCSV.TabIndex = 14;
            btnExportarCSV.Text = "Exportar CSV";
            btnExportarCSV.UseVisualStyleBackColor = true;
            btnExportarCSV.Click += button1_Click;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "FrmReportes";
            Text = "Form1";
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
    }
}