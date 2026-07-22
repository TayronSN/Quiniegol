using Quiniegol.Data;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Net.Mail;

namespace Quiniegol.Controllers
{
    internal class UsuarioController
    {

        public string RegistrarUsuario(Usuario usuario, string confirmarPassword)

        {

            string mensaje = ValidarCamposObligatorios(usuario, confirmarPassword);

            if (!string.IsNullOrWhiteSpace(mensaje))
            {

                return mensaje;

            }

            mensaje = ValidarCorreo(usuario);

            if (!string.IsNullOrEmpty(mensaje))
            {
                return mensaje;
            }

            mensaje = ValidarPassword(usuario);

            if (!string.IsNullOrEmpty(mensaje))
            {
                return mensaje;
            }

            mensaje = ValidarConfirmacionPassword(usuario, confirmarPassword);

            if (!string.IsNullOrEmpty(mensaje))
            {
                return mensaje;
            }

            mensaje = VerificarIdExistente(usuario);

            if (!string.IsNullOrEmpty(mensaje))
            {
                return mensaje;
            }

            mensaje = VerificarCorreoExistente(usuario);

            if (!string.IsNullOrEmpty(mensaje))
            {
                return mensaje;
            }

            UsuariosData.GuardarUsuario(usuario);

            return "";

        }

        private string ValidarCamposObligatorios(Usuario usuario, string confirmarPassword)

        {

            if (string.IsNullOrWhiteSpace(usuario.IdEmpleado))
            {

                return "Debe ingresar el ID del empleado";

            }
                        
            if (string.IsNullOrWhiteSpace(usuario.Correo))
            {

                return "Debe ingresar un correo valido";

            }        

            if (string.IsNullOrWhiteSpace(usuario.Password))
            {

                return "Debe ingresar una contraseña";

            }           

            if (string.IsNullOrWhiteSpace(confirmarPassword))
            {

                return "Confirme su contraseña";

            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {

                return "Debe ingresar un nombre valido";

            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {

                return "Debe ingresar un apellido valido";

            }

            if (string.IsNullOrWhiteSpace(usuario.Departamento))
            {

                return "Debe ingresar un departamento de trabajo valido";

            }

            return "";

        }

        private string ValidarCorreo(Usuario usuario)

        {
            try
            {

                MailAddress correo = new MailAddress(usuario.Correo);
            
            }
            catch
            {
                return "El correo electronico no es valido";
            }
            

            return "";

        }

        private string ValidarPassword(Usuario usuario)
        {
            if (usuario.Password.Length<5)
            {
                return "La contraseña debe tener al menos 5 caracteres";
            }

            foreach (char caracter in usuario.Password)
            {
                if (!char.IsLetter(caracter))
                {
                    return "La contraseña solo puede contener letras";
                }
            }

            return "";

        }

        private string ValidarConfirmacionPassword(Usuario usuario, string confirmarPassword)
        {

            if (usuario.Password != confirmarPassword)
            {
                return "La contraseña no coincide";
            }

            return "";
        
        }

        private string VerificarIdExistente(Usuario usuario)
        {

            Usuario? usuarioExistente = UsuariosData.BuscarPorIdEmpleado(usuario.IdEmpleado);

            if (usuarioExistente != null)
            {
                return "El ID del empleado ya se encuentra registrado";
            }

            return "";

        }

        private string VerificarCorreoExistente(Usuario usuario)
        {
            Usuario? usuarioExistente = UsuariosData.BuscarPorCorreo(usuario.Correo);

            if (usuarioExistente != null)
            {
                return "El correo ya se encuentra registrado";
            }

            return "";
        
        }

        public string IniciarSesion(string idEmpleado, string password)
        {
            if (string.IsNullOrWhiteSpace(idEmpleado))
            {
                return "Debe ingresar el ID del empleado";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return "Debe de ingresar la contraseña";
            }

            Usuario? usuario = UsuariosData.BuscarPorIdEmpleado(idEmpleado);

            if (usuario == null)
            {
                return "El ID del empleado no existe";
            }

            if (usuario.Password != password)
            {
                return "La contraseña es incorrecta";
            }

            return "";
        }


    }
}
