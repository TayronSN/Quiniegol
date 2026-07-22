using Quiniegol.Models;
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
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.IdEmpleado = txtIdEmpleado.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Departamento = cmbDepartamento.Text;
            usuario.Correo = txtCorreo.Text;
            usuario.Password = txtPassword.Text;

            usuario.IdRol = 2;

            UsuarioController usuarioController = new UsuarioController();

            string mensaje = usuarioController.RegistrarUsuario(usuario, txtConfirmarPassword.Text);

            if (string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Usuario registrado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje);
            }

        }
    }
}
