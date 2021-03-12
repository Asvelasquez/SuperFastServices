using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;

namespace Logica
{
    public class LPedidosCliente
    {
        string redireccion;
        public void LGV_pedidocarrito(string ecommand,string ecommandarg)
        {
            
            DAOPedido daopedido = new DAOPedido();
            UPedido pedido2 = new UPedido();
            pedido2.Id_pedido = int.Parse(ecommandarg);
            if (ecommand == "Cancelar")
            {
                daopedido.Cancelarpedido(pedido2);
               

            }
        }
        public void LGV_pedidocarrito0(string ecommand,UPedido pedido4)
        {
            DAOPedido daop = new DAOPedido();
            if (ecommand == "Guardar")
            {
                daop.guardarcomentariocliente(pedido4);
                
            }
        }//

        public string LBTN_Generarfactura()
        {

           return redireccion="Reportes.aspx";

        }
    }
}
