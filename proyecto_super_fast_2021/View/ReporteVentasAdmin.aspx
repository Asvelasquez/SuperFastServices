<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/ReporteVentasAdmin.aspx.cs" Inherits="View_ReporteVentasAdmin" %>

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
            <td>
                <CR:CrystalReportViewer ID="CRV_ReporteAdmin" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_ReporteAdmin" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" Visible="False" />
                <CR:CrystalReportSource ID="CRS_ReporteAdmin" runat="server">
                    <Report FileName="~\Reportes\ReporteAdmin.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

