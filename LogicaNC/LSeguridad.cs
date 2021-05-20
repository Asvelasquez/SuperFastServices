using Utilitarios;
using DataNC;
namespace LogicaNC
{
    public class LSeguridad
    {
        public UAplicacion ObtenerConfiguracion(string token)
        {
            return new DAOSeguridad().getAplicaionesByToken(token);
        }
    }
}
