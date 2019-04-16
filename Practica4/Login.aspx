<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica4.Login" %>

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
    <br />
       <br /><br /><br />
    <center><img src="texto2.png"></center>
<body>
    <center>
    <div class="container well contenedor" >
        <div class="row">
            <div class="col-xs-12">
                <h2>INICIAR SESION</h2>
            </div>

        </div>
        
        <form runat="server" class="form-horizontal center-block">
            <div class="form-group">
                <asp:Label ID= "Codigo" runat="server" Text="Codigo Usuario" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCodigo" runat="server" Cssclass="form-control">Ingrese Su Codigo</asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID= "Usuario" runat="server" Text="Usuario" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUsuario" runat="server" Cssclass="form-control">Ingrese Su Usuario</asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID= "PassU" runat="server" Text="Password" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPassword" runat="server" Cssclass="form-control" type="Password">password</asp:TextBox>
                </div>
            </div>
            

            <div class="form-group">
                <asp:Button ID="btnInicio" runat="server" Text ="Inicio"  Cssclass="form-control btn btn-primary" OnClick="btnInicio_Click" Width="247px"></asp:Button>
            </div>
            
            <div class="form-group">
                <asp:Button ID="Registro" runat="server" Text ="Registro"  Cssclass="form-control btn btn-primary" OnClick="Registro_Click" Width="247px"></asp:Button>
            </div>
            
            
        
     </form>

    </div>
</center>    
    
</body>
</html>
