using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
public partial class View_RecuperarContrasenia : System.Web.UI.Page{
    LRecuperarContrasenia LRecuperarContrasenia1 = new LRecuperarContrasenia();
    protected void Page_Load(object sender, EventArgs e){
        if (Request.QueryString.Count > 0){
            int request1 = Request.QueryString.Count;
            UToken token = LRecuperarContrasenia1.LPage_Load(request1);
            if (token == null)
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"Login.aspx\"</script>");
            else if (token.Vigencia < DateTime.Now)
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"Login.aspx\"</script>");
            else
                Session["user_id"] = token.User_id;
        }
        else
            Response.Redirect("Login.aspx");
    }
    //
    protected void B_Cambiar_Click(object sender, EventArgs e){
        UUsuario usuario = new UUsuario();
        UUsuario usuar = new UUsuario();
        usuar = LRecuperarContrasenia1.LB_Cambiar1(usuario);

        usuario.Id = int.Parse(Session["user_id"].ToString());
        usuario.Contrasenia = TB_ConfirmarContrasenia.Text;

        LRecuperarContrasenia1.LB_Cambiar2(usuario);
        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Su contraseña fue actualizada');window.location=\"Login.aspx\"</script>");
    }
    //
}