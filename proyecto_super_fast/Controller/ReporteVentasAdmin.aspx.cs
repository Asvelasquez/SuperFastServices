using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
public partial class View_ReporteVentasAdmin : System.Web.UI.Page{
    //
    LReportesVentasAdmin lreportesventasadmin1 = new LReportesVentasAdmin();
    UMac datos1 = new UMac();
    //
    protected void Page_Load(object sender, EventArgs e){
        datos1 = lreportesventasadmin1.LPage_Load((UUsuario)Session["user"]);
        try{
            Response.Redirect(datos1.Url);
        }catch (Exception) { }
        CRS_ReporteAdmin.ReportDocument.SetDataSource(obtenerInformacion());
        CRV_ReporteAdmin.ReportSource = CRS_ReporteAdmin;
        CRV_ReporteAdmin.Visible = true;
    }
    //
     protected SuministroInformacion obtenerInformacion(){

        SuministroInformacion informe = new SuministroInformacion();
      //  DateTime fechaInicio = DateTime.Parse(TB_FechaInicio.Text);
       // DateTime fechaFin = DateTime.Parse(TB_FechaFin.Text);
        List<UProducto> listaProductos = new List<UProducto>();
        //List<UDetalle_pedido> lista = new DAOPedido().productosVendidos(((UUsuario)Session["user"]).Id);
        List<UDetalle_pedido> lista = lreportesventasadmin1.obtenerInformacion(((UUsuario)Session["user"]).Id);
        var prod = lista.GroupBy(x => (x.Nombreprodet)).Select(grp => grp.ToList()).ToList();
        foreach (var item in prod){
            List<UDetalle_pedido> detalle = item;
            UProducto nuevo = new UProducto();
            nuevo.Nombre_producto = detalle.First().Nombreprodet;
            nuevo.Cantidad = detalle.Sum(x => x.Cantidad);
            nuevo.Id = detalle.First().Producto_id;
            nuevo.Precio_producto = detalle.Average(x => x.V_unitario);
            nuevo.Nombre_aliado = detalle.First().Nombre_aliado;
            listaProductos.Add(nuevo);
        }     
        DataTable datosFinal = informe.Ventas;
        DataRow fila;
        foreach (var item in listaProductos){
            fila = datosFinal.NewRow();
            fila["ProductoId"] = item.Id;
            fila["NombreProducto"] = item.Nombre_producto;
            fila["Cantidad"] = item.Cantidad;
            fila["NombreAdmin"] =item.Nombre_aliado;
            datosFinal.Rows.Add(fila);
        }
        return informe;
    }
}