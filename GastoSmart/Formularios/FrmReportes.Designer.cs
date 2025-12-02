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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(90, 78);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(66, 211);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Categorias:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(98, 171);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Tipo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(90, 123);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(150, 78);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(216, 23);
            dtpDesde.TabIndex = 4;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(150, 123);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(216, 23);
            dtpHasta.TabIndex = 5;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(150, 171);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(126, 23);
            cboTipo.TabIndex = 6;
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(150, 211);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(126, 23);
            cboCategoria.TabIndex = 7;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.Transparent;
            btnLimpiarFiltros.Location = new Point(98, 316);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(102, 23);
            btnLimpiarFiltros.TabIndex = 8;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnAplicarFiltros
            // 
            btnAplicarFiltros.Location = new Point(98, 257);
            btnAplicarFiltros.Name = "btnAplicarFiltros";
            btnAplicarFiltros.Size = new Size(102, 23);
            btnAplicarFiltros.TabIndex = 9;
            btnAplicarFiltros.Text = "Aplicar Filtros";
            btnAplicarFiltros.UseVisualStyleBackColor = true;
            btnAplicarFiltros.Click += btnAplicarFiltros_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(423, 72);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowHeadersWidth = 51;
            dgvReporte.Size = new Size(333, 150);
            dgvReporte.TabIndex = 10;
            dgvReporte.CellContentClick += dgvReporte_CellContentClick;
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.ForeColor = Color.White;
            lblTotalIngresos.Location = new Point(576, 238);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(83, 15);
            lblTotalIngresos.TabIndex = 11;
            lblTotalIngresos.Text = "Total Ingresos:";
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.ForeColor = Color.White;
            lblTotalGastos.Location = new Point(576, 284);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(74, 15);
            lblTotalGastos.TabIndex = 12;
            lblTotalGastos.Text = "Total Gastos:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(576, 348);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(51, 15);
            lblBalance.TabIndex = 13;
            lblBalance.Text = "Balance:";
            // 
            // btnExportarCSV
            // 
            btnExportarCSV.BackColor = SystemColors.HotTrack;
            btnExportarCSV.ForeColor = Color.White;
            btnExportarCSV.Location = new Point(585, 383);
            btnExportarCSV.Name = "btnExportarCSV";
            btnExportarCSV.Size = new Size(131, 23);
            btnExportarCSV.TabIndex = 14;
            btnExportarCSV.Text = "Exportar CSV";
            btnExportarCSV.UseVisualStyleBackColor = false;
            btnExportarCSV.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.ForeColor = Color.White;
            button1.Location = new Point(98, 383);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(102, 22);
            button1.TabIndex = 15;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HotTrack;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-5, -27);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(817, 501);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
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
            Controls.Add(pictureBox1);
            Name = "FrmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}