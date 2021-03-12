<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Carrito.aspx.cs" Inherits="View_Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }
        .auto-style34 {
            text-align: left;
        }
        .auto-style35 {
            text-align: right;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style33">
        <tr>
            <td class="auto-style34">
                <table class="auto-style33">
                    <tr>
                        <td>
                            <asp:Label ID="LB_Pedidos" runat="server" Font-Size="Large" Text="Pedidos agregados en el carrito"></asp:Label>
                        </td>
                        <td class="auto-style35">
                            <asp:Button ID="BTN_MisPedidos" runat="server" BorderColor="Black" Text="Mis Pedidos" Width="108px" OnClick="BTN_MisPedidos_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ImageButton ID="IB_recargar0" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar0_Click"  />
                <br />
                <asp:Label ID="LB_pedidoscarrito" runat="server" Text="No tienes pedidos agregados en el carrito" Font-Size="Large"></asp:Label>
                <asp:GridView ID="GV_pedidocarrito" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_carrito9" OnRowDataBound="GV_pedidocarrito_RowDataBound" OnRowCommand="GV_pedidocarrito_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id_pedido" HeaderText="Pedido N°" SortExpression="Id_pedido" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Comentario_cliente" HeaderText="Comentario Cliente" SortExpression="Comentario_cliente" />
                        <asp:BoundField DataField="Comentario_aliado" HeaderText="Comentario Aliado" SortExpression="Comentario_aliado" />
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado del pedido" SortExpression="Nombre_estado_ped" />
                        <asp:BoundField DataField="nombre_estado_domicilio" HeaderText="Estado del domicilio" SortExpression="nombre_estado_domicilio" />
                        <asp:BoundField DataField="Nombre_aliado" HeaderText="Aliado" SortExpression="Nombre_aliado" />
                        <asp:TemplateField HeaderText="Detalles del Pedido">
                            <ItemTemplate>
                                <asp:GridView ID="GV_detallespedido" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Nombreprodet" HeaderText="Producto" SortExpression="Nombreprodet" />
                                    <asp:BoundField DataField="Especprodaliado" HeaderText="Descripcion" SortExpression="Especprodaliado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /> 
                                    <asp:BoundField DataField="Descripcion" HeaderText="Especificacion" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="V_unitario" HeaderText="Valor unitario" SortExpression="V_unitario" />
                                    <asp:BoundField DataField="V_total" HeaderText="Sub Total" SortExpression="V_total" />
                                  </Columns>   
                                </asp:GridView>
                            </ItemTemplate>
                        

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cancelar Pedido">
                            <ItemTemplate>
                                <asp:Button ID="BTN_cancelar" runat="server" Text="Cancelar" CommandName="Cancelar" CommandArgument='<%# Eval("Id_pedido") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_carrito9" runat="server" SelectMethod="obtenerPedidoUsuario" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuariopedido" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp; <strong>
                            <br />
            </strong>
                <table class="auto-style33">
                    <tr>
                        <td>
                            <asp:Label ID="LB_telefono" runat="server" Text="Telefono"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LB_direccion" runat="server" Text="Direccion"></asp:Label>
                        </td>
                        <td><strong>
                            <asp:Label ID="LB_subtotal" runat="server" Text="Sub total"></asp:Label>
            </strong></td>
                        <td><strong>
                            <asp:Label ID="Label12" runat="server" Text="Domicilios"></asp:Label>
            </strong></td>
                        <td><strong>
                            <asp:Label ID="LB_total" runat="server" Text="Total"></asp:Label>
            </strong></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TBX_telefono" runat="server" Height="25px" TextMode="Number" Width="150px" Enabled="False"></asp:TextBox>
                            <strong>
                            <br />
                            <asp:TextBox ID="TBX_telefono1" runat="server" Visible="False" Height="25px" Width="150px"></asp:TextBox>
                            <br />
            <asp:RegularExpressionValidator ID="REV_Telefono" runat="server" ControlToValidate="TBX_telefono" ErrorMessage="el telefono no contiene entre 7 y  10 digitos" ValidationExpression="[0-9]{6,10}" ValidationGroup="VG_Comprar" ForeColor="White"></asp:RegularExpressionValidator>
            </strong></td>
                        <td><strong>
                            <asp:TextBox ID="TBX_direccion" runat="server" Height="25px" Width="150px" Enabled="False"></asp:TextBox>
                            <asp:ImageButton ID="IB_validar" runat="server" ImageUrl="~/Imagenes/Iconos/editar.png" OnClick="IB_validar_Click" Width="24px" />
                            <br />
                            <asp:TextBox ID="TBX_direccion1" runat="server" Visible="False" Height="25px" Width="150px"></asp:TextBox>
                            <br />
            <asp:RegularExpressionValidator ID="REV_Direccion" runat="server" ControlToValidate="TBX_direccion" ErrorMessage="por favor revise la direccion" ValidationExpression="^[#.0-9a-zA-Z\s,-]+$" ValidationGroup="VG_Comprar" ForeColor="White"></asp:RegularExpressionValidator>
            </strong></td>
                        <td><strong>
                            <asp:TextBox ID="TBX_subtotal1" runat="server" Height="22px" Width="129px" Enabled="False"></asp:TextBox>
            </strong></td>
                        <td>
                            <asp:TextBox ID="TBX_valordomicilio" runat="server" Enabled="False" Width="60px"></asp:TextBox>
                            <asp:Label ID="Label13" runat="server" Height="25px" Text="X"></asp:Label>
                            <asp:TextBox ID="TBX_cantidaddomicilios" runat="server" Enabled="False" Width="25px"></asp:TextBox>
                            <br />
                            <asp:Label ID="LB_subtotaldomi" runat="server" Text="Sub total"></asp:Label>
                            <br />
                            <asp:TextBox ID="TBX_totalpreciodomi" runat="server" Enabled="False" Width="60px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="TBX_total" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td><strong>
                            <asp:Button ID="BTN_comprar" runat="server" Text="Comprar" ValidationGroup="VG_Comprar" OnClick="BTN_comprar_Click" BorderColor="Black" Width="108px" Enabled="False" />
            </strong></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

