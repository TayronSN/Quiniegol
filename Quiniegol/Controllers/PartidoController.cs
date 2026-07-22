using Quiniegol.Data;
using Quiniegol.Models;
using System;

namespace Quiniegol.Controllers
{
    internal class PartidoController
    {
        public string RegistrarPartido(Partido partido)
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

            partido.IdPartido = PartidosData.ObtenerSiguienteId();
            
            partido.Estado = "Abierto";

            PartidosData.GuardarPartido(partido);

            return "Partido registrado correctamente.";
        }

        private string ValidarCamposObligatorios(Partido partido)
        {
            if (partido.IdEquipoLocal == 0)
                return "Seleccione el equipo local";

            if (partido.IdEquipoVisitante == 0)
                return "Seleccione el equipo visitante";

            if (string.IsNullOrWhiteSpace(partido.Fase))
                return "Seleccione la fase";

            return "";
        }

       private string ValidarEquipos(Partido partido)
        {
            if (partido.IdEquipoLocal == partido.IdEquipoVisitante)
            {
                return "Un equipo no puede jugar contra el mismo";
            }

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