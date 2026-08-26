using Microsoft.EntityFrameworkCore;
using Quiniegol.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Quiniegol.Core.Data
{
    // Clase encargada de manejar los datos de los partidos.
    public class PartidosData
    {
        // Ruta del archivo JSON que conservamos como respaldo.
        private static readonly string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "partidos.json");

        // Lee todos los partidos desde SQLite.
        public static List<Partido> LeerPartidos()
        {
            using AppDbContext db = new AppDbContext();

            return db.Partidos .AsNoTracking() .ToList();
        }

        // Busca un partido por su identificador.
        public static Partido? BuscarPorId(int idPartido)
        {
            using AppDbContext db = new AppDbContext();

            return db.Partidos .AsNoTracking() .FirstOrDefault( p => p.IdPartido == idPartido);
        }

        // Obtiene el siguiente ID disponible para un nuevo partido.
        public static int ObtenerSiguienteId()
        {
            using AppDbContext db = new AppDbContext();

            // Si no existen partidos, el primer ID será 1.
            if (!db.Partidos.Any())
            {
                return 1;
            }

            // Obtiene el ID más alto y le suma uno.
            return db.Partidos.Max( p => p.IdPartido) + 1;
        }

        // Guarda un nuevo partido en SQLite.
        public static void GuardarPartido(Partido partido)
        {
            using AppDbContext db = new AppDbContext();

            db.Partidos.Add(partido);
            db.SaveChanges();

            // También actualiza el archivo JSON como respaldo.
            GuardarEnJson();
        }

        // Actualiza un partido existente.
        public static void ActualizarPartido(Partido partido)
        {
            using AppDbContext db = new AppDbContext();

            db.Partidos.Update(partido);
            db.SaveChanges();

            // También actualiza el archivo JSON como respaldo.
            GuardarEnJson();
        }

        // Elimina un partido de SQLite.
        public static void EliminarPartido(Partido partido)
        {
            using AppDbContext db = new AppDbContext();

            Partido? partidoExistente = db.Partidos.FirstOrDefault( p => p.IdPartido == partido.IdPartido);

            if (partidoExistente != null)
            {
                db.Partidos.Remove(partidoExistente);
                db.SaveChanges();
            }

            // También actualiza el archivo JSON como respaldo.
            GuardarEnJson();
        }

        // Inicializa SQLite utilizando los datos existentes del JSON para conservar los datosque ya teníamos en la versión anterior.
        public static void InicializarPartidos()
        {
            using AppDbContext db = new AppDbContext();

            // Si SQLite ya contiene partidos, no se vuelven a cargar.
            if (db.Partidos.Any())
            {
                return;
            }

            // Lee los partidos existentes desde el JSON.
            List<Partido> partidos = LeerPartidosJson();

            if (partidos.Count == 0)
            {
                return;
            }

            // Copia los partidos del JSON hacia SQLite.
            db.Partidos.AddRange(partidos);
            db.SaveChanges();
        }

        // Lee los partidos directamente desde el archivo JSON, sin pasar por SQLite para realizar la carga inicial.
        private static List<Partido> LeerPartidosJson()
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

        // Guarda en JSON los datos que actualmente existen en SQLite, el JSON queda como respaldo.
        private static void GuardarEnJson()
        {
            List<Partido> partidos = LeerPartidos();

            string json = JsonSerializer.Serialize( partidos, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(rutaArchivo, json);
        }
    }
}