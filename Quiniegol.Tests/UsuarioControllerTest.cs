using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiniegol.Core.Controllers;
using Quiniegol.Core.Models;

namespace Quiniegol.Tests
{
    // Tests para UsuarioController
    // Cubre: RegistrarUsuario, IniciarSesion, CambiarPassword
    [TestClass]
    public class UsuarioControllerTest
    {
        
        // RegistrarUsuario — campos obligatorios
        

        [TestMethod]
        public void RegistrarUsuario_SinIdEmpleado_RetornaMensajeError()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.IdEmpleado = "";

            // Act
            string resultado = controller.RegistrarUsuario(usuario, "abcde");

            // Assert
            Assert.AreEqual("Debe ingresar el ID del empleado", resultado);
        }

        [TestMethod]
        public void RegistrarUsuario_SinCorreo_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Correo = "";

            string resultado = controller.RegistrarUsuario(usuario, usuario.Password);

            Assert.AreEqual("Debe ingresar un correo valido", resultado);
        }

        [TestMethod]
        public void RegistrarUsuario_SinNombre_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Nombre = "";

            string resultado = controller.RegistrarUsuario(usuario, usuario.Password);

            Assert.AreEqual("Debe ingresar un nombre valido", resultado);
        }

        [TestMethod]
        public void RegistrarUsuario_SinApellido_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Apellido = "";

            string resultado = controller.RegistrarUsuario(usuario, usuario.Password);

            Assert.AreEqual("Debe ingresar un apellido valido", resultado);
        }

        [TestMethod]
        public void RegistrarUsuario_SinDepartamento_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Departamento = "";

            string resultado = controller.RegistrarUsuario(usuario, usuario.Password);

            Assert.AreEqual("Debe ingresar un departamento de trabajo valido", resultado);
        }

        
        // RegistrarUsuario — validación correo
        

        [TestMethod]
        public void RegistrarUsuario_CorreoInvalido_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Correo = "esto-no-es-un-correo";

            string resultado = controller.RegistrarUsuario(usuario, usuario.Password);

            Assert.AreEqual("El correo electronico no es valido", resultado);
        }

        
        // RegistrarUsuario — validación contraseña
        

        [TestMethod]
        public void RegistrarUsuario_PasswordCorta_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Password = "abc";

            string resultado = controller.RegistrarUsuario(usuario, "abc");

            Assert.AreEqual("La contraseña debe tener al menos 5 caracteres", resultado);
        }

        [TestMethod]
        public void RegistrarUsuario_PasswordConNumeros_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();
            usuario.Password = "abc123";

            string resultado = controller.RegistrarUsuario(usuario, "abc123");

            Assert.AreEqual("La contraseña solo puede contener letras", resultado);
        }

        [TestMethod]
        public void RegistrarUsuario_PasswordNoCoincide_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();
            Usuario usuario = CrearUsuarioValido();

            string resultado = controller.RegistrarUsuario(usuario, "diferente");

            Assert.AreEqual("La contraseña no coincide", resultado);
        }

        
        // IniciarSesion — validaciones
        

        [TestMethod]
        public void IniciarSesion_SinIdEmpleado_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();

            string resultado = controller.IniciarSesion("", "abcde");

            Assert.AreEqual("Debe ingresar el ID del empleado", resultado);
        }

        [TestMethod]
        public void IniciarSesion_SinPassword_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();

            string resultado = controller.IniciarSesion("12345", "");

            Assert.AreEqual("Debe de ingresar la contraseña", resultado);
        }

        
        // CambiarPassword — validaciones
        

        [TestMethod]
        public void CambiarPassword_SinPassword_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();

            string resultado = controller.CambiarPassword("12345", "");

            Assert.AreEqual("Debe ingresar la nueva contraseña.", resultado);
        }

        [TestMethod]
        public void CambiarPassword_PasswordCorta_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();

            string resultado = controller.CambiarPassword("12345", "ab");

            Assert.AreEqual("La contraseña debe tener al menos 5 caracteres.", resultado);
        }

        [TestMethod]
        public void CambiarPassword_PasswordConNumeros_RetornaMensajeError()
        {
            UsuarioController controller = new UsuarioController();

            string resultado = controller.CambiarPassword("12345", "abc12");

            Assert.AreEqual("La contraseña solo puede contener letras.", resultado);
        }

        
        // Método auxiliar
        

        // Crea un usuario con todos los datos válidos para las pruebas
        private Usuario CrearUsuarioValido()
        {
            return new Usuario
            {
                IdEmpleado   = "99999",
                Nombre       = "Test",
                Apellido     = "Usuario",
                Departamento = "Tecnología",
                Correo       = "test@test.com",
                Password     = "abcde",
                IdRol        = 2
            };
        }
    }
}
