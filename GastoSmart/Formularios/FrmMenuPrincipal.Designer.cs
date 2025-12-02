namespace GastoSmart
{
    partial class FrmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            lblBienvenido = new Label();
            lblSaldoActual = new Label();
            lblPresupuesto = new Label();
            lblMontoGastado = new Label();
            btnTransacciones = new Button();
            btnPresupuestos = new Button();
            btnReportes = new Button();
            btnCategorias = new Button();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.BackColor = Color.White;
            lblBienvenido.ForeColor = Color.Black;
            lblBienvenido.Location = new Point(449, 35);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(76, 15);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenid@, ";
            // 
            // lblSaldoActual
            // 
            lblSaldoActual.AutoSize = true;
            lblSaldoActual.BackColor = Color.White;
            lblSaldoActual.ForeColor = Color.Black;
            lblSaldoActual.Location = new Point(129, 83);
            lblSaldoActual.Name = "lblSaldoActual";
            lblSaldoActual.Size = new Size(73, 15);
            lblSaldoActual.TabIndex = 2;
            lblSaldoActual.Text = "Saldo Actual";
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.BackColor = Color.White;
            lblPresupuesto.ForeColor = Color.Black;
            lblPresupuesto.Location = new Point(307, 83);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(72, 15);
            lblPresupuesto.TabIndex = 3;
            lblPresupuesto.Text = "Presupuesto";
            // 
            // lblMontoGastado
            // 
            lblMontoGastado.AutoSize = true;
            lblMontoGastado.BackColor = Color.White;
            lblMontoGastado.ForeColor = Color.Black;
            lblMontoGastado.Location = new Point(449, 83);
            lblMontoGastado.Name = "lblMontoGastado";
            lblMontoGastado.Size = new Size(89, 15);
            lblMontoGastado.TabIndex = 4;
            lblMontoGastado.Text = "Monto Gastado";
            // 
            // btnTransacciones
            // 
            btnTransacciones.BackColor = SystemColors.HotTrack;
            btnTransacciones.ForeColor = Color.White;
            btnTransacciones.Location = new Point(187, 161);
            btnTransacciones.Margin = new Padding(3, 2, 3, 2);
            btnTransacciones.Name = "btnTransacciones";
            btnTransacciones.Size = new Size(100, 22);
            btnTransacciones.TabIndex = 5;
            btnTransacciones.Text = "Transacciones";
            btnTransacciones.UseVisualStyleBackColor = false;
            btnTransacciones.Click += btnTransacciones_Click;
            // 
            // btnPresupuestos
            // 
            btnPresupuestos.BackColor = SystemColors.HotTrack;
            btnPresupuestos.ForeColor = Color.White;
            btnPresupuestos.Location = new Point(409, 258);
            btnPresupuestos.Margin = new Padding(3, 2, 3, 2);
            btnPresupuestos.Name = "btnPresupuestos";
            btnPresupuestos.Size = new Size(97, 22);
            btnPresupuestos.TabIndex = 6;
            btnPresupuestos.Text = "Presupuestos";
            btnPresupuestos.UseVisualStyleBackColor = false;
            btnPresupuestos.Click += btnPresupuestos_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = SystemColors.HotTrack;
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(410, 161);
            btnReportes.Margin = new Padding(3, 2, 3, 2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(96, 22);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = SystemColors.Highlight;
            btnCategorias.ForeColor = Color.White;
            btnCategorias.Location = new Point(187, 257);
            btnCategorias.Margin = new Padding(3, 2, 3, 2);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(100, 22);
            btnCategorias.TabIndex = 8;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(-10, 11);
            logo.Margin = new Padding(3, 2, 3, 2);
            logo.Name = "logo";
            logo.Size = new Size(721, 316);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 9;
            logo.TabStop = false;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(700, 338);
            Controls.Add(btnCategorias);
            Controls.Add(btnReportes);
            Controls.Add(btnPresupuestos);
            Controls.Add(btnTransacciones);
            Controls.Add(lblMontoGastado);
            Controls.Add(lblPresupuesto);
            Controls.Add(lblSaldoActual);
            Controls.Add(lblBienvenido);
            Controls.Add(logo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMenuPrincipal";
            Text = "FrmMenuPrincipal";
            Load += FrmMenuPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblBienvenido;
        private Label lblSaldoActual;
        private Label lblPresupuesto;
        private Label lblMontoGastado;
        private Button btnTransacciones;
        private Button btnPresupuestos;
        private Button btnReportes;
        private Button btnCategorias;
        private PictureBox logo;
    }
}