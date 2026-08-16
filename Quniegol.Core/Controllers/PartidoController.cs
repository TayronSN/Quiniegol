using Quiniegol.Core.Data;
using Quiniegol.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Net.Mail;

namespace Quiniegol.Core.Controllers
{
    public class PartidoController
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