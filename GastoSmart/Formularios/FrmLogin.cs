using GastoSmart.Services;
using GastoSmart.Models;
using System;
using System.Windows.Forms;

namespace GastoSmart.Formularios
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioService _usuarioService = AppServices.UsuarioService;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Llamamos al servicio de usuarios
            var usuario = _usuarioService.Autenticar(email, password);

            if (usuario == null)
            {
                MessageBox.Show("Correo o contraseña incorrectos.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos el usuario logueado para el resto de la app
            AppServices.UsuarioActual = usuario;

            // Opcional: mostrar su nombre en el menú principal, etc.
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistro();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
