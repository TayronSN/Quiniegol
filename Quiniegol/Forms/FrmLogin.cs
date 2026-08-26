using Quiniegol.Controllers;
using Quiniegol.Data;
using Quiniegol.Models;
using Quiniegol.Utils;

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
            UsuarioController controller = new UsuarioController();

            string mensaje = controller.IniciarSesion(txtIdEmpleado.Text, txtPassword.Text);

            if (!string.IsNullOrEmpty(mensaje))
            {
                lblError.Text = mensaje;
                return;
            }

            lblError.Text = "";

            Usuario usuario = controller.ObtenerUsuario(txtIdEmpleado.Text)!;

            Sesion.IdEmpleado = usuario.IdEmpleado;

            if (usuario.IdRol == 1)
            {
                new FrmPrincipal().Show();
            }
            else
            {
                new FrmPrincipalUsuario().Show();
            }

            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e) { }
    }
}
