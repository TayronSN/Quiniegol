using Quiniegol.Core.Controllers;
using Quiniegol.Core.Data;
using Quiniegol.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Quiniegol.Utils;

namespace Quiniegol.Forms
{
    public partial class FrmRanking : Form
    {
        public FrmRanking()
        {
            InitializeComponent();
        }

        private void FrmRanking_Load(object sender, EventArgs e)
        {
            CargarRanking();
        }

        private RankingController rankingController = new RankingController();

        private void CargarRanking()
        {
            dgvRanking.Rows.Clear();

            List<Ranking> ranking = rankingController.GenerarRanking();

            int posicion = 1;

            foreach (Ranking jugador in ranking)
            {
                Usuario usuario = UsuariosData.BuscarPorIdEmpleado(jugador.IdEmpleado);

                string nombre = jugador.IdEmpleado;

                if (usuario != null)
                {
                    nombre = usuario.Nombre + " " + usuario.Apellido;
                }

                dgvRanking.Rows.Add(
                    posicion,
                    nombre,
                    jugador.Puntos
                );

                posicion++;
            }
        }

        private void btnDescargarRanking_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo de texto|*.txt";
            guardar.FileName = "Ranking.txt";

            if (guardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            RankingController rankingController = new RankingController();

            List<Ranking> ranking = rankingController.GenerarRanking();

            List<string> lineas = new List<string>();

            lineas.Add("========== RANKING QUINIEGOL ==========");
            lineas.Add("");

            int posicion = 1;

            foreach (Ranking jugador in ranking)
            {
                Usuario usuario = UsuariosData.BuscarPorIdEmpleado(jugador.IdEmpleado);

                string nombre = jugador.IdEmpleado;

                if (usuario != null)
                {
                    nombre = usuario.Nombre + " " + usuario.Apellido;
                }

                lineas.Add($"{posicion}. {nombre} - {jugador.Puntos} puntos");

                posicion++;
            }

            ExportadorTXT.Exportar(guardar.FileName, lineas);

            MessageBox.Show("Ranking exportado correctamente.");
        }
    }
}
