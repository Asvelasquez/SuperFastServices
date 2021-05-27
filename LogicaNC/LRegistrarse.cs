using Utilitarios;
using DataNC;
namespace LogicaNC
{
    public class LRegistrarse {
        private readonly Mapeo _context;
        //
        public UUsuario LBT_Registrar(string correo){              
                DAOUsuario dAOUsuario = new DAOUsuario(_context);
            return dAOUsuario.getCorreoByregistrarse(correo); 
        }
        //
        public void LBT_Registrar1(UUsuario cliente1)
        {
            
            
            
            new DAOUsuario(_context).insertUsuario(cliente1);

        }

    }
}
