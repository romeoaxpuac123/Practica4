using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Practica4
{
    public class RegistroM
    {
        public Boolean EsAlfanumerico(String password)
        {
            char[] Validos = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K'
            ,'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            char[] Validos2 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k'
            ,'l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[] Validos3 = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int v1 = 0;
            int v2 = 0;
            v1 = 0;
            v2 = 0;
            for (int i = 0; i < Validos.Length; i++)
            {
                if (password.Contains(Validos[i]))
                {
                    v1 = v1 + 1;
                }

            }
            for (int i = 0; i < Validos2.Length; i++)
            {
                if (password.Contains(Validos2[i]))
                {
                    v1 = v1 + 1;
                }

            }
            for (int i = 0; i < Validos3.Length; i++)
            {
                if (password.Contains(Validos3[i]))
                {
                    v2 = v2 + 1;
                }

            }
            if (v1 > 0 && v2 > 0)
            {
                return true;
            }

            return false;
        }

        public Int32 Largo(String Palabra)
        {
            return Palabra.Length;
        }

        public Boolean ExistenciaUsuario(String Usuario)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "VerificarUsuario"; //Stored Procedure Name
            com.Parameters.Add("@usuarioR", SqlDbType.NVarChar).Value = Usuario;
            com.ExecuteNonQuery();
            String nombre = "";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nombre = reader.GetString(2);
                    break;
                }
            }
            con.Close();
            if (nombre.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}