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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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
            if (nombre.Length>0)
            {
                return true;
            }
            return false;
        }
        public void RegistrarENBD()
        {
            SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            con2.Open();
            SqlCommand com2 = new SqlCommand(); // Create a object of SqlCommand class
            com2.Connection = con2; //Pass the connection object to Command
            com2.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            com2.CommandText = "spInsertUser"; //Stored Procedure Name
            com2.Parameters.Add("@nombre_usuario", SqlDbType.NVarChar).Value = txtNombre.Text;
            com2.Parameters.Add("@correoelectronico", SqlDbType.NVarChar).Value = txtEmail.Text;
            com2.Parameters.Add("@passwordU", SqlDbType.NVarChar).Value = txtPassword.Text;
            com2.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = txtUsuario.Text;
            com2.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = txtUsuario.Text;
            com2.ExecuteNonQuery();
            MessageBox.Show("El Usuario " + txtNombre.Text + " Ha sido Registrado con exito");
            con2.Close();
        }
        public void MostrarCodigo()
        {
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerificarCodigoUs"; //Stored Procedure Name
            comx.Parameters.Add("@usuarioR", SqlDbType.NVarChar).Value = txtUsuario.Text;
            comx.ExecuteNonQuery();
            int nombrex = 0;
            SqlDataReader readerx = comx.ExecuteReader();
            if (readerx.HasRows)
            {
                while (readerx.Read())
                {
                    nombrex = readerx.GetInt32(0);
                    break;
                }
            }
            conx.Close();
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "CrearCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@codigoUsuario", SqlDbType.NVarChar).Value = nombrex;
            comxx.ExecuteNonQuery();
            conxx.Close();
            MessageBox.Show("Su Codigo de Usuario Es " + nombrex + " Gracias.");
            Response.Redirect("Login.aspx");

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //SUPERVISANDO LA CONTRASEÑA
            Boolean AprobacionContrasena = EsAlfanumerico(txtPassword.Text);
            Boolean LargoContrenia = true;
            if (AprobacionContrasena == false)
            {

                MessageBox.Show("La Contraseña No es Alfanumerica");
            }
            if (Largo(txtPassword.Text) != 8)
            {
                MessageBox.Show("El Largo de la Contaseña no es de 8 Caracteres");
                LargoContrenia = false;
            }
            //SUPERVISANDO EL USUARIO
            Boolean AprobacionUsuario = EsAlfanumerico(txtUsuario.Text);
            Boolean LargoUsuario = true;
            if (AprobacionUsuario == false)
            {
                MessageBox.Show("El Usuario No es Alfanumerica");
            }
            if (Largo(txtUsuario.Text) >= 12)
            {
                MessageBox.Show("El largo del usuario debe ser menor de 12 caracteres");
                LargoUsuario = false;
            }
            //VERIFICANDO EXISTENCIA USUARIO
            if (ExistenciaUsuario(txtUsuario.Text) == true)
            {
                MessageBox.Show("El Usuario Ya existe");
            }
            if (AprobacionContrasena == true && AprobacionUsuario == true && LargoContrenia==true
                && LargoUsuario == true && ExistenciaUsuario(txtUsuario.Text) == false)
            {
                RegistrarENBD();
                MostrarCodigo();
                Response.Redirect("Login.aspx");
            }
            else
            {
                MessageBox.Show("EXISTE UN ERROR EN LOS DATOS");
            }
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtPassword.Text = "";
            txtUsuario.Text = "";


        }
    }
}