﻿using System.Collections.Generic;
using DataNC;
using Utilitarios;
namespace LogicaNC
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
