<%@ Page Title="" Language="C#" MasterPageFile="~/View/Mastersuper.master" AutoEventWireup="true" CodeFile="~/Controller/ReporteVentas.aspx.cs" Inherits="View_ReporteVentas" %>

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
                <CR:CrystalReportViewer ID="CRV_Ventas" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" HasRefreshButton="True" Height="50px" ReportSourceID="CRS_Ventas" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" Visible="False" />
                <CR:CrystalReportSource ID="CRS_Ventas" runat="server">
                    <Report FileName="~\Reportes\Ventas.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

