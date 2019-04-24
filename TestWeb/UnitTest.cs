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
            //Verificando los metodos de Login
            var Login = new LoginM();
            var Servicio1Login = Login.Ingreso("rome123", "1234asdf", "1022");
            Assert.IsTrue(Servicio1Login);
        }

        [TestMethod]
        public void DepositoAdmin()
        {
            //Verificando los metodos de Administrador
            var Admin = new AdministradorM();
            var Servicio1Admin = Admin.HacerDeposito(10221022, 120);
            Assert.IsTrue(Servicio1Admin);
        }
        [TestMethod]
        public void HacerDebitoAdmin()
        {
            //Verificando los metodos de Administrador
            var Admin = new AdministradorM();
            var Servicio2Admin = Admin.DebitarXD(10221022, 120, "Prueba");
            Assert.IsTrue(Servicio2Admin);
        }
        [TestMethod]
        public void HacerDepositoCredito()
        {
            //Verificando los metodos de Credito
            var Credito = new CreditosM();
            var Servicio1 = Credito.HacerDeposito(10221022, 10);
            Assert.IsTrue(Servicio1);
        }
        [TestMethod]
        public void NumeroCuentaCredito()
        {
            //Verificando los metodos de Credito
            var Credito = new CreditosM();
            var Servicio2 = Credito.NumeroCuenta(76767);
            if(Servicio2 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void MontoCredito()
        {
            //Verificando los metodos de Credito
            var credito = new CreditosM();
            var Servicio3 = credito.MONTO(76767);
            if (Servicio3 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void EstadoCredito()
        {
            //Verificando los metodos de Credito
            var credito = new CreditosM();
            var Servicio4 = credito.CreditoAprobado(76767);
            Assert.IsTrue(Servicio4);
        }
        [TestMethod]
        public void NombreUsuarioInicio()
        {
            //Verificando los metodos de Inicio
            var Inicio = new InicioM();
            var Servicio1 = Inicio.NombreUsuario(1022);
            if(Servicio1.Length > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void UsuarioInicio()
        {
            //Verificando los metodos de Inicio
            var Inicio = new InicioM();
            var Servicio2 = Inicio.Usuario(1022);
            if (Servicio2.Length > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void CuentaInicio()
        {
            //Verificando los metodos de Inicio
            var Inicio = new InicioM();
            var Servicio3 = Inicio.Cuenta(1022);
            if (Servicio3 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void SaldoInicio()
        {//Verificando los metodos de Inicio
            var Inicio = new InicioM();
            var Servicio4 = Inicio.Saldo(1022);
            if (Servicio4 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void SaldoSuficienteInicio()
        {
            //Verificando los metodos de Inicio
            var Inicio = new InicioM();
            var Servicio5 = Inicio.SaldoSuficiente(1022, 10);
            Assert.IsTrue(Servicio5);
        }
        [TestMethod]
        public void ConsultaDeSaldoInicio()
        {
            //Verificando los metodos de Inicio
            var Inicio = new InicioM();
            var Servicio6 = Inicio.ConsultaDeSaldo2("10221022");
            if (Servicio6 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        public void NombreUsuarioPerfil()
        {
            //Verificando los metodos de perfil
            var Inicio = new PerfilM();
            var Servicio1 = Inicio.NombreUsuario(1022);
            if (Servicio1.Length > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void UsuarioPerfil()
        {
            //Verificando los metodos de perfil
            var Inicio = new PerfilM();
            var Servicio2 = Inicio.Usuario(1022);
            if (Servicio2.Length > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void CuentaPerfil()
        {
            //Verificando los metodos de perfil
            var Inicio = new PerfilM();
            var Servicio3 = Inicio.Cuenta(1022);
            if (Servicio3 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void SaldoPerfil()
        {//Verificando los metodos de perfil
            var Inicio = new PerfilM();
            var Servicio4 = Inicio.Saldo(1022);
            if (Servicio4 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void SaldoSuficientePerfil()
        {
            //Verificando los metodos de perfil
            var Inicio = new PerfilM();
            var Servicio5 = Inicio.SaldoSuficiente(1022, 10);
            Assert.IsTrue(Servicio5);
        }
        [TestMethod]
        public void ConsultaDeSaldoPerfil()
        {
            //Verificando los metodos de pefil
            var Inicio = new PerfilM();
            var Servicio6 = Inicio.ConsultaDeSaldo2("10221022");
            if (Servicio6 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void NombreUsuarioSolicitud()
        {
            //Verificando los metodos de Solicitud
            var Inicio = new SolicitudM();
            var Servicio1 = Inicio.NombreUsuario(1022);
            if (Servicio1.Length > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void UsuarioSolicitud()
        {
            //Verificando los metodos de Solicitud
            var Inicio = new SolicitudM();
            var Servicio2 = Inicio.Usuario(1022);
            if (Servicio2.Length > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void CuentaSolicitud()
        {
            //Verificando los metodos de Solicitud
            var Inicio = new SolicitudM();
            var Servicio3 = Inicio.Cuenta(1022);
            if (Servicio3 > 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }


    }
}
