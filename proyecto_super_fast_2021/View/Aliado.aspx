﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/Aliado.aspx.cs" Inherits="View_Aliado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style33 {
            width: 100%;
        }
        .auto-style36 {
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style33">
        <tr>
            <td class="auto-style36">
                <br />
&nbsp;<asp:Label ID="LB_nombreproducto" runat="server" Text="Nombre del producto"></asp:Label>
                <br />
&nbsp;<asp:TextBox ID="TB_nombreproducto" runat="server" BorderColor="Black" Height="20px" Width="180px" ValidationGroup="VG_cargarproducto"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Nombre" runat="server" ControlToValidate="TB_nombreproducto" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_cargarproducto"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RFV_Nombre0" runat="server" ControlToValidate="TB_nombreproducto" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_editarproducto"></asp:RequiredFieldValidator>
                <br />
    <strong>
            <asp:RegularExpressionValidator ID="REV_Nombre" runat="server" ControlToValidate="TB_nombreproducto" ErrorMessage="por favor revise el nombre" ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="VG_cargarproducto" ForeColor="White"></asp:RegularExpressionValidator>
                <br />
            <asp:RegularExpressionValidator ID="REV_Nombre0" runat="server" ControlToValidate="TB_nombreproducto" ErrorMessage="por favor revise el nombre" ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="VG_editarproducto" ForeColor="White"></asp:RegularExpressionValidator>
            </strong>
                <br />
&nbsp;<asp:Label ID="LB_descripcionproducto" runat="server" Text="Descripcion del producto"></asp:Label>
                <br />
&nbsp;<asp:TextBox ID="TB_descripcionproducto" runat="server" BorderColor="Black" Height="20px" Width="180px" ValidationGroup="VG_cargarproducto"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Descripcion" runat="server" ControlToValidate="TB_descripcionproducto" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_cargarproducto"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RFV_Descripcion0" runat="server" ControlToValidate="TB_descripcionproducto" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_editarproducto"></asp:RequiredFieldValidator>
                <br />
    <strong>
            <asp:RegularExpressionValidator ID="REV_Descripcion" runat="server" ControlToValidate="TB_descripcionproducto" ErrorMessage="por favor revise la descripcion" ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="VG_cargarproducto" ForeColor="White"></asp:RegularExpressionValidator>
                <br />
            <asp:RegularExpressionValidator ID="REV_Descripcion0" runat="server" ControlToValidate="TB_descripcionproducto" ErrorMessage="por favor revise la descripcion" ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="VG_editarproducto" ForeColor="White"></asp:RegularExpressionValidator>
            </strong>
                <br />
&nbsp;<asp:Label ID="LB_precioproducto" runat="server" Text="Precio del producto"></asp:Label>
                <br />
&nbsp;<asp:TextBox ID="TB_precioproducto" runat="server" TextMode="Number" BorderColor="Black" Height="20px" Width="180px" ValidationGroup="VG_cargarproducto"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Precio" runat="server" ControlToValidate="TB_precioproducto" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_cargarproducto"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RFV_Precio0" runat="server" ControlToValidate="TB_precioproducto" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_editarproducto"></asp:RequiredFieldValidator>
                <br />
    <strong>
            <asp:RegularExpressionValidator ID="REV_Precio" runat="server" ControlToValidate="TB_precioproducto" ErrorMessage="por favor revise el precio" ValidationExpression="^\d*[1-9]\d*$" ValidationGroup="VG_cargarproducto" ForeColor="White"></asp:RegularExpressionValidator>
                <br />
            <asp:RegularExpressionValidator ID="REV_Precio0" runat="server" ControlToValidate="TB_precioproducto" ErrorMessage="por favor revise el precio" ValidationExpression="^\d*[1-9]\d*$" ValidationGroup="VG_editarproducto" ForeColor="White"></asp:RegularExpressionValidator>
            </strong>
                <br />
&nbsp;<asp:Label ID="LB_imagenproducto1" runat="server" Text="Cargar imagen del producto #1"></asp:Label>
                <br />
&nbsp;<asp:FileUpload ID="FP_imagen1" runat="server" Width="276px" />
                <br />
                <br />
&nbsp;<asp:TextBox ID="TB_Url" runat="server" Height="20px" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_CargarProducto" runat="server" ControlToValidate="FP_imagen1" ErrorMessage="*" ForeColor="Red" ValidationGroup="VG_cargarproducto"></asp:RequiredFieldValidator>
                <br />
&nbsp;<br />
&nbsp;<asp:TextBox ID="TBX_Id" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TBX_estado" runat="server" Visible="False"></asp:TextBox>
                <br />
&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BTN_guardarproducto" runat="server" OnClick="BTN_guardarproducto_Click" Text="Guardar" ValidationGroup="VG_cargarproducto" BorderColor="Black" Height="30px" Width="110px" />
                <asp:Button ID="BTN_GuardarCambios" runat="server" OnClick="BTN_GuardarCambios_Click" Text="Guardar Cambios" Visible="False" ValidationGroup="VG_editarproducto"  />
                <br />
            </td>
            <td>
                <br />
                <asp:Label ID="LB_productosactivos" runat="server" Font-Size="X-Large" ForeColor="White" Text="Productos activos"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GV_Productos" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_producto1" OnRowCommand="GV_Productos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Nombre_producto" HeaderText="Nombre_producto" SortExpression="Nombre_producto" />
                        <asp:BoundField DataField="Descripcion_producto" HeaderText="Descripcion_producto" SortExpression="Descripcion_producto" />
                        <asp:BoundField DataField="Precio_producto" HeaderText="Precio_producto" SortExpression="Precio_producto" />
                        <asp:BoundField DataField="Imagen_producto1" HeaderText="Imagen_producto1" SortExpression="Imagen_producto1" Visible="False" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <asp:Image ID="IMG_Producto" runat="server" Height="60px" Width="60px" ImageUrl='<%# Eval("imagen_producto1") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="editar">
                            <ItemTemplate>
                                <asp:Button ID="BTN_Editar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="inactivo">
                            <ItemTemplate>
                                <asp:Button ID="BTN_Desactivar" runat="server" Text="Desactivar" CommandName="Desactivar" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_producto1" runat="server" SelectMethod="mostrarproducto" TypeName="DAOProductos">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="consulta" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:Label ID="LB_productosdesactivados" runat="server" Font-Size="X-Large" ForeColor="White" Text="Productos deactivados"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GV_Productosdesactivado" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_productodesactivado" OnRowCommand="GV_Productosdesactivado_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Nombre_producto" HeaderText="Nombre_producto" SortExpression="Nombre_producto" />
                        <asp:BoundField DataField="Descripcion_producto" HeaderText="Descripcion_producto" SortExpression="Descripcion_producto" />
                        <asp:BoundField DataField="Precio_producto" HeaderText="Precio_producto" SortExpression="Precio_producto" />
                        <asp:BoundField DataField="Imagen_producto1" HeaderText="Imagen_producto1" SortExpression="Imagen_producto1" Visible="False" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <asp:Image ID="IMG_Producto0" runat="server" Height="60px" Width="60px" ImageUrl='<%# Eval("imagen_producto1") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="editar">
                            <ItemTemplate>
                                <asp:Button ID="BTN_Editar0" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="inactivo">
                            <ItemTemplate>
                                <asp:Button ID="BTN_Activado" runat="server" Text="Activar" CommandName="Activar" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_productodesactivado" runat="server" SelectMethod="mostrarproductodesactivado" TypeName="DAOProductos">
                    <SelectParameters>
                        <asp:SessionParameter Name="consulta" SessionField="user" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Button ID="BTN_productosactivados" runat="server" OnClick="BTN_productosactivados_Click" Text="Productos Activados" />
&nbsp;<asp:Button ID="BTN_productosdesactivados" runat="server" OnClick="BTN_productosdesactivados_Click" Text="Productos Desactivados" />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        </table>
</asp:Content>

