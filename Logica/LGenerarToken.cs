using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;


namespace Logica
{
    public class LGenerarToken{
        string respuesta;
        public string LB_Recuperar(String TB_Correo,UToken token1,UUsuario usuario){
          //  UUsuario usuario = new DAOUsuario().getUserByUserName(TB_Correo);

            if (usuario != null){
                UToken validarToken = new DAOSeguridad().getTokenByUser(usuario.Id);
                //if (validarToken != null)
                //{
                //    L_Mensaje.Text = "Ya extsite un token, por favor verifique su correo.";
                //}
                //else
                //{
                //UToken token = new UToken();
                //token.Creado = token1.Creado;
                //token.User_id = usuario.Id;
                //token.Vigencia = token1.Vigencia;
                //token.Tokeng = token1.Tokeng;

                new DAOSeguridad().insertarToken(token1);
                Correo correo = new Correo();
                new DAOUsuario().getCorreoByCorreos(usuario.Correo);
                String mensaje = "su link de acceso es: " + "http://localhost:56248/View/RecuperarContrasenia.aspx?" + token1.Tokeng;
                correo.enviarCorreo(usuario.Correo, token1.Tokeng, mensaje);
                respuesta= "Su nueva contraseña ha sido enviada a su correo";
                //}
            }else{
                respuesta= "El usurio digitado no existe";
            }
            return respuesta;
        }
        //
        public UUsuario LB_Recuperar2(String TB_Correo)
        {
            return  new DAOUsuario().getUserByUserName(TB_Correo);


        }
        //
        public UToken LB_Recuperar3(UUsuario usuario)
        {
            return new DAOSeguridad().getTokenByUser(usuario.Id);
        }
        public  void  LB_Recuperar4(UToken token)
        {
             new DAOSeguridad().insertarToken(token);
        }
        public void LB_Recuperar5(UUsuario usuario)
        {
            new DAOUsuario().getCorreoByCorreos(usuario.Correo);
        }
    }
}
