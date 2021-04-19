using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;
namespace Logica
{
    public class LSeguridad
    {
        public UAplicacion ObtenerConfiguracion(string token)
        {
            return new DAOSeguridad().getAplicaionesByToken(token);
        }
    }
}
