using System;
using Utilitarios;
using Data;


namespace Logica{

    public class LAliado {
        URespuesta respuesta = new URespuesta();
        UMac datos = new UMac();
        //
        public string LBTN_guardarproducto(UProducto producto2){
            new DAOProductos().insertProducto(producto2);
             return  datos.Url="Aliado.aspx";    

        }//
        public UMac LGV_Producto(UProducto producto1,string err,int idmostrar ) {
            
            DAOProductos us = new DAOProductos();
            UProducto producto2 = new UProducto();
            producto2.Id = producto1.Id;
            if (err == "Editar"){
              datos.Falso = false;
              datos.Verdadero = true;
                Lmostrar(idmostrar);  
            }
            else if (err == "Desactivar"){
                us.Desactivarproducto(producto1);
            }
            return datos;
        }//
       public UProducto Lmostrar(int id3)  {
            DAOProductos productos1 = new DAOProductos();
            UProducto productos2 = new UProducto();
            productos2 = productos1.mostrar(id3);
            return productos2;
        }
        //
        //
        public string LBTN_GuardarCambios(UProducto producto2){
            new DAOProductos().updateproducto(producto2);           
            return datos.Url = "Aliado.aspx";

        }//
        //  
        public UMac LGV_Productosdesactivado(UProducto producto1, string err, int idmostrar) {
            DAOProductos us = new DAOProductos();
            UProducto producto2 = new UProducto();
            producto2.Id = producto1.Id ;
            if (err == "Editar"){
                datos.Falso = false;
                datos.Verdadero = true;
                Lmostrar(idmostrar);             
            }
            else if (err == "Activar") {
                us.Activarproducto(producto2);             
            }
            return datos;
        }
        //
        //public UMac PLoad()
        //{

        //    UMac datos = new UMac();
        //    datos.Url = "hol";
    }
}
