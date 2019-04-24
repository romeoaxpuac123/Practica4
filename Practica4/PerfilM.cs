using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Practica4
{
    public class PerfilM
    {
        public string NombreUsuario(int codigoUsuario)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "VerUsuario"; //Stored Procedure Name
            com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = codigoUsuario;
            com.ExecuteNonQuery();
            String Nombre_Usuario = "";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Nombre_Usuario = reader.GetString(0);
                    //Usuario = reader.GetString(1);
                    break;
                }
            }
            con.Close();
            return Nombre_Usuario;
        }
        public string Usuario(int codigoUsuario)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "VerUsuario"; //Stored Procedure Name
            com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = codigoUsuario;
            com.ExecuteNonQuery();
            String Usuario = "";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Usuario = reader.GetString(1);
                    break;
                }
            }
            con.Close();
            return Usuario;
        }
        public int Cuenta(int codigoUsuario)
        {
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerCuenta"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = codigoUsuario;
            comx.ExecuteNonQuery();
            int cuenta = 0;
            SqlDataReader readerx = comx.ExecuteReader();
            if (readerx.HasRows)
            {
                while (readerx.Read())
                {
                    cuenta = readerx.GetInt32(0);
                    break;
                }
            }
            conx.Close();
            return cuenta;
        }
        public decimal Saldo(int codigoUsuario)
        {
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerSaldo"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = codigoUsuario;
            comx.ExecuteNonQuery();
            decimal SALDO = 0;
            SqlDataReader readerx = comx.ExecuteReader();
            if (readerx.HasRows)
            {
                while (readerx.Read())
                {
                    SALDO = readerx.GetDecimal(0);
                    break;
                }
            }
            return SALDO;
        }
        public Boolean SaldoSuficiente(int codigoUsuario, decimal saldox)
        {
            ///Obteniendo Saldo de la Cuenta
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerSaldo"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = codigoUsuario;
            comx.ExecuteNonQuery();
            decimal SALDO = 0;
            SqlDataReader readerx = comx.ExecuteReader();
            if (readerx.HasRows)
            {
                while (readerx.Read())
                {
                    SALDO = readerx.GetDecimal(0);
                    break;
                }
            }
            if (SALDO < saldox)
            {
                return false;
            }
            return true;
        }
        public decimal ConsultaDeSaldo2(String cuenta)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "ExistenciaDeCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@numerodecuenta", SqlDbType.NVarChar).Value = cuenta;
            comxx.ExecuteNonQuery();
            decimal ElSaldo = 0;
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    ElSaldo = readerxx.GetDecimal(2);
                    break;
                }
            }
            return ElSaldo;
        }

    }
}