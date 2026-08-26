using Quiniegol.Controllers;
using Quiniegol.Models;

namespace Quiniegol.Forms
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e) { }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                IdEmpleado   = txtIdEmpleado.Text,
                Nombre       = txtNombre.Text,
                Apellido     = txtApellido.Text,
                Departamento = cmbDepartamento.Text,
                Correo       = txtCorreo.Text,
                Password     = txtPassword.Text,
                IdRol        = 2
            };

            UsuarioController controller = new UsuarioController();

            string mensaje = controller.RegistrarUsuario(usuario, txtConfirmarPassword.Text);

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
