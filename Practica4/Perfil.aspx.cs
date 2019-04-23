using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

//using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using iTextSharp.text.html.simpleparser;
//using Image = iTextSharp.text.Image;
//using System.Text;

namespace Practica4
{
    public partial class Perfil : System.Web.UI.Page
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

        protected void SOLIC_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void SESIONX_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void elinicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void Archivo_Click(object sender, EventArgs e)
        {
           
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
           //base.VerifyRenderingInServerForm(control);
        }

        protected void Word_Click(object sender, EventArgs e)
        {
           
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

        protected void PDF_Click(object sender, EventArgs e)
        {
            /*
            iTextSharp.text.Image img = Image.GetInstance("C:\\Users\\Bayyron\\Desktop\\a.png");

            Response.ContentType = "application/pdf ";
            Response.AddHeader("content-disposition", "attachment;filename=TuCuenta.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            StringWriter sw2 = new StringWriter();
            HtmlTextWriter hw2 = new HtmlTextWriter(sw2);

            StringWriter sw3 = new StringWriter();
            HtmlTextWriter hw3 = new HtmlTextWriter(sw3);

            StringWriter sw4 = new StringWriter();
            HtmlTextWriter hw4 = new HtmlTextWriter(sw4);

            StringWriter sw5 = new StringWriter();
            HtmlTextWriter hw5 = new HtmlTextWriter(sw5);


            GridView1.AllowPaging = false;
            GridView1.DataBind();
            GridView1.RenderControl(hw);

            GridView2.AllowPaging = false;
            GridView2.DataBind();
            GridView2.RenderControl(hw2);

            GridView3.AllowPaging = false;
            GridView3.DataBind();
            GridView3.RenderControl(hw3);

            GridView4.AllowPaging = false;
            GridView4.DataBind();
            GridView4.RenderControl(hw4);

            GridView5.AllowPaging = false;
            GridView5.DataBind();
            GridView5.RenderControl(hw5);


            String Texto = "Bancos S.A \nEstado de Cuenta del Usuario " + NombreUsuario() +
                "\nCuenta No. "+ Cuenta() + "\nGuatemala Abril 2019 \n";

            StringReader sr = new StringReader(sw.ToString() + "\n\n\n");
            StringReader sr2 = new StringReader(sw2.ToString() + "\n\n\n");
            StringReader sr3 = new StringReader(sw3.ToString() + "\n\n\n");
            StringReader sr4 = new StringReader(sw4.ToString() + "\n\n\n");
            StringReader sr5 = new StringReader(sw5.ToString() + "\n\n\n");
            StringReader linea = new StringReader("\n\n* TUS CREDITOS * \n\n");
            StringReader linea2 = new StringReader("\n\n____________________________________________________________________________________________________________________________________________________________________________\n\n");

            StringReader lineaA = new StringReader("\n\n* TUS DEBITOS * \n\n");
            StringReader lineaA2 = new StringReader("\n\n____________________________________________________________________________________________________________________________________________________________________________\n\n");

            StringReader lineaB = new StringReader("\n\n* TUS DEPOSITOS * \n\n");
            StringReader lineaB2 = new StringReader("\n\n____________________________________________________________________________________________________________________________________________________________________________\n\n");

            StringReader lineaI = new StringReader("\n\n* TUS TRANSACCIONES * \n\n");
            StringReader lineaI2 = new StringReader("\n\n____________________________________________________________________________________________________________________________________________________________________________\n\n");


            StringReader lineaF = new StringReader("\n\n* TUS SALDO ES Q. \n\n" + ConsultaDeSaldo2(Convert.ToString(Cuenta())));
            StringReader lineaF2 = new StringReader("\n\n____________________________________________________________________________________________________________________________________________________________________________\n\n");

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            Paragraph par = new Paragraph(Texto);
            //var logo = iTextSharp.text.Image.GetInstance("Logo.png");
            var parrafo2 = new Paragraph("             ESTADO DE CUENTA");
            parrafo2.SpacingBefore = 30;
            parrafo2.SpacingAfter = 0;
            parrafo2.Alignment = 1; //0-Left, 1 middle,2 Right
            img.ScaleToFit(125f, 60F);
            //Imagen - Esquina inferior izquierda
            img.SetAbsolutePosition(420, 750);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(par);
            pdfDoc.AddTitle("REPORTE DEL ESTATUS DE CUENTA");
            pdfDoc.AddCreator("Romeo Axpuac - soyromeoaxpuac@gmail.com");
            pdfDoc.Add(parrafo2);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(img);
            htmlparser.Parse(lineaI);
            htmlparser.Parse(lineaI2);
            htmlparser.Parse(sr);
            htmlparser.Parse(linea);
            htmlparser.Parse(linea2);
            htmlparser.Parse(sr2);
            htmlparser.Parse(lineaA);
            htmlparser.Parse(lineaA2);
            htmlparser.Parse(sr3);
            htmlparser.Parse(lineaB);
            htmlparser.Parse(lineaB2);
            htmlparser.Parse(sr4);
            htmlparser.Parse(sr5);
            htmlparser.Parse(lineaF);
            htmlparser.Parse(lineaF2);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            */

        }
    }
}