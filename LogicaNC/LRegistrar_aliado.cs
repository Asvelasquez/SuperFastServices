using DataNC;
using Utilitarios;


namespace LogicaNC
{
    public class LRegistrar_aliado
    {
        //prueba
        //prueba2
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
