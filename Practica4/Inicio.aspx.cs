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
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Codigo_Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Nombre.Text = "Nombre: " + NombreUsuario();
                USUARIO.Text = "Usuario: " + Usuario();
                CUENTA2.Text = "Cuenta No. " + Convert.ToString(Cuenta());
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

        protected void SALDO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Su Saldo es Q." + Convert.ToString(Saldo()));
        }
        
        public decimal Saldo()
        {
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerSaldo"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
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

        protected void SESIONX_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void TRANSFERIRX_Click(object sender, EventArgs e)
        {
            int i = CUENTASD.SelectedIndex;
            //MessageBox.Show(Convert.ToString(CUENTASD.Items[i].Text));
            if (SaldoSuficiente() == false)
            {
                MessageBox.Show("Saldo Insuficiente para Realizar la Transaccion");
                txtCuenta.Text = "";
            }
            else
            {
                HacerTransferencia(Convert.ToString(CUENTASD.Items[i].Text));
                txtCuenta.Text = "";
            }
        }
        public Boolean SaldoSuficiente()
        {
            ///Obteniendo Saldo de la Cuenta
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerSaldo"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
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
            if (SALDO < Convert.ToDecimal(txtCuenta.Text))
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
        public void HacerTransferencia(String Cuentax)
        {
            //Modificando Saldo En cuenta Actual
            decimal SALDOa = Saldo() - Convert.ToDecimal(txtCuenta.Text);
            SqlConnection conxaA = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxaA.Open();
            SqlCommand comxaA = new SqlCommand(); // Create a object of SqlCommand class
            comxaA.Connection = conxaA; //Pass the connection object to Command
            comxaA.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxaA.CommandText = "ModificarSaldo"; //Stored Procedure Name
            comxaA.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = SALDOa;
            comxaA.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
            comxaA.ExecuteNonQuery();
            conxaA.Close();

            ///Modificando Saldo En otra cuenta
            decimal SALDOax = ConsultaDeSaldo2(Cuentax) + Convert.ToDecimal(txtCuenta.Text);
            SqlConnection conxaAy = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxaAy.Open();
            SqlCommand comxaAy = new SqlCommand(); // Create a object of SqlCommand class
            comxaAy.Connection = conxaAy; //Pass the connection object to Command
            comxaAy.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxaAy.CommandText = "ModificarSaldo2"; //Stored Procedure Name
            comxaAy.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = SALDOax;
            comxaAy.Parameters.Add("@codigo_Cuenta", SqlDbType.NVarChar).Value = Cuentax;
            comxaAy.ExecuteNonQuery();
            conxaAy.Close();
            
            ///ALMACENANDO LA TRANSFERENCIA EN LA BD

            SqlConnection conxaAyx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxaAyx.Open();
            SqlCommand comxaAyx = new SqlCommand(); // Create a object of SqlCommand class
            comxaAyx.Connection = conxaAyx; //Pass the connection object to Command
            comxaAyx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxaAyx.CommandText = "AgregarTrasnferencia"; //Stored Procedure Name
            comxaAyx.Parameters.Add("@numero_de_cuenta", SqlDbType.NVarChar).Value = Convert.ToDecimal(Cuenta());
            comxaAyx.Parameters.Add("@cuenta_a_transferir", SqlDbType.NVarChar).Value = Convert.ToInt32(Cuentax);
            comxaAyx.Parameters.Add("@monto", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCuenta.Text);
            comxaAyx.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = DateTime.Now;
            comxaAyx.ExecuteNonQuery();

            MessageBox.Show("Transaccion Realizada Con exito");
        }

        protected void SOLICITAR_Click(object sender, EventArgs e)
        {
            Response.Redirect("Solicitud.aspx");
        }

        protected void VERPERFIL_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}