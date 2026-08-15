using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Quiniegol.Data;
using Quiniegol.Core.Models;
using Quiniegol.Utils;

namespace Quiniegol.Forms
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.Rows.Clear();

            List<Usuario> usuarios = UsuariosData.LeerUsuarios();

            foreach (Usuario usuario in usuarios)
            {
                string rol = usuario.IdRol == 1 ? "Administrador" : "Usuario";

                dgvUsuarios.Rows.Add(
                    usuario.IdEmpleado,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Departamento,
                    usuario.Correo,
                    usuario.Password,
                    rol
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            string idEmpleado = dgvUsuarios.CurrentRow.Cells["colIdEmpleado"].Value.ToString();

            Usuario usuario = UsuariosData.BuscarPorIdEmpleado(idEmpleado);

            if (usuario == null)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            if (usuario.IdRol == 1)
            {
                MessageBox.Show("No se puede eliminar un administrador.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            UsuariosData.EliminarUsuario(usuario);

            MessageBox.Show("Usuario eliminado correctamente.");

            CargarUsuarios();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();

            MessageBox.Show("Lista actualizada.");
        }

        private void btnDescargarUsuarios_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo de texto|*.txt";
            guardar.FileName = "Usuarios.txt";

            if (guardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<string> lineas = new List<string>();

            lineas.Add("===== USUARIOS REGISTRADOS =====");
            lineas.Add("");

            foreach (Usuario usuario in UsuariosData.LeerUsuarios())
            {
                string rol = usuario.IdRol == 1 ? "Administrador" : "Usuario";

                lineas.Add($"ID: {usuario.IdEmpleado}");
                lineas.Add($"Nombre: {usuario.Nombre} {usuario.Apellido}");
                lineas.Add($"Departamento: {usuario.Departamento}");
                lineas.Add($"Correo: {usuario.Correo}");
                lineas.Add($"Contraseña: {usuario.Password}");
                lineas.Add($"Rol: {rol}");
                lineas.Add("----------------------------------------");
            }

            ExportadorTXT.Exportar(guardar.FileName, lineas);

            MessageBox.Show("Usuarios exportados correctamente.");
        }
    }
}
