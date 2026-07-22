using Quiniegol.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quiniegol.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            frmRegistro.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioController usuarioController = new UsuarioController();

            string mensaje = usuarioController.IniciarSesion(txtIdEmpleado.Text,txtPassword.Text);

            if (string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Inicio de sesion exitoso.");

                FrmPrincipal frmPrincipal = new FrmPrincipal();
                frmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(mensaje);
            }


        }
    }
}
