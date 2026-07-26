using Quiniegol.Controllers;
using Quiniegol.Data;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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


    }
}
