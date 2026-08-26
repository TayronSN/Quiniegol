using Quiniegol.Controllers;
using Quiniegol.Data;
using Quiniegol.Models;
using Quiniegol.Utils;

namespace Quiniegol.Forms
{
    public partial class FrmRanking : Form
    {
        private RankingController rankingController = new RankingController();

        public FrmRanking()
        {
            InitializeComponent();
        }

        private void FrmRanking_Load(object sender, EventArgs e)
        {
            CargarRanking();
        }

        private void CargarRanking()
        {
            dgvRanking.Rows.Clear();

            int posicion = 1;

            foreach (Ranking jugador in rankingController.GenerarRanking())
            {
                Usuario? usuario = UsuariosData.BuscarPorIdEmpleado(jugador.IdEmpleado);

                string nombre = usuario != null
                    ? usuario.Nombre + " " + usuario.Apellido
                    : jugador.IdEmpleado;

                dgvRanking.Rows.Add(posicion, nombre, jugador.Puntos);

                posicion++;
            }
        }

        private void btnDescargarRanking_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog
            {
                Filter   = "Archivo de texto|*.txt",
                FileName = "Ranking.txt"
            };

            if (guardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<string> lineas = new List<string>();

            lineas.Add("========== RANKING QUINIEGOL ==========");
            lineas.Add("");

            int posicion = 1;

            foreach (Ranking jugador in rankingController.GenerarRanking())
            {
                Usuario? usuario = UsuariosData.BuscarPorIdEmpleado(jugador.IdEmpleado);

                string nombre = usuario != null
                    ? usuario.Nombre + " " + usuario.Apellido
                    : jugador.IdEmpleado;

                lineas.Add($"{posicion}. {nombre} - {jugador.Puntos} puntos");

                posicion++;
            }

            ExportadorTXT.Exportar(guardar.FileName, lineas);

            MessageBox.Show("Ranking exportado correctamente.");
        }
    }
}
