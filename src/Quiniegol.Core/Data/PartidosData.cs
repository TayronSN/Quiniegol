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

            string json = JsonSerializer.Serialize(partidos);

            File.WriteAllText(rutaArchivo, json);
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

            string json = JsonSerializer.Serialize(partidos);

            File.WriteAllText(rutaArchivo, json);
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

            string json = JsonSerializer.Serialize(partidos);

            File.WriteAllText(rutaArchivo, json);
        }
    }
}