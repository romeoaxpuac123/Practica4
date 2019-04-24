using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Practica4
{
    public class LoginM
    {

        public Boolean Ingreso(String txtUsuario, String txtPassword, String txtCodigo)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "Login"; //Stored Procedure Name
            com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Convert.ToInt32(txtCodigo);
            com.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = txtUsuario;
            com.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword;
            com.ExecuteNonQuery();
            int codigo1 = 0;
            String Usuario = "";
            String Passwordo = "";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    codigo1 = reader.GetInt32(0);
                    Usuario = reader.GetString(1);
                    Passwordo = reader.GetString(2);
                    break;
                }
            }
            if (codigo1 != 0 && Usuario.Length > 0 && Passwordo.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}