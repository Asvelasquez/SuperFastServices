using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Domiciliario : System.Web.UI.Page
{
    LDomiciliario domiciliario = new LDomiciliario();
    UMac umac1 = new UMac();
    protected void Page_Load(object sender, EventArgs e){
        if (Session["user"] != null) {
            if (((UUsuario)Session["user"]).Id_rol != 3) {
                Response.Redirect("AccesoDenegado.aspx");
            }
        } else {
            Response.Redirect("AccesoDenegado.aspx");
        }//
       
        }

    protected void GV_PedDomi_RowDataBound(object sender, GridViewRowEventArgs e){
        UPedido pedido = (UPedido)e.Row.DataItem;
        int rowcount = GV_PedDomi.Rows.Count;
        //if (rowcount == 0){
        //    LB_nohaydomiciliosdisponibles.Visible = true;
        //}else{
        //    LB_nohaydomiciliosdisponibles.Visible = false;

        //}
        umac1 = domiciliario.GV_PedDomi(rowcount);
        LB_nohaydomiciliosdisponibles.Visible = umac1.Falso;
        LB_nohaydomiciliosdisponibles.Visible = umac1.Verdadero;

        if (e.Row.FindControl("GV_detallespedido") != null){
            ((GridView)e.Row.FindControl("GV_detallespedido")).DataSource = pedido.Compras;
            ((GridView)e.Row.FindControl("GV_detallespedido")).DataBind();
        }
    }

    protected void GV_mispedidos_RowDataBound(object sender, GridViewRowEventArgs e){
        UPedido pedido = (UPedido)e.Row.DataItem;
        int rowcount = GV_mispedidos.Rows.Count;
        //if (rowcount == 0){
        //    LB_mispedidosno.Visible = true;
        //} else{
        //    LB_mispedidosno.Visible = false;
        //}
        umac1 = domiciliario.GV_PedDomi(rowcount);
        LB_mispedidosno.Visible = umac1.Falso;
        LB_mispedidosno.Visible = umac1.Verdadero;

        if (e.Row.FindControl("GV_detallespedido1") != null) {
            ((GridView)e.Row.FindControl("GV_detallespedido1")).DataSource = pedido.Compras;
            ((GridView)e.Row.FindControl("GV_detallespedido1")).DataBind();
        }
    }

    protected void GV_historial_RowDataBound(object sender, GridViewRowEventArgs e) {
        UPedido pedido = (UPedido)e.Row.DataItem;
        int rowcount = GV_historial.Rows.Count;
        //if (rowcount == 0){
        //    LB_historialno.Visible = true;
        //} else{
        //  LB_historialno.Visible = false;
        //}

        umac1 = domiciliario.GV_PedDomi(rowcount);
        LB_historialno.Visible = umac1.Falso;
        LB_historialno.Visible = umac1.Verdadero;

        if (e.Row.FindControl("GV_detallespedido2") != null){
            ((GridView)e.Row.FindControl("GV_detallespedido2")).DataSource = pedido.Compras;
            ((GridView)e.Row.FindControl("GV_detallespedido2")).DataBind();
        }
    }

    protected void DDL_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //DAOPedido pedido3 = new DAOPedido();
        UPedido pedido4 = new UPedido();
        DropDownList opciones = (DropDownList)sender;
        GridViewRow fila = (GridViewRow)opciones.Parent.Parent;
        int pedido = int.Parse(((Label)fila.FindControl("L_Pedido")).Text);
        pedido4.Id_pedido = pedido;
        pedido4.Domiciliario_id= ((UUsuario)Session["user"]).Id;
        //hacer el update
        string idseleccion = opciones.SelectedValue;
        domiciliario.DDL_Estado(pedido4, idseleccion);
        //pedido3.actualizarPedidoDomiciliario();
        GV_PedDomi.DataBind();//
    }

    protected void DDL_Estado0_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DAOPedido pedido3 = new DAOPedido();
        UPedido pedido4 = new UPedido();
        DropDownList opciones = (DropDownList)sender;
        GridViewRow fila = (GridViewRow)opciones.Parent.Parent;
        int pedido = int.Parse(((Label)fila.FindControl("L_Pedido0")).Text);
        pedido4.Id_pedido = pedido;
        pedido4.Domiciliario_id = ((UUsuario)Session["user"]).Id;
        //hacer el update
        string idseleccion = opciones.SelectedValue;
        //if (int.Parse(idseleccion) == 5)
        //{
        //    pedido3.actualizarPedidoDomiciliario(pedido4, 1);
        //    GV_PedDomi.DataBind();//
        //}
        //else
        //{

        //    pedido3.actualizarPedidoDomiciliario(pedido4, int.Parse(idseleccion));
        //    
        //}
        domiciliario.DDL_Estado0(pedido4, idseleccion);
        GV_PedDomi.DataBind();//
    }
    protected void IB_recargar0_Click(object sender, ImageClickEventArgs e)
    {
        GV_PedDomi.DataBind();
    }
    protected void IB_recargar1_Click(object sender, ImageClickEventArgs e)
    {
        ODS_misdomicilios.DataBind();
    }

    protected void IB_recargar2_Click(object sender, ImageClickEventArgs e)
    {
        GV_historial.DataBind();
    }
}