using DataNC;
using Utilitarios;


namespace LogicaNC
{
    public class Lregistar_domiciliario{

        public void LBTND_registrar(string correo){
            DAOUsuario dAOUsuario = new DAOUsuario();
            new DAOUsuario().getCorreoByregistrarse(correo);
        }
       
        public void LBTND_registrar1(UUsuario domiciliario)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            new DAOUsuario().insertUsuario(domiciliario);
        }
     
    }
}
