<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/AccesoDenegado.aspx.cs" Inherits="View_AccesoDenegado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }
        .auto-style34 {
            text-align: center;
            font-size: large;
        }
        .auto-style35 {
            text-align: center;
        }
        .auto-style36 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style33">
        <tr>
            <td class="auto-style34">
                <h2>ACCESO DENEGADO</h2>
            </td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:Image ID="IMG_AccesoDenegado" runat="server" Height="350px" ImageUrl="~/Imagenes/acceso-denegado.png" Width="350px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:Button ID="Button1" runat="server" CssClass="auto-style36" OnClick="Button1_Click" Text="Regresar" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

