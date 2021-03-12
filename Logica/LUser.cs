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

        public string Llogin1(int idrol3,int aprobacion1){
            if (idrol3 == 0)
            {
                redireccion1 = "inicio.aspx";
            }
            if (idrol3 == 1){
                redireccion1 = "inicio.aspx";
                }else{
                    if (idrol3 == 2 && aprobacion1 == 1){
                    redireccion1 = "pedidosaliado.aspx";
                    }
                if (idrol3 == 3 && aprobacion1 == 1){
                    redireccion1 = "Domiciliario.aspx";
                    }
                if (idrol3 == 4 && aprobacion1 == 1){
                    redireccion1 = "administrador.aspx";
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
