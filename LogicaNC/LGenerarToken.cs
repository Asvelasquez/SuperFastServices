using DataNC;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using Utilitarios;


namespace LogicaNC
{
    public class LGenerarToken{
        string respuesta;
        private readonly Mapeo _context;
        public string LB_Recuperar(String TB_Correo){
          UUsuario usuario = new DAOUsuario(_context).getUserByUserName(TB_Correo);

            if (usuario != null){
                UToken validarToken = new DAOSeguridad(_context).getTokenByUser(usuario.Id);
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
                new DAOSeguridad(_context).insertarToken(token);
                Correo correo = new Correo();
                new DAOUsuario(_context).getCorreoByCorreos(usuario.Correo);
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
            return  new DAOUsuario(_context).getUserByUserName(TB_Correo);


        }
        //
        public UToken LB_Recuperar3(UUsuario usuario)
        {
            return new DAOSeguridad(_context).getTokenByUser(usuario.Id);
        }
        public  void  LB_Recuperar4(UToken token)
        {
             new DAOSeguridad(_context).insertarToken(token);
        }
        public void LB_Recuperar5(UUsuario usuario)
        {
            new DAOUsuario(_context).getCorreoByCorreos(usuario.Correo);
        }
    }
}
