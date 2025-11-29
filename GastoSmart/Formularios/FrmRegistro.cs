using GastoSmart.Models;
using GastoSmart.Services;
using System;
using System.Windows.Forms;

namespace GastoSmart.Formularios
{
    public partial class FrmRegistro : Form
    {
        private readonly UsuarioService _usuarioService = AppServices.UsuarioService;

        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmar = txtConfirmarPassword.Text.Trim();

            // Validaciones
            if (nombre == "" || email == "" || password == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si ya existe una cuenta con ese email
            var existente = _usuarioService.Autenticar(email, password: "___NO_IMPORTA___");
            if (_usuarioService.ExisteEmail(email))
            {
                MessageBox.Show("Ya existe una cuenta con este correo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registrar nuevo usuario
            var nuevo = _usuarioService.Registrar(nombre, email, password);

            MessageBox.Show("Cuenta creada correctamente.",
                "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void FrmRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
