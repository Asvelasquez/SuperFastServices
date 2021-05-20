﻿using System.Collections.Generic;
using Utilitarios;
using DataNC;
namespace LogicaNC
{
    public class LReportesVentasAdmin{
        UMac datos = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if (usuario1 != null){
                if (usuario1.Id_rol != 4){
                    datos.Url = "AccesoDenegado.aspx";
                }
            }else {
                datos.Url = "AccesoDenegado.aspx";
            }
            return datos;
        }
        //
        //
        public List<UDetalle_pedido> obtenerInformacion(int id){
            return new DAOPedido().productosVendidos(id);
        }
            //
    }
}
