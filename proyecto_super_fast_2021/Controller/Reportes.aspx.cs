using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Reportes : System.Web.UI.Page
{
    LReportes reportes1 = new LReportes();
    UMac datos = new UMac();
    protected void Page_Load(object sender, EventArgs e)
    {
        //TextBox1.Text = pedidosclientes;
        if (Session["user"] != null)
        {
            if (((UUsuario)Session["user"]).Id_rol != 1)
            {
                Response.Redirect("AccesoDenegado.aspx");
            }

        }
        else
        {
            Response.Redirect("AccesoDenegado.aspx");
        }//
        
    }
    
    protected  generarFactura( informe)
    {
        
       reportes1.generarFactura(informe);
        //SuministroInformacion informe = new SuministroInformacion();
        //UPedido factura = new DAOPedido().obtenerFactura(facturaId);

        //DataTable datosFinal = informe.Factura;
        //DataRow fila;

        //foreach (var item in factura.Compras)
        //{
        //    fila = datosFinal.NewRow();
        //    fila["No"] = factura.Id_pedido;
        //    fila["Fecha"] = factura.Fecha;
        //    fila["NombreCliente"] = factura.Nombre_cliente;
        //    fila["NombreProducto"] = item.Nombreprodet;
        //    fila["Cantidad"] = item.Cantidad;
        //    fila["ValorUnitario"] = item.V_unitario;
        //    fila["ValorTotal"] = item.V_total;

        //    datosFinal.Rows.Add(fila);
        //}
        //fila = datosFinal.NewRow();
        //fila["NombreProducto"] = "Domicilio";
        //fila["Cantidad"] = "1";
        //fila["ValorUnitario"] ="3000";
        //fila["ValorTotal"] = "3000";

        //datosFinal.Rows.Add(fila);
        //return informe;
    }//

    protected void GV_pedidocarrito0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        UPedido pedido = (UPedido)e.Row.DataItem;
        int rowcount = GV_pedidocarrito0.Rows.Count;
        //if (rowcount == 0)
        //{
        //    LB_historial.Visible = true;
        //}
        //else
        //{
        //    LB_historial.Visible = false;
        //}
       datos= reportes1.LGV_pedidocarrito0(rowcount);
        LB_historial.Visible = datos.Verdadero;
        LB_historial.Visible = datos.Falso;

        if (e.Row.FindControl("GV_detallespedido0") != null)
        {
            ((GridView)e.Row.FindControl("GV_detallespedido0")).DataSource = pedido.Compras;
            ((GridView)e.Row.FindControl("GV_detallespedido0")).DataBind();
        }
    }//
    protected void GV_pedidocarrito0_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //DAOPedido daop = new DAOPedido();
        UPedido pedido4 = new UPedido();
        pedido4.Id_pedido = int.Parse(e.CommandArgument.ToString());
       if (e.CommandName == "Generar")
        {
            ////int idpedidofactura = 
            int factura = int.Parse(e.CommandArgument.ToString());
            CRS_Facturas.ReportDocument.SetDataSource(generarFactura(factura));
            CRV_Factura.ReportSource = CRS_Facturas;
            CRV_Factura.Visible = true;
        }
    }//
    protected void IB_recargar1_Click(object sender, ImageClickEventArgs e)
    {
        GV_pedidocarrito0.DataBind();
    }//


  
}