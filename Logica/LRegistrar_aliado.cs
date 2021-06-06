using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Data;
using Utilitarios;


namespace Logica
{
   public class LRegistrar_aliado
    {
        UMac datos = new UMac();
        //prueba
        //prueba2
        public UUsuario LBTN_registrar(string correo)
        {              
                DAOUsuario dAOUsuario = new DAOUsuario();   
            
         return      dAOUsuario.getCorreoByregistrarse(correo);
               
        }
        public void LBTN_registrar21(UUsuario aliado1)
        {
            new DAOUsuario().insertUsuario(aliado1);
        }
        public string LBTN_registrar1(byte[] Foto_logo, byte[] rut, UUsuario usuario, string extension_logo,string extension_rut, string direccion_logo, string direccion_rut)
        {
            if (Foto_logo != null){
                extension_logo = extension_logo.ToLower();//Extension de la imagen y minusculas
                extension_rut= extension_rut.ToLower();
                if (extension_logo == "jpg" || extension_logo == "jpeg" || extension_logo == "png"){
                    if (extension_rut=="pdf") {
                        try{
                            string direc = HttpContext.Current.Server.MapPath(direccion_logo);
                            FileStream fileStream = new FileStream(direc, FileMode.Create, FileAccess.ReadWrite);
                            fileStream.Write(Foto_logo, 0, Foto_logo.Length);//mapea y guarda el archivo en la direccion
                            fileStream.Close();

                            string direcrut = HttpContext.Current.Server.MapPath(direccion_rut);
                            FileStream fileStreamrut = new FileStream(direcrut, FileMode.Create, FileAccess.ReadWrite);
                            fileStreamrut.Write(rut, 0, rut.Length);//mapea y guarda el archivo en la direccion
                            fileStreamrut.Close();
                        //    new DAOUsuario().insertUsuario(usuario);
                            datos.Url = "Registro exitoso";
                        }catch (Exception ex){
                            datos.Url = "No se pudo agregar producto    " + ex;
                        }
                    }else{
                        datos.Url = "Extension no valida, intentelo de nuevo";
                    }

                }
                else { }
            }else{
                datos.Url = "Foto Vacia, intentelo de nuevo";
            }

            return datos.Url;
        }
    }
}
