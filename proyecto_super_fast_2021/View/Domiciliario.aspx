<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Domiciliario.aspx.cs" Inherits="View_Domiciliario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }
        .auto-style34 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style33">
        <tr>
            <td class="auto-style34" colspan="2">
                <br />
                <asp:Label ID="Label10" runat="server" Font-Size="Large" Text="Pedidos Disponibles"></asp:Label>
                <br />
                <asp:ImageButton ID="IB_recargar0" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar0_Click"  />
                <br />
                <asp:Label ID="LB_nohaydomiciliosdisponibles" runat="server" Text="No hay domicilios disponibles"></asp:Label>
                <br />
                <asp:GridView ID="GV_PedDomi" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Domiciliario" OnRowDataBound="GV_PedDomi_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido n°" SortExpression="Id_pedido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Pedido" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Comentario_cliente" HeaderText="Comentario_cliente" SortExpression="Comentario_cliente" />
                        <asp:BoundField DataField="Comentario_aliado" HeaderText="Comentario_aliado" SortExpression="Comentario_aliado" />
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado pedido" SortExpression="Nombre_estado_ped" />
                        <asp:BoundField DataField="Nombre_aliado" HeaderText="Aliado" SortExpression="Nombre_aliado" />
                        <asp:BoundField DataField="Direccion_aliado" HeaderText="Direccion" SortExpression="Direccion_aliado" />
                        <asp:TemplateField HeaderText="Pedido">
                            <ItemTemplate>
                                <asp:GridView ID="GV_detallespedido" runat="server" AutoGenerateColumns="False">
                                     <Columns>
                                    <asp:BoundField DataField="Pedido_id" HeaderText="Pedido N°" SortExpression="Pedido_id" />
                                    <asp:BoundField DataField="Nombreprodet" HeaderText="Producto" SortExpression="Nombreprodet" />
                                    <asp:BoundField DataField="Especprodaliado" HeaderText="Descripcion" SortExpression="Especprodaliado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /> 
                                    <asp:BoundField DataField="Descripcion" HeaderText="Especificacion" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="V_total" HeaderText="Valor total" SortExpression="V_total" />
                                    
                                  </Columns>   
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre_cliente" HeaderText="Cliente" SortExpression="Nombre_cliente" />
                        <asp:BoundField DataField="Direccion_cliente" HeaderText="Direccion" SortExpression="Direccion_cliente" />
                        <asp:BoundField DataField="Telefono_cliente" HeaderText="Telefono" SortExpression="Telefono_cliente" />
                        <asp:BoundField DataField="nombre_estado_domicilio" HeaderText="Estado del domicilio" SortExpression="nombre_estado_domicilio" />
                        <asp:TemplateField HeaderText="Cambiar Estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="DDL_Estado" runat="server" DataSourceID="ODS_EstadoDomicilio" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Estado_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ODS_EstadoDomicilio" runat="server" SelectMethod="estado_Domicilios" TypeName="DAOProductos"></asp:ObjectDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_Domiciliario" runat="server" SelectMethod="obtenerPedidoDomiciliario" TypeName="DAOPedido"></asp:ObjectDataSource>
                <br />
                <asp:Label ID="LB_mispedidos" runat="server" Text="Mis pedidos"></asp:Label>
                <br />
                <asp:ImageButton ID="IB_recargar1" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar1_Click" />
                <br />
                <asp:Label ID="LB_mispedidosno" runat="server" Text="No tiene pedidos en proceso"></asp:Label>
                <br />
                <asp:GridView ID="GV_mispedidos" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_misdomicilios" OnRowDataBound="GV_mispedidos_RowDataBound" >
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido n°" SortExpression="Id_pedido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Pedido0" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Comentario_cliente" HeaderText="Comentario_cliente" SortExpression="Comentario_cliente" />
                        <asp:BoundField DataField="Comentario_aliado" HeaderText="Comentario_aliado" SortExpression="Comentario_aliado" />
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado pedido" SortExpression="Nombre_estado_ped" />
                        <asp:BoundField DataField="Nombre_aliado" HeaderText="Aliado" SortExpression="Nombre_aliado" />
                        <asp:BoundField DataField="Direccion_aliado" HeaderText="Direccion" SortExpression="Direccion_aliado" />
                        <asp:TemplateField HeaderText="Pedido">
                            <ItemTemplate>
                                <asp:GridView ID="GV_detallespedido1" runat="server" AutoGenerateColumns="False">
                                     <Columns>
                                    <asp:BoundField DataField="Pedido_id" HeaderText="Pedido N°" SortExpression="Pedido_id" />
                                    <asp:BoundField DataField="Nombreprodet" HeaderText="Producto" SortExpression="Nombreprodet" />
                                    <asp:BoundField DataField="Especprodaliado" HeaderText="Descripcion" SortExpression="Especprodaliado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /> 
                                    <asp:BoundField DataField="Descripcion" HeaderText="Especificacion" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="V_total" HeaderText="Valor total" SortExpression="V_total" />
                                    
                                  </Columns>   
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre_cliente" HeaderText="Cliente" SortExpression="Nombre_cliente" />
                        <asp:BoundField DataField="Direccion_cliente" HeaderText="Direccion" SortExpression="Direccion_cliente" />
                        <asp:BoundField DataField="Telefono_cliente" HeaderText="Telefono" SortExpression="Telefono_cliente" />
                        <asp:BoundField DataField="nombre_estado_domicilio" HeaderText="Estado del domicilio" SortExpression="nombre_estado_domicilio" />
                        <asp:TemplateField HeaderText="Cambiar Estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="DDL_Estado0" runat="server" DataSourceID="ODS_EstadoDomicilio0" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Estado0_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ODS_EstadoDomicilio0" runat="server" SelectMethod="estado_Domicilios" TypeName="DAOProductos"></asp:ObjectDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_misdomicilios" runat="server" SelectMethod="obtenermiPedidoDomiciliario" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuario4" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:Label ID="LB_historial" runat="server" Text="Mi historial"></asp:Label>
                <br />
                <asp:ImageButton ID="IB_recargar2" runat="server" ImageUrl="~/Imagenes/Iconos/refrescar.png" OnClick="IB_recargar2_Click" />
                <br />
                <asp:Label ID="LB_historialno" runat="server" Text="No tiene historial"></asp:Label>
                <asp:GridView ID="GV_historial" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_historial" OnRowDataBound="GV_historial_RowDataBound" >
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido n°" SortExpression="Id_pedido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Pedido1" runat="server" Text='<%# Bind("Id_pedido") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Comentario_cliente" HeaderText="Comentario_cliente" SortExpression="Comentario_cliente" />
                        <asp:BoundField DataField="Comentario_aliado" HeaderText="Comentario_aliado" SortExpression="Comentario_aliado" />
                        <asp:BoundField DataField="Nombre_estado_ped" HeaderText="Estado pedido" SortExpression="Nombre_estado_ped" />
                        <asp:BoundField DataField="Nombre_aliado" HeaderText="Aliado" SortExpression="Nombre_aliado" />
                        <asp:BoundField DataField="Direccion_aliado" HeaderText="Direccion" SortExpression="Direccion_aliado" />
                        <asp:TemplateField HeaderText="Pedido">
                            <ItemTemplate>
                                <asp:GridView ID="GV_detallespedido2" runat="server" AutoGenerateColumns="False">
                                     <Columns>
                                    <asp:BoundField DataField="Pedido_id" HeaderText="Pedido N°" SortExpression="Pedido_id" />
                                    <asp:BoundField DataField="Nombreprodet" HeaderText="Producto" SortExpression="Nombreprodet" />
                                    <asp:BoundField DataField="Especprodaliado" HeaderText="Descripcion" SortExpression="Especprodaliado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /> 
                                    <asp:BoundField DataField="Descripcion" HeaderText="Especificacion" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="V_total" HeaderText="Valor total" SortExpression="V_total" />
                                    
                                  </Columns>   
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre_cliente" HeaderText="Cliente" SortExpression="Nombre_cliente" />
                        <asp:BoundField DataField="Direccion_cliente" HeaderText="Direccion" SortExpression="Direccion_cliente" />
                        <asp:BoundField DataField="Telefono_cliente" HeaderText="Telefono" SortExpression="Telefono_cliente" />
                        <asp:BoundField DataField="nombre_estado_domicilio" HeaderText="Estado del domicilio" SortExpression="nombre_estado_domicilio" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_historial" runat="server" SelectMethod="obtenermiPedidosentregadosDomiciliario" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuario4" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

