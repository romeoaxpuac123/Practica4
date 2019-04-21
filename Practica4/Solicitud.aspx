<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="Practica4.Solicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> </head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REGISTRO BANCO S.A.</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" /> 
    <link href="CSS/estilos.css" rel="stylesheet" />
<style>

    body {
    background-image: url(banco1.jpg);
    background-position: center center;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-size: cover;
    }
</style>
<body>
    <br />
       <br /><br /><br />
    
    <center><img src="texto2.png"></center>

       <div class="container well contenedor" >
        <div class="row">
            <div class="col-xs-12">
                <h2></h2>
                
            </div>

        </div>
         <center><img src="data.png" style="height: 61px; width: 250px"><br /></center>
        <form runat="server" class="form-horizontal center-block">
            <center>
            <div class="col-sm-10">
                    <asp:Label ID= "USUARIO" runat="server" Text="USUARIO" CssClass="control-label "></asp:Label> 
            </div>
           <div class="col-sm-10">
                    <asp:Label ID= "CUENTA2" runat="server" Text="CUENTA" CssClass="control-label "></asp:Label> 
            </div>
            <div class="col-sm-10">
                 <asp:Label ID= "Nombre" runat="server" Text="NOMBRE" CssClass="control-label "></asp:Label> 
           </div>
                <br />
           <br />
                <br />
           <div class="form-group">
               <br />
               <asp:Button ID="SESIONX" runat="server" Text ="Cerrar Sesion"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="SESIONX_Click"></asp:Button>
           </div>

                <br />
               <br />
            </center>
            <center><img src="solicitud.png" style="height: 61px; width: 349px"><br /></center>
            <div class="col-sm-10">
                    <asp:Label ID= "NoCuenta" runat="server" Text="CUENTA" CssClass="control-label"></asp:Label> 
            </div>
            <div class="col-sm-10">
            <asp:Label ID= "Monto" runat="server" Text="Q." CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCuenta" runat="server" Cssclass="form-control">MONTO</asp:TextBox>
                </div>
            </div>
            <div class="col-sm-10">
            <asp:Label ID= "Descripcion" runat="server" Text="INFO" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDescripcion" runat="server" Cssclass="form-control">Descripcion</asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="form-group">
                <br />
                        <asp:Button ID="SOLICITAR" runat="server" Text ="ENVIAR SOLICITUD"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="SOLICITAR_Click"></asp:Button>
             </div>

            <center><img src="gif2.gif" style="height: 111px; width: 140px"></center>
                    <div class="form-group">
                        <asp:Button ID="VERPERFIL" runat="server" Text ="VE TU PERFIL AQUI"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="VERPERFIL_Click"></asp:Button>
                    </div>
        </form>

       </div>
        
    
    
</body>
</html>