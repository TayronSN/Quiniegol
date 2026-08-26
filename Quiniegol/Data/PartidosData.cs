using Quiniegol.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Quiniegol.Data
{
    // Lee y escribe los datos de partidos en el archivo JSON.
    internal class PartidosData
    {
        private static readonly string rutaArchivo = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data", "partidos.json");

        public static List<Partido> LeerPartidos()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Partido>();
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Partido>();
            }

            List<Partido>? partidos = JsonSerializer.Deserialize<List<Partido>>(json);

            return partidos ?? new List<Partido>();
        }

        public static Partido? BuscarPorId(int idPartido)
        {
            foreach (Partido partido in LeerPartidos())
            {
                if (partido.IdPartido == idPartido)
                {
                    return partido;
                }
            }

            return null;
        }

        public static int ObtenerSiguienteId()
        {
            List<Partido> partidos = LeerPartidos();

            if (partidos.Count == 0)
            {
                return 1;
            }

            int mayorId = 0;

            foreach (Partido partido in partidos)
            {
                if (partido.IdPartido > mayorId)
                {
                    mayorId = partido.IdPartido;
                }
            }

            return mayorId + 1;
        }

        public static void GuardarPartido(Partido partido)
        {
            List<Partido> partidos = LeerPartidos();

            partidos.Add(partido);

            File.WriteAllText(rutaArchivo, JsonSerializer.Serialize(partidos));
        }

        public static void ActualizarPartido(Partido partido)
        {
            List<Partido> partidos = LeerPartidos();

            for (int i = 0; i < partidos.Count; i++)
            {
                if (partidos[i].IdPartido == partido.IdPartido)
                {
                    partidos[i] = partido;
                    break;
                }
            }

            File.WriteAllText(rutaArchivo, JsonSerializer.Serialize(partidos));
        }

        public static void EliminarPartido(Partido partido)
        {
            List<Partido> partidos = LeerPartidos();

            for (int i = 0; i < partidos.Count; i++)
            {
                if (partidos[i].IdPartido == partido.IdPartido)
                {
                    partidos.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllText(rutaArchivo, JsonSerializer.Serialize(partidos));
        }
    }
}
