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
        private static readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Quiniegol.Core\Data\pronosticos.json"));

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

            // Convierte el contenido del archivo JSON en una lista de objetos Pronostico
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

            // Si no existen pronósticos, el primer ID será 1
            if (pronosticos.Count == 0)
            {
                return 1;
            }

            // ^1 obtiene el último elemento de la lista a partir de su ID se genera el siguiente consecutivo
            return pronosticos[^1].IdPronostico + 1;
        }

        public static void GuardarPronostico(Pronostico pronostico)
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            pronosticos.Add(pronostico);

            // Se serializa nuevamente toda la lista para guardar el nuevo pronóstico
            string json = JsonSerializer.Serialize(pronosticos, new JsonSerializerOptions
            {
                // Mantiene el archivo JSON organizado y fácil de leer
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }

        public static void ActualizarPronostico(Pronostico pronostico)
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            // Se busca el pronóstico por su ID y se reemplaza por la versión actualizada
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

            // RemoveAll elimina los pronósticos que tengan el mismo ID
            pronosticos.RemoveAll(p => p.IdPronostico == pronostico.IdPronostico);

            string json = JsonSerializer.Serialize(pronosticos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, json);
        }
    }
}