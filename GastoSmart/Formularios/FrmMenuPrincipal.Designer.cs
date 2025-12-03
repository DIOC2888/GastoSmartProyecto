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
            lblBienvenido.Location = new Point(513, 47);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(95, 20);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenid@, ";
            // 
            // lblSaldoActual
            // 
            lblSaldoActual.AutoSize = true;
            lblSaldoActual.BackColor = Color.White;
            lblSaldoActual.ForeColor = Color.Black;
            lblSaldoActual.Location = new Point(189, 111);
            lblSaldoActual.Name = "lblSaldoActual";
            lblSaldoActual.Size = new Size(93, 20);
            lblSaldoActual.TabIndex = 2;
            lblSaldoActual.Text = "Saldo Actual";
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.BackColor = Color.White;
            lblPresupuesto.ForeColor = Color.Black;
            lblPresupuesto.Location = new Point(438, 111);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(89, 20);
            lblPresupuesto.TabIndex = 3;
            lblPresupuesto.Text = "Presupuesto";
            // 
            // lblMontoGastado
            // 
            lblMontoGastado.AutoSize = true;
            lblMontoGastado.BackColor = Color.White;
            lblMontoGastado.ForeColor = Color.Black;
            lblMontoGastado.Location = new Point(332, 149);
            lblMontoGastado.Name = "lblMontoGastado";
            lblMontoGastado.Size = new Size(112, 20);
            lblMontoGastado.TabIndex = 4;
            lblMontoGastado.Text = "Monto Gastado";
            // 
            // btnTransacciones
            // 
            btnTransacciones.BackColor = SystemColors.HotTrack;
            btnTransacciones.ForeColor = Color.White;
            btnTransacciones.Location = new Point(214, 215);
            btnTransacciones.Name = "btnTransacciones";
            btnTransacciones.Size = new Size(114, 29);
            btnTransacciones.TabIndex = 5;
            btnTransacciones.Text = "Transacciones";
            btnTransacciones.UseVisualStyleBackColor = false;
            btnTransacciones.Click += btnTransacciones_Click;
            // 
            // btnPresupuestos
            // 
            btnPresupuestos.BackColor = SystemColors.HotTrack;
            btnPresupuestos.ForeColor = Color.White;
            btnPresupuestos.Location = new Point(467, 344);
            btnPresupuestos.Name = "btnPresupuestos";
            btnPresupuestos.Size = new Size(111, 29);
            btnPresupuestos.TabIndex = 6;
            btnPresupuestos.Text = "Presupuestos";
            btnPresupuestos.UseVisualStyleBackColor = false;
            btnPresupuestos.Click += btnPresupuestos_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = SystemColors.HotTrack;
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(469, 215);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(110, 29);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = SystemColors.Highlight;
            btnCategorias.ForeColor = Color.White;
            btnCategorias.Location = new Point(214, 343);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(114, 29);
            btnCategorias.TabIndex = 8;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(-11, 15);
            logo.Name = "logo";
            logo.Size = new Size(824, 421);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 9;
            logo.TabStop = false;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 451);
            Controls.Add(btnCategorias);
            Controls.Add(btnReportes);
            Controls.Add(btnPresupuestos);
            Controls.Add(btnTransacciones);
            Controls.Add(lblMontoGastado);
            Controls.Add(lblPresupuesto);
            Controls.Add(lblSaldoActual);
            Controls.Add(lblBienvenido);
            Controls.Add(logo);
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