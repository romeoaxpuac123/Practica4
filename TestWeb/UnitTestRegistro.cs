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
            var Servicio1 = Regis1.EsAlfanumerico("123456");
            Assert.IsTrue(Servicio1);
        }
    }
}
