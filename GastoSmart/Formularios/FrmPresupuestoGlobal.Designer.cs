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
            button1 = new Button();
            button2 = new Button();
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
            nudUmbralMensual.Name = "nudUmbralMensual";
            nudUmbralMensual.Size = new Size(150, 27);
            nudUmbralMensual.TabIndex = 1;
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
            nudMontoMensual.Location = new Point(309, 73);
            nudMontoMensual.Name = "nudMontoMensual";
            nudMontoMensual.Size = new Size(150, 27);
            nudMontoMensual.TabIndex = 4;
            // 
            // nudUmbralDiario
            // 
            nudUmbralDiario.Location = new Point(309, 187);
            nudUmbralDiario.Name = "nudUmbralDiario";
            nudUmbralDiario.Size = new Size(150, 27);
            nudUmbralDiario.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(206, 261);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;            
            // 
            // button2
            // 
            button2.Location = new Point(334, 261);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // FrmPresupuestoGlobal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(nudUmbralDiario);
            Controls.Add(nudMontoMensual);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudUmbralMensual);
            Controls.Add(label1);
            Name = "FrmPresupuestoGlobal";
            Text = "FrmPresupuestoGlobal";
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
        private Button button1;
        private Button button2;
    }
}