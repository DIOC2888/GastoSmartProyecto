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
            label1 = new Label();
            nudUmbralMensual = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            nudMontoMensual = new NumericUpDown();
            nudUmbralDiario = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudUmbralMensual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMontoMensual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUmbralDiario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 80);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "Presupuesto Mensual:";
            // 
            // nudUmbralMensual
            // 
            nudUmbralMensual.Location = new Point(309, 130);
            nudUmbralMensual.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudUmbralMensual.Name = "nudUmbralMensual";
            nudUmbralMensual.Size = new Size(150, 27);
            nudUmbralMensual.TabIndex = 1;
            nudUmbralMensual.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 137);
            label2.Name = "label2";
            label2.Size = new Size(188, 20);
            label2.TabIndex = 2;
            label2.Text = "Umbral alerta mensual (%):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 187);
            label3.Name = "label3";
            label3.Size = new Size(171, 20);
            label3.TabIndex = 3;
            label3.Text = "Umbral alerta diaria (%):";
            // 
            // nudMontoMensual
            // 
            nudMontoMensual.DecimalPlaces = 2;
            nudMontoMensual.Location = new Point(309, 73);
            nudMontoMensual.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMontoMensual.Name = "nudMontoMensual";
            nudMontoMensual.Size = new Size(150, 27);
            nudMontoMensual.TabIndex = 4;
            // 
            // nudUmbralDiario
            // 
            nudUmbralDiario.Location = new Point(309, 187);
            nudUmbralDiario.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudUmbralDiario.Name = "nudUmbralDiario";
            nudUmbralDiario.Size = new Size(150, 27);
            nudUmbralDiario.TabIndex = 5;
            nudUmbralDiario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(206, 261);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(334, 261);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmPresupuestoGlobal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(nudUmbralDiario);
            Controls.Add(nudMontoMensual);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudUmbralMensual);
            Controls.Add(label1);
            Name = "FrmPresupuestoGlobal";
            Text = "FrmPresupuestoGlobal";
            Load += FrmPresupuestoGlobal_Load;
            ((System.ComponentModel.ISupportInitialize)nudUmbralMensual).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMontoMensual).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUmbralDiario).EndInit();
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
    }
}