namespace GastoSmart.Formularios
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtConfirmarPassword = new TextBox();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(405, 295);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(204, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(405, 332);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(204, 27);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(405, 369);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(204, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Location = new Point(405, 412);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.PasswordChar = '*';
            txtConfirmarPassword.Size = new Size(204, 27);
            txtConfirmarPassword.TabIndex = 3;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(336, 476);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 29);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(463, 476);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 303);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 6;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(305, 343);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 7;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 387);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 8;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F);
            label4.Location = new Point(238, 432);
            label4.Name = "label4";
            label4.Size = new Size(123, 19);
            label4.TabIndex = 9;
            label4.Text = "Confirm Password:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-41, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(960, 635);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 628);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrar);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtNombre);
            Controls.Add(pictureBox1);
            Name = "FrmRegistro";
            Text = "FrmRegistro";
            Load += FrmRegistro_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmarPassword;
        private Button btnRegistrar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
    }
}