using DataNC;
using Utilitarios;


namespace LogicaNC
{
    public class LRegistrar_aliado
    {
        private readonly Mapeo _context;
        //prueba
        //prueba2
        public UUsuario LBTN_registrar(string correo)
        {              
                DAOUsuario dAOUsuario = new DAOUsuario(_context);   
            
         return      dAOUsuario.getCorreoByregistrarse(correo);
               
        }
        public void LBTN_registrar1(UUsuario aliado1)
        {
            new DAOUsuario(_context).insertUsuario(aliado1);
        }

    }
}
