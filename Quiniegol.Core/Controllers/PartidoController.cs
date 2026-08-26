using Quiniegol.Core.Data;
using Quiniegol.Core.Models;

namespace Quiniegol.Core.Controllers
{
    public class PartidoController
    {
        public string RegistrarPartido(Partido partido)
        {
            // Primero se validan los campos obligatorios.
            string mensaje = ValidarCamposObligatorios(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            // Después se validan los equipos seleccionados.
            mensaje = ValidarEquipos(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            // Se obtiene un ID nuevo antes de guardar el partido.
            partido.IdPartido = PartidosData.ObtenerSiguienteId();

            // Todo partido nuevo comienza abierto para recibir pronósticos.
            partido.Estado = "Abierto";

            // Un partido nuevo todavía no tiene resultado.
            partido.Resultado = null;

            // Se guarda el partido en SQLite y se actualiza el JSON de respaldo.
            PartidosData.GuardarPartido(partido);

            return "Partido registrado correctamente.";
        }

        public string ActualizarPartido(Partido partido)
        {
            // Se validan los campos obligatorios.
            string mensaje = ValidarCamposObligatorios(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            // Se validan los equipos.
            mensaje = ValidarEquipos(partido);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return mensaje;
            }

            // Si el partido tiene un resultado, significa que ya terminó y debe quedar cerrado.
            if (!string.IsNullOrWhiteSpace(partido.Resultado))
            {
                partido.Estado = "Cerrado";
            }
            else
            {
                // Si no tiene resultado, permanece abierto para recibir pronósticos.
                partido.Estado = "Abierto";
            }

            // Se actualiza el partido en SQLite y posteriormente se sincroniza el archivo JSON.
            PartidosData.ActualizarPartido(partido);

            return "Partido actualizado correctamente.";
        }

        public string EliminarPartido(int idPartido)
        {
            // Se busca el partido que se desea eliminar.
            Partido? partido = PartidosData.BuscarPorId(idPartido);

            // Si no existe, se informa al usuario.
            if (partido == null)
            {
                return "Partido no encontrado.";
            }

            // Se elimina el partido de SQLite y se actualiza el JSON de respaldo.
            PartidosData.EliminarPartido(partido);

            return "Partido eliminado correctamente.";
        }

        private string ValidarCamposObligatorios(Partido partido)
        {
            // El equipo local es obligatorio.
            if (partido.IdEquipoLocal == 0)
            {
                return "Seleccione el equipo local";
            }

            // El equipo visitante es obligatorio.
            if (partido.IdEquipoVisitante == 0)
            {
                return "Seleccione el equipo visitante";
            }

            // La fase es obligatoria.
            if (string.IsNullOrWhiteSpace(partido.Fase))
            {
                return "Seleccione la fase";
            }

            return "";
        }

        private string ValidarEquipos(Partido partido)
        {
            // Se evita que un equipo juegue contra sí mismo.
            if (partido.IdEquipoLocal == partido.IdEquipoVisitante)
            {
                return "Un equipo no puede jugar contra el mismo";
            }

            // Se comprueba que el equipo local exista.
            if (EquiposData.BuscarPorId(partido.IdEquipoLocal) == null)
            {
                return "El equipo local no existe";
            }

            // Se comprueba que el equipo visitante exista.
            if (EquiposData.BuscarPorId(partido.IdEquipoVisitante) == null)
            {
                return "El equipo visitante no existe";
            }

            return "";
        }
    }
}