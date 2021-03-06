﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Practica4.Administrador" %>

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
         <center><img src="eldeposito.png" style="height: 61px; width: 350px"><br />
        <form runat="server" class="form-horizontal center-block">
            <div class="form-group">
                <asp:Label ID= "Cuenta" runat="server" Text="CUENTA" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:ListBox  ID="LasCuentas" runat="server" Cssclass="form-control"  Height="28px" Rows="1" DataSourceID="SqlDataSource1" DataTextField="numero_de_cuenta" DataValueField="numero_de_cuenta">
                        
                    </asp:ListBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT [numero_de_cuenta] FROM [cuenta_bancaria]"></asp:SqlDataSource>
                </div>

                <asp:Label ID= "Monto" runat="server" Text="TOTAL" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCuenta" runat="server" Cssclass="form-control">MONTO</asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Button ID="btnRealizarDeposito" runat="server" Text ="Depositar"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="btnRealizarDeposito_Click"></asp:Button>
            </div>
            <br />
            <br />
            <br />
        <center><img src="eldebito.png" style="height: 61px; width: 350px"><br />
            <div class="form-group">
                <asp:Label ID= "CUENTA2" runat="server" Text="CUENTA" CssClass="control-label col-sm-2"></asp:Label> 
                <div class="col-sm-10">
                    <asp:ListBox  ID="CUENTASD" runat="server" Cssclass="form-control" Height="28px" Rows="1" DataSourceID="SqlDataSource1" DataTextField="numero_de_cuenta" DataValueField="numero_de_cuenta">
                      
                    </asp:ListBox>
                </div>

                    <asp:Label ID= "DESC" runat="server" Text="INFO" CssClass="control-label col-sm-2"></asp:Label> 
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescripcion" runat="server" Cssclass="form-control">DESCRIPCION</asp:TextBox>
                    </div>
                    <asp:Label ID= "Monto2" runat="server" Text="MONTO" CssClass="control-label col-sm-2"></asp:Label> 
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox2" runat="server" Cssclass="form-control">MONTO</asp:TextBox>
                        <br />
                    </div>
                <br />
                <br />
                    <div class="form-group">
                        <asp:Button ID="Debitar" runat="server" Text ="Debitar"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="Debitar_Click"></asp:Button>
                    </div>


                <br />
                <br />
                    <div class="form-group">
                        <asp:Button ID="LOSCREDITOS" runat="server" Text ="Gestión de Creditos"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="LOSCREDITOS_Click"></asp:Button>
                    </div>


                <br />
                <br />
                    <div class="form-group">
                        <asp:Button ID="SESION" runat="server" Text ="Cerrar Sesion"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="SESION_Click"></asp:Button>
                    </div>
               </div>
     </form>

       </div>


   
    
    
</body>
</html>
