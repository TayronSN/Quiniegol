using Quiniegol.Utils;

namespace Quiniegol.Forms
{
    public partial class FrmPrincipalUsuario : Form
    {
        public FrmPrincipalUsuario()
        {
            InitializeComponent();
        }

        private void FrmPrincipalUsuario_Load(object sender, EventArgs e) { }

        private void btnPronosticos_Click(object sender, EventArgs e)
        {
            new FrmPronosticos().ShowDialog();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            new FrmRanking().ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.IdEmpleado = "";
            new FrmLogin().Show();
            this.Close();
        }
    }
}
