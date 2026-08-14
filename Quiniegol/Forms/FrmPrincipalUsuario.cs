using Quiniegol.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quiniegol.Forms
{
    public partial class FrmPrincipalUsuario : Form
    {
        public FrmPrincipalUsuario()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.IdEmpleado = "";

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();

            this.Close();
        }

        private void btnPronosticos_Click(object sender, EventArgs e)
        {
            FrmPronosticos frmPronosticos = new FrmPronosticos();
            frmPronosticos.ShowDialog();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            FrmRanking frmRanking = new FrmRanking();
            frmRanking.ShowDialog();
        }
    }
}
