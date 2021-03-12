using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;
namespace Logica
{
   public  class LPedidosaliado
    {
        public void LDDL_Categoria(UPedido pedido4, string idseleccion){
            DAOPedido pedido3 = new DAOPedido();
            pedido3.actualizarPedido(pedido4, int.Parse(idseleccion));
        }
        //
        public void LGV_pedidos(UPedido pedido4, string CommandName){
            DAOPedido daop = new DAOPedido();          
            if (CommandName == "Guardar") {
                daop.guardarcomentario(pedido4);
            }
        }
        //
    }
}
