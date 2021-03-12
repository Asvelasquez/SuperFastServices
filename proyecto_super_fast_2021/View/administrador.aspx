<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/administrador.aspx.cs" Inherits="View_administrador" %>

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
            <td>&nbsp;<table class="auto-style33">
                <tr>
                    <td class="auto-style34">
                        <asp:Button ID="BTN_ventasgenerales" runat="server" BorderColor="Black" Height="30px" PostBackUrl="~/View/ReporteVentasAdmin.aspx" Text="Reporte de Ventas Generales" />
                    </td>
                </tr>
                </table>
                <br />
        <asp:Label ID="LB_solicitudesaliados" runat="server" Font-Size="X-Large" Height="25px" Text="Solicitudes de aliados"></asp:Label>
                <br />
                <br />
        <asp:GridView ID="GV_aliadoaprobar" runat="server" AutoGenerateColumns="False" DataSourceID="ODSaliado" OnRowCommand="GV_aliadoaprobar_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Documento" HeaderText="NIT" SortExpression="Documento" />
                <asp:TemplateField HeaderText="Rut">
                    <ItemTemplate>
                        <asp:HyperLink ID="HYL_rut" NavigateUrl='<%# Eval("Rut") %>' Target="_blank" runat="server">Rut</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Logo" >
                    <ItemTemplate>
                        <asp:Image ID="IM_perfil" runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("Imagenperfil") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Actividadcomercial" HeaderText="Actividad comercial" SortExpression="Actividadcomercial" />
                <asp:TemplateField HeaderText="Aceptar">
                    <ItemTemplate>
                        <asp:Button ID="BTN_aceptaraliado" runat="server" CommandName="Aceptar" CommandArgument='<%# Eval("Id") %>' Text="Aceptar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rechazar">
                    <ItemTemplate>
                        <asp:Button ID="BTN_rechazaraliado" runat="server" CommandName="Rechazar" CommandArgument='<%# Eval("Id") %>' Text="Rechazar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSaliado" runat="server" SelectMethod="mostrarsolicitudaliado" TypeName="DAOUsuario"></asp:ObjectDataSource>
                <br />
        <asp:Label ID="LB_solicituddomicilios" runat="server" Font-Size="X-Large" Height="25px" Text="Solicitudes de domiciliarios"></asp:Label>
       
                <br />
       
                <br />
       
        <asp:GridView ID="GV_domiciliariiosaprobar" runat="server" AutoGenerateColumns="False" DataSourceID="ODSDom" OnRowCommand="GV_domiciliariiosaprobar_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento" />
                <asp:TemplateField HeaderText="Imagen Perfil">
                    <ItemTemplate>
                        <asp:Image ID="IM_perfil2" runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("Imagenperfil") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hoja de Vida">
                    <ItemTemplate>
                        <asp:HyperLink ID="HYL_hojavida"  NavigateUrl='<%# Eval("hojavida") %>' Target="_blank" runat="server">Hoja de vida</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Tipovehiculo" HeaderText="Tipovehiculo" SortExpression="Tipovehiculo" />
                <asp:TemplateField HeaderText="aceptar">
                    <ItemTemplate>
                        <asp:Button ID="BTN_aceptardomiciliario" runat="server"  CommandName="Aceptar" CommandArgument='<%# Eval("Id") %>' Text="Aceptar"    />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rechazar">
                    <ItemTemplate>
                        <asp:Button ID="BTN_rechazardomiciliario" runat="server" CommandName="Rechazar"  CommandArgument='<%# Eval("Id") %>' Text="Rechazar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSDom" runat="server" SelectMethod="mostrarsolicituddomiciliario" TypeName="DAOUsuario"></asp:ObjectDataSource>
   
                <br />
   
         <asp:Label ID="LB_solicitudalaadosrechazados" runat="server" Text="Solicitud de aliados rechazados" Font-Size="X-Large"></asp:Label>
                <br />
                <br />
        <asp:GridView ID="GV_aliadorechazado" runat="server" AutoGenerateColumns="False" DataSourceID="ODSaliadorechazado" OnRowCommand="GV_aliadorechazado_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Documento" HeaderText="NIT" SortExpression="Documento" />
                <asp:TemplateField HeaderText="Rut">
                    <ItemTemplate>
                        <asp:HyperLink ID="HYP_rut3" NavigateUrl='<%# Eval("Rut") %>' Target="_blank" runat="server">Rut</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Logo">
                    <ItemTemplate>
                        <asp:Image ID="IM_perfil3" runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("Imagenperfil") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Actividadcomercial" HeaderText="Actividadcomercial" SortExpression="Actividadcomercial" />
                <asp:TemplateField HeaderText="Aceptar">
                    <ItemTemplate>
                        <asp:Button ID="BTN_aceptar" runat="server" CommandName="Aceptar"  CommandArgument='<%# Eval("Id") %>' Text="Aceptar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Revision">
                    <ItemTemplate>
                        <asp:Button ID="BTN_revision" runat="server" CommandName="Revision"  CommandArgument='<%# Eval("Id") %>' Text="Revision" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <asp:ObjectDataSource ID="ODSaliadorechazado" runat="server" SelectMethod="mostrarsolicitudaliadorechazado" TypeName="DAOUsuario"></asp:ObjectDataSource>
                <br />
        <asp:Label ID="LB_solicituddomiciliariosrechazados" runat="server" Text="Solicitud de domiciliarios rechazados" Font-Size="X-Large"></asp:Label>
                <br />
                <br />
        <asp:GridView ID="GV_domiciliariorechazado" runat="server" AutoGenerateColumns="False" DataSourceID="ODSdomiciliariorechazados" OnRowCommand="GV_domiciliariorechazado_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento" />
                <asp:TemplateField HeaderText="Imagen Perfil">
                    <ItemTemplate>
                        <asp:Image ID="IM3_imageperfil"   runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("Imagenperfil") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hoja de vida">
                    <ItemTemplate>
                        <asp:HyperLink ID="Hyp_hojaivida3" NavigateUrl='<%# Eval("hojavida") %>' Target="_blank" runat="server">Hoja de vida</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Tipovehiculo" HeaderText="Tipovehiculo" SortExpression="Tipovehiculo" />
                <asp:TemplateField HeaderText="Aceptar">
                    <ItemTemplate>
                        <asp:Button ID="BTN_acpetar" runat="server" CommandName="Aceptar"  CommandArgument='<%# Eval("Id") %>' Text="Aceptar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Revision">
                    <ItemTemplate>
                        <asp:Button ID="BTN_revision0" runat="server" CommandName="Revision"  CommandArgument='<%# Eval("Id") %>' Text="Revision" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <asp:ObjectDataSource ID="ODSdomiciliariorechazados" runat="server" SelectMethod="mostrarsolicituddomiciliariorechazado" TypeName="DAOUsuario"></asp:ObjectDataSource>
                <br />
       &nbsp;<asp:Label ID="LB_solicitudalidosaceptados" runat="server" Text="Solicitud de aliados aceptados" Font-Size="X-Large"></asp:Label>
         &nbsp;&nbsp;<br />
                <br />
                <asp:GridView ID="GV_solicitudaliadosaceptados" runat="server" AutoGenerateColumns="False" DataSourceID="ODSalidadoaceptado" OnRowCommand="GV_solicitudaliadosaceptados_RowCommand">
             <Columns>
                 <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                 <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                 <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                 <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                 <asp:BoundField DataField="Documento" HeaderText="NIT" SortExpression="Documento" />
                 <asp:TemplateField HeaderText="Rut">
                     <ItemTemplate>
                         <asp:HyperLink ID="HYP_rut" NavigateUrl='<%# Eval("Rut") %>' Target="_blank" runat="server">Rut</asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Logo">
                     <ItemTemplate>
                         <asp:Image ID="Image_logo" runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("Imagenperfil") %>' />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="Actividadcomercial" HeaderText="Actividadcomercial" SortExpression="Actividadcomercial" />
                 <asp:TemplateField HeaderText="Rechazar">
                     <ItemTemplate>
                         <asp:Button ID="BTN_Rechazaraliadosaceptados" runat="server" CommandName="Rechazar"  CommandArgument='<%# Eval("Id") %>' Text="Rechazar" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
         <asp:ObjectDataSource ID="ODSalidadoaceptado" runat="server" SelectMethod="mostrarsolicitudaliadoaceptado" TypeName="DAOUsuario"></asp:ObjectDataSource>
                <br />
         <asp:Label ID="LB_solicituddedomiciliariosaceptados" runat="server" Text="Solicitud de domiciliarios aceptados" Font-Size="X-Large"></asp:Label>
         &nbsp;<br />
                <br />
                <asp:GridView ID="GV_domiciliariosaceptados" runat="server" AutoGenerateColumns="False" DataSourceID="ODSdomiciliarioaceptado" OnRowCommand="GV_domiciliariosaceptados_RowCommand">
             <Columns>
                 <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                 <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                 <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                 <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                 <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento" />
                 <asp:TemplateField HeaderText="Imagen de Perfil">
                     <ItemTemplate>
                         <asp:Image ID="IMG4_imangenperfil"   runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("Imagenperfil") %>'/>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Hoja de vida">
                     <ItemTemplate>
                         <asp:HyperLink ID="HYP_hojavida4" NavigateUrl='<%# Eval("hojavida") %>' Target="_blank" runat="server">Hoja de vida</asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="Tipovehiculo" HeaderText="Tipovehiculo" SortExpression="Tipovehiculo" />
                 <asp:TemplateField HeaderText="Rechazar">
                     <ItemTemplate>
                         <asp:Button ID="BTN_rechazardomiciiarioaceptado" runat="server" CommandName="Rechazar"  CommandArgument='<%# Eval("Id") %>' Text="Rechazar" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
         <asp:ObjectDataSource ID="ODSdomiciliarioaceptado" runat="server" SelectMethod="mostrarsolicituddomiciliarioaceptado" TypeName="DAOUsuario"></asp:ObjectDataSource>
                <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
         <asp:Button ID="BTN_solicitudesrechazas" runat="server"  Text="Solicitudes Rechazadas" OnClick="BTN_solicitudesrechazas_Click" Width="179px" BorderColor="Black" Height="30px" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="BTN_solicitudesaceptadas" runat="server" Text="Solicitudes Aceptadas" Width="179px" OnClick="BTN_solicitudesaceptadas_Click" BorderColor="Black" Height="30px" />
         &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BTN_solicitudesaprobar" runat="server" Text="Solicitudes por aprobar" BorderColor="Black" Height="30px" Width="179px" OnClick="BTN_solicitudesaprobar_Click" />
                <br />
                <br />
                <br />
         <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </td>
        </tr>
    </table>
   
  
    
</asp:Content>

