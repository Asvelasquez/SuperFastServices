using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;


namespace Logica
{
    public class Lregistar_domiciliario
    {
        public void LBTND_registrar(string correo)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            new DAOUsuario().getCorreoByregistrarse(correo);
        }
       
        public void LBTND_registrar1(UUsuario domiciliario)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            new DAOUsuario().insertUsuario(domiciliario);
        }
        public UUsuario LBTND_registrar2(string correo)
        {
            
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.getCorreoByregistrarse(correo);
            
        }
    }
}
