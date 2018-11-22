using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestT4
{
    [TestClass]
    public class UnitTestTP4
    {
        [TestMethod]
        public void ListaCorreoInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo c = new Correo();

            c += new Paquete("Caboto 151 ", "303-898-4554");
            c += new Paquete("Caboto 152 ", "303-898-4554");
        }
    }
}
