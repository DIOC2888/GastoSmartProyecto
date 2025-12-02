namespace GastoSmart.Formularios
{
    partial class FrmTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransacciones));
            dgvTransacciones = new DataGridView();
            btnNueva = new Button();
            Editar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // dgvTransacciones
            // 
            dgvTransacciones.AllowUserToAddRows = false;
            dgvTransacciones.BackgroundColor = SystemColors.HotTrack;
            dgvTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransacciones.Location = new Point(78, 154);
            dgvTransacciones.Name = "dgvTransacciones";
            dgvTransacciones.RowHeadersWidth = 51;
            dgvTransacciones.Size = new Size(598, 235);
            dgvTransacciones.TabIndex = 0;
            // 
            // btnNueva
            // 
            btnNueva.BackColor = Color.Transparent;
            btnNueva.Location = new Point(122, 79);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(94, 29);
            btnNueva.TabIndex = 1;
            btnNueva.Text = "Nueva";
            btnNueva.UseVisualStyleBackColor = false;
            btnNueva.Click += btnNueva_Click;
            // 
            // Editar
            // 
            Editar.Location = new Point(321, 79);
            Editar.Name = "Editar";
            Editar.Size = new Size(94, 29);
            Editar.TabIndex = 2;
            Editar.Text = "Editar";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(543, 79);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = SystemColors.HotTrack;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(321, 395);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // logo
            // 
            logo.BackColor = SystemColors.HotTrack;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(-54, -20);
            logo.Name = "logo";
            logo.Size = new Size(849, 535);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 10;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // FrmTransacciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(784, 451);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(Editar);
            Controls.Add(btnNueva);
            Controls.Add(dgvTransacciones);
            Controls.Add(logo);
            Name = "FrmTransacciones";
            Text = "FrmTransacciones";
            Load += FrmTransacciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTransacciones;
        private Button btnNueva;
        private Button Editar;
        private Button btnEliminar;
        private Button btnCerrar;
        private PictureBox logo;
    }
}