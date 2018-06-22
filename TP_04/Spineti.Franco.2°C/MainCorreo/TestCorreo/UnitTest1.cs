using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestCorreo
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la instancia de la clase Correo no sea null.
        /// </summary>
        [TestMethod]
        public void ListaCorreo()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica que los ID's sean iguales.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void IDRepetido()
        {
            Correo correo = new Correo();

            correo += new Paquete("Oliden 1180", "123-456-7890");
            correo += new Paquete("9 de Julio 800", "123-456-7890");
        }
    }
}
