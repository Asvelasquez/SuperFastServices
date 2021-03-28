using System;
using Utilitarios;
using Logica;

public partial class View_CerrarSession : System.Web.UI.Page
{
    LCerrarSession cerrarSesion = new LCerrarSession();
   UMac datos1 = new UMac();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        cerrarSesion.Page_Load(((UUsuario)Session["user"]));

        Session["user"] = null;
        Response.Redirect("Login.aspx");
    }


}