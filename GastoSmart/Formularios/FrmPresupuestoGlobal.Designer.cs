namespace GastoSmart.Formularios
{
    partial class FrmPresupuestoGlobal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPresupuestoGlobal));
            label1 = new Label();
            nudUmbralMensual = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            nudMontoMensual = new NumericUpDown();
            nudUmbralDiario = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nudUmbralMensual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMontoMensual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUmbralDiario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 193);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 0;
            label1.Text = "Presupuesto Mensual:";
            // 
            // nudUmbralMensual
            // 
            nudUmbralMensual.Location = new Point(381, 241);
            nudUmbralMensual.Margin = new Padding(3, 2, 3, 2);
            nudUmbralMensual.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudUmbralMensual.Name = "nudUmbralMensual";
            nudUmbralMensual.Size = new Size(131, 23);
            nudUmbralMensual.TabIndex = 1;
            nudUmbralMensual.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 241);
            label2.Name = "label2";
            label2.Size = new Size(150, 15);
            label2.TabIndex = 2;
            label2.Text = "Umbral alerta mensual (%):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 301);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 3;
            label3.Text = "Umbral alerta diaria (%):";
            // 
            // nudMontoMensual
            // 
            nudMontoMensual.DecimalPlaces = 2;
            nudMontoMensual.Location = new Point(381, 191);
            nudMontoMensual.Margin = new Padding(3, 2, 3, 2);
            nudMontoMensual.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMontoMensual.Name = "nudMontoMensual";
            nudMontoMensual.Size = new Size(131, 23);
            nudMontoMensual.TabIndex = 4;
            // 
            // nudUmbralDiario
            // 
            nudUmbralDiario.Location = new Point(381, 299);
            nudUmbralDiario.Margin = new Padding(3, 2, 3, 2);
            nudUmbralDiario.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudUmbralDiario.Name = "nudUmbralDiario";
            nudUmbralDiario.Size = new Size(131, 23);
            nudUmbralDiario.TabIndex = 5;
            nudUmbralDiario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.HotTrack;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(260, 345);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 22);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.HotTrack;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(364, 345);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(-102, -22);
            logo.Margin = new Padding(3, 2, 3, 2);
            logo.Name = "logo";
            logo.Size = new Size(919, 478);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 11;
            logo.TabStop = false;
            // 
            // FrmPresupuestoGlobal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(726, 428);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(nudUmbralDiario);
            Controls.Add(nudMontoMensual);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudUmbralMensual);
            Controls.Add(label1);
            Controls.Add(logo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPresupuestoGlobal";
            Text = "FrmPresupuestoGlobal";
            Load += FrmPresupuestoGlobal_Load;
            ((System.ComponentModel.ISupportInitialize)nudUmbralMensual).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMontoMensual).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUmbralDiario).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown nudUmbralMensual;
        private Label label2;
        private Label label3;
        private NumericUpDown nudMontoMensual;
        private NumericUpDown nudUmbralDiario;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox logo;
    }
}