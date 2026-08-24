using Quiniegol.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Quiniegol.Core.Data
{
    public class PartidosData
    {
        public static readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Quiniegol.Core\Data\partidos.json"));

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

            // Convierte el contenido del archivo JSON en una lista de objetos Partido
            List<Partido>? partidos = JsonSerializer.Deserialize<List<Partido>>(json);

            return partidos ?? new List<Partido>();
        }

        public static Partido? BuscarPorId(int idPartido)
        {
            List<Partido> partidos = LeerPartidos();

            foreach (Partido partido in partidos)
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

            // Si no existen partidos, el primer ID será 1
            if (partidos.Count == 0)
            {
                return 1;
            }

            int mayorId = 0;

            // Se busca el ID más alto para generar el siguiente consecutivo
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

            // Se vuelve a serializar toda la lista para guardar los cambios en el JSON
            string json = JsonSerializer.Serialize(partidos);

            File.WriteAllText(rutaArchivo, json);
        }

        public static void ActualizarPartido(Partido partido)
        {
            List<Partido> partidos = LeerPartidos();

            // Se busca el partido por su ID y se reemplaza por la versión actualizada
            for (int i = 0; i < partidos.Count; i++)
            {
                if (partidos[i].IdPartido == partido.IdPartido)
                {
                    partidos[i] = partido;
                    break;
                }
            }

            string json = JsonSerializer.Serialize(partidos);

            File.WriteAllText(rutaArchivo, json);
        }

        public static void EliminarPartido(Partido partido)
        {
            List<Partido> partidos = LeerPartidos();

            // Se busca el partido por su ID y se elimina de la lista
            for (int i = 0; i < partidos.Count; i++)
            {
                if (partidos[i].IdPartido == partido.IdPartido)
                {
                    partidos.RemoveAt(i);
                    break;
                }
            }

            string json = JsonSerializer.Serialize(partidos);

            File.WriteAllText(rutaArchivo, json);
        }
    }
}