using Quiniegol.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Quiniegol.Utils;
using Quiniegol.Models;

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

            string mensaje = usuarioController.IniciarSesion(txtIdEmpleado.Text, txtPassword.Text);

            if (string.IsNullOrEmpty(mensaje))
            {
                Usuario usuario = usuarioController.ObtenerUsuario(txtIdEmpleado.Text);

                Sesion.IdEmpleado = usuario.IdEmpleado;

                MessageBox.Show("Inicio de sesion exitoso.");

                if (usuario.IdRol == 1)
                {
                    FrmPrincipal frmPrincipal = new FrmPrincipal();
                    frmPrincipal.Show();
                }

                else
                {
                    FrmPrincipalUsuario frmPrincipalUsuario = new FrmPrincipalUsuario();
                    frmPrincipalUsuario.Show();
                }

                this.Hide();
            }


        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
