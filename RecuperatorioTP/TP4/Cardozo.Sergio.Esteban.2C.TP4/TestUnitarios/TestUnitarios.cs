using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Verifica que la lista de paquetes del correo este instanciada
        /// </summary>
        [TestMethod]
        public void ListaDePaquetesInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }
        /// <summary>
        /// Verifica que no se puedan cargar dos paquetes con el mismo ID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void ExceptionPaqueteRepetido()
        {
            Correo correo = new Correo();
            Paquete paquete = new Paquete("Somellera", "10");
            Paquete paquete1 = new Paquete("Buenos Aires", "10");

            correo += paquete;
            correo += paquete1;

            Assert.Fail();
        }
    }
}
