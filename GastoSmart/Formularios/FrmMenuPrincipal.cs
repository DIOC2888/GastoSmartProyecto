using GastoSmart.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GastoSmart
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            FrmTransacciones frm = new FrmTransacciones();
            frm.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCategorias())
            {
                frm.ShowDialog();
            }
        }
    }
}
