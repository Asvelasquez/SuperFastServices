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
    string mensaje;
    //
    protected void B_Recuperar_Click1(object sender, EventArgs e){

       // UUsuario usuario = new DAOUsuario().getUserByUserName(TB_Correo.Text);
        UUsuario usuario = lGenerarToken.LB_Recuperar2(TB_Correo.Text);
        // if (usuario != null){
        //     UToken validarToken = new DAOSeguridad().getTokenByUser(usuario.Id);
        //     //if (validarToken != null)
        //     //{
        //     //    L_Mensaje.Text = "Ya extsite un token, por favor verifique su correo.";
        //     //}
        //     //else
        //     //{
        //     UToken token = new UToken();
        //     token.Creado = DateTime.Now;
        //     token.User_id = usuario.Id;
        //     token.Vigencia = DateTime.Now.AddHours(1);
        //     token.Tokeng = encriptar(JsonConvert.SerializeObject(token));
        //     new DAOSeguridad().insertarToken(token);
        //     Correo correo = new Correo();
        //     new DAOUsuario().getCorreoByCorreos(usuario.Correo);
        //     String mensaje = "su link de acceso es: " + "http://localhost:56248/View/RecuperarContrasenia.aspx?" + token.Tokeng;
        //     correo.enviarCorreo(usuario.Correo, token.Tokeng, mensaje);
        //     LB_Mensaje.Text = "Su nueva contraseña ha sido enviada a su correo";
        //     //}
        // }else{
        //     LB_Mensaje.Text = "El usurio digitado no existe";
        // }

        string TB_correo1 = TB_Correo.Text;
        
        
       mensaje = lGenerarToken.LB_Recuperar(TB_correo1,token,usuario);
        LB_Mensaje.Text = mensaje;

    }
    //
    protected void B_Recuperar_Click(object sender, EventArgs e)
    {
        UUsuario usuario = lGenerarToken.LB_Recuperar2(TB_Correo.Text);

        if (usuario != null)
        {
            UToken validarToken = lGenerarToken.LB_Recuperar3(usuario);
            //if (validarToken != null)
            //{
            //    L_Mensaje.Text = "Ya extsite un token, por favor verifique su correo.";
            //}
            //else
            //{
            UToken token = new UToken();
            token.Creado = DateTime.Now;
            token.User_id = usuario.Id;
            token.Vigencia = DateTime.Now.AddHours(1);

            token.Tokeng = encriptar(JsonConvert.SerializeObject(token));
            //new DAOSeguridad().insertarToken(token);
            lGenerarToken.LB_Recuperar4(token);
            Correo correo = new Correo();

            // new DAOUsuario().getCorreoByCorreos(usuario.Correo);
            //http://localhost:56248/View/RecuperarContrasenia.aspx?
            lGenerarToken.LB_Recuperar5(usuario);
             String mensaje = "su link de acceso es: " + "https://www.superfastisw.tk/View/RecuperarContrasenia.aspx?" + token.Tokeng;
              //  String mensaje = "su link de acceso es: " + "http://localhost:56248/View/RecuperarContrasenia.aspx?" + token.Tokeng;
            correo.enviarCorreo(usuario.Correo, token.Tokeng, mensaje);

            LB_Mensaje.Text = "Su nueva contraseña ha sido enviada a su correo";
            //}
        }

        else
        {
            LB_Mensaje.Text = "El usurio digitado no existe";
        }

    }
    //

    


}