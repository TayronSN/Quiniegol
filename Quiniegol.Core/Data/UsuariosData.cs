using Microsoft.EntityFrameworkCore;
using Quiniegol.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Quiniegol.Core.Data
{
    // Clase encargada de manejar los datos de los usuarios.
    public class UsuariosData
    {
        // Ruta del archivo JSON que conservamos como respaldo.
        private static readonly string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "usuarios.json");

        // Lee todos los usuarios desde SQLite.
        public static List<Usuario> LeerUsuarios()
        {
            using AppDbContext db = new AppDbContext();

            // Primero se obtienen los datos desde SQLite.
            // El ordenamiento se realiza posteriormente en memoria, ya que int.Parse no puede ser traducido por Entity Framework a SQL.
            return db.Usuarios
                .AsNoTracking()
                .ToList();
        }

        // Busca un usuario por su ID de empleado.
        public static Usuario? BuscarPorIdEmpleado(string idEmpleado)
        {
            using AppDbContext db = new AppDbContext();

            return db.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.IdEmpleado == idEmpleado);
        }

        // Busca un usuario por su correo.
        public static Usuario? BuscarPorCorreo(string correo)
        {
            using AppDbContext db = new AppDbContext();

            return db.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.Correo == correo);
        }

        // Guarda un nuevo usuario en SQLite.
        public static void GuardarUsuario(Usuario usuario)
        {
            using AppDbContext db = new AppDbContext();

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            // También actualiza el JSON como respaldo.
            GuardarEnJson();
        }

        // Actualiza un usuario existente en SQLite.
        public static void ActualizarUsuario(Usuario usuario)
        {
            using AppDbContext db = new AppDbContext();

            db.Usuarios.Update(usuario);
            db.SaveChanges();

            // También actualiza el JSON como respaldo.
            GuardarEnJson();
        }

        // Elimina un usuario de SQLite.
        public static void EliminarUsuario(Usuario usuario)
        {
            using AppDbContext db = new AppDbContext();

            Usuario? usuarioExistente =
                db.Usuarios.FirstOrDefault(
                    u => u.IdEmpleado == usuario.IdEmpleado
                );

            if (usuarioExistente != null)
            {
                db.Usuarios.Remove(usuarioExistente);
                db.SaveChanges();
            }

            // También actualiza el JSON como respaldo.
            GuardarEnJson();
        }

        // Inicializa SQLite utilizando los usuarios existentes en el archivo JSON.
        public static void InicializarUsuarios()
        {
            using AppDbContext db = new AppDbContext();

            // Si SQLite ya tiene usuarios, no se vuelven a cargar.
            if (db.Usuarios.Any())
            {
                return;
            }

            // Lee los usuarios existentes desde JSON.
            List<Usuario> usuarios = LeerUsuariosJson();

            if (usuarios.Count == 0)
            {
                return;
            }

            // Copia los usuarios del JSON hacia SQLite.
            db.Usuarios.AddRange(usuarios);
            db.SaveChanges();
        }

        // Lee los usuarios directamente desde JSON.
        // Este método solamente se utiliza durante la carga inicial.
        private static List<Usuario> LeerUsuariosJson()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Usuario>();
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Usuario>();
            }

            List<Usuario>? usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

            return usuarios ?? new List<Usuario>();
        }

        // Guarda en JSON los usuarios que actualmente existen en SQLite.
        private static void GuardarEnJson()
        {
            List<Usuario> usuarios = LeerUsuarios();

            string json = JsonSerializer.Serialize( usuarios, new JsonSerializerOptions { WriteIndented = true } );

            File.WriteAllText(rutaArchivo, json);
        }

    }
}