
namespace GastoSmart.Formularios
{
    partial class FrmCategoriasDetalle
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
            NombreCategoria = new Label();
            txtNombre = new TextBox();
            lblTipoCat = new Label();
            cboTipo = new ComboBox();
            lblDescripcionCategoria = new Label();
            txtDescripcionCategoria = new TextBox();
            chkActiva = new CheckBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // NombreCategoria
            // 
            NombreCategoria.AutoSize = true;
            NombreCategoria.Location = new Point(132, 85);
            NombreCategoria.Name = "NombreCategoria";
            NombreCategoria.Size = new Size(71, 20);
            NombreCategoria.TabIndex = 0;
            NombreCategoria.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(246, 85);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblTipoCat
            // 
            lblTipoCat.AutoSize = true;
            lblTipoCat.Location = new Point(161, 133);
            lblTipoCat.Name = "lblTipoCat";
            lblTipoCat.Size = new Size(42, 20);
            lblTipoCat.TabIndex = 2;
            lblTipoCat.Text = "Tipo:";
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Ingreso", "Gasto" });
            cboTipo.Location = new Point(246, 125);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(151, 28);
            cboTipo.TabIndex = 3;
            // 
            // lblDescripcionCategoria
            // 
            lblDescripcionCategoria.AutoSize = true;
            lblDescripcionCategoria.Location = new Point(109, 170);
            lblDescripcionCategoria.Name = "lblDescripcionCategoria";
            lblDescripcionCategoria.Size = new Size(94, 20);
            lblDescripcionCategoria.TabIndex = 4;
            lblDescripcionCategoria.Text = "Descripción: ";
            // 
            // txtDescripcionCategoria
            // 
            txtDescripcionCategoria.Location = new Point(246, 167);
            txtDescripcionCategoria.Multiline = true;
            txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            txtDescripcionCategoria.ScrollBars = ScrollBars.Both;
            txtDescripcionCategoria.Size = new Size(221, 51);
            txtDescripcionCategoria.TabIndex = 5;
            // 
            // chkActiva
            // 
            chkActiva.AutoSize = true;
            chkActiva.Location = new Point(247, 224);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(139, 24);
            chkActiva.TabIndex = 6;
            chkActiva.Text = "Categoria activa";
            chkActiva.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(225, 283);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(373, 285);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmCategoriasDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(chkActiva);
            Controls.Add(txtDescripcionCategoria);
            Controls.Add(lblDescripcionCategoria);
            Controls.Add(cboTipo);
            Controls.Add(lblTipoCat);
            Controls.Add(txtNombre);
            Controls.Add(NombreCategoria);
            Name = "FrmCategoriasDetalle";
            Text = "FrmCategorias";
            Load += FrmCategoriasDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label NombreCategoria;
        private TextBox txtNombre;
        private Label lblTipoCat;
        private ComboBox cboTipo;
        private Label lblDescripcionCategoria;
        private TextBox txtDescripcionCategoria;
        private CheckBox chkActiva;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}