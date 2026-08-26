using Quiniegol.Data;
using Quiniegol.Models;

namespace Quiniegol.Controllers
{
    // Maneja el registro, actualización y eliminación de pronósticos.
    internal class PronosticoController
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

            // Un empleado no puede tener más de un pronóstico por partido.
            foreach (Pronostico p in PronosticosData.LeerPronosticos())
            {
                if (p.IdEmpleado == pronostico.IdEmpleado &&
                    p.IdPartido == pronostico.IdPartido)
                {
                    return "Este empleado ya realizo un pronostico para este partido.";
                }
            }

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
            Pronostico? pronostico = PronosticosData.BuscarPorId(idPronostico);

            if (pronostico == null)
            {
                return "Pronostico no encontrado.";
            }

            PronosticosData.EliminarPronostico(pronostico);

            return "Pronóstico eliminado correctamente.";
        }
    }
}
