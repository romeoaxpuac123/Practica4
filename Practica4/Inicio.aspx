<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Practica4.Inicio" %>

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
                    <asp:Label ID= "USUARIO" runat="server" Text="USUARIO" CssClass="control-label col-sm-2"></asp:Label> 
            </div>
           <div class="col-sm-10">
                    <asp:Label ID= "CUENTA2" runat="server" Text="CUENTA" CssClass="control-label col-sm-2"></asp:Label> 
            </div>
            <div class="col-sm-10">
                 <asp:Label ID= "Nombre" runat="server" Text="NOMBRE" CssClass="control-label col-sm-2"></asp:Label> 
           </div>
           <br />
           <div class="form-group">
               <asp:Button ID="SESIONX" runat="server" Text ="Cerrar Sesion"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
           </div>

                <br />
               <br />
            <center><img src="saldo.png" style="height: 61px; width: 340px"></center>
                <center><img src="gif2.gif" style="height: 111px; width: 140px"></center>
                <div class="form-group">
               <asp:Button ID="SALDO" runat="server" Text ="Consulta tu Saldo Aquí"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
           </div>
                <br />
               <br />
                <center><img src="bancxD.png" style="height: 111px; width: 328px"></center>
          </center>

            <div class="form-group">
                <asp:Label ID= "Label1" runat="server" Text="CUENTA" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:ListBox  ID="CUENTASD" runat="server" Cssclass="form-control" AutoPostBack="True" Height="28px" Rows="1">
                        <asp:ListItem>SDFA</asp:ListItem>
                        <asp:ListItem>SDAFDS</asp:ListItem>
                        <asp:ListItem>SADFASD</asp:ListItem>
                        <asp:ListItem>ASDF</asp:ListItem>
                        <asp:ListItem>SADF</asp:ListItem>
                    </asp:ListBox>
                </div>

                <asp:Label ID= "Monto" runat="server" Text="TOTAL" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCuenta" runat="server" Cssclass="form-control">MONTO</asp:TextBox>
                </div>
                 <br />
                <br />
                    <div class="form-group">
                        <asp:Button ID="TRANSFERIRX" runat="server" Text ="TRANSFERIR"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
                    </div>

                <br />
               <br />
                <center><img src="SOLI.png" style="height: 111px; width: 328px"></center>
                <center><img src="gif2.gif" style="height: 111px; width: 140px"></center>
                    <div class="form-group">
                        <asp:Button ID="SOLICITAR" runat="server" Text ="SOLICITA UN CREDITO AQUI"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
                    </div>

                <img src="gif2.gif" style="height: 111px; width: 140px"></center>
                    <div class="form-group">
                        <asp:Button ID="VERPERFIL" runat="server" Text ="VE TU PERFIL AQUI"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
                    </div>
            </div>
        </form>

       </div>
        
    
    
</body>
</html>