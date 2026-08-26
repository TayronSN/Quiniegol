using Quiniegol.Core.Data;
using Quiniegol.Core.Models;

namespace Quiniegol.Core.Controllers
{
    public class PronosticoController
    {
        public string RegistrarPronostico(Pronostico pronostico)
        {
            // Se valida que se haya seleccionado un empleado.
            if (string.IsNullOrWhiteSpace(pronostico.IdEmpleado))
            {
                return "Debe seleccionar un empleado.";
            }

            // Se valida que se haya seleccionado un partido.
            if (pronostico.IdPartido == 0)
            {
                return "Debe seleccionar un partido.";
            }

            // Se valida que se haya seleccionado un pronóstico.
            if (string.IsNullOrWhiteSpace(pronostico.ResultadoPronosticado))
            {
                return "Debe seleccionar un pronostico.";
            }

            // Se busca el partido seleccionado.
            Partido? partido = PartidosData.BuscarPorId(pronostico.IdPartido);

            // Si el partido no existe, no se puede registrar el pronóstico.
            if (partido == null)
            {
                return "El partido no existe.";
            }

            // Solo se pueden registrar pronósticos mientras el partido se encuentre abierto.
            if (partido.Estado != "Abierto")
            {
                return "El partido ya esta cerrado y no acepta pronosticos.";
            }

            // Se revisan los pronósticos existentes para evitar que un empleado registre más de uno para el mismo partido.
            foreach (Pronostico p in PronosticosData.LeerPronosticos())
            {
                if (p.IdEmpleado == pronostico.IdEmpleado &&
                    p.IdPartido == pronostico.IdPartido)
                {
                    return "Este empleado ya realizo un pronostico para este partido.";
                }
            }

            // Se obtiene un nuevo ID antes de guardar el pronóstico.
            pronostico.IdPronostico = PronosticosData.ObtenerSiguienteId();

            // Se guarda el pronóstico en SQLite y se actualiza el archivo JSON de respaldo.
            PronosticosData.GuardarPronostico(pronostico);

            return "Pronostico registrado correctamente.";
        }

        public string ActualizarPronostico(Pronostico pronostico)
        {
            // Se verifica que el pronóstico exista.
            Pronostico? pronosticoExistente =
                PronosticosData.BuscarPorId(pronostico.IdPronostico);

            if (pronosticoExistente == null)
            {
                return "Pronostico no encontrado.";
            }

            // Se busca el partido relacionado con el pronóstico.
            Partido? partido =
                PartidosData.BuscarPorId(pronostico.IdPartido);

            if (partido == null)
            {
                return "El partido no existe.";
            }

            // No se permite modificar un pronóstico cuando el partido ya está cerrado.
            if (partido.Estado != "Abierto")
            {
                return "El partido ya esta cerrado y no se puede modificar el pronostico.";
            }

            // Se valida que exista un resultado pronosticado.
            if (string.IsNullOrWhiteSpace(pronostico.ResultadoPronosticado))
            {
                return "Debe seleccionar un pronostico.";
            }

            // Se actualiza el pronóstico en SQLite y se sincroniza el JSON de respaldo.
            PronosticosData.ActualizarPronostico(pronostico);

            return "Pronostico actualizado correctamente.";
        }

        public string EliminarPronostico(int idPronostico)
        {
            // Se busca el pronóstico por su ID.
            Pronostico? pronostico =
                PronosticosData.BuscarPorId(idPronostico);

            if (pronostico == null)
            {
                return "Pronostico no encontrado.";
            }

            // Se elimina el pronóstico de SQLite y se actualiza el JSON de respaldo.
            PronosticosData.EliminarPronostico(pronostico);

            return "Pronóstico eliminado correctamente.";
        }
    }
}