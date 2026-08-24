using System;
using System.Collections.Generic;
using System.Text;
using Quiniegol.Core.Models;

namespace Quiniegol.Core.Utils
{
    public static class Sesion
    {
        // Guarda el usuario que actualmente tiene la sesión iniciada
        public static Usuario? UsuarioActual { get; private set; }

        // Indica si existe un usuario con una sesión iniciada
        public static bool InicioSesion
        {
            get
            {
                return UsuarioActual != null;
            }
        }

        // Indica si el usuario actual tiene el rol de administrador
        public static bool EsAdmin
        {
            get
            {
                return UsuarioActual != null && UsuarioActual.IdRol == 1;
            }
        }

        // Indica si el usuario actual tiene el rol de usuario normal
        public static bool EsUser
        {
            get
            {
                return UsuarioActual != null && UsuarioActual.IdRol == 2;
            }
        }

        // Guarda el usuario recibido como el usuario de la sesión actual
        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        // Elimina el usuario actual y cierra la sesión
        public static void Cerrar()
        {
            UsuarioActual = null;
        }
    }
}