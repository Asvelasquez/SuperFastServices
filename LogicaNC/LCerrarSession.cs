using System.Collections.Generic;
using DataNC;
using Utilitarios;


namespace LogicaNC
{
    public class LCerrarSession
    {
        private readonly Mapeo _context;
        public string Page_Load(int usuario1)
        {

            List<UToken_Seguridad> tokenSeguridadLista = new List<UToken_Seguridad>();
            UToken_Seguridad tokenSeguridad = new UToken_Seguridad();
            DAOSeguridad daoSeguridad = new DAOSeguridad(_context);
            tokenSeguridadLista = daoSeguridad.recorrerTokenSeguridad();
            string respuesta="";
            int count = 0;
            if(tokenSeguridadLista==null)
            {
                respuesta = "no existen registros";
            }
            else
            {
                foreach (var item in tokenSeguridadLista)
                {

                    if (item.UserId == usuario1)
                    {
                        count++;
                        new DAOSeguridad(_context).destruirToken(usuario1);
                        //  new DAOSeguridad().cerrarAcceso(usuario1);
                        respuesta = "session cerrada exitosamente";
                    }
                    else
                    {
                        if (count > 0)
                        {
                            respuesta = "session cerrada exitosamente";
                        }
                        else
                        {
                            respuesta = "usuario no encontrado";
                        }
                    }
                }
              
            }
            return respuesta;
            // Response.Redirect("Login.aspx");
        }

    }
}
