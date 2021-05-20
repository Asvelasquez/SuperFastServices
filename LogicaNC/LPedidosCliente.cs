using DataNC;
using Utilitarios;

namespace LogicaNC
{
    public class LPedidosCliente{
        
        UMac datos = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if (usuario1 != null)
            {
                if (usuario1.Id_rol != 1)
                {
                    datos.Url = "AccesoDenegado.aspx";
                }
            }
            else
            {
                datos.Url = "AccesoDenegado.aspx";
            }
            return datos;
        }
        //
        public void LGV_pedidocarrito(string comandname, string Id_pedido){
            DAOPedido daopedido = new DAOPedido();
            UPedido pedido2 = new UPedido();
            pedido2.Id_pedido = int.Parse(Id_pedido);
            if (comandname == "Cancelar"){
                daopedido.Cancelarpedido(pedido2);
            }
        }
        //
        public void LGV_pedidocarrito0(string comandname, UPedido pedido4){
            DAOPedido daop = new DAOPedido();
            if (comandname == "Guardar"){
                daop.guardarcomentariocliente(pedido4);
            }
        }
        //
        public UMac LBTN_Generarfactura(){
            datos.Url="Reportes.aspx";
            return datos;
        }
        //
    }
}
