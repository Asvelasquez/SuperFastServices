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
        UMac datos = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if (usuario1 != null){
                if (usuario1.Id_rol == 2){
                    datos.Url = "pedidosaliado.aspx";
                }else if (usuario1.Id_rol == 3){
                    datos.Url ="Domiciliario.aspx";
                } else if (usuario1.Id_rol == 4){
                    datos.Url = "administrador.aspx";
                }
            }
            return datos;
        }
        //
        public void actualizarPrecioPedido(UPedido pedido)
        {
            DAOPedido daopedido = new DAOPedido();
            daopedido.actualizarPrecioPedido(pedido);
            
        }
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
        public void AgregarPedidoCarrito1(UPedido pedido)
        {
            DAOPedido daopedido = new DAOPedido();
            daopedido.insertPedido(pedido);
        }
        public void AgregarPedidoCarrito2(UDetalle_pedido det_pedido)
        {
            DAODetalle_Pedido daodetpedido = new DAODetalle_Pedido();
            daodetpedido.insertdetallePedido(det_pedido);
        }
    }
}
