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
                    <asp:Label ID= "USUARIO" runat="server" Text="USUARIO" CssClass="control-label"></asp:Label> 
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

                <center><img src="tustransacciones.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#999999" DataKeyNames="codigo_transferencia" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="codigo_transferencia" HeaderText="Trasferencia" InsertVisible="False" ReadOnly="True" SortExpression="codigo_transferencia" />
                            <asp:BoundField DataField="cuenta_a_transferir" HeaderText="Cuenta" SortExpression="cuenta_a_transferir" />
                            <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                            <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT [codigo_transferencia], [cuenta_a_transferir], [monto], [fecha] FROM [transferencia] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="10221022" Name="numero_de_cuenta" SessionField="Cuenta_Usuario" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                </div>
                <center><img src="tuscreditos.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#999999" DataKeyNames="codigo_credito" DataSourceID="SqlDataSource2">
                            <Columns>
                                <asp:BoundField DataField="codigo_credito" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="codigo_credito" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                                <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
                            </Columns>
                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT [codigo_credito], [descripcion], [monto], [estado] FROM [credito] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                            <SelectParameters>
                                <asp:SessionParameter Name="numero_de_cuenta" SessionField="Cuenta_Usuario" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                </div>
                <center><img src="tusdebitos.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#999999" DataSourceID="SqlDataSource3">
                            <Columns>
                                <asp:BoundField DataField="codigo_debito" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="codigo_debito" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT [codigo_debito], [descripcion], [monto] FROM [debito] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                            <SelectParameters>
                                <asp:SessionParameter Name="numero_de_cuenta" SessionField="Cuenta_Usuario" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                </div>
                <center><img src="losdepositos.png" style="height: 61px; width: 250px"><br /></center>
                <div class="col-sm-10">
                        <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#999999" DataKeyNames="codigo_deposito" DataSourceID="SqlDataSource4">
                            <Columns>
                                <asp:BoundField DataField="codigo_deposito" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="codigo_deposito" />
                                <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT [codigo_deposito], [monto], [fecha] FROM [deposito] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                            <SelectParameters>
                                <asp:SessionParameter Name="numero_de_cuenta" SessionField="Cuenta_Usuario" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#999999" DataKeyNames="codigo_transferencia" DataSourceID="SqlDataSource5">
                            <Columns>
                                <asp:BoundField DataField="codigo_transferencia" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="codigo_transferencia" />
                                <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT [codigo_transferencia], [monto], [fecha] FROM [transferencia] WHERE ([cuenta_a_transferir] = @cuenta_a_transferir)">
                            <SelectParameters>
                                <asp:SessionParameter Name="cuenta_a_transferir" SessionField="Cuenta_Usuario" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                </div>
        </center>

            <div class="form-group">
                        <asp:Button ID="elinicio" runat="server" Text ="INICIO"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="elinicio_Click"></asp:Button>
                    </div>
            <center><img src="gif2.gif" style="height: 111px; width: 140px"></center>
                    <div class="form-group">
                        <asp:Button ID="SOLIC" runat="server" Text ="SOLICITA UN CREDITO AQUI"  Cssclass="form-control btn btn-primary"  Width="247px" OnClick="SOLIC_Click"></asp:Button>
                    </div>
              
        </form>

       
        
    
    
</body>
</html>
