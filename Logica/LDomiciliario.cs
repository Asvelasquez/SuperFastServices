using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;


namespace Logica
{
     public class LDomiciliario
    {
        UMac respuesta = new UMac();
        public UMac GV_PedDomi(int rowcount)
        {
            if (rowcount == 0)
            {
                respuesta.Verdadero = true;
            }
            else
            {
                respuesta.Falso = false;
            }
            return respuesta;
        }
        public void DDL_Estado(UPedido pedido4,string idseleccion)
        {
            DAOPedido pedido3 = new DAOPedido();
            pedido3.actualizarPedidoDomiciliario(pedido4, int.Parse(idseleccion));
            
        }
        //
        public void DDL_Estado0(UPedido pedido4,string idseleccion)
        {
            DAOPedido pedido3 = new DAOPedido();
           
            if (int.Parse(idseleccion) == 5)
            {
                pedido3.actualizarPedidoDomiciliario(pedido4, 1);   
            }
            else
            {
                pedido3.actualizarPedidoDomiciliario(pedido4, int.Parse(idseleccion));
            }

        }
    }
}
