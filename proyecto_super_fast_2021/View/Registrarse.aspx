<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Registrarse.aspx.cs" Inherits="View_Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            text-align: center;
        }
        .auto-style11 {
            height: 20%;
            text-align: center;
        }
        .auto-style13 {
            font-size: large;
        }
        .auto-style14 {
            font-weight: bold;
            font-size: medium;
        }
        .auto-style15 {
            text-align: center;
             height: 20%;
            height: 30px;
        }
        </style>
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style10"><strong>
            <asp:Label ID="LB_Nombre" runat="server" Text="Nombre" CssClass="auto-style13"></asp:Label>
            <br />
            <asp:TextBox ID="TB_Nombre" runat="server" Width="200px" BorderColor="Black" Height="20px" ValidationGroup="VG_Registrar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Nombre" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Nombre" ValidationGroup="VG_Registrar"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="REV_Nombre" runat="server" ControlToValidate="TB_Nombre" ErrorMessage="por favor revise el nombre" ValidationExpression="^[a-z A-Z ñÑ]*$" ValidationGroup="VG_Registrar" ForeColor="White"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="LB_Apellido" runat="server" Text="Apellido" CssClass="auto-style13"></asp:Label>
            <br />
            <asp:TextBox ID="TB_Apellido" runat="server" Width="200px" BorderColor="Black" Height="20px" ValidationGroup="VG_Registrar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Apellido" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Apellido" ValidationGroup="VG_Registrar"></asp:RequiredFieldValidator>
&nbsp;
            <br />
            <asp:RegularExpressionValidator ID="REV_Apellido" runat="server" ControlToValidate="TB_Apellido" ErrorMessage="por favor revise el apellido" ValidationExpression="^[a-z A-Z ñÑ]*$" ValidationGroup="VG_Registrar" ForeColor="White"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="LB_Correo" runat="server" Text="Correo" CssClass="auto-style13"></asp:Label>
            <br />
            <asp:TextBox ID="TB_Correo" runat="server" Width="200px" TextMode="Email" BorderColor="Black" Height="20px" ValidationGroup="VG_Registrar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Correo" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Correo" ValidationGroup="VG_Registrar"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LB_Telefono" runat="server" Text="Telefono" CssClass="auto-style13"></asp:Label>
&nbsp;
            <br />
            <asp:TextBox ID="TB_Telefono" runat="server" Width="200px" TextMode="Phone" BorderColor="Black" Height="20px" ValidationGroup="VG_Registrar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Telefono" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Telefono" ValidationGroup="VG_Registrar"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="REV_Telefono" runat="server" ControlToValidate="TB_Telefono" ErrorMessage="el telefono no contiene  10 digitos" ValidationExpression="[0-9]{6,10}" ValidationGroup="VG_Registrar" ForeColor="White"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="LB_Contrasenia" runat="server" Text="Contraseña" CssClass="auto-style13"></asp:Label>
            <br />
            <asp:TextBox ID="TB_Contrasenia" runat="server" TextMode="Password" Width="200px" BorderColor="Black" Height="20px" ValidationGroup="VG_Registrar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Contrasenia" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Contrasenia" ValidationGroup="VG_Registrar"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="REV_Contrasenia" runat="server" ControlToValidate="TB_Contrasenia" ErrorMessage="por favor revise la contraseña" ValidationExpression="^[a-zA-Z0-9\s]{5,20}$" ValidationGroup="VG_Registrar" ForeColor="White"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="LB_Direccion" runat="server" Text="Direccion" CssClass="auto-style13"></asp:Label>
            <br />
            <asp:TextBox ID="TB_Direccion" runat="server" Width="200px" BorderColor="Black" Height="20px" ValidationGroup="VG_Registrar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV_Direccion" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Direccion" ValidationGroup="VG_Registrar"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="REV_Direccion" runat="server" ControlToValidate="TB_Direccion" ErrorMessage="por favor revise la direccion" ValidationExpression="^[#.0-9a-zA-Z\s,-]+$" ValidationGroup="VG_Registrar" ForeColor="White"></asp:RegularExpressionValidator>
            <br />
            <asp:CheckBox ID="CB_Terminos" runat="server" CssClass="auto-style13" Text="Acepto terminos y condiciones"  ValidateRequestMode="Enabled" ValidationGroup="VG_Registrar"  />
                        
            <br />
            <asp:Label ID="LB_Mensaje" runat="server" ForeColor="White"></asp:Label>
            <br />
            <asp:Button ID="BT_Registrar" runat="server" CssClass="auto-style14" Text="Registrarme" OnClick="BT_Registrar_Click" ValidationGroup="VG_Registrar" Height="35px" Width="120px" BorderColor="Black"  />
           
            <br />
            <asp:Label ID="LB_Ingresar" runat="server" CssClass="auto-style13" Text="¿ya tienes  una cuenta?"></asp:Label>
            <asp:HyperLink ID="HL_Ingresar" runat="server" CssClass="auto-style13">Ingresar</asp:HyperLink>
            </strong></td>
    </tr>
</table>
   
</asp:Content>

