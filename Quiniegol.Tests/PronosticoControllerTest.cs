using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiniegol.Core.Controllers;
using Quiniegol.Core.Models;

namespace Quiniegol.Tests
{
    // Tests para PronosticoController
    // Cubre: RegistrarPronostico — validaciones de campos
    [TestClass]
    public class PronosticoControllerTest
    {
        
        // RegistrarPronostico — campos obligatorios
        

        [TestMethod]
        public void RegistrarPronostico_SinIdEmpleado_RetornaMensajeError()
        {
            // Arrange
            PronosticoController controller = new PronosticoController();
            Pronostico pronostico = CrearPronosticoValido();
            pronostico.IdEmpleado = "";

            // Act
            string resultado = controller.RegistrarPronostico(pronostico);

            // Assert
            Assert.AreEqual("Debe seleccionar un empleado.", resultado);
        }

        [TestMethod]
        public void RegistrarPronostico_SinPartido_RetornaMensajeError()
        {
            PronosticoController controller = new PronosticoController();
            Pronostico pronostico = CrearPronosticoValido();
            pronostico.IdPartido = 0;

            string resultado = controller.RegistrarPronostico(pronostico);

            Assert.AreEqual("Debe seleccionar un partido.", resultado);
        }

        [TestMethod]
        public void RegistrarPronostico_SinResultado_RetornaMensajeError()
        {
            PronosticoController controller = new PronosticoController();
            Pronostico pronostico = CrearPronosticoValido();
            pronostico.ResultadoPronosticado = "";

            string resultado = controller.RegistrarPronostico(pronostico);

            Assert.AreEqual("Debe seleccionar un pronostico.", resultado);
        }

        
        // RegistrarPronostico — resultado inválido
        

        [TestMethod]
        public void RegistrarPronostico_ResultadoEspacios_RetornaMensajeError()
        {
            PronosticoController controller = new PronosticoController();
            Pronostico pronostico = CrearPronosticoValido();

            // Un resultado con solo espacios también es inválido
            pronostico.ResultadoPronosticado = "   ";

            string resultado = controller.RegistrarPronostico(pronostico);

            Assert.AreEqual("Debe seleccionar un pronostico.", resultado);
        }

        
        // Método auxiliar
        

        // Crea un pronóstico con datos básicos válidos para las pruebas
        private Pronostico CrearPronosticoValido()
        {
            return new Pronostico
            {
                IdPronostico          = 999,
                IdEmpleado            = "12345",
                IdPartido             = 1,
                ResultadoPronosticado = "Local"
            };
        }
    }
}
