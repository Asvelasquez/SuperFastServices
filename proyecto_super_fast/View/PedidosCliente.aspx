<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/PedidosCliente.aspx.cs" Inherits="View_PedidosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style33 {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style33">
    <tr>
        <td>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Pedidos En Proceso"></asp:Label>
            <br />
                <asp:ImageButton ID="IB_recargar0" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar0_Click"  />
                <br />
            <asp:Label ID="LB_Pedidos" runat="server" Text="No tiene pedidos en proceso"></asp:Label>
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
                        <asp:BoundField DataField="valor_total" HeaderText="Valor Total" SortExpression="valor_total" />
                        <asp:TemplateField HeaderText="Cancelar Pedido">
                            <ItemTemplate>
                                <asp:Button ID="BTN_cancelar" runat="server" Text="Cancelar" CommandName="Cancelar" CommandArgument='<%# Eval("Id_pedido") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_carrito9" runat="server" SelectMethod="obtenercomprasUsuario" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuariopedido" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
            <asp:Label ID="Label11" runat="server" Text="Historial de pedidos"></asp:Label>
            <br />
                <asp:ImageButton ID="IB_recargar1" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar1_Click"  />
            <br />
            <asp:Label ID="LB_historial" runat="server" Text="No tiene historial de pedidos" Visible="False"></asp:Label>
            <br />
                <asp:GridView ID="GV_pedidocarrito0" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_historial" OnRowDataBound="GV_pedidocarrito0_RowDataBound" OnRowCommand="GV_pedidocarrito0_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="Id_pedido" HeaderText="Pedido N°" SortExpression="Id_pedido" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:TemplateField HeaderText="Comentario_cliente" SortExpression="Comentario_cliente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comentario_cliente") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LB_comentariocliente" runat="server" Text='<%# Bind("Comentario_cliente") %>'></asp:Label>
                                <br />
                                <asp:TextBox ID="TBX_comentarioaliado" runat="server" Height="32px" Width="137px"></asp:TextBox>
                                <asp:ImageButton ID="IB_guardarcomentario1" runat="server" CommandArgument='<%# Eval("Id_pedido") %>' CommandName="Guardar" ImageUrl="~/Imagenes/Iconos/guardar.png" />
                                &nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Comentario_aliado" HeaderText="Comentario_aliado" SortExpression="Comentario_aliado" />
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado del pedido" SortExpression="Nombre_estado_ped" />
                        <asp:BoundField DataField="nombre_estado_domicilio" HeaderText="Estado del domicilio" SortExpression="nombre_estado_domicilio" />
                        <asp:BoundField DataField="Nombre_aliado" HeaderText="Aliado" SortExpression="Nombre_aliado" />
                        <asp:TemplateField HeaderText="Detalles del Pedido">
                            <ItemTemplate>
                                <asp:GridView ID="GV_detallespedido0" runat="server" AutoGenerateColumns="False">
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
                        <asp:BoundField DataField="valor_total" HeaderText="Valor Total" SortExpression="valor_total" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_historial" runat="server" SelectMethod="obtenercomprasUsuarioentregado" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuariopedido" SessionField="user" Type="Object" />
                    </SelectParameters>
            </asp:ObjectDataSource>
                <br />
            <asp:Button ID="BTN_Generarfactura" runat="server" BorderColor="Black" Height="30px" OnClick="BTN_Generarfactura_Click" Text="Generar Facturas" />
            <br />
                <br />
        </td>
    </tr>
</table>
</asp:Content>

