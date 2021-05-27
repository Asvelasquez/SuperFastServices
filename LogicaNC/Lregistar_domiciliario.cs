using DataNC;
using Utilitarios;


namespace LogicaNC
{
    public class Lregistar_domiciliario{
        private readonly Mapeo _context;
        public void LBTND_registrar(string correo){
            DAOUsuario dAOUsuario = new DAOUsuario(_context);
            new DAOUsuario(_context).getCorreoByregistrarse(correo);
        }
       
        public void LBTND_registrar1(UUsuario domiciliario)
        {
            DAOUsuario dAOUsuario = new DAOUsuario(_context);
            new DAOUsuario(_context).insertUsuario(domiciliario);
        }
     
    }
}
