<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/pedidosaliado.aspx.cs" Inherits="View_pedidosaliado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }
        .auto-style34 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style33">
        <tr>
            <td class="auto-style34">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BTN_estadisitca" runat="server" BorderColor="Black" Height="30px" PostBackUrl="~/View/ReporteVentas.aspx" Text="Estadisticas de ventas" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:Button ID="BT_Productos" runat="server" BackColor="White" Height="30px" PostBackUrl="~/View/Aliado.aspx" Text="Productos" Width="95px" BorderColor="Black" />

                </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Label ID="LB_Pedidos" runat="server" Font-Size="Large" ForeColor="White" Text="Pedido(s)"></asp:Label>
                <br />
                <asp:ImageButton ID="IB_recargar" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar_Click" />
                <br />
                <asp:Label ID="LB_notienespedidos" runat="server" Font-Size="Large" ForeColor="White" Text="NO tiene solicitud de pedidos"></asp:Label>
                <br />
                <asp:GridView ID="GV_pedidos" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Pedido"  OnRowDataBound="GV_pedidos_RowDataBound" OnRowCommand="GV_pedidos_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido N°" SortExpression="Id_pedido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TBX_L_Pedido" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Pedido" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Valor_total" HeaderText="Valor_total" SortExpression="Valor_total" />
                        <asp:BoundField DataField="Comentario_cliente" HeaderText="Comentario_cliente" SortExpression="Comentario_cliente" />
                        <asp:TemplateField HeaderText="Comentario_aliado" SortExpression="Comentario_aliado">
                            <EditItemTemplate>
                                <asp:TextBox ID="TBX_LB_comentarioadliado" runat="server" Text='<%# Bind("Comentario_aliado") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LB_comentarioadliado" runat="server" Text='<%# Bind("Comentario_aliado") %>'></asp:Label>
                                &nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalles del pedido" SortExpression="Compras">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Compras") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:GridView ID="GV_Compras" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                    
                                    <asp:BoundField DataField="Nombreprodet" HeaderText="Producto" SortExpression="Nombreprodet" />
                                    <asp:BoundField DataField="Especprodaliado" HeaderText="Descripcion" SortExpression="Especprodaliado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /> 
                                    <asp:BoundField DataField="Descripcion" HeaderText="Especificacion" SortExpression="Descripcion" />
                                     

                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado pedido" SortExpression="Nombre_estado_ped" />
                        <asp:TemplateField HeaderText="Cambiar estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="DDL_Categoria" runat="server" DataSourceID="ODS_categorias" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Categoria_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ODS_categorias" runat="server" SelectMethod="estado_Pedidos" TypeName="DAOProductos"></asp:ObjectDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_Pedido" runat="server" SelectMethod="obtenerEstadoPedido" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuario2" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:Label ID="Label10" runat="server" Font-Size="Large" ForeColor="White" Text="Pedido(s) Terminados"></asp:Label>
                <br />
                <asp:ImageButton ID="IB_recargar0" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar1_Click" />
                <br />
                <asp:Label ID="LB_Notienepedidosterminados" runat="server" Font-Size="Large" ForeColor="White" Text="No tiene pedidos terminado"></asp:Label>
                <br />

                <asp:GridView ID="GV_pedidosterminado" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Pedidoterminado"  OnRowDataBound="GV_pedidosterminado_RowDataBound" OnRowCommand="GV_pedidosterminado_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido N°" SortExpression="Id_pedido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TBX_L_Pedido1" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Pedido1" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Valor_total" HeaderText="Valor_total" SortExpression="Valor_total" />
                        <asp:BoundField DataField="Comentario_cliente" HeaderText="Comentario_cliente" SortExpression="Comentario_cliente" />
                        <asp:TemplateField HeaderText="Comentario_aliado" SortExpression="Comentario_aliado">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comentario_aliado") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LB_comentarioadliado" runat="server" Text='<%# Bind("Comentario_aliado") %>'></asp:Label>
                                <br />
                                <asp:TextBox ID="TBX_comentarioaliado" runat="server" Height="32px" Width="137px"></asp:TextBox>
                                <asp:ImageButton ID="IB_guardarcomentario1" runat="server" CommandArgument='<%# Eval("Id_pedido") %>' CommandName="Guardar" ImageUrl="~/Imagenes/Iconos/guardar.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalles del pedido" SortExpression="Compras">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Compras") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:GridView ID="GV_Compras1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                    
                                    <asp:BoundField DataField="Nombreprodet" HeaderText="Producto" SortExpression="Nombreprodet" />
                                    <asp:BoundField DataField="Especprodaliado" HeaderText="Descripcion" SortExpression="Especprodaliado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /> 
                                    <asp:BoundField DataField="Descripcion" HeaderText="Especificacion" SortExpression="Descripcion" />
                                     

                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado pedido" SortExpression="Nombre_estado_ped" />
                        <asp:TemplateField HeaderText="Cambiar estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="DDL_Categoria1" runat="server" DataSourceID="ODS_categorias0" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Categoria1_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ODS_categorias0" runat="server" SelectMethod="estado_Pedidos" TypeName="DAOProductos"></asp:ObjectDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_Pedidoterminado" runat="server" SelectMethod="obtenerEstadoPedidoterminado" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuario3" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

