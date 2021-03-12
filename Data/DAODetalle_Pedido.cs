using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Data
{
    public class DAODetalle_Pedido
    {
        public void insertdetallePedido(UDetalle_pedido d_pedido2)
        {
            using (var db = new Mapeo())
            {
                db.detpedido.Add(d_pedido2);
                db.SaveChanges();
            }
        }//
    }
}
