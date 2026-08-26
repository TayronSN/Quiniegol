using Quiniegol.Utils;

namespace Quiniegol.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e) { }

        private void btnPronosticos_Click(object sender, EventArgs e)
        {
            new FrmPronosticos().ShowDialog();
        }

        private void btnPartidos_Click(object sender, EventArgs e)
        {
            new FrmPartidos().ShowDialog();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            new FrmRanking().ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new FrmUsuarios().ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.IdEmpleado = "";
            new FrmLogin().Show();
            this.Close();
        }
    }
}
