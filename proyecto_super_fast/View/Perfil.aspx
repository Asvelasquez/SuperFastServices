<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Perfil.aspx.cs" Inherits="View_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
                    &nbsp;
                    <table class="auto-style33">
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;
                                <br />
&nbsp;<asp:Label ID="LB_fotoperfil" runat="server" Text="Foto de perfil"></asp:Label>
                                <br />
&nbsp;<asp:Image ID="imagen_perfil" runat="server" Height="80px" Width="98px" />
                                <br />
&nbsp;<asp:Label ID="LB_actualizarfoto" runat="server" Text="Actualizar foto de perfil"></asp:Label>
                                <br />
&nbsp;<asp:FileUpload ID="FUD_imagenperfil" runat="server" />
                                <br />
&nbsp;<asp:TextBox ID="TB_urlfoto" runat="server" Width="323px"></asp:TextBox>
                                <br />
&nbsp;<asp:TextBox ID="TB_urlfotoa" runat="server" Width="324px"></asp:TextBox>
                    <br />
                    &nbsp;<asp:Label ID="LB_nombre" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                    <asp:Label ID="LB_apellido" runat="server" Text="Apellido"></asp:Label>
                    &nbsp;
                    <br />
                    &nbsp;<asp:TextBox ID="TB_nombreperfil" runat="server" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="TB_apellidoperfil" runat="server" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; <br />
        &nbsp;<asp:TextBox ID="TB_nombreperfila" runat="server" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_apellidoperfila" runat="server" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
        <br />
                    &nbsp;<asp:Label ID="LB_correo" runat="server" Text="Correo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LB_contrasenia" runat="server" Text="Contraseña"></asp:Label>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;<asp:TextBox ID="TB_correoperfil" runat="server" TextMode="Email" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_contraseniaperfil" runat="server" Enabled="False" BorderColor="Black" Height="20px" Width="200px" ></asp:TextBox>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;<asp:TextBox ID="TB_correoperfila" runat="server" TextMode="Email" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_contraseniaperfila" runat="server" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    &nbsp;<asp:Label ID="LB_direccion" runat="server" Text="Direccion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="LB_telefono" runat="server" Text="Telefono"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;<asp:TextBox ID="TB_direccionperfil" runat="server" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_telefonoperfil" runat="server" TextMode="Number" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;
                    <br />
                    &nbsp;<asp:TextBox ID="TB_direccionperfila" runat="server" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_telefonoperfila" runat="server" TextMode="Number" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    &nbsp;<asp:Label ID="LB_documento" runat="server" Text="Documento"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    &nbsp;&nbsp;
                    <asp:Label ID="LB_actividadcomercial" runat="server" Text="Actividad Comercial"></asp:Label>
                    <br />
                    &nbsp;<asp:TextBox ID="TB_documentoperfil" runat="server" TextMode="Number" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_actividadcomercialperfil" runat="server" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    &nbsp;<asp:TextBox ID="TB_documentoperfila" runat="server" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    &nbsp;<asp:Label ID="LB_tipodevehiculoperfil" runat="server" Text="Tipo de Vehiculo"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <br />

                       &nbsp;&nbsp;<asp:DropDownList ID="DDLD_tipovehiculo" runat="server" Width="150px" Height="20px" OnSelectedIndexChanged="DDLD_tipovehiculo_SelectedIndexChanged">
        <asp:ListItem>Bicicleta</asp:ListItem>
        <asp:ListItem>Motocicleta</asp:ListItem>
    </asp:DropDownList>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <br />
                &nbsp; <asp:TextBox ID="TB_tipodevehiculoperfil" runat="server" Enabled="False" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
        &nbsp;
                    <asp:TextBox ID="TB_tipodevehiculoperfila" runat="server" BorderColor="Black" Height="20px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BTN_guardar" runat="server"  Text="Guardar" Width="61px" OnClick="BTN_guardar_Click" />
&nbsp;<asp:Button ID="BTN_cancelar" runat="server" OnClick="BTN_cancelar_Click" Text="Cancelar" Width="66px" EnableTheming="True" />
                    &nbsp;<asp:Button ID="BTN_editar" runat="server"  CommandName="Editar"   Text="Editar" OnClick="BTN_editar_Click" />
&nbsp;&nbsp;
                    </td>
                        </tr>
                    </table>

     
    </p>
    
   
  
</asp:Content>

