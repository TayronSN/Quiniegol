using System;
using System.Collections.Generic;
using System.Text;
using Quiniegol.Core.Models;

namespace Quiniegol.Core.Utils
{
    public static class Sesion
    {
        public static Usuario? UsuarioActual { get; private set; }

        public static bool InicioSesion
        {
            get
            {
                return UsuarioActual != null;
            }
        }

        public static bool EsAdmin
        {
            get
            {
                return UsuarioActual != null && UsuarioActual.IdRol == 1;
            }
        }

        public static bool EsUser
        {
            get
            {
                return UsuarioActual != null && UsuarioActual.IdRol == 2;
            }
        }

        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }
    }
}
