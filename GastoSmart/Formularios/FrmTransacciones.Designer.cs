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
            dgvTransacciones = new DataGridView();
            btnNueva = new Button();
            Editar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).BeginInit();
            SuspendLayout();
            // 
            // dgvTransacciones
            // 
            dgvTransacciones.AllowUserToAddRows = false;
            dgvTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransacciones.Location = new Point(114, 113);
            dgvTransacciones.Name = "dgvTransacciones";
            dgvTransacciones.RowHeadersWidth = 51;
            dgvTransacciones.Size = new Size(598, 235);
            dgvTransacciones.TabIndex = 0;
            // 
            // btnNueva
            // 
            btnNueva.Location = new Point(176, 58);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(94, 29);
            btnNueva.TabIndex = 1;
            btnNueva.Text = "Nueva";
            btnNueva.UseVisualStyleBackColor = true;
            btnNueva.Click += btnNueva_Click;
            // 
            // Editar
            // 
            Editar.Location = new Point(344, 58);
            Editar.Name = "Editar";
            Editar.Size = new Size(94, 29);
            Editar.TabIndex = 2;
            Editar.Text = "Editar";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(512, 58);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(372, 370);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // FrmTransacciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(Editar);
            Controls.Add(btnNueva);
            Controls.Add(dgvTransacciones);
            Name = "FrmTransacciones";
            Text = "FrmTransacciones";
            Load += FrmTransacciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTransacciones;
        private Button btnNueva;
        private Button Editar;
        private Button btnEliminar;
        private Button btnCerrar;
    }
}