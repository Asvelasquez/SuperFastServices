<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Reportes.aspx.cs" Inherits="View_Reportes" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
        <td>&nbsp;</td>
        <td>
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
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Comentario_cliente") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LB_comentariocliente" runat="server" Text='<%# Bind("Comentario_cliente") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
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
                        <asp:TemplateField HeaderText="Factura">
                            <ItemTemplate>
                                <asp:Button ID="BTN_generarfactura" runat="server" Text="Generar" CommandName="Generar" CommandArgument='<%# Eval("Id_pedido") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_historial" runat="server" SelectMethod="obtenercomprasUsuarioentregado" TypeName="DAOPedido">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuariopedido" SessionField="user" Type="Object" />
                    </SelectParameters>
            </asp:ObjectDataSource>
                <br />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <CR:CrystalReportViewer ID="CRV_Factura" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_Facturas" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" HasRefreshButton="True" Visible="False" />
            <CR:CrystalReportSource ID="CRS_Facturas" runat="server">
                <Report FileName="~\Reportes\Factura.rpt">
                </Report>
            </CR:CrystalReportSource>
            <CR:CrystalReportSource ID="CRS_Factura" runat="server">
                <Report FileName="~\Reportes\Factura.rpt">
                </Report>
            </CR:CrystalReportSource>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

