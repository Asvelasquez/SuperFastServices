using DataNC;
using Utilitarios;
namespace LogicaNC
{
    public class LRecuperarContrasenia {
        UMac datos = new UMac();
        //
        public UToken LPage_Load(string Request) {
          return new DAOSeguridad().getTokenByToken(Request.ToString());           
        }
        //
        public UUsuario LB_Cambiar1(UUsuario usuario){
            UUsuario usuar = new UUsuario();
            return usuar = new DAOUsuario().nuevacontrasenia(usuario);
        }
        //
        public void LB_Cambiar2(UUsuario usuario){            
            new DAOSeguridad().updateClave(usuario);
        }
        //
    }
    //
}//namespace
