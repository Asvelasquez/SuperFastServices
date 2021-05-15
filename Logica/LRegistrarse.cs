using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
namespace Logica{
   public class LRegistrarse {

        //
        public UUsuario LBT_Registrar(string correo){              
                DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.getCorreoByregistrarse(correo); 
        }
        //
        public void LBT_Registrar1(UUsuario cliente1)
        {
            
            
            
            new DAOUsuario().insertUsuario(cliente1);

        }

    }
}
