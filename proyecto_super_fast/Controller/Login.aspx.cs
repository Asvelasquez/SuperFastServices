using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Login : System.Web.UI.Page{
    string redireccion1;
    int idrol2, aprobacion1;
    LUser luser1 = new LUser();
    protected void Page_Load(object sender, EventArgs e)
   {

    }
    protected void LG_Principal_Authenticate(object sender, AuthenticateEventArgs e){
        UUsuario usuario = new UUsuario();
        usuario.Correo = LG_Principal.UserName;
        usuario.Contrasenia = LG_Principal.Password;
        ClientScriptManager cm = this.ClientScript;
        //usuario = new DAOUsuario().loginusuario(usuario);
        UMac user = new LUser().Llogin(usuario);
        Session["user"] = user.Usuario;
        // URespuesta resp = new UMac().Usuario(usuario);
        if (usuario == null){   
            
            Session["user"] = null;
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('revise sus credenciales de acceso');window.location=\"Login.aspx\"</script>");
        }
        else{
            idrol2 = usuario.Id_rol;
            aprobacion1 = usuario.Aprobacion;
            redireccion1= luser1.Llogin1(idrol2, aprobacion1);
            Response.Redirect(redireccion1);
            if (usuario.Id_rol == 2 && usuario.Aprobacion == 0){
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('En este momento no puede iniciar sesion, se esta revisando su solicitud de registro como aliado, recibira una respuesta al correo que ingreso en el registro para la aprobacion o no aprobacion para nuestra plataforma');window.location.href=\"CerrarSession.aspx\"</script>");
                    return;
                }
                else if (usuario.Id_rol == 3 && usuario.Aprobacion == 0) {
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('En este momento no puede iniciar sesion, se esta revisando su solicitud de registro como domiciliario, recibira una respuesta al correo que ingreso en el registro para la aprobacion o no aprobacion para nuestra plataforma');window.location.href=\"CerrarSession.aspx\"</script>");
                    return;
                }
                else if (usuario.Id_rol == 4 && usuario.Aprobacion == 0){
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('En este momento no puede iniciar sesion, se esta revisando su solicitud de registro como administrador, recibira una respuesta al correo que ingreso en el registro para la aprobacion o no aprobacion para nuestra plataforma');window.location.href=\"CerrarSession.aspx\"</script>");
                    return;
                }
                if (usuario.Id_rol == 2 && usuario.Aprobacion == 2) {
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su solicitud como Aliado ha sido rachazada');window.location.href=\"CerrarSession.aspx\"</script>");
                    return;
                }
                if (usuario.Id_rol == 3 && usuario.Aprobacion == 2){
                    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su solicitud como Domiciliario ha sido rachazada');window.location.href=\"CerrarSession.aspx\"</script>");
                    return;
                }
        }
        //
    }

    protected void LB_RecuperarContrasenia_Click(object sender, EventArgs e){
        redireccion1 = luser1.LLB_RecuperarContrasenia();
        Response.Redirect(redireccion1);
    }
}