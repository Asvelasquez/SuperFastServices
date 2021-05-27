using Utilitarios;
using DataNC;
namespace LogicaNC
{
    public class LPerfil{
        UMac datos1 = new UMac();
        private readonly Mapeo _context;
        //

        public UUsuario mostrar(int id){
         DAOUsuario us = new DAOUsuario(_context);
         UUsuario usuario1 = new UUsuario();           
         return usuario1 = us.mostrar(id);
         }
        //
        public string mostrar1() {
          return  datos1.Url=  "AccesoDenegado.aspx";
        }
        //
        public void BTN_guardar(UUsuario usuario1){
                DAOUsuario us = new DAOUsuario(_context);
                us.actualizarperfil(usuario1);
        }//

        //
    }//class
}
