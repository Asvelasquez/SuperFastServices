using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;

namespace Logica
{
   
     public class LReportes
    {
        UMac datos = new UMac();
        public SuministroInformacion generarFactura(int facturaId)
        {
            SuministroInformacion informe = new SuministroInformacion();
            UPedido factura = new DAOPedido().obtenerFactura(facturaId);

            DataTable datosFinal = informe.Factura;
            DataRow fila;

            foreach (var item in factura.Compras)
            {
                fila = datosFinal.NewRow();
                fila["No"] = factura.Id_pedido;
                fila["Fecha"] = factura.Fecha;
                fila["NombreCliente"] = factura.Nombre_cliente;
                fila["NombreProducto"] = item.Nombreprodet;
                fila["Cantidad"] = item.Cantidad;
                fila["ValorUnitario"] = item.V_unitario;
                fila["ValorTotal"] = item.V_total;

                datosFinal.Rows.Add(fila);
            }
            fila = datosFinal.NewRow();
            fila["NombreProducto"] = "Domicilio";
            fila["Cantidad"] = "1";
            fila["ValorUnitario"] = "3000";
            fila["ValorTotal"] = "3000";

            datosFinal.Rows.Add(fila);
            return informe;
        }//

        public UMac LGV_pedidocarrito0(int rowcount)
        {
      
            if (rowcount == 0)
            {
                datos.Verdadero = true;

               
            }
            else
            {
                datos.Falso = false;
            
            }

            return datos;
        }//

      
    }
}
