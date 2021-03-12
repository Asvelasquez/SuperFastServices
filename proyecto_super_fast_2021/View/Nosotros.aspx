<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Nosotros.aspx.cs" Inherits="View_Nosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }

        .auto-style34 {
            width: 33%;
        }
        .auto-style35 {
            width: 33%;
        }
        .auto-style36 {
            width: 33%;
        }

        .auto-style37 {
            width: 33%;
            text-align: center;
        }
        .auto-style38 {
            text-align: center;
        }
        .auto-style39 {
            font-size: large;
        }

    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table class="auto-style33">
        <tr>
            <td class="auto-style38" colspan="3">
                <h4>
    <asp:Label ID="LB_sobrenosotros" runat="server" Font-Size="X-Large" Text="Sobre nosotros"></asp:Label>
                </h4>
            </td>
        </tr>
        <tr>
            <td class="auto-style36">&nbsp;</td>
            <td class="auto-style34">&nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style37">
            <asp:Image ID="IMG_Nosotros1" runat="server" Height="300px" ImageUrl="~/Imagenes/_CCC7703.jpg" Width="400px" />
            </td>
            <td class="auto-style37">
            <asp:Image ID="IMG_Nosotros2" runat="server" Height="300px" ImageUrl="~/Imagenes/_CCC7625.jpg" Width="400px" />
            </td>
            <td class="auto-style37">
            <asp:Image ID="IMG_Nosotros3" runat="server" Height="300px" ImageUrl="~/Imagenes/_CCC7492.jpg" Width="400px" />
                </td>
        </tr>
        <tr>
            <td class="auto-style38" colspan="3">
                <asp:Image ID="I_Mapa" runat="server" ImageUrl="~/Imagenes/Mapa.JPG" />
            </td>
        </tr>
    </table>
    <span class="auto-style39">&nbsp;</span><asp:Label ID="LB_quienesomos" runat="server" Text="¿Quienes somos?" CssClass="auto-style39"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;
    <asp:Label ID="LB_quienesomos1" runat="server" Text="Una microempresa que presta el servicio de domicilios en el municipio de Facatativa (Cundinamarca), te ofrecemos domicilios de restaurante,"></asp:Label>
    <br />
&nbsp;&nbsp;
    <asp:Label ID="LB_quienessomos2" runat="server" Text=" mercado y farmacia, pagos de servicios, mandados y mucho mas"></asp:Label>
    <br />
&nbsp;<br />
    <br />
</asp:Content>

