using Utilitarios;

namespace DataNC
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
