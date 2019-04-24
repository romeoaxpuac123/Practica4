using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Practica4
{
    public class CreditosM
    {

        public void EstadoCredito(int lacuenta, decimal monto, int codigo, string estado)
        {
            if (estado != "Rechazao")
                HacerDeposito(lacuenta, monto);

            SqlConnection conxxq = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxq.Open();
            SqlCommand comxxq = new SqlCommand(); // Create a object of SqlCommand class
            comxxq.Connection = conxxq; //Pass the connection object to Command
            comxxq.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxq.CommandText = "AprobarCredito"; //Stored Procedure Name
            comxxq.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
            comxxq.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado;
            comxxq.ExecuteNonQuery();
            conxxq.Close();
        }

        public Boolean HacerDeposito(int Cuenta, decimal monto)
        {
            ///Primero Buscamos el Saldo
            ///
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "ExistenciaDeCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@numerodecuenta", SqlDbType.NVarChar).Value = Cuenta;
            comxx.ExecuteNonQuery();
            int cuenta1 = 0;
            decimal ElSaldo = 0;
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    cuenta1 = readerxx.GetInt32(0);
                    ElSaldo = readerxx.GetDecimal(2);
                    break;
                }
            }
            conxx.Close();
            monto = monto + ElSaldo;

            ///Realizamos el Deposito
            SqlConnection conxxp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxp.Open();
            SqlCommand comxxp = new SqlCommand(); // Create a object of SqlCommand class
            comxxp.Connection = conxxp; //Pass the connection object to Command
            comxxp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxp.CommandText = "ModificarSaldo2"; //Stored Procedure Name
            comxxp.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = monto;
            comxxp.Parameters.Add("@codigo_Cuenta", SqlDbType.NVarChar).Value = Cuenta;
            comxxp.ExecuteNonQuery();
            conxxp.Close();

            ///Añadimos a la bd el deposito
            ///
            SqlConnection conxxpx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxpx.Open();
            SqlCommand comxxpx = new SqlCommand(); // Create a object of SqlCommand class
            comxxpx.Connection = conxxpx; //Pass the connection object to Command
            comxxpx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxpx.CommandText = "NuevoDeposito"; //Stored Procedure Name
            comxxpx.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = DateTime.Now;
            comxxpx.Parameters.Add("@monto ", SqlDbType.NVarChar).Value = monto;
            comxxpx.Parameters.Add("@numero_de_cuenta", SqlDbType.NVarChar).Value = Cuenta;
            comxxpx.ExecuteNonQuery();
            conxxpx.Close();
            if (Cuenta > 0)
            {
                return true;
            }
            return false;
        }

        public int NumeroCuenta(int codigo)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "NumCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
            comxx.ExecuteNonQuery();
            int codigox = 0;
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    codigox = readerxx.GetInt32(1);
                    break;
                }
            }
            return codigox;
        }

        public decimal MONTO(int codigo)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "NumCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
            comxx.ExecuteNonQuery();
            decimal codigox = 0;
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    codigox = readerxx.GetDecimal(3);
                    break;
                }
            }
            return codigox;

        }

        public Boolean CreditoAprobado(int codigo)
        {

            SqlConnection conxxhp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxhp.Open();
            SqlCommand comxxhp = new SqlCommand(); // Create a object of SqlCommand class
            comxxhp.Connection = conxxhp; //Pass the connection object to Command
            comxxhp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxhp.CommandText = "ESTADO"; //Stored Procedure Name
            comxxhp.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
            comxxhp.ExecuteNonQuery();
            string Elestado = "";
            SqlDataReader readerxxhp = comxxhp.ExecuteReader();
            if (readerxxhp.HasRows)
            {
                while (readerxxhp.Read())
                {
                    Elestado = readerxxhp.GetString(0);
                    break;
                }
            }

            if (Elestado == "Aprobado")
            {
                return true;
            }
            return false;
        }

    }
}