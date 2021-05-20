using DataNC;
using Utilitarios;
namespace LogicaNC
{
    public  class LPedidosaliado{
        UMac datos = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if (usuario1 != null) {
                if (usuario1.Id_rol != 2){
                    datos.Url = "AccesoDenegado.aspx";
                }
            }else{
                datos.Url = "AccesoDenegado.aspx";
            }
            return datos;
        }
        //
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
