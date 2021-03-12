using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
public partial class View_inicio : System.Web.UI.Page{
    LInicio LInicio1 = new LInicio();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            if (((UUsuario)Session["user"]).Id_rol == 2)
            {
                Response.Redirect("pedidosaliado.aspx");
            }else if(((UUsuario)Session["user"]).Id_rol == 3)
            {
                Response.Redirect("Domiciliario.aspx");
            }else if (((UUsuario)Session["user"]).Id_rol == 4)
            {
                Response.Redirect("administrador.aspx");
            }
        }
        
        LB_Carrito.Text = "0";
        mostrarcantidadtotal();
    }

    protected void Menu_principal_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
    

    protected void DL_Productos_ItemCommand(object source, DataListCommandEventArgs e){
        ClientScriptManager cm = this.ClientScript;
        if (Session["user"] == null) {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe iniciar session, para poder comprar');</script>");
        }
        else if (((UUsuario)(Session["user"])).Id_rol == 1) {
            DL_Productos.SelectedIndex = e.Item.ItemIndex;
            if (String.IsNullOrEmpty(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_cantidad")).Text) || String.IsNullOrEmpty(((TextBox)DL_Productos.SelectedItem.FindControl("TB_especificacion")).Text)){
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe Diligenciar todos los campos, para poder comprar');</script>");
            }
            else{
                List<UPedido> ped20 = new List<UPedido>();
                UPedido pedido3 = new UPedido();
                UDetalle_pedido det_pedido = new UDetalle_pedido();
                ped20 = LInicio1.DL_Productos1(((UUsuario)(Session["user"])).Id);
                int contador = 0;
                foreach (var item in ped20)  {
                    if (item.Aliado_id == int.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_IDaliado")).Text)){
                        try {
                            det_pedido.Pedido_id = item.Id_pedido;
                            det_pedido.Descripcion = ((TextBox)DL_Productos.SelectedItem.FindControl("TB_especificacion")).Text;
                            det_pedido.V_unitario = double.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_precio")).Text);
                            det_pedido.Cantidad = int.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_cantidad")).Text);
                            det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                            det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                            det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                            double valorunitario, resultado;
                            int cantidad5;
                            valorunitario = double.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_precio")).Text);
                            cantidad5 = int.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_cantidad")).Text);
                            resultado = valorunitario * cantidad5;
                            det_pedido.V_total = resultado;
                            LInicio1.DL_Productos2(det_pedido);
                            contador++;
                        }
                        catch (Exception) { throw; }
                    }

                }
                if (contador == 0){
                    try{
                        pedido3.Cliente_id = ((UUsuario)Session["user"]).Id;
                        pedido3.Fecha = DateTime.Now;
                        pedido3.Estado_id = 1;//1) posible compra 2)comprado 3)cancelado
                        pedido3.Aliado_id = int.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_IDaliado")).Text);
                        pedido3.Domiciliario_id = 1;
                        pedido3.Estado_pedido = 0;// 0) posible compra 1)comprado 2)cancelado
                        pedido3.Estado_domicilio_id = 1;
                        LInicio1.DL_Productos3(pedido3);

                        det_pedido.Pedido_id = pedido3.Id_pedido;
                        det_pedido.Descripcion = ((TextBox)DL_Productos.SelectedItem.FindControl("TB_especificacion")).Text;
                        det_pedido.V_unitario = double.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_precio")).Text);
                        det_pedido.Cantidad = int.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_cantidad")).Text);
                        det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                        det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                        det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                        double valorunitario, resultado;
                        int cantidad5;
                        valorunitario = double.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_precio")).Text);
                        cantidad5 = int.Parse(((TextBox)DL_Productos.SelectedItem.FindControl("TBX_cantidad")).Text);
                        resultado = valorunitario * cantidad5;
                        det_pedido.V_total = resultado;
                        LInicio1.DL_Productos2(det_pedido);
                    }
                    catch (Exception ex)
                    { return; }//
                }
            }//else
        }//ELSE
    }
   //

    protected void DL_productosfiltros_ItemCommand(object source, DataListCommandEventArgs e){
        ClientScriptManager cm = this.ClientScript;
        if (Session["user"] == null) {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe iniciar session, para poder comprar');</script>");
        }else if (((UUsuario)(Session["user"])).Id_rol == 1){
            DL_productosfiltros.SelectedIndex = e.Item.ItemIndex;
            if (String.IsNullOrEmpty(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_cantidad")).Text) || String.IsNullOrEmpty(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TB_especificacion")).Text))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe Diligenciar todos los campos, para poder comprar');</script>");
            }else {
                
                List<UPedido> ped20 = new List<UPedido>();
                UPedido pedido3 = new UPedido();
                UDetalle_pedido det_pedido = new UDetalle_pedido();
                ped20 = LInicio1.DL_Productos1(((UUsuario)(Session["user"])).Id);
                int contador = 0;
                foreach (var item in ped20){
                    if (item.Aliado_id == int.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_IDaliado")).Text)){
                        try {
                            det_pedido.Pedido_id = item.Id_pedido;
                            det_pedido.Descripcion = ((TextBox)DL_productosfiltros.SelectedItem.FindControl("TB_especificacion")).Text;
                            det_pedido.V_unitario = double.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_precio")).Text);
                            det_pedido.Cantidad = int.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_cantidad")).Text);
                            det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                            det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                            det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                            double valorunitario, resultado;
                            int cantidad5;
                            valorunitario = double.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_precio")).Text);
                            cantidad5 = int.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_cantidad")).Text);
                            resultado = valorunitario * cantidad5;
                            det_pedido.V_total = resultado;
                            LInicio1.DL_Productos2(det_pedido);
                            contador++;
                        }
                        catch (Exception) { throw; }
                    }
                }
                if (contador == 0){
                    try{
                        pedido3.Cliente_id = ((UUsuario)Session["user"]).Id;
                        pedido3.Fecha = DateTime.Now;
                        pedido3.Estado_id = 1;//1) posible compra 2)comprado 3)cancelado
                        pedido3.Aliado_id = int.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_IDaliado")).Text);
                        pedido3.Domiciliario_id = 1;
                        pedido3.Estado_pedido = 0;// 0) posible compra 1)comprado 2)cancelado
                        pedido3.Estado_domicilio_id = 1;
                        LInicio1.DL_Productos3(pedido3);

                        det_pedido.Pedido_id = pedido3.Id_pedido;
                        det_pedido.Descripcion = ((TextBox)DL_productosfiltros.SelectedItem.FindControl("TB_especificacion")).Text;
                        det_pedido.V_unitario = double.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_precio")).Text);
                        det_pedido.Cantidad = int.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_cantidad")).Text);
                        det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                        det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                        det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                        double valorunitario, resultado;
                        int cantidad5;
                        valorunitario = double.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_precio")).Text);
                        cantidad5 = int.Parse(((TextBox)DL_productosfiltros.SelectedItem.FindControl("TBX_cantidad")).Text);
                        resultado = valorunitario * cantidad5;
                        det_pedido.V_total = resultado;
                        LInicio1.DL_Productos2(det_pedido);
                    }
                    catch (Exception ex)
                    { return; }//
                }//ifcontador
            }//elseinterno
        }//else
    }//DL_productosfiltros
    //
    protected void DL_productosfiltrorest_ItemCommand(object source, DataListCommandEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        if (Session["user"] == null) {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe iniciar session, para poder comprar');</script>");
        } else if (((UUsuario)(Session["user"])).Id_rol == 1) {
            DL_productosfiltrorest.SelectedIndex = e.Item.ItemIndex;
            if (String.IsNullOrEmpty(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_cantidad")).Text) || String.IsNullOrEmpty(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TB_especificacion")).Text))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe Diligenciar todos los campos, para poder comprar');</script>");
            }else {
                List<UPedido> ped20 = new List<UPedido>();
                UPedido pedido3 = new UPedido();
                UDetalle_pedido det_pedido = new UDetalle_pedido();
                ped20 = LInicio1.DL_Productos1(((UUsuario)(Session["user"])).Id);
                int contador = 0;
                foreach (var item in ped20) {
                    if (item.Aliado_id == int.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_IDaliado")).Text)){
                        try{
                            det_pedido.Pedido_id = item.Id_pedido;
                            det_pedido.Descripcion = ((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TB_especificacion")).Text;
                            det_pedido.V_unitario = double.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_precio")).Text);
                            det_pedido.Cantidad = int.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_cantidad")).Text);
                            det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                            det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                            det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                            double valorunitario, resultado;
                            int cantidad5;
                            valorunitario = double.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_precio")).Text);
                            cantidad5 = int.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_cantidad")).Text);
                            resultado = valorunitario * cantidad5;
                            det_pedido.V_total = resultado;
                            LInicio1.DL_Productos2(det_pedido);
                            contador++;
                        }
                        catch (Exception) { throw; }
                    }
                }
                if (contador == 0) {
                    try {
                        pedido3.Cliente_id = ((UUsuario)Session["user"]).Id;
                        pedido3.Fecha = DateTime.Now;
                        pedido3.Estado_id = 1;//1) posible compra 2)comprado 3)cancelado
                        pedido3.Aliado_id = int.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_IDaliado")).Text);
                        pedido3.Domiciliario_id = 1;
                        pedido3.Estado_pedido = 0;// 0) posible compra 1)comprado 2)cancelado
                        pedido3.Estado_domicilio_id = 1;
                        LInicio1.DL_Productos3(pedido3);

                        det_pedido.Pedido_id = pedido3.Id_pedido;
                        det_pedido.Descripcion = ((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TB_especificacion")).Text;
                        det_pedido.V_unitario = double.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_precio")).Text);
                        det_pedido.Cantidad = int.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_cantidad")).Text);
                        det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                        det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                        det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                        double valorunitario, resultado;
                        int cantidad5;
                        valorunitario = double.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_precio")).Text);
                        cantidad5 = int.Parse(((TextBox)DL_productosfiltrorest.SelectedItem.FindControl("TBX_cantidad")).Text);
                        resultado = valorunitario * cantidad5;
                        det_pedido.V_total = resultado;
                        LInicio1.DL_Productos2(det_pedido);
                    }
                    catch (Exception ex)
                    { return; }//
                }
            }//else
        }//else
    }//DL_productosfiltrorest
    //
    protected void DL_productosfiltroPrecio_ItemCommand(object source, DataListCommandEventArgs e){
        ClientScriptManager cm = this.ClientScript;
        if (Session["user"] == null){
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe iniciar session, para poder comprar');</script>");
        }else if (((UUsuario)(Session["user"])).Id_rol == 1){
            DL_productosfiltroPrecio.SelectedIndex = e.Item.ItemIndex;
            if (String.IsNullOrEmpty(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_cantidad")).Text) || String.IsNullOrEmpty(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TB_especificacion")).Text))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe Diligenciar todos los campos, para poder comprar');</script>");
            }else {
                
                List<UPedido> ped20 = new List<UPedido>();
                UPedido pedido3 = new UPedido();
                UDetalle_pedido det_pedido = new UDetalle_pedido();
                ped20 = LInicio1.DL_Productos1(((UUsuario)(Session["user"])).Id);
                int contador = 0;
                foreach (var item in ped20){
                    if (item.Aliado_id == int.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_IDaliado")).Text)){
                        try {
                            det_pedido.Pedido_id = item.Id_pedido;
                            det_pedido.Descripcion = ((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TB_especificacion")).Text;
                            det_pedido.V_unitario = double.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_precio")).Text);
                            det_pedido.Cantidad = int.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_cantidad")).Text);
                            det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                            det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                            det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                            double valorunitario, resultado;
                            int cantidad5;
                            valorunitario = double.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_precio")).Text);
                            cantidad5 = int.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_cantidad")).Text);
                            resultado = valorunitario * cantidad5;
                            det_pedido.V_total = resultado;
                            LInicio1.DL_Productos2(det_pedido);
                            contador++;
                        }
                        catch (Exception) { throw; }
                    }
                }
                if (contador == 0) {
                    try{
                        pedido3.Cliente_id = ((UUsuario)Session["user"]).Id;
                        pedido3.Fecha = DateTime.Now;
                        pedido3.Estado_id = 1;//1) posible compra 2)comprado 3)cancelado
                        pedido3.Aliado_id = int.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_IDaliado")).Text);
                        pedido3.Domiciliario_id = 1;
                        pedido3.Estado_pedido = 0;// 0) posible compra 1)comprado 2)cancelado
                        pedido3.Estado_domicilio_id = 1;
                        LInicio1.DL_Productos3(pedido3);

                        det_pedido.Pedido_id = pedido3.Id_pedido;
                        det_pedido.Descripcion = ((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TB_especificacion")).Text;
                        det_pedido.V_unitario = double.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_precio")).Text);
                        det_pedido.Cantidad = int.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_cantidad")).Text);
                        det_pedido.Producto_id = int.Parse(e.CommandArgument.ToString());
                        det_pedido.Direccion_cliente = ((UUsuario)Session["user"]).Direccion;
                        det_pedido.Telefono_cliente = ((UUsuario)Session["user"]).Telefono;
                        double valorunitario, resultado;
                        int cantidad5;
                        valorunitario = double.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_precio")).Text);
                        cantidad5 = int.Parse(((TextBox)DL_productosfiltroPrecio.SelectedItem.FindControl("TBX_cantidad")).Text);
                        resultado = valorunitario * cantidad5;
                        det_pedido.V_total = resultado;
                        LInicio1.DL_Productos2(det_pedido);
                    }
                    catch (Exception ex)
                    { return; }//
                }//ifcontador
            }
        }//else
    }//DL_productosfiltroPrecio
    //
    protected void IB_Carrito_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        if (Session["user"] == null) {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('debe iniciar sesion, para poder comprar');</script>");
         } else if (((UUsuario)(Session["user"])).Id_rol == 1) {
            //new DAOPedido().obtenercarrito(((Usuario)Session["user"]).Id);
            Response.Redirect("Carrito.aspx");
        }
    }
    //
    protected void BTN_buscar_Click(object sender, EventArgs e) {
        DL_Productos.Visible = false;
        DL_productosfiltros.Visible = true;
        DL_productosfiltrorest.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_buscar.Text=TBX_filtro1.Text;
        TBX_buscar.Text.Contains("");
    }
    //
    protected void BTN_hamburguesa_Click(object sender, EventArgs e) {
        DL_productosfiltros.Visible = true;
        DL_Productos.Visible = false;        
        DL_productosfiltrorest.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_buscar.Text = "Hamburguesa";
    }
    //
    protected void BTN_perrocaliente_Click(object sender, EventArgs e){
        DL_productosfiltros.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltrorest.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_buscar.Text = "perro";
       
    }
    //
    protected void BTN_Restaurantes_Click(object sender, EventArgs e){
        DL_productosfiltrorest.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltros.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_actividadcomercial.Text = "Restaurante";
       // DaoRest.mostrarproductoinicioactividad("Restaurante");
    }
    //
    protected void BTN_Supermecados_Click(object sender, EventArgs e){
        DL_productosfiltrorest.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltros.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_actividadcomercial.Text = "Super mercado";
    }
    //
    //protected void BTN_Restaurantes_Click1(object sender, EventArgs e)
    //{
    //    DL_Productos.Visible = false;
    //    DL_productosfiltros.Visible = false;
    //    DL_productosfiltrorest.Visible = true;
    //    TBX_actividadcomercial.Text = "Restaurantes";
    //}
    //
    protected void TBX_filtro1_TextChanged(object sender, EventArgs e){

    }
    //
    protected void BTN_Todos_Click(object sender, EventArgs e) {
         Response.Redirect("inicio.aspx");
    }
    //
    protected void BTN_Pizza_Click(object sender, EventArgs e)
    {
        DL_productosfiltros.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltrorest.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_buscar.Text = "pizza";
        
    }
    //
    protected void BTN__Click(object sender, EventArgs e){
        DL_productosfiltros.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltrorest.Visible = false;
        DL_productosfiltroPrecio.Visible = false;
        TBX_buscar.Text = "empanadas";
        
    }
    //
    protected void BTN_BuscarValor_Click(object sender, EventArgs e){

    }
    //
    protected void mostrarcantidadtotal(){
        if (Session["user"] != null){
            LInicio1.mostrarcantidadtotal(((UUsuario)Session["user"]).Id);
        }
    }
    //
    protected void BT_Rango1_Click(object sender, EventArgs e){
        TBX_V_minimo.Text = "1000";
        TBX_V_max.Text = "10000";
        DL_productosfiltroPrecio.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltros.Visible = false;
        DL_productosfiltrorest.Visible = false;
    }
    //
    protected void BT_Rango2_Click(object sender, EventArgs e){
        TBX_V_minimo.Text = "11000";
        TBX_V_max.Text = "20000";
        DL_productosfiltroPrecio.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltros.Visible = false;
        DL_productosfiltrorest.Visible = false;

    }
    //
    protected void Button1_Click(object sender, EventArgs e){
        TBX_V_minimo.Text = "21000";
        TBX_V_max.Text = "30000";
        DL_productosfiltroPrecio.Visible = true;
        DL_Productos.Visible = false;
        DL_productosfiltros.Visible = false;
        DL_productosfiltrorest.Visible = false;
    }
    //
}