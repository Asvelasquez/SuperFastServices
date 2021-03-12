using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using Newtonsoft.Json;
using Utilitarios;
using Logica;
public partial class View_GenerarToken : System.Web.UI.Page
{
    LGenerarToken lGenerarToken = new LGenerarToken();
    protected void Page_Load(object sender, EventArgs e){

    }
    protected void B_Recuperar_Click(object sender, EventArgs e){
       ////UUsuario usuario = new DAOUsuario().getUserByUserName(TB_Correo.Text);

       //// if (usuario != null){
       ////     UToken validarToken = new DAOSeguridad().getTokenByUser(usuario.Id);
       ////     //if (validarToken != null)
       ////     //{
       ////     //    L_Mensaje.Text = "Ya extsite un token, por favor verifique su correo.";
       ////     //}
       ////     //else
       ////     //{
       ////     UToken token = new UToken();
       ////     token.Creado = DateTime.Now;
       ////     token.User_id = usuario.Id;
       ////     token.Vigencia = DateTime.Now.AddHours(1);
       ////     token.Tokeng = encriptar(JsonConvert.SerializeObject(token));
       ////     new DAOSeguridad().insertarToken(token);
       ////     Correo correo = new Correo();
       ////     new DAOUsuario().getCorreoByCorreos(usuario.Correo);
       ////     String mensaje = "su link de acceso es: " + "http://localhost:56248/View/RecuperarContrasenia.aspx?" + token.Tokeng;
       ////     correo.enviarCorreo(usuario.Correo, token.Tokeng, mensaje);
       ////     LB_Mensaje.Text = "Su nueva contraseña ha sido enviada a su correo";
       ////     //}
       //// }else{
       ////     LB_Mensaje.Text = "El usurio digitado no existe";
       //// }

        string TB_correo1 = TB_Correo.Text;
        UToken token = new UToken();
        token.Creado = DateTime.Now;
      //  token.User_id = usuario.Id;
        token.Vigencia = DateTime.Now.AddHours(1);
        token.Tokeng = encriptar(JsonConvert.SerializeObject(token));
        
        lGenerarToken.LB_Recuperar(TB_correo1,token);


    }

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


}