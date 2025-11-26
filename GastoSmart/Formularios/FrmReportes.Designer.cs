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
            btnAplicarFiltros = new Button();
            btnLimpiarFiltros = new Button();
            ReporteMensual = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            cboTipo = new ComboBox();
            label4 = new Label();
            cboCategoria = new ComboBox();
            dataGridView1 = new DataGridView();
            lblTotalIngresos = new Label();
            lblTotalGastos = new Label();
            lblBalance = new Label();
            btnExportarCsv = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.Location = new Point(9, 301);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(115, 59);
            btnAplicarFiltros.TabIndex = 0;
            btnAplicarFiltros.Text = "Aplicar filtros";
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(174, 301);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(111, 59);
            btnLimpiarFiltros.TabIndex = 1;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // ReporteMensual
            // 
            ReporteMensual.AutoSize = true;
            ReporteMensual.Location = new Point(275, 10);
            ReporteMensual.Name = "ReporteMensual";
            ReporteMensual.Size = new Size(117, 20);
            ReporteMensual.TabIndex = 2;
            ReporteMensual.Text = "ReporteMensual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 62);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 3;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 120);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 6;
            label2.Text = "Hasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 168);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 7;
            label3.Text = "Tipo:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(111, 63);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(281, 27);
            dtpDesde.TabIndex = 8;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(111, 115);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(281, 27);
            dtpHasta.TabIndex = 9;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(111, 165);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(151, 28);
            cboTipo.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 212);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 11;
            label4.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(111, 212);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(151, 28);
            cboCategoria.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(469, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 13;
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.Location = new Point(469, 266);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(104, 20);
            lblTotalIngresos.TabIndex = 14;
            lblTotalIngresos.Text = "Total ingresos:";
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.Location = new Point(469, 301);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(92, 20);
            lblTotalGastos.TabIndex = 15;
            lblTotalGastos.Text = "Total gastos:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(469, 340);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(64, 20);
            lblBalance.TabIndex = 16;
            lblBalance.Text = "Balance:";
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(566, 379);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(94, 59);
            btnExportarCsv.TabIndex = 17;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportarCsv);
            Controls.Add(lblBalance);
            Controls.Add(lblTotalGastos);
            Controls.Add(lblTotalIngresos);
            Controls.Add(dataGridView1);
            Controls.Add(cboCategoria);
            Controls.Add(label4);
            Controls.Add(cboTipo);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ReporteMensual);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(btnAplicarFiltros);
            Name = "FrmReportes";
            Text = "FrmReportes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAplicarFiltros;
        private Button btnLimpiarFiltros;
        private Label ReporteMensual;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private ComboBox cboTipo;
        private Label label4;
        private ComboBox cboCategoria;
        private DataGridView dataGridView1;
        private Label lblTotalIngresos;
        private Label lblTotalGastos;
        private Label lblBalance;
        private Button btnExportarCsv;
    }
}