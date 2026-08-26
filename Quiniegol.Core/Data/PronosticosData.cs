using Microsoft.EntityFrameworkCore;
using Quiniegol.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Quiniegol.Core.Data
{
    // Clase encargada de manejar los datos de los pronósticos.
    public class PronosticosData
    {
        // Ruta del archivo JSON que conservamos como respaldo.
        private static readonly string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "pronosticos.json");

        // Lee todos los pronósticos desde SQLite.
        public static List<Pronostico> LeerPronosticos()
        {
            using AppDbContext db = new AppDbContext();

            return db.Pronosticos .AsNoTracking() .ToList();
        }

        // Busca un pronóstico por su identificador.
        public static Pronostico? BuscarPorId(int idPronostico)
        {
            using AppDbContext db = new AppDbContext();

            return db.Pronosticos .AsNoTracking() .FirstOrDefault(p => p.IdPronostico == idPronostico);
        }

        // Obtiene el siguiente ID disponible.
        public static int ObtenerSiguienteId()
        {
            using AppDbContext db = new AppDbContext();

            // Si no existen pronósticos, el primer ID será 1.
            if (!db.Pronosticos.Any())
            {
                return 1;
            }

            // Busca el ID más alto y le suma 1.
            return db.Pronosticos .Max(p => p.IdPronostico) + 1;
        }

        // Guarda un nuevo pronóstico en SQLite.
        public static void GuardarPronostico(Pronostico pronostico)
        {
            using AppDbContext db = new AppDbContext();

            db.Pronosticos.Add(pronostico);
            db.SaveChanges();

            // También actualiza el JSON como respaldo.
            GuardarEnJson();
        }

        // Actualiza un pronóstico existente en SQLite.
        public static void ActualizarPronostico(Pronostico pronostico)
        {
            using AppDbContext db = new AppDbContext();

            db.Pronosticos.Update(pronostico);
            db.SaveChanges();

            // También actualiza el JSON como respaldo.
            GuardarEnJson();
        }

        // Elimina un pronóstico de SQLite.
        public static void EliminarPronostico(Pronostico pronostico)
        {
            using AppDbContext db = new AppDbContext();

            Pronostico? pronosticoExistente = db.Pronosticos.FirstOrDefault( p => p.IdPronostico == pronostico.IdPronostico);

            if (pronosticoExistente != null)
            {
                db.Pronosticos.Remove(pronosticoExistente);
                db.SaveChanges();
            }

            // También actualiza el JSON como respaldo.
            GuardarEnJson();
        }

        // Inicializa SQLite utilizando los pronósticos existentes en el JSON.
        public static void InicializarPronosticos()
        {
            using AppDbContext db = new AppDbContext();

            // Si SQLite ya tiene pronósticos, no se vuelven a cargar.
            if (db.Pronosticos.Any())
            {
                return;
            }

            // Lee los pronósticos existentes desde JSON.
            List<Pronostico> pronosticos = LeerPronosticosJson();

            if (pronosticos.Count == 0)
            {
                return;
            }

            // Copia los pronósticos del JSON hacia SQLite.
            db.Pronosticos.AddRange(pronosticos);
            db.SaveChanges();
        }

        // Lee los pronósticos directamente desde el archivo JSON.
        // Este método solamente se utiliza durante la carga inicial.
        private static List<Pronostico> LeerPronosticosJson()
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

            List<Pronostico>? pronosticos = JsonSerializer.Deserialize<List<Pronostico>>(json);

            return pronosticos ?? new List<Pronostico>();
        }

        // Guarda en JSON los pronósticos que actualmente existen en SQLite.
        // Mantiene el JSON ordenado y fácil de leer.
        private static void GuardarEnJson()
        {
            List<Pronostico> pronosticos = LeerPronosticos();

            string json = JsonSerializer.Serialize( pronosticos, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(rutaArchivo, json);
        }
    }
}