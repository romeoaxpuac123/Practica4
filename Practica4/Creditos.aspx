<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Creditos.aspx.cs" Inherits="Practica4.Creditos" %>

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
    
    <center><img src="ad.png"></center>

       <div class="container well contenedor" >
        <div class="row">
            <div class="col-xs-12">
                <h2></h2>
            </div>

        </div>
         <center><img src="credito.png" style="height: 61px; width: 350px"><br />
        <form runat="server" class="form-horizontal center-block">
            <div class="form-group">
                <div class="col-sm-10">
                    <div class="col-sm-10">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </div>
                     <br />
                    <br />
                    <div class="col-sm-10">
                    <asp:Label ID= "Credito2" runat="server" Text="CREDITO" CssClass="control-label col-sm-2"></asp:Label>
                    </div>
                     <div class="col-sm-10">
                        <asp:TextBox ID="txtCodigoC" runat="server" Cssclass="form-control">Codigo Credito</asp:TextBox>
                    </div>
                    <div class="col-sm-10">
                    <asp:RadioButton ID="Aceptar" runat="server" OnCheckedChanged="Aceptar_CheckedChanged" Text="ACEPTAR"></asp:RadioButton>
                    <asp:RadioButton ID="Rechazar" runat="server" Text="RECHAZAR"></asp:RadioButton>
                    </div>
                </div>
                
                
            </div>
            <div class="form-group">
                <asp:Button ID="Gestionar" runat="server" Text ="Gestionar Credito"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
            </div>
            <br />
            <div class="form-group">
                <asp:Button ID="Regresar" runat="server" Text ="Depositos y Debitos"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
            </div>
            <br />
            <div class="form-group">
                <asp:Button ID="Session2" runat="server" Text ="Cerrar Sesión"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
            </div>
            <br />
            <br />
     </form>

       </div>


   
    
    
</body>
</html>

