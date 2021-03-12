using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
namespace Logica{
   public class LPerfil{
        UMac datos1 = new UMac();
        public UUsuario mostrar(int id){

         DAOUsuario us = new DAOUsuario();
         UUsuario usuario1 = new UUsuario();
           
         return usuario1 = us.mostrar(id);
         }
        //
        public string mostrar1() {
          return  datos1.Url=  "AccesoDenegado.aspx";
        }
        //
        public void BTN_guardar(UUsuario usuario1){
                DAOUsuario us = new DAOUsuario();
                us.actualizarperfil(usuario1);
        }//

        //
    }//class
}
