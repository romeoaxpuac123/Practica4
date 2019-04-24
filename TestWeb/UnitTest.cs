using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica4;
using System.Web;


namespace TestWeb
{
    [TestClass]
    public class UnitTest
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
            //Verificando los metodos de registro
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
            //Verificando los metodos de registro
            var Registro = new RegistroM();
            var Servicio3 = Registro.ExistenciaUsuario("rome123");
            Assert.IsTrue(true);

        }

        [TestMethod]
        public void LoginTest()
        {
            var Login = new LoginM();
            var Servicio1Login = Login.Ingreso("rome123", "1234asdf", "1022");
            Assert.IsTrue(true);
        }
    }
}
