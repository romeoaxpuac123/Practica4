using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica4;
using System.Web;


namespace TestWeb
{
    [TestClass]
    public class UnitTestRegistro
    {
        [TestMethod]
        public void PruebaAlfanumerica()
        {
            //Verificando los metodos de registro
            var Regis1 = new RegistroM();
            var Servicio1 = Regis1.EsAlfanumerico("123456a");
            Assert.IsTrue(Servicio1);
        }
        [TestMethod]
        public void LargoPalabra()
        {
            var Registro = new RegistroM();
            var Servicio2 = Registro.Largo("12345678");
            if (Convert.ToInt32(Servicio2) == 8)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }

        }
        [TestMethod]
        public void ExistenciaUsuario()
        {
            var Registro = new RegistroM();
            var Servicio3 = Registro.ExistenciaUsuario("rome123");
            Assert.IsTrue(true);

        }
    }
}
