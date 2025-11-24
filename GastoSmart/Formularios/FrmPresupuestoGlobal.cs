using GastoSmart.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GastoSmart.Formularios
{
    public partial class FrmPresupuestoGlobal : Form
    {
        private readonly PresupuestoService _presupuestoService = AppServices.PresupuestoService;
        public FrmPresupuestoGlobal()
        {
            InitializeComponent();
            CargarValoresActuales();
        }
        // Carga en los NumericUpDown los valores actuales del presupuesto.
        private void CargarValoresActuales()
        {
            var p = _presupuestoService.ObtenerPresupuesto();

            nudMontoMensual.Value = p.MontoMensual > nudMontoMensual.Maximum
                ? nudMontoMensual.Maximum
                : p.MontoMensual;

            nudUmbralMensual.Value = (decimal)p.UmbralAlertaPorcentaje;
            nudUmbralDiario.Value = (decimal)p.UmbralDiarioPorcentaje;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Leemos los valores que el usuario configuró
            var montoMensual = nudMontoMensual.Value;
            var umbralMensual = nudUmbralMensual.Value;
            var umbralDiario = nudUmbralDiario.Value;

            // Validación básica: monto mayor que 0
            if (montoMensual <= 0)
            {
                MessageBox.Show("El presupuesto mensual debe ser mayor que 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMontoMensual.Focus();
                return;
            }

            // Guardamos la configuración en el servicio
            _presupuestoService.Configurar(
                montoMensual,
                umbralMensual,
                umbralDiario
            );

            MessageBox.Show("Presupuesto actualizado correctamente.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}