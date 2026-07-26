using Quiniegol.Controllers;
using Quiniegol.Data;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quiniegol.Forms
{
    public partial class FrmPartidos : Form
    {
        private PartidoController partidoController = new PartidoController();

        private int idPartidoSeleccionado = 0;

        public FrmPartidos()
        {
            InitializeComponent();
        }

        private void FrmPartidos_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            CargarFases();

            cmbResultado.Items.Clear();
            cmbResultado.Items.Add("Local");
            cmbResultado.Items.Add("Empate");
            cmbResultado.Items.Add("Visitante");

            txtEstado.Text = "Abierto";
            txtEstado.ReadOnly = true;

            cmbResultado.Enabled = false;

            ConfigurarDataGridView();
            CargarPartidos();
        }

        private void CargarEquipos()
        {
            List<Equipo> equipos = EquiposData.LeerEquipos();

            cmbEquipoLocal.DataSource = equipos.ToList();
            cmbEquipoLocal.DisplayMember = "Nombre";
            cmbEquipoLocal.ValueMember = "IdEquipo";

            cmbEquipoVisitante.DataSource = equipos.ToList();
            cmbEquipoVisitante.DisplayMember = "Nombre";
            cmbEquipoVisitante.ValueMember = "IdEquipo";
        }

        private void CargarFases()
        {
            cmbFase.Items.Clear();

            cmbFase.Items.Add("Grupos");
            cmbFase.Items.Add("Dieciseisavos");
            cmbFase.Items.Add("Octavos");
            cmbFase.Items.Add("Cuartos");
            cmbFase.Items.Add("Semifinal");
            cmbFase.Items.Add("Final");

            cmbFase.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvPartidos.Columns.Clear();

            dgvPartidos.Columns.Add("IdPartido", "ID");
            dgvPartidos.Columns.Add("EquipoLocal", "Equipo Local");
            dgvPartidos.Columns.Add("EquipoVisitante", "Equipo Visitante");
            dgvPartidos.Columns.Add("Fase", "Fase");
            dgvPartidos.Columns.Add("Estado", "Estado");
            dgvPartidos.Columns.Add("Resultado", "Resultado");
        }

        private void CargarPartidos()
        {
            dgvPartidos.Rows.Clear();

            List<Partido> partidos = PartidosData.LeerPartidos();

            foreach (Partido partido in partidos)
            {
                Equipo equipoLocal = EquiposData.BuscarPorId(partido.IdEquipoLocal);
                Equipo equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

                string nombreLocal = "";
                string nombreVisitante = "";

                if (equipoLocal != null)
                {
                    nombreLocal = equipoLocal.Nombre;
                }

                if (equipoVisitante != null)
                {
                    nombreVisitante = equipoVisitante.Nombre;
                }

                dgvPartidos.Rows.Add(
                    partido.IdPartido,
                    nombreLocal,
                    nombreVisitante,
                    partido.Fase,
                    partido.Estado,
                    partido.Resultado
                );
            }
        }

        private void LimpiarFormulario()
        {
            cmbEquipoLocal.SelectedIndex = 0;
            cmbEquipoVisitante.SelectedIndex = 0;

            cmbFase.SelectedIndex = 0;

            cmbResultado.SelectedIndex = -1;
            cmbResultado.Enabled = false;

            txtEstado.Text = "Abierto";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Partido partido = new Partido();

            partido.IdEquipoLocal = Convert.ToInt32(cmbEquipoLocal.SelectedValue);
            partido.IdEquipoVisitante = Convert.ToInt32(cmbEquipoVisitante.SelectedValue);
            partido.Fase = cmbFase.Text;
            partido.Resultado = "";

            string mensaje = partidoController.RegistrarPartido(partido);

            MessageBox.Show(mensaje);

            CargarPartidos();
            LimpiarFormulario();
        }

        private void dgvPartidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            idPartidoSeleccionado = Convert.ToInt32(dgvPartidos.Rows[e.RowIndex].Cells[0].Value);

            Partido partido = PartidosData.BuscarPorId(idPartidoSeleccionado);

            if (partido == null)
            {
                return;
            }

            cmbEquipoLocal.SelectedValue = partido.IdEquipoLocal;
            cmbEquipoVisitante.SelectedValue = partido.IdEquipoVisitante;
            cmbFase.Text = partido.Fase;

            txtEstado.Text = partido.Estado;

            cmbResultado.Enabled = true;
            cmbResultado.Text = partido.Resultado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idPartidoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un partido.");
                return;
            }

            Partido partido = new Partido();

            partido.IdPartido = idPartidoSeleccionado;
            partido.IdEquipoLocal = Convert.ToInt32(cmbEquipoLocal.SelectedValue);
            partido.IdEquipoVisitante = Convert.ToInt32(cmbEquipoVisitante.SelectedValue);
            partido.Fase = cmbFase.Text;
            partido.Resultado = cmbResultado.Text;

            string mensaje = partidoController.ActualizarPartido(partido);

            MessageBox.Show(mensaje);

            CargarPartidos();
            LimpiarFormulario();

            idPartidoSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPartidoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un partido.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar este partido?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            Partido partido = PartidosData.BuscarPorId(idPartidoSeleccionado);

            if (partido == null)
            {
                MessageBox.Show("No se encontró el partido.");
                return;
            }

            PartidosData.EliminarPartido(partido);

            MessageBox.Show("Partido eliminado correctamente.");

            CargarPartidos();
            LimpiarFormulario();

            idPartidoSeleccionado = 0;
        }
    }
}