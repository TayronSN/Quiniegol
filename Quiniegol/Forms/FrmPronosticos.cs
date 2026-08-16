using Quiniegol.Core.Controllers;
using Quiniegol.Core.Data;
using Quiniegol.Core.Models;
using Quiniegol.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quiniegol.Forms
{
    public partial class FrmPronosticos : Form
    {
        public FrmPronosticos()
        {
            InitializeComponent();
        }

        private class PartidoCombo
        {
            public int IdPartido { get; set; }

            public string Nombre { get; set; } = string.Empty;
        }

        private void FrmPronosticos_Load(object sender, EventArgs e)
        {
            CargarPartidos();
            CargarPronosticos();
        }


        private PronosticoController pronosticoController = new PronosticoController();

        private void CargarPartidos()
        {
            List<Partido> partidos = PartidosData.LeerPartidos();

            List<PartidoCombo> lista = new List<PartidoCombo>();

            foreach (Partido partido in partidos)
            {
                if (partido.Estado == "Abierto")
                {
                    Equipo equipoLocal = EquiposData.BuscarPorId(partido.IdEquipoLocal);
                    Equipo equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

                    lista.Add(new PartidoCombo
                    {
                        IdPartido = partido.IdPartido,
                        Nombre = equipoLocal.Nombre + " vs " + equipoVisitante.Nombre
                    });
                }
            }

            cmbPartidos.DataSource = lista;
            cmbPartidos.DisplayMember = "Nombre";
            cmbPartidos.ValueMember = "IdPartido";
        }

        private void CargarPronosticos()
        {
            dgvPronosticos.Rows.Clear();

            List<Pronostico> pronosticos = PronosticosData.LeerPronosticos();

            foreach (Pronostico pronostico in pronosticos)
            {
                if (pronostico.IdEmpleado != Sesion.IdEmpleado)
                {
                    continue;
                }

                Partido partido = PartidosData.BuscarPorId(pronostico.IdPartido);

                if (partido == null)
                {
                    continue;
                }

                Equipo equipoLocal = EquiposData.BuscarPorId(partido.IdEquipoLocal);
                Equipo equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

                if (equipoLocal == null || equipoVisitante == null)
                {
                    continue;
                }

                dgvPronosticos.Rows.Add(
                    equipoLocal.Nombre + " vs " + equipoVisitante.Nombre,
                    pronostico.ResultadoPronosticado,
                    partido.Estado
                );
            }
        }

        private void CargarBanderas(Equipo equipoLocal, Equipo equipoVisitante)
        {
            string rutaLocal = Path.Combine(Application.StartupPath, "..", "..", "..", equipoLocal.Bandera);
            string rutaVisitante = Path.Combine(Application.StartupPath, "..", "..", "..", equipoVisitante.Bandera);

            rutaLocal = Path.GetFullPath(rutaLocal);
            rutaVisitante = Path.GetFullPath(rutaVisitante);

            if (File.Exists(rutaLocal))
            {
                picEquipoLocal.Image = Image.FromFile(rutaLocal);
            }

            if (File.Exists(rutaVisitante))
            {
                picEquipoVisitante.Image = Image.FromFile(rutaVisitante);
            }

            lblEquipoLocal.Text = equipoLocal.Nombre;
            lblEquipoVisitante.Text = equipoVisitante.Nombre;
        }

        private string ObtenerResultadoSeleccionado()
        {
            if (rdbLocal.Checked)
            {
                return "Local";
            }

            if (rdbEmpate.Checked)
            {
                return "Empate";
            }

            if (rdbVisitante.Checked)
            {
                return "Visitante";
            }

            return "";
        }

        private void cmbPartidos_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbPartidos.SelectedItem == null)
            {
                return;
            }

            PartidoCombo partidoCombo = (PartidoCombo)cmbPartidos.SelectedItem;

            Partido partido = PartidosData.BuscarPorId(partidoCombo.IdPartido);

            if (partido == null)
            {
                return;
            }

            Equipo equipoLocal = EquiposData.BuscarPorId(partido.IdEquipoLocal);
            Equipo equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

            CargarBanderas(equipoLocal, equipoVisitante);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbPartidos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un partido.");
                return;
            }

            PartidoCombo partidoCombo = (PartidoCombo)cmbPartidos.SelectedItem;

            Pronostico pronostico = new Pronostico();

            pronostico.IdEmpleado = Sesion.IdEmpleado;
            pronostico.IdPartido = partidoCombo.IdPartido;
            pronostico.ResultadoPronosticado = ObtenerResultadoSeleccionado();

            string mensaje = pronosticoController.RegistrarPronostico(pronostico);

            MessageBox.Show(mensaje);

            if (mensaje == "Pronostico registrado correctamente.")
            {
                CargarPronosticos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }

}
