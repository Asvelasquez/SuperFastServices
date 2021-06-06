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
    public class Lregistar_domiciliario{

        public void LBTND_registrar(string correo){
            DAOUsuario dAOUsuario = new DAOUsuario();
            new DAOUsuario().getCorreoByregistrarse(correo);
        }
       
        public void LBTND_registrar1(UUsuario domiciliario)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            new DAOUsuario().insertUsuario(domiciliario);
        }
        public string GuardarHojaVida(byte[] archivo, UUsuario usuario, string extension, string direccion)
        {
            UMac datos = new UMac();

            if (archivo != null)
            {
                extension = extension.ToLower();//Extension de la imagen y minusculas

                if (extension == ".pdf" )
                {
                    try
                    {
                        //FileStream fileStream = new FileStream(direccion, FileMode.Create, FileAccess.ReadWrite);
                        //fileStream.Write(Foto_producto, 0, Foto_producto.Length);
                        //fileStream.Close();
                        string direc = HttpContext.Current.Server.MapPath(direccion);
                        FileStream fileStream = new FileStream(direc, FileMode.Create, FileAccess.ReadWrite);
                        fileStream.Write(archivo, 0, archivo.Length);//mapea y guarda el archivo en la direccion
                        fileStream.Close();

                        new DAOUsuario().insertUsuario(usuario);
                        
                        datos.Url = "Aliado.aspx";
                    }
                    catch (Exception ex)
                    {
                        datos.Url = "No se pudo agregar producto    " + ex;
                    }

                }
                else
                {
                    datos.Url = "Extension no valida, intentelo de nuevo";
                }

            }
            else
            {
                datos.Url = "Foto No valida, intentelo de nuevo";
            }

            return datos.Url;

        }//
    }
}
