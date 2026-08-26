using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiniegol.Core.Controllers;
using Quiniegol.Core.Models;

namespace Quiniegol.Tests
{
    // Tests para PartidoController
    // Cubre: RegistrarPartido, ActualizarPartido
    [TestClass]
    public class PartidoControllerTest
    {
        
        // RegistrarPartido — campos obligatorios
        

        [TestMethod]
        public void RegistrarPartido_SinEquipoLocal_RetornaMensajeError()
        {
            // Arrange
            PartidoController controller = new PartidoController();
            Partido partido = CrearPartidoValido();
            partido.IdEquipoLocal = 0;

            // Act
            string resultado = controller.RegistrarPartido(partido);

            // Assert
            Assert.AreEqual("Seleccione el equipo local", resultado);
        }

        [TestMethod]
        public void RegistrarPartido_SinEquipoVisitante_RetornaMensajeError()
        {
            PartidoController controller = new PartidoController();
            Partido partido = CrearPartidoValido();
            partido.IdEquipoVisitante = 0;

            string resultado = controller.RegistrarPartido(partido);

            Assert.AreEqual("Seleccione el equipo visitante", resultado);
        }

        [TestMethod]
        public void RegistrarPartido_SinFase_RetornaMensajeError()
        {
            PartidoController controller = new PartidoController();
            Partido partido = CrearPartidoValido();
            partido.Fase = "";

            string resultado = controller.RegistrarPartido(partido);

            Assert.AreEqual("Seleccione la fase", resultado);
        }

        [TestMethod]
        public void RegistrarPartido_MismoEquipo_RetornaMensajeError()
        {
            PartidoController controller = new PartidoController();
            Partido partido = CrearPartidoValido();

            // El mismo equipo en ambas posiciones no está permitido
            partido.IdEquipoLocal     = 1;
            partido.IdEquipoVisitante = 1;

            string resultado = controller.RegistrarPartido(partido);

            Assert.AreEqual("Un equipo no puede jugar contra el mismo", resultado);
        }

        
        // ActualizarPartido — mismas validaciones
        

        [TestMethod]
        public void ActualizarPartido_SinEquipoLocal_RetornaMensajeError()
        {
            PartidoController controller = new PartidoController();
            Partido partido = CrearPartidoValido();
            partido.IdEquipoLocal = 0;

            string resultado = controller.ActualizarPartido(partido);

            Assert.AreEqual("Seleccione el equipo local", resultado);
        }

        [TestMethod]
        public void ActualizarPartido_MismoEquipo_RetornaMensajeError()
        {
            PartidoController controller = new PartidoController();
            Partido partido = CrearPartidoValido();
            partido.IdEquipoLocal     = 2;
            partido.IdEquipoVisitante = 2;

            string resultado = controller.ActualizarPartido(partido);

            Assert.AreEqual("Un equipo no puede jugar contra el mismo", resultado);
        }

        
        // Método auxiliar
        

        // Crea un partido con IDs distintos para que pase la validación de equipos iguales
        private Partido CrearPartidoValido()
        {
            return new Partido
            {
                IdPartido         = 0,
                IdEquipoLocal     = 1,
                IdEquipoVisitante = 2,
                Fase              = "Grupos",
                Estado            = "Abierto"
            };
        }
    }
}
