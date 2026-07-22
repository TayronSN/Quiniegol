using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;



namespace Quiniegol.Data
{
    internal class UsuariosData
    {
        
        private static readonly string rutaArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data\usuarios.json"));
        public static List<Usuario> LeerUsuarios()

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

        public static Usuario? BuscarPorIdEmpleado(string idEmpleado)

        {
            List<Usuario> usuarios = LeerUsuarios();

            foreach (Usuario usuario in usuarios)

            {
                if (usuario.IdEmpleado == idEmpleado)

                {
                    return usuario;
                }

            }

            return null;
        }

        public static Usuario? BuscarPorCorreo(string correo)

        {
            List<Usuario> usuarios = LeerUsuarios();

            foreach (Usuario usuario in usuarios)

            {
                if (usuario.Correo == correo)

                {
                    return usuario;
                }

            }

            return null;
        }

        public static void GuardarUsuario(Usuario usuario)

        {
            List<Usuario> usuarios = LeerUsuarios();

            usuarios.Add(usuario);

            string json = JsonSerializer.Serialize(usuarios);

            File.WriteAllText(rutaArchivo, json);

        }

        public static void ActualizarUsuario(Usuario usuario)

        {

            List<Usuario> usuarios = LeerUsuarios();

            for (int i = 0; i < usuarios.Count; i++)

            {

                if (usuarios[i].IdEmpleado == usuario.IdEmpleado)

                {
                    usuarios[i] = usuario;

                    break;
                }


            }

            string json = JsonSerializer.Serialize(usuarios);

            File.WriteAllText(rutaArchivo, json);

        }

        public static void EliminarUsuario(Usuario usuario)

        {
            List<Usuario> usuarios = LeerUsuarios();

            for (int i = 0; i < usuarios.Count; i++)

            {

                if (usuarios[i].IdEmpleado == usuario.IdEmpleado)

                {
                    usuarios.RemoveAt(i);

                    break;
                }


            }

            string json = JsonSerializer.Serialize(usuarios);

            File.WriteAllText(rutaArchivo, json);
        }
    }
}