using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
public partial class View_AccesoDenegado : System.Web.UI.Page
{
    UMac umac1 = new UMac();
    LAccesoDenegado laccesodenegado1 = new LAccesoDenegado();

    protected void Page_Load(object sender, EventArgs e){

    }
    int idrol;
    string redireccion1;
    protected void Button1_Click(object sender, EventArgs e)
    {

       // umac1.Session = Session["user"];
        if (Session["user"] == null){
            redireccion1 = laccesodenegado1.LButton(0);
        }else{
            idrol = ((UUsuario)Session["user"]).Id_rol;
            redireccion1= laccesodenegado1.LButton(idrol);            
        }
        Response.Redirect(redireccion1);

    }
}