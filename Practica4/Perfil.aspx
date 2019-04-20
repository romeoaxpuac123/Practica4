<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Practica4.Perfil" %>

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
           <br />
                <br />
           <div class="form-group">
               <br />
               <asp:Button ID="SESIONX" runat="server" Text ="Cerrar Sesion"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
           </div>

                <center><img src="tustransacciones.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

                </div>
                <center><img src="tuscreditos.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                        <asp:GridView ID="GridView2" runat="server"></asp:GridView>

                </div>
                <center><img src="tusdebitos.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                        <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                </div>
        </center>

            <div class="form-group">
                        <asp:Button ID="elinicio" runat="server" Text ="INICIO"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
                    </div>
            <center><img src="gif2.gif" style="height: 111px; width: 140px"></center>
                    <div class="form-group">
                        <asp:Button ID="SOLIC" runat="server" Text ="SOLICITA UN CREDITO AQUI"  Cssclass="form-control btn btn-primary"  Width="247px"></asp:Button>
                    </div>
              
        </form>

       
        
    
    
</body>
</html>
