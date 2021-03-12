using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // UUsuario user = new UUsuario();
        //validar que un rol diferente no entre a otro
        if (((UUsuario)Session["user"]).Id_rol != 1)
            Response.Redirect("Login.aspx");

       

    }
}