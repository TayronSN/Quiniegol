using Quiniegol.Core.Data;
using Quiniegol.Core.Models;

namespace Quiniegol.Core.Controllers
{
    public class PartidoController
    {
        public string RegistrarPartido(Partido partido)
        {
            // Primero se validan los campos obligatorios y posteriormente los equipos
            string mensaje = ValidarCamposObligatorios(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            mensaje = ValidarEquipos(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            // Se obtiene un ID nuevo antes de guardar el partido
            partido.IdPartido = PartidosData.ObtenerSiguienteId();

            // Todo partido nuevo comienza abierto para recibir pronósticos
            partido.Estado = "Abierto";

            PartidosData.GuardarPartido(partido);

            return "Partido registrado correctamente.";
        }

        public string ActualizarPartido(Partido partido)
        {
            string mensaje = ValidarCamposObligatorios(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            mensaje = ValidarEquipos(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            // Un partido con resultado queda cerrado y uno sin resultado permanece abierto para recibir pronósticos
            if (!string.IsNullOrWhiteSpace(partido.Resultado))
            {
                partido.Estado = "Cerrado";
            }
            else
            {
                partido.Estado = "Abierto";
            }

            PartidosData.ActualizarPartido(partido);

            return "Partido actualizado correctamente.";
        }

        public string EliminarPartido(int idPartido)
        {
            Partido? partido = PartidosData.BuscarPorId(idPartido);

            if (partido == null)
            {
                return "Partido no encontrado.";
            }

            PartidosData.EliminarPartido(partido);

            return "Partido eliminado correctamente.";
        }

        private string ValidarCamposObligatorios(Partido partido)
        {
            if (partido.IdEquipoLocal == 0)
            {
                return "Seleccione el equipo local";
            }

            if (partido.IdEquipoVisitante == 0)
            {
                return "Seleccione el equipo visitante";
            }

            if (string.IsNullOrWhiteSpace(partido.Fase))
            {
                return "Seleccione la fase";
            }

            return "";
        }

        private string ValidarEquipos(Partido partido)
        {
            // Se evita que un mismo equipo sea seleccionado como local y visitante
            if (partido.IdEquipoLocal == partido.IdEquipoVisitante)
            {
                return "Un equipo no puede jugar contra el mismo";
            }

            // Se comprueba que los IDs seleccionados correspondan a equipos existentes en el sistema
            if (EquiposData.BuscarPorId(partido.IdEquipoLocal) == null)
            {
                return "El equipo local no existe";
            }

            if (EquiposData.BuscarPorId(partido.IdEquipoVisitante) == null)
            {
                return "El equipo visitante no existe";
            }

            return "";
        }
    }
}