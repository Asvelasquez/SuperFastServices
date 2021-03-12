using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
public partial class View_ReporteVentas : System.Web.UI.Page
{
    LReportesVentas lreportesventas1 = new LReportesVentas();
    UMac datos1 = new UMac();
    protected void Page_Load(object sender, EventArgs e){
        //if (Session["user"] != null)
        //{
        //    if (((UUsuario)Session["user"]).Id_rol != 2)
        //    {
        //        Response.Redirect("AccesoDenegado.aspx");
        //    }

        //}
        //else
        //{
        //    Response.Redirect("AccesoDenegado.aspx");
        //}//
        datos1 = lreportesventas1.LPage_Load((UUsuario)Session["user"]);
        try{
            Response.Redirect(datos1.Url);
        }catch (Exception) { }
        CRS_Ventas.ReportDocument.SetDataSource(obtenerInformacion());
        CRV_Ventas.ReportSource = CRS_Ventas;
        CRV_Ventas.Visible = true;
    }
  
    protected SuministroInformacion obtenerInformacion(){
        SuministroInformacion informe = new SuministroInformacion();
      //  DateTime fechaInicio = DateTime.Parse(TB_FechaInicio.Text);
       // DateTime fechaFin = DateTime.Parse(TB_FechaFin.Text);
        List<UProducto> listaProductos = new List<UProducto>();
        // List<UDetalle_pedido> lista = new DAOPedido().productosVendidosXFecha(((UUsuario)Session["user"]).Id);
        List<UDetalle_pedido> lista = lreportesventas1.obtenerInformacion(((UUsuario)Session["user"]).Id);
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