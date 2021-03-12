using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;


namespace Logica
{
   public class LRegistrar_aliado
    {
        //prueba
        public UUsuario LBTN_registrar(string correo)
        {              
                DAOUsuario dAOUsuario = new DAOUsuario();   
            
         return      dAOUsuario.getCorreoByregistrarse(correo);
               
        }
        public void LBTN_registrar1(UUsuario aliado1)
        {
            new DAOUsuario().insertUsuario(aliado1);
        }

    }
}
