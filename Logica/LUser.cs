using System;
using Utilitarios;
using Data;

namespace Logica
{
   
    public class LUser {
        string redireccion1;
        public void InsertarAcceso(UAcceso acceso) {

            new DAOSeguridad().insertarAcceso(acceso);
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
