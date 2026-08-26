using Quiniegol.Controllers;
using Quiniegol.Data;
using Quiniegol.Models;
using Quiniegol.Utils;

namespace Quiniegol.Forms
{
    public partial class FrmPronosticos : Form
    {
        private PronosticoController pronosticoController = new PronosticoController();

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

        private void CargarPartidos()
        {
            List<PartidoCombo> lista = new List<PartidoCombo>();

            foreach (Partido partido in PartidosData.LeerPartidos())
            {
                if (partido.Estado != "Abierto")
                {
                    continue;
                }

                Equipo? equipoLocal     = EquiposData.BuscarPorId(partido.IdEquipoLocal);
                Equipo? equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

                lista.Add(new PartidoCombo
                {
                    IdPartido = partido.IdPartido,
                    Nombre    = (equipoLocal?.Nombre ?? "") + " vs " + (equipoVisitante?.Nombre ?? "")
                });
            }

            cmbPartidos.DataSource    = lista;
            cmbPartidos.DisplayMember = "Nombre";
            cmbPartidos.ValueMember   = "IdPartido";
        }

        private void CargarPronosticos()
        {
            dgvPronosticos.Rows.Clear();

            foreach (Pronostico pronostico in PronosticosData.LeerPronosticos())
            {
                if (pronostico.IdEmpleado != Sesion.IdEmpleado)
                {
                    continue;
                }

                Partido? partido = PartidosData.BuscarPorId(pronostico.IdPartido);

                if (partido == null)
                {
                    continue;
                }

                Equipo? equipoLocal     = EquiposData.BuscarPorId(partido.IdEquipoLocal);
                Equipo? equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

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
            string rutaLocal     = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "..", equipoLocal.Bandera));
            string rutaVisitante = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "..", equipoVisitante.Bandera));

            if (File.Exists(rutaLocal))
            {
                picEquipoLocal.Image = Image.FromFile(rutaLocal);
            }

            if (File.Exists(rutaVisitante))
            {
                picEquipoVisitante.Image = Image.FromFile(rutaVisitante);
            }

            lblEquipoLocal.Text     = equipoLocal.Nombre;
            lblEquipoVisitante.Text = equipoVisitante.Nombre;
        }

        private string ObtenerResultadoSeleccionado()
        {
            if (rdbLocal.Checked)     return "Local";
            if (rdbEmpate.Checked)    return "Empate";
            if (rdbVisitante.Checked) return "Visitante";
            return "";
        }

        private void cmbPartidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartidos.SelectedItem == null)
            {
                return;
            }

            PartidoCombo partidoCombo = (PartidoCombo)cmbPartidos.SelectedItem;

            Partido? partido = PartidosData.BuscarPorId(partidoCombo.IdPartido);

            if (partido == null)
            {
                return;
            }

            Equipo? equipoLocal     = EquiposData.BuscarPorId(partido.IdEquipoLocal);
            Equipo? equipoVisitante = EquiposData.BuscarPorId(partido.IdEquipoVisitante);

            if (equipoLocal != null && equipoVisitante != null)
            {
                CargarBanderas(equipoLocal, equipoVisitante);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbPartidos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un partido.");
                return;
            }

            PartidoCombo partidoCombo = (PartidoCombo)cmbPartidos.SelectedItem;

            Pronostico pronostico = new Pronostico
            {
                IdEmpleado            = Sesion.IdEmpleado,
                IdPartido             = partidoCombo.IdPartido,
                ResultadoPronosticado = ObtenerResultadoSeleccionado()
            };

            string mensaje = pronosticoController.RegistrarPronostico(pronostico);

            MessageBox.Show(mensaje);

            if (mensaje == "Pronostico registrado correctamente.")
            {
                CargarPronosticos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { }
    }
}
