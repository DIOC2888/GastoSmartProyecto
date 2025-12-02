namespace GastoSmart.Formularios
{
    partial class FrmTransaccionDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransaccionDetalle));
            lblFecha = new Label();
            lblTipo = new Label();
            lblMonto = new Label();
            lblDescripcion = new Label();
            dtpFecha = new DateTimePicker();
            cboTipo = new ComboBox();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.White;
            lblFecha.Location = new Point(300, 199);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.BackColor = Color.White;
            lblTipo.Location = new Point(308, 246);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(42, 20);
            lblTipo.TabIndex = 1;
            lblTipo.Text = "Tipo:";
            lblTipo.Click += lblTipo_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.BackColor = Color.White;
            lblMonto.Location = new Point(308, 299);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(56, 20);
            lblMonto.TabIndex = 2;
            lblMonto.Text = "Monto:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.White;
            lblDescripcion.Location = new Point(308, 349);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(380, 194);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(209, 27);
            dtpFecha.TabIndex = 4;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Ingreso", "Gasto" });
            cboTipo.Location = new Point(438, 243);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(151, 28);
            cboTipo.TabIndex = 5;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(449, 296);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(125, 27);
            txtMonto.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(449, 346);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(125, 27);
            txtDescripcion.TabIndex = 7;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.HotTrack;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(308, 438);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.HotTrack;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(469, 438);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.BackColor = Color.White;
            lblCategoria.Location = new Point(308, 393);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(77, 20);
            lblCategoria.TabIndex = 10;
            lblCategoria.Text = "Categoria:";
            lblCategoria.TextAlign = ContentAlignment.TopCenter;
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(438, 390);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(151, 28);
            cboCategoria.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-40, -36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(934, 598);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // FrmTransaccionDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(870, 536);
            Controls.Add(cboCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtMonto);
            Controls.Add(cboTipo);
            Controls.Add(dtpFecha);
            Controls.Add(lblDescripcion);
            Controls.Add(lblMonto);
            Controls.Add(lblTipo);
            Controls.Add(lblFecha);
            Controls.Add(pictureBox1);
            Name = "FrmTransaccionDetalle";
            Text = "Transaccion detalle";
            Load += FrmTransaccionDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFecha;
        private Label lblTipo;
        private Label lblMonto;
        private Label lblDescripcion;
        private DateTimePicker dtpFecha;
        private ComboBox cboTipo;
        private TextBox txtMonto;
        private TextBox txtDescripcion;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblCategoria;
        private ComboBox cboCategoria;
        private PictureBox pictureBox1;
    }
}