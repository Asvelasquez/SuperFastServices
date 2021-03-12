using System;
using Utilitarios;
using Logica;

public partial class View_CerrarSession : System.Web.UI.Page
{
    LCerrarSession cerrarSesion = new LCerrarSession();
    protected void Page_Load(object sender, EventArgs e){
        int Id = ((UUsuario)Session["user"]).Id;
        //new DAOSeguridad().cerrarAcceso(((UUsuario)Session["user"]).Id);
        cerrarSesion.Page_Load(Id);
        Session["user"] = null;
        Response.Redirect("Login.aspx");
    }
}