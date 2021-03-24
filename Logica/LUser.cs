using System;
using Utilitarios;
using Data;

namespace Logica
{
   
    public class LUser {
        string redireccion1;
        public UMac Llogin(UUsuario usuario) {
            UMac datos = new UMac();
            MAC mac = new MAC();

            datos.Usuario = new DAOUsuario().loginusuario(usuario);
            datos.Fecha_Inicio1 = DateTime.Now;

            datos.Ip = mac.ip();
            datos.Mac = mac.mac();


            datos.User_id = usuario.Id;

            return datos;
        }
        public UUsuario LG_Principal(UUsuario usuario1)
        {
            UUsuario usuario = new UUsuario();
          
          return  usuario = new DAOUsuario().loginusuario(usuario1);
           
        }
            public string Llogin1(UUsuario usuario9) {
            if (usuario9 == null)
            {
                redireccion1 = "inicio.aspx";
            }
            else { 
            if (usuario9.Id_rol == 1) {
                redireccion1 = "inicio.aspx";
            } else {
                if (usuario9.Id_rol == 2 && usuario9.Aprobacion == 1) {
                    redireccion1 = "pedidosaliado.aspx";
                }
                if (usuario9.Id_rol == 3 && usuario9.Aprobacion == 1) {
                    redireccion1 = "Domiciliario.aspx";
                }
                if (usuario9.Id_rol == 4 && usuario9.Aprobacion == 1) {
                    redireccion1 = "administrador.aspx";
                }
            }
        }
            return redireccion1;
        }
        public string LLB_RecuperarContrasenia()
        {
           return redireccion1 = "GenerarToken.aspx";
        }
        //}
    }
}
