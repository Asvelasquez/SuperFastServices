using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;

namespace Logica
{
   public class Ladministrador
    {
        UMac datos = new UMac();
        public void LPage_Load(int idrol){
                if (idrol != 4)
                {
                    datos.Url = ("AccesoDenegado.aspx");
                }
          
        }
            public void LGV_domiciliariiosaprobar(UUsuario usuario3, string Lcorreo, string comandname){
            
            DAOUsuario us = new DAOUsuario();
            UUsuario usuario1 = new UUsuario();
            UUsuario usuario2 = new UUsuario();
            usuario1.Id = usuario3.Id;
            usuario2.Hojavida = usuario3.Hojavida;
            if (comandname == "Aceptar"){
                us.aceptarusuario(usuario1,Lcorreo);
                //GV_domiciliariiosaprobar.DataBind();
            }else if (comandname == "Rechazar"){
                us.rechazarusuario(usuario1,Lcorreo);
                //GV_domiciliariiosaprobar.DataBind();
            }else if (comandname == "hojavida"){
                datos.Url = ("window.open(usuario2, '_newtab');");
            }
        }//

        public void LGV_aliadoaprobar(UUsuario usuario3, string Lcorreo, string comandname)
        {
            DAOUsuario us = new DAOUsuario();
            UUsuario usuario1 = new UUsuario();
            usuario1.Id = usuario3.Id;
            if (comandname == "Aceptar") {
                us.aceptarusuario(usuario1, Lcorreo);
            }else if (comandname == "Rechazar"){
                us.rechazarusuario(usuario1, Lcorreo);
            }
        }
        //
        public void LGV_aliadorechazado(UUsuario usuario3, string Lcorreo, string comandname)
        {
            DAOUsuario us = new DAOUsuario();
            UUsuario usuario1 = new UUsuario();
            usuario1.Id = usuario3.Id;
            if (comandname == "Aceptar"){
                us.aceptarusuario(usuario1, Lcorreo);
                //  GV_aliadorechazado.DataBind();
            }
            else if (comandname == "Revision"){
                us.revisionusuario(usuario1, Lcorreo);
                // GV_aliadorechazado.DataBind();
            }
        }
        //

        public void LGV_domiciliariorechazado(UUsuario usuario3, string Lcorreo, string comandname)
        {
            DAOUsuario us = new DAOUsuario();
            UUsuario usuario1 = new UUsuario();
            usuario1.Id = usuario3.Id;
            if (comandname == "Aceptar"){
                us.aceptarusuario(usuario1, Lcorreo);
            }else if (comandname == "Revision") {
                us.revisionusuario(usuario1, Lcorreo);
            }
        }
        //
        public void LGV_solicitudaliadosaceptados(UUsuario usuario3, string Lcorreo, string comandname)
        {
            DAOUsuario us = new DAOUsuario();
            UUsuario usuario1 = new UUsuario();
            usuario1.Id = usuario3.Id;
            if (comandname == "Rechazar"){
                us.rechazarusuario(usuario1, Lcorreo);
            }
        }
        //
        public void LGV_domiciliariosaceptados(UUsuario usuario3, string Lcorreo, string comandname){
            DAOUsuario us = new DAOUsuario();
            UUsuario usuario1 = new UUsuario();
            usuario1.Id = usuario3.Id;
            if (comandname == "Rechazar") { 
                us.rechazarusuario(usuario1, Lcorreo);
            }
        }





    }
}
