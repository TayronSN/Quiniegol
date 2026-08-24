using System;
using System.Collections.Generic;
using System.Text;
using Quiniegol.Core.Data;
using Quiniegol.Core.Models;

namespace Quiniegol.Core.Controllers
{
    public class PronosticoController
    {
        public string RegistrarPronostico(Pronostico pronostico)
        {
            if (string.IsNullOrWhiteSpace(pronostico.IdEmpleado))
            {
                return "Debe seleccionar un empleado.";
            }

            if (pronostico.IdPartido == 0)
            {
                return "Debe seleccionar un partido.";
            }

            if (string.IsNullOrWhiteSpace(pronostico.ResultadoPronosticado))
            {
                return "Debe seleccionar un pronostico.";
            }

            // Se revisan los pronósticos existentes para evitar que un empleado registre más de un pronóstico para el mismo partido
            foreach (Pronostico p in PronosticosData.LeerPronosticos())
            {
                if (p.IdEmpleado == pronostico.IdEmpleado && p.IdPartido == pronostico.IdPartido)
                {
                    return "Este empleado ya realizo un pronostico para este partido.";
                }
            }

            // Se obtiene un nuevo ID antes de guardar el pronóstico.
            pronostico.IdPronostico = PronosticosData.ObtenerSiguienteId();

            PronosticosData.GuardarPronostico(pronostico);

            return "Pronostico registrado correctamente.";
        }

        public string ActualizarPronostico(Pronostico pronostico)
        {
            PronosticosData.ActualizarPronostico(pronostico);

            return "Pronostico actualizado correctamente.";
        }

        public string EliminarPronostico(int idPronostico)
        {
            Pronostico pronostico = PronosticosData.BuscarPorId(idPronostico);

            if (pronostico == null)
            {
                return "Pronostico no encontrado.";
            }

            PronosticosData.EliminarPronostico(pronostico);

            return "Pronóstico eliminado correctamente.";
        }
    }
}