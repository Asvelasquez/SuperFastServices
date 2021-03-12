using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;


namespace Logica
{
     public class LCerrarSession
    {
        public void Page_Load(int Id)
        {
            new DAOSeguridad().cerrarAcceso(Id);
            
        }
    }
}
