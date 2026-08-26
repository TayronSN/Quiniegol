using Quiniegol.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Quiniegol.Data
{
    // Lee y escribe los datos de usuarios en el archivo JSON.
    internal class UsuariosData
    {
        private static readonly string rutaArchivo = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data", "usuarios.json");

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
            foreach (Usuario usuario in LeerUsuarios())
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
            foreach (Usuario usuario in LeerUsuarios())
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

            Guardar(usuarios);
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

            Guardar(usuarios);
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

            Guardar(usuarios);
        }

        // Serializa la lista y la escribe en el archivo JSON.
        private static void Guardar(List<Usuario> usuarios)
        {
            string json = JsonSerializer.Serialize(usuarios);

            try
            {
                File.WriteAllText(rutaArchivo, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar usuarios: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
