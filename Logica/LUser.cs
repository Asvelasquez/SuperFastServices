using System;
using Utilitarios;
using Data;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Logica
{

    public class LUser
    {
        string redireccion1;
        //public void InsertarAcceso(UAcceso acceso)
        //{

        //    new DAOSeguridad().insertarAcceso(acceso);
        //}

        public void InsertarAcceso(UAcceso acceso)
        {
            new DAOSeguridad().insertarAcceso(acceso);
        }

        //public UUsuario LG_Principal(UUsuario usuario1)
        //{
        //    UUsuario usuario = new UUsuario();

        //    return usuario = new DAOUsuario().loginusuario(usuario1);


        //}
        public List<UUsuario> ObtenerUsuarios()
        {
            return new DAOUsuario().ObtenerUsuarios();
        }
        // login normal
        public async Task< UUsuario> LG_Principal1( UUsuario usuario1)
        {
            UUsuario usuario =   new UUsuario();
            UMac mensaje = new UMac();
           return   usuario = await new  DAOUsuario().loginusuario(usuario1);
           
        }
        //request
        public  async Task<UUsuario> LG_Principal2(LoginRequest usuario1)
        {
            UUsuario usuario = new UUsuario();
            UMac mensaje = new UMac();
            return usuario =await new DAOUsuario().loginusuario1(usuario1);

        }
        //ejemplo obtener usuarios
        //public async  Task<List<UUsuario>>  ObtenerUsuarioAsync()
        //{
        //    return await new DAOUsuario().ObtenerUsuarios();
        //}

        //public string Llogin1(UUsuario usuario9)
        //{
        //    if (usuario9 == null)
        //    {
        //        redireccion1 = "inicio.aspx";
        //    }
        //    else
        //    {
        //        if (usuario9.Id_rol == 1)
        //        {
        //            redireccion1 = "inicio.aspx";
        //        }
        //        else
        //        {
        //            if (usuario9.Id_rol == 2 && usuario9.Aprobacion == 1)
        //            {
        //                redireccion1 = "pedidosaliado.aspx";
        //            }
        //            if (usuario9.Id_rol == 3 && usuario9.Aprobacion == 1)
        //            {
        //                redireccion1 = "Domiciliario.aspx";
        //            }
        //            if (usuario9.Id_rol == 4 && usuario9.Aprobacion == 1)
        //            {
        //                redireccion1 = "administrador.aspx";
        //            }
        //        }
        //    }
        //    return redireccion1;
        //}
        public string Llogin1(UUsuario usuario9)
        {
            if (usuario9 == null)
            {
                redireccion1 = "inicio.aspx";
            }
            else
            {
                if (usuario9.Id_rol == 1)
                {
                    redireccion1 = "inicio.aspx";
                }
                else
                {
                    if (usuario9.Id_rol == 2 && usuario9.Aprobacion == 1)
                    {
                        redireccion1 = "pedidosaliado.aspx";
                    }
                    if (usuario9.Id_rol == 3 && usuario9.Aprobacion == 1)
                    {
                        redireccion1 = "Domiciliario.aspx";
                    }
                    if (usuario9.Id_rol == 4 && usuario9.Aprobacion == 1)
                    {
                        redireccion1 = "administrador.aspx";
                    }
                }
            }
            // return redireccion1 = await new LUser().Llogin1Async(usuario9);
            return redireccion1;

        }
        public string LLB_RecuperarContrasenia()
        {
            return redireccion1 = "GenerarToken.aspx";
        }
        //}


        public void guardarToken(UToken_Seguridad token_seguridad)
        {
            new DAOSeguridad().insertarToken_Seguridad(token_seguridad);
        }
    }
}
