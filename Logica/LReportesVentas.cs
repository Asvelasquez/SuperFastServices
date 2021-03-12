using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
namespace Logica{
   public class LReportesVentas {
        UMac datos = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if(usuario1 != null){
                if (usuario1.Id_rol != 2){
                    datos.Url = "AccesoDenegado.aspx";
                }
            }else{
                datos.Url = "AccesoDenegado.aspx";
            }
            return datos;
        }
        //
      

        //
        public List<UDetalle_pedido> obtenerInformacion(int id) {
           return new DAOPedido().productosVendidosXFecha(id);
        }
        //
        }
    }
