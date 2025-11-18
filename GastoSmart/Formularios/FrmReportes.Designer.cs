namespace GastoSmart.Formularios
{
    partial class FrmReportes
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
            exportarCSV = new Button();
            ImportarCSV = new Button();
            ReporteMensual = new Label();
            SuspendLayout();
            // 
            // exportarCSV
            // 
            exportarCSV.Location = new Point(164, 351);
            exportarCSV.Name = "exportarCSV";
            exportarCSV.Size = new Size(115, 59);
            exportarCSV.TabIndex = 0;
            exportarCSV.Text = "Exportar archivo CSV";
            exportarCSV.UseVisualStyleBackColor = true;
            // 
            // ImportarCSV
            // 
            ImportarCSV.Location = new Point(416, 351);
            ImportarCSV.Name = "ImportarCSV";
            ImportarCSV.Size = new Size(111, 59);
            ImportarCSV.TabIndex = 1;
            ImportarCSV.Text = "Importar archivo CSV";
            ImportarCSV.UseVisualStyleBackColor = true;
            // 
            // ReporteMensual
            // 
            ReporteMensual.AutoSize = true;
            ReporteMensual.Location = new Point(275, 10);
            ReporteMensual.Name = "ReporteMensual";
            ReporteMensual.Size = new Size(117, 20);
            ReporteMensual.TabIndex = 2;
            ReporteMensual.Text = "ReporteMensual";
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ReporteMensual);
            Controls.Add(ImportarCSV);
            Controls.Add(exportarCSV);
            Name = "FrmReportes";
            Text = "FrmReportes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exportarCSV;
        private Button ImportarCSV;
        private Label ReporteMensual;
    }
}