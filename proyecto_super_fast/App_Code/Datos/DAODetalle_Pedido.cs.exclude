using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAODetalle_Pedido
/// </summary>
public class DAODetalle_Pedido
{
    public void insertdetallePedido(Detalle_pedido d_pedido2)
    {
        using (var db = new Mapeo())
        {
            db.detpedido.Add(d_pedido2);
            db.SaveChanges();
           
        }
    }//
}