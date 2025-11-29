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
            logoGS = new Label();
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
            // logoGS
            // 
            logoGS.AutoSize = true;
            logoGS.Location = new Point(25, 111);
            logoGS.Name = "logoGS";
            logoGS.Size = new Size(86, 20);
            logoGS.TabIndex = 0;
            logoGS.Text = "GastoSmart";
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Location = new Point(636, 9);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(95, 20);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "Bienvenid@, ";
            // 
            // lblSaldoActual
            // 
            lblSaldoActual.AutoSize = true;
            lblSaldoActual.Location = new Point(180, 111);
            lblSaldoActual.Name = "lblSaldoActual";
            lblSaldoActual.Size = new Size(93, 20);
            lblSaldoActual.TabIndex = 2;
            lblSaldoActual.Text = "Saldo Actual";
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.Location = new Point(367, 111);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(89, 20);
            lblPresupuesto.TabIndex = 3;
            lblPresupuesto.Text = "Presupuesto";
            // 
            // lblMontoGastado
            // 
            lblMontoGastado.AutoSize = true;
            lblMontoGastado.Location = new Point(619, 111);
            lblMontoGastado.Name = "lblMontoGastado";
            lblMontoGastado.Size = new Size(112, 20);
            lblMontoGastado.TabIndex = 4;
            lblMontoGastado.Text = "Monto Gastado";
            // 
            // btnTransacciones
            // 
            btnTransacciones.Location = new Point(138, 197);
            btnTransacciones.Name = "btnTransacciones";
            btnTransacciones.Size = new Size(135, 29);
            btnTransacciones.TabIndex = 5;
            btnTransacciones.Text = "Transacciones";
            btnTransacciones.UseVisualStyleBackColor = true;
            btnTransacciones.Click += btnTransacciones_Click;
            // 
            // btnPresupuestos
            // 
            btnPresupuestos.Location = new Point(138, 302);
            btnPresupuestos.Name = "btnPresupuestos";
            btnPresupuestos.Size = new Size(135, 29);
            btnPresupuestos.TabIndex = 6;
            btnPresupuestos.Text = "Presupuestos";
            btnPresupuestos.UseVisualStyleBackColor = true;
            btnPresupuestos.Click += btnPresupuestos_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(138, 267);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(135, 29);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Location = new Point(138, 232);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(135, 29);
            btnCategorias.TabIndex = 8;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.LogoGastoSmart;
            logo.Location = new Point(12, 9);
            logo.Name = "logo";
            logo.Size = new Size(111, 99);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 9;
            logo.TabStop = false;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logo);
            Controls.Add(btnCategorias);
            Controls.Add(btnReportes);
            Controls.Add(btnPresupuestos);
            Controls.Add(btnTransacciones);
            Controls.Add(lblMontoGastado);
            Controls.Add(lblPresupuesto);
            Controls.Add(lblSaldoActual);
            Controls.Add(lblBienvenido);
            Controls.Add(logoGS);
            Name = "FrmMenuPrincipal";
            Text = "FrmMenuPrincipal";
            Load += FrmMenuPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label logoGS;
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