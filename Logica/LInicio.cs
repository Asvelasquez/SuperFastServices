using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;
namespace Logica
{
   public class LInicio {
        //
        public List<UPedido> DL_Productos1(int idsesion){
            DAOPedido daoped = new DAOPedido();
            List<UPedido> ped20 = new List<UPedido>();
            ped20 = daoped.consultarpedido(idsesion);
            return ped20;
        }
        //
        public void DL_Productos2(UDetalle_pedido det_pedido) {
            new DAODetalle_Pedido().insertdetallePedido(det_pedido);
         }
        //
        public void DL_Productos3(UPedido pedido3){
            DAOPedido dao = new DAOPedido();
            dao.insertPedido(pedido3);
        }
        //
        public void DL_Productos4(UDetalle_pedido det_pedido)
        {
            new DAODetalle_Pedido().insertdetallePedido(det_pedido);
        }
        //
        public string mostrarcantidadtotal(int idusuario){            
                DAOPedido dpedido = new DAOPedido();
                List<UPedido> pedido3 = new List<UPedido>();
                UUsuario usuario3 = new UUsuario();
                pedido3 = dpedido.PedidosTotal(idusuario);
                int total = 0;
                foreach (var item in pedido3){
                    total++;
                }
                return total.ToString();
        }
        //
    }
}
