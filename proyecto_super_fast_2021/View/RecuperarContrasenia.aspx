<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/RecuperarContrasenia.aspx.cs" Inherits="View_RecuperarContrasenia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="L_Contrasenia" runat="server" Text="Digite su nueva contaseña: "></asp:Label>
                        <asp:TextBox ID="TB_Contrasenia" runat="server" TextMode="Password"></asp:TextBox>
                        <strong>
            <asp:RequiredFieldValidator ID="RFV_NuevaContrasenia" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_Contrasenia" ValidationGroup="VG_Contrasenia"></asp:RequiredFieldValidator>
                                                                                                                                                                                                                       <%-- grupo de validacion
                                                                                                                                                                                                                           (?=.{6,15}) - minimo 6 caracreres max 15
                                                                                                                                                                                                                            (?=.*[\d]) - minimo un dígito
                                                                                                                                                                                                                            (?=.*[\W]) - minimo un carácter especial--%>
                            <asp:RegularExpressionValidator ID="REV_Contrasenia" runat="server" ControlToValidate="TB_Contrasenia" ErrorMessage="minimo 5 digitos" ValidationExpression="^[a-zA-Z0-9\s]{5,20}$" ValidationGroup="VG_Contrasenia"></asp:RegularExpressionValidator>
            </strong>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="L_ConfirmarContrasenia" runat="server" Text="Repita su nueva contraseña: "></asp:Label>
                        <asp:TextBox ID="TB_ConfirmarContrasenia" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CV_Contrasenia" runat="server" ControlToCompare="TB_Contrasenia" ControlToValidate="TB_ConfirmarContrasenia" ForeColor="White"></asp:CompareValidator>
                        <strong>
            <asp:RequiredFieldValidator ID="RFV_ConfirmarNuevaContrasenia" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_ConfirmarContrasenia" ValidationGroup="VG_Contrasenia"></asp:RequiredFieldValidator>
            </strong>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Cambiar" runat="server" OnClick="B_Cambiar_Click" Text="Cambiar" ValidationGroup="VG_Contrasenia" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
