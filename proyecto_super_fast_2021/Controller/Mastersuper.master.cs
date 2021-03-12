using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
public partial class View_Mastersuper : System.Web.UI.MasterPage{

    protected void Page_Load(object sender, EventArgs e) {
        
        if (!Page.AppRelativeVirtualPath.Contains("CerrarSession.aspx")) {
            Response.Cache.SetNoStore();
            if (Session["user"] == null) {
                //   Response.Redirect("inicio.aspx");
            }
            menu();

        } else {
                    sinRol();

                }
            }
            protected void menu() {
                if (Session["user"] != null) {
                    switch (((UUsuario)Session["user"]).Id_rol) {
                        case 1:
                            rolCliente();
                            break;
                        case 2:
                            rolAliado();
                            break;
                        case 3:
                            rolDomiciliario();
                            break;
                        case 4:
                            rolAdmin();
                            break;
                     
                         default:
                            sinRol();
                            break;

                     }
                    
                    
                } else
                    sinRol();
            }

            protected void rolAdmin() {
                
                BT_IniciarSesion.Visible = false;
                BT_Registrarse.Visible = false;
                BT_cerrarsesion.Visible = true;
              //  IB_carrito.Visible = false;
                BT_Perfil.Visible = true;
                // BT_Productos.Visible = false;
            }

            protected void rolCliente() {
                
                BT_IniciarSesion.Visible = false;
                BT_Registrarse.Visible = false;
                BT_cerrarsesion.Visible = true;
               // IB_carrito.Visible = true;
                BT_Perfil.Visible = true;
             //   BT_Productos.Visible = false;
    }
            protected void rolDomiciliario() {
               
                BT_IniciarSesion.Visible = false;
                BT_Registrarse.Visible = false;
                BT_cerrarsesion.Visible = true;
              //  IB_carrito.Visible = false;
                BT_nosotros.Visible = false;
                BT_Perfil.Visible = true;
              //   BT_Productos.Visible = false;

    }
            protected void rolAliado() {
                
                BT_IniciarSesion.Visible = false;
                BT_Registrarse.Visible = false;
                BT_cerrarsesion.Visible = true;
               // IB_carrito.Visible = false;
                BT_nosotros.Visible = false;
                BT_Perfil.Visible = true;
              //  BT_Productos.Visible = true;
    }
            protected void sinRol() {
              
                BT_IniciarSesion.Visible = true;
                BT_Registrarse.Visible = true;
                BT_cerrarsesion.Visible = false;
              //  IB_carrito.Visible = true;
                BT_Perfil.Visible = false;
              //  BT_Productos.Visible = false;
    }


    protected void BT_Perfil_Click(object sender, EventArgs e){       
            Response.Redirect("Perfil.aspx");        
    }

    protected void BT_cerrarsesion_Click(object sender, EventArgs e){
        Response.Redirect("CerrarSession.aspx");
    }

    protected void BT_Inicio_Click(object sender, EventArgs e){
        if (Session["user"] == null){
            Response.Redirect("inicio.aspx");
        }else if (((UUsuario)(Session["user"])).Id_rol == 1){
            Response.Redirect("inicio.aspx");
        }
        else if (((UUsuario)(Session["user"])).Id_rol == 2) {
            Response.Redirect("pedidosaliado.aspx");
        }
        else if (((UUsuario)(Session["user"])).Id_rol == 3){
            Response.Redirect("Domiciliario.aspx");
        }
        else if (((UUsuario)(Session["user"])).Id_rol == 4){
            Response.Redirect("administrador.aspx");
        }
       


    }

    protected void IB_carrito_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("administrador.aspx");
    }
}
    
