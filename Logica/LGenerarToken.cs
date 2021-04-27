using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using Newtonsoft.Json;
using Utilitarios;


namespace Logica
{
    public class LGenerarToken{
        string respuesta;
        public string LB_Recuperar(String TB_Correo){
          UUsuario usuario = new DAOUsuario().getUserByUserName(TB_Correo);

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
                UToken token = new UToken();
                token.Creado = DateTime.Now;
                token.User_id = usuario.Id;
                token.Vigencia = DateTime.Now.AddHours(1);
                token.Tokeng = encriptar(JsonConvert.SerializeObject(token));
                new DAOSeguridad().insertarToken(token);
                Correo correo = new Correo();
                new DAOUsuario().getCorreoByCorreos(usuario.Correo);
                String mensaje = "su link de acceso es: " + "http://localhost:56248/View/RecuperarContrasenia.aspx?" + token.Tokeng;
                correo.enviarCorreo(usuario.Correo, token.Tokeng, mensaje);
                respuesta= "Su nueva contraseña ha sido enviada a su correo";
                //}
            }else{
                respuesta= "El usuario digitado no existe";
            }
            return respuesta;
        }
        //
        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
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
