using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Carrito : System.Web.UI.Page
{
    //prueba
    protected void Page_Load(object sender, EventArgs e){
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
        TBX_subtotal1.Text = "0";
        mostrardatosentrega();
        mostrarpreciototal();
        mostrarpreciodomicilio();
       
    }

   

    protected void GV_pedidocarrito_RowDataBound(object sender, GridViewRowEventArgs e){
        UPedido pedido = (UPedido)e.Row.DataItem;
        int rowcount = GV_pedidocarrito.Rows.Count;
        if (rowcount == 0) {
            LB_pedidoscarrito.Visible = true;
            BTN_comprar.Enabled = false;
        } else{
            LB_pedidoscarrito.Visible = false;
            BTN_comprar.Enabled = true;
        }
        if (e.Row.FindControl("GV_detallespedido") != null) {
            ((GridView)e.Row.FindControl("GV_detallespedido")).DataSource = pedido.Compras;
            ((GridView)e.Row.FindControl("GV_detallespedido")).DataBind();
        }
    }
    //////////////////////
    protected void mostrardatosentrega(){
        TBX_direccion.Text = ((UUsuario)Session["user"]).Direccion;
        TBX_telefono.Text = ((UUsuario)Session["user"]).Telefono;
    }
    ////////////////
    protected void GV_pedidocarrito_RowCommand(object sender, GridViewCommandEventArgs e){
        DAOPedido daopedido = new DAOPedido();
        UPedido pedido2 = new UPedido();
        pedido2.Id_pedido = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "Cancelar") {
            daopedido.Cancelarpedido(pedido2);
            GV_pedidocarrito.DataBind();
            Response.Redirect("Carrito.aspx");
        }
    }
    protected void mostrarpreciototal(){
        DAOPedido dpedido = new DAOPedido();
        List<UPedido> pedido3 = new List<UPedido>();
        List<UDetalle_pedido> detallepedido3 = new List<UDetalle_pedido>();
        int idusuario = ((UUsuario)Session["user"]).Id;
       pedido3 = dpedido.preciototal(idusuario);
        double total = 0;
        int idpedido8=0;
        foreach (var item in pedido3) {
            idpedido8=item.Id_pedido;
            detallepedido3 = dpedido.precioTotal2(idpedido8);
            foreach (var item2 in detallepedido3) {
                total += item2.V_total;
            }
        }
        TBX_subtotal1.Text = total.ToString();
    }
    protected void mostrarpreciodomicilio(){
        DAOPedido dpedido = new DAOPedido();
        List<UPedido> pedido3 = new List<UPedido>();
        UUsuario usuario3 = new UUsuario();
        int idusuario = ((UUsuario)Session["user"]).Id;
        pedido3 = dpedido.PedidosTotal(idusuario);
        int total = 0;
        foreach (var item in pedido3) {
            total++;
        }
        TBX_cantidaddomicilios.Text = total.ToString();
        TBX_valordomicilio.Text = "3000";
        int cantidad=int.Parse(TBX_cantidaddomicilios.Text);
        double valordomicilio, resultado,total2,subtotal1;
        valordomicilio = int.Parse(TBX_valordomicilio.Text);
        resultado = cantidad * valordomicilio;
        TBX_totalpreciodomi.Text = resultado.ToString();
        subtotal1 = int.Parse(TBX_subtotal1.Text);
        total2 = resultado + subtotal1;
        TBX_total.Text = total2.ToString();
    }
    protected void BTN_comprar_Click(object sender, EventArgs e){
        DAOPedido dpedido = new DAOPedido();
        List<UPedido> pedido3 = new List<UPedido>();
        UPedido pedido4 = new UPedido();
        UDetalle_pedido detapedido4 = new UDetalle_pedido();
        UUsuario usuario3 = new UUsuario();
        int idusuario = ((UUsuario)Session["user"]).Id;
        pedido3 = dpedido.pedidoscomprar(idusuario);
        pedido4.Valor_total = double.Parse(TBX_total.Text);
        detapedido4.Telefono_cliente = TBX_telefono1.Text;
        detapedido4.Direccion_cliente = TBX_direccion1.Text;
        //  int total = 0;68/64
        foreach (var item in pedido3){
            dpedido.actualizarcomprar(item.Id_pedido,pedido4);
            dpedido.actualizardatosentrega(item.Id_pedido, detapedido4);
        }
        Response.Redirect("Carrito.aspx");
    }

    protected void IB_validar_Click(object sender, ImageClickEventArgs e){
        TBX_direccion1.Text = TBX_direccion.Text;
        TBX_telefono1.Text = TBX_telefono.Text;
        TBX_telefono1.Visible = true;
        TBX_direccion1.Visible = true;
    }
    protected void IB_recargar0_Click(object sender, ImageClickEventArgs e){
        GV_pedidocarrito.DataBind();
    }
    protected void BTN_MisPedidos_Click(object sender, EventArgs e){
        Response.Redirect("PedidosCliente.aspx");
    }
}