using System;
using Utilitarios;
using Data;
using System.IO;

namespace Logica{

    public class LAliado {

        URespuesta respuesta = new URespuesta();
        UMac datos = new UMac();
        //
        public UMac LPage_Load(UUsuario usuario1){
            if (usuario1 != null){
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
        public string LBTN_guardarproducto(byte[] Foto_producto,UProducto producto,string extension, string direccion){
            
            if(Foto_producto!= null){
                if (extension == ".jpg"|| extension == ".JPG"|| extension == ".jpeg"|| extension == ".JPEG"|| extension == ".png"|| extension == ".PNG"){
                    try{
                        FileStream fileStream = new FileStream(direccion, FileMode.Create, FileAccess.ReadWrite);
                        fileStream.Write(Foto_producto, 0, Foto_producto.Length);
                        fileStream.Close();

                        new DAOProductos().insertProducto(producto);
                        datos.Url = "Aliado.aspx";
                    }
                    catch{
                        datos.Url = "No se pudo agregar producto";
                    }

                }else{
                    datos.Url = "Extension no valida, intentelo de nuevo";
                }

            }else{
                datos.Url = "Foto No valida, intentelo de nuevo";
            }

            return datos.Url;

        }//
        public UMac LGV_Producto(UProducto producto1,string comandname, int idmostrar ) {
            
            DAOProductos us = new DAOProductos();            
            if (comandname == "Editar"){
              datos.Falso = false;
              datos.Verdadero = true;
            datos.UmacUproducto1=  Lmostrar(idmostrar);  
            }else if (comandname == "Desactivar"){
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
                datos.UmacUproducto1 = Lmostrar(idmostrar);             
            }else if (err == "Activar") {
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
