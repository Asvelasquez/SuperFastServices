﻿using DataNC;
using Utilitarios;


namespace LogicaNC
{
    public class LDomiciliario
    {
        UMac respuesta = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if (usuario1 != null){
                if (usuario1.Id_rol != 3){
                    respuesta.Url = "AccesoDenegado.aspx";
                }
            }else{
                respuesta.Url = "AccesoDenegado.aspx";
            }
            return respuesta;
        }
        //
        public UMac GV_PedDomi(int rowcount){
            if (rowcount == 0){
                respuesta.Decision = true;
            }else{
                respuesta.Decision = false;
            }
            return respuesta;
        }
        //
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
