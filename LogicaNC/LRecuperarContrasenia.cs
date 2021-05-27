using DataNC;
using Utilitarios;
namespace LogicaNC
{
    public class LRecuperarContrasenia {
        private readonly Mapeo _context;
        UMac datos = new UMac();
        //
        public UToken LPage_Load(string Request) {
          return new DAOSeguridad(_context).getTokenByToken(Request.ToString());           
        }
        //
        public UUsuario LB_Cambiar1(UUsuario usuario){
            UUsuario usuar = new UUsuario();
            return usuar = new DAOUsuario(_context).nuevacontrasenia(usuario);
        }
        //
        public void LB_Cambiar2(UUsuario usuario){            
            new DAOSeguridad(_context).updateClave(usuario);
        }
        //
    }
    //
}//namespace
