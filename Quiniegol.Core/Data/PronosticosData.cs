using System;
using System.Collections.Generic;
using System.Text;
using Quiniegol.Core.Models;
using System.Text.Json;
using System.IO;

namespace Quiniegol.Core.Data
{
    public class PronosticosData
    {
        private static readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\..\Data\pronosticos.json"));

        public static List<Pronostico> LeerPronosticos()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Pronostico>();
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Pronostico>();
            }

            List<Pronostico> pronosticos = JsonSerializer.Deserialize<List<Pronostico>>(json);

            return pronosticos ?? new List<Pronostico>();
        }

        public static Pronostico BuscarPorId(int idPronostico)
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            foreach (Pronostico pronostico in pronosticos)
            {
                if (pronostico.IdPronostico == idPronostico)
                {
                    return pronostico;
                }
            }

            return null;
        }

        public static int ObtenerSiguienteId()
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            if (pronosticos.Count == 0)
            {
                return 1;
            }

            return pronosticos[^1].IdPronostico + 1;
        }

        public static void GuardarPronostico(Pronostico pronostico)
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            pronosticos.Add(pronostico);

            string json = JsonSerializer.Serialize(pronosticos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }

        public static void ActualizarPronostico(Pronostico pronostico)
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            for (int i = 0; i < pronosticos.Count; i++)
            {
                if (pronosticos[i].IdPronostico == pronostico.IdPronostico)
                {
                    pronosticos[i] = pronostico;
                    break;
                }
            }

            string json = JsonSerializer.Serialize(pronosticos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }

        public static void EliminarPronostico(Pronostico pronostico)
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            pronosticos.RemoveAll(p => p.IdPronostico == pronostico.IdPronostico);

            string json = JsonSerializer.Serialize(pronosticos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }
    }
}

