using GastoSmart.Formularios;
using System;
using System.Windows.Forms;

namespace GastoSmart
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Mostrar Login
            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    // Si cancelan el login, se cierra la app
                    return;
                }
            }

            // 2. Si el login fue exitoso, abrimos el menú principal
            Application.Run(new FrmMenuPrincipal());
        }
    }
}
