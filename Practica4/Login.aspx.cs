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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                
            
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = txtCodigo.Text;
            if (Ingreso() == true)
            {
                MessageBox.Show("Bienvenido " + txtUsuario.Text);
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                MessageBox.Show("Datos Incorrectos, Intentelo de Nuevo");
            }
            txtCodigo.Text = "";
            txtPassword.Text = "";
            txtUsuario.Text = "";
        }
        protected void Registro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
        public Boolean Ingreso()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con.Open();
            SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
            com.Connection = con; //Pass the connection object to Command
            com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com.CommandText = "Login"; //Stored Procedure Name
            com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Convert.ToInt32(txtCodigo.Text);
            com.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = txtUsuario.Text;
            com.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;
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