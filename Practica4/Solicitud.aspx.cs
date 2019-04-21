using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Practica4
{
    public partial class Solicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Codigo_Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Nombre.Text = "Nombre: " + NombreUsuario();
                USUARIO.Text = "Usuario: " + Usuario();
                CUENTA2.Text = "Cuenta No. " + Convert.ToString(Cuenta());
                NoCuenta.Text = "Cuenta No. " + Convert.ToString(Cuenta());
            }
        }

        public string NombreUsuario()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "VerUsuario"; //Stored Procedure Name
            com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
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
        public string Usuario()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "VerUsuario"; //Stored Procedure Name
            com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
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
        public int Cuenta()
        {
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerCuenta"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
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

        protected void SESIONX_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void SOLICITAR_Click(object sender, EventArgs e)
        {
            SqlConnection conxa = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxa.Open();
            SqlCommand comxa = new SqlCommand(); // Create a object of SqlCommand class
            comxa.Connection = conxa; //Pass the connection object to Command
            comxa.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxa.CommandText = "SolicitudDeCretido"; //Stored Procedure Name
            comxa.Parameters.Add("@cuenta", SqlDbType.NVarChar).Value = Cuenta();
            comxa.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = txtDescripcion.Text;
            comxa.Parameters.Add("@monto", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCuenta.Text);

            comxa.ExecuteNonQuery();
            MessageBox.Show("Credito Solicitado");
            txtDescripcion.Text = "";
            txtCuenta.Text = "";
        }

        protected void VERPERFIL_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}