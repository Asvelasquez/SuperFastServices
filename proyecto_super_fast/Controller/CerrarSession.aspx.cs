using System;
using Utilitarios;
using Logica;

public partial class View_CerrarSession : System.Web.UI.Page
{
    LCerrarSession cerrarSesion = new LCerrarSession();
    UMac datos1 = new UMac();

    protected void Page_Load(object sender, EventArgs e){
        int Id = ((UUsuario)Session["user"]).Id;
        //new DAOSeguridad().cerrarAcceso(((UUsuario)Session["user"]).Id);
        
     datos1=cerrarSesion.Page_Load(Id);

        Session["user"] = null;
        try
        {
            Response.Redirect(datos1.Url);
        }
        catch (Exception ex)
        {

        
        }
       
    }
}