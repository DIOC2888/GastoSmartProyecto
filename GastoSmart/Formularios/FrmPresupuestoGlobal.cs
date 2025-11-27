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
        // Servicio central del presupuesto.
        // Permite leer y guardar la configuración del presupuesto mensual global.
        private readonly PresupuestoService _presupuestoService = AppServices.PresupuestoService;

        public FrmPresupuestoGlobal()
        {
            InitializeComponent();

            // Al iniciar el formulario cargamos en pantalla
            // la configuración actual del presupuesto (si existe).
            CargarValoresActuales();
        }


        // Carga los valores del presupuesto global en los controles NumericUpDown.
        // Esto permite mostrar al usuario la configuración actual para editarla.
        private void CargarValoresActuales()
        {
            var p = _presupuestoService.ObtenerPresupuesto();

            // Cargar monto mensual.
            // Se verifica que el valor no exceda el máximo del NumericUpDown.
            nudMontoMensual.Value = p.MontoMensual > nudMontoMensual.Maximum
                ? nudMontoMensual.Maximum
                : p.MontoMensual;

            // Cargar umbral mensual de alerta (%)
            nudUmbralMensual.Value = (decimal)p.UmbralAlertaPorcentaje;

            // Cargar umbral diario (%)
            nudUmbralDiario.Value = (decimal)p.UmbralDiarioPorcentaje;
        }

        // Evento del botón "Guardar".
        // Toma los valores del usuario, valida, y los envía al servicio
        // para actualizar la configuración del presupuesto.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Leer valores introducidos por el usuario
            var montoMensual = nudMontoMensual.Value;
            var umbralMensual = nudUmbralMensual.Value;
            var umbralDiario = nudUmbralDiario.Value;

            // Validación básica: el presupuesto mensual debe ser positivo
            if (montoMensual <= 0)
            {
                MessageBox.Show("El presupuesto mensual debe ser mayor que 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                nudMontoMensual.Focus();
                return;
            }

            // Guardar en el servicio la nueva configuración
            _presupuestoService.Configurar(
                montoMensual,
                umbralMensual,
                umbralDiario
            );

            // Confirmación de guardado
            MessageBox.Show("Presupuesto actualizado correctamente.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Indicamos que la operación terminó correctamente
            DialogResult = DialogResult.OK;

            // Cerrar el formulario
            Close();
        }

        // Botón Cancelar.
        // Cierra el formulario sin guardar cambios.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
