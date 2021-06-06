using System;
using Utilitarios;
using Data;
using System.IO;
using System.Web;

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

       
//    public UPerfil subirFoto(byte[] foto, URegistro session, string direccion, string ext, string imagenEliminar)
//        {​​​
//                UPerfil datos = new UPerfil();
//            if (foto != null)
//            {​​​
//                ext = ext.ToLower();//Extension de la imagen y minusculas

//                //int tam = foto.PostedFile.ContentLength;//obtiene tamano archivo
//                //string fotoperfil;
//                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg"))//menor a 1MB en bytes (tam < 1048576)
//                {​​​
//                try
//                    {​​​
////                        imagen
//                        string direc = HttpContext.Current.Server.MapPath(direccion);
//                        FileStream fileStream = new FileStream(direc, FileMode.Create, FileAccess.ReadWrite);
//                        fileStream.Write(foto, 0, foto.Length);//mapea y guarda el archivo en la direccion
//                        fileStream.Close();
//                        datos.Mensaje = "*Imagen aceptada";
//                        //actualiza foto de perfil
//                        URegistro nuevodat = new URegistro();
//                        nuevodat.Id = session.Id;
//                        nuevodat.Fotoperfil = direccion;
//                        new DAOLogin().actualizarfoto(nuevodat);

//                        if (File.Exists(imagenEliminar))
//                        {​​​
//                            File.Delete(imagenEliminar);
//                        }​​​
//                            session.Fotoperfil = nuevodat.Fotoperfil;
//                        datos.Fotoperfil = nuevodat.Fotoperfil;
//                        datos.Mensaje = "*Imagen cargada con exito";
//                    }​​​
//                        catch (Exception ex)
//                    {​​​
//                        datos.Mensaje = "*Verifique la imagen y cargue nuevamente";
//                    }​​​
//                }​​​
//                else
//                    {​​​
//                        datos.Mensaje = "*Imagen no esta en formato correcto o es muy pesada";
//                }​​​
//            }​​​
//            else
//                            {​​​
//            datos.Mensaje = "*Selecciona una imagen";
//                      }​​​
//                return datos;
//                        }​​​


        //
        public string LBTN_guardarproducto(byte[] Foto_producto,UProducto producto,string extension, string direccion){
            
            if(Foto_producto!= null){
                extension = extension.ToLower();//Extension de la imagen y minusculas

                if (extension == ".jpg"||  extension == ".jpeg"|| extension == ".png"){
                    try{
                        //FileStream fileStream = new FileStream(direccion, FileMode.Create, FileAccess.ReadWrite);
                        //fileStream.Write(Foto_producto, 0, Foto_producto.Length);
                        //fileStream.Close();
                        string direc = HttpContext.Current.Server.MapPath(direccion);
                        FileStream fileStream = new FileStream(direc, FileMode.Create, FileAccess.ReadWrite);
                        fileStream.Write(Foto_producto, 0, Foto_producto.Length);//mapea y guarda el archivo en la direccion
                        fileStream.Close();                       
                        
                       
                        new DAOProductos().insertProducto(producto);
                        datos.Url = "Aliado.aspx";
                    }
                    catch (Exception ex)
                    {
                        datos.Url = "No se pudo agregar producto    "+ex;
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
    }
}
