using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
   public class URespuesta
    {
        private string mensaje;
        private string mac;
        private string acceso;
        private string url;
        

        public string Mensaje { get => mensaje; set => mensaje = value; }

        public string Mac { get => mac; set => mac = value; }
        public string Acceso { get => acceso; set => acceso = value; }
        public string Url { get => url; set => url = value; }
    }
}
