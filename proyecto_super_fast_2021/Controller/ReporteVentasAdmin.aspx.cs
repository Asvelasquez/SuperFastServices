using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ReporteVentasAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CRS_ReporteAdmin.ReportDocument.SetDataSource(obtenerInformacion());
        CRV_ReporteAdmin.ReportSource = CRS_ReporteAdmin;
        CRV_ReporteAdmin.Visible = true;
    }

     protected SuministroInformacion obtenerInformacion()
    {

        SuministroInformacion informe = new SuministroInformacion();
      //  DateTime fechaInicio = DateTime.Parse(TB_FechaInicio.Text);
       // DateTime fechaFin = DateTime.Parse(TB_FechaFin.Text);
        List<Producto> listaProductos = new List<Producto>();

        List<Detalle_pedido> lista = new DAOPedido().productosVendidos(((Usuario)Session["user"]).Id);
        var prod = lista.GroupBy(x => (x.Nombreprodet)).Select(grp => grp.ToList()).ToList();


        foreach (var item in prod)
        {
            List<Detalle_pedido> detalle = item;
            Producto nuevo = new Producto();
            nuevo.Nombre_producto = detalle.First().Nombreprodet;
            nuevo.Cantidad = detalle.Sum(x => x.Cantidad);
            nuevo.Id = detalle.First().Producto_id;
            nuevo.Precio_producto = detalle.Average(x => x.V_unitario);
            nuevo.Nombre_aliado = detalle.First().Nombre_aliado;

            listaProductos.Add(nuevo);
        }
      
       
        DataTable datosFinal = informe.Ventas;
        DataRow fila;

        foreach (var item in listaProductos)
        {
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