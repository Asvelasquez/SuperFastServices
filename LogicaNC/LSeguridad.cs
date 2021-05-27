using Utilitarios;
using DataNC;
namespace LogicaNC
{
    public class LSeguridad
    {
        private readonly Mapeo _context;
        public UAplicacion ObtenerConfiguracion(string token)
        {
            return new DAOSeguridad(_context).getAplicaionesByToken(token);
        }
    }
}
