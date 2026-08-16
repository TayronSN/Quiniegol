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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnPronosticos_Click(object sender, EventArgs e)
        {
            FrmPronosticos frm = new FrmPronosticos();
            frm.ShowDialog();
        }

        private void btnPartidos_Click(object sender, EventArgs e)
        {
            FrmPartidos frm = new FrmPartidos();
            frm.ShowDialog();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            FrmRanking frm = new FrmRanking();
            frm.ShowDialog();
        }

        //private void btnReportes_Click(object sender, EventArgs e)
        //{
        //    FrmReportes frm = new FrmReportes();
        //    frm.ShowDialog();
        //}   se elimina este metodo porque al final no aporta nada y se simplifica
        
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.IdEmpleado = "";

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();

            this.Close();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.ShowDialog();
        }
    }
}
