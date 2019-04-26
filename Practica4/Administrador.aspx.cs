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
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Codigo_Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnRealizarDeposito_Click(object sender, EventArgs e)
        {
            int i = LasCuentas.SelectedIndex;
            HacerDeposito(Convert.ToInt32(LasCuentas.Items[i].Text), Convert.ToDecimal(txtCuenta.Text));

            MessageBox.Show("DEPOSITO REALIZADO CON EXITO");
            txtCuenta.Text = "";
        }

        public void HacerDeposito(int Cuenta, decimal monto)
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
            asdfkljasdhfsahdkjhsdahkjasdhfjkahsdfk
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
        }

        protected void Debitar_Click(object sender, EventArgs e)
        {
            int i = CUENTASD.SelectedIndex;
            DebitarXD(Convert.ToInt32(CUENTASD.Items[i].Text),Convert.ToDecimal(TextBox2.Text),txtDescripcion.Text);

            MessageBox.Show("DEBITO REALIZADO CON EXITO");
            TextBox2.Text = "";
        }
        public void DebitarXD(int Cuenta, decimal monto,String Descripcion)
        {
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
            decimal monto2 = monto;
            monto = ElSaldo - monto;


            SqlConnection conxxpa = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxpa.Open();
            SqlCommand comxxpa = new SqlCommand(); // Create a object of SqlCommand class
            comxxpa.Connection = conxxpa; //Pass the connection object to Command
            comxxpa.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxpa.CommandText = "ModificarSaldo2"; //Stored Procedure Name
            comxxpa.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = monto;
            comxxpa.Parameters.Add("@codigo_Cuenta", SqlDbType.NVarChar).Value = Cuenta;
            comxxpa.ExecuteNonQuery();
            conxxpa.Close();


            SqlConnection conxxp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxp.Open();
            SqlCommand comxxp = new SqlCommand(); // Create a object of SqlCommand class
            comxxp.Connection = conxxp; //Pass the connection object to Command
            comxxp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxp.CommandText = "HacerDebito"; //Stored Procedure Name
            comxxp.Parameters.Add("@numero_de_Cuenta", SqlDbType.NVarChar).Value = Cuenta;
            comxxp.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = Descripcion;
            comxxp.Parameters.Add("@monto", SqlDbType.NVarChar).Value = monto2;
            comxxp.ExecuteNonQuery();
            conxxp.Close();
        }

        protected void LOSCREDITOS_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "admin";
            Response.Redirect("Creditos.aspx");
        }

        protected void SESION_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}