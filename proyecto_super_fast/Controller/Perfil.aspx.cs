using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
public partial class View_Perfil : System.Web.UI.Page{
    LPerfil lperfil1 = new LPerfil();
    string redireccion1;
    protected void Page_Load(object sender, EventArgs e) {//1
        
        menu();
        mostrar();
        TB_nombreperfila.Visible = false;
        TB_apellidoperfila.Visible = false;
        TB_correoperfila.Visible = false;
        TB_contraseniaperfila.Visible = false;
        TB_direccionperfila.Visible = false;
        TB_telefonoperfila.Visible = false;
        TB_documentoperfila.Visible = false;
        TB_tipodevehiculoperfila.Visible = false;
        TB_urlfoto.Visible = false;
        TB_urlfotoa.Visible = false;
        LB_actualizarfoto.Visible = false;
        FUD_imagenperfil.Visible = false;

    }//1
    protected void menu() {//2
        if (Session["user"] != null) {//3
            switch (((UUsuario)Session["user"]).Id_rol) {//4
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
            }//4
        }//3
    }//2
     protected void rolAdmin(){
        TB_tipodevehiculoperfil.Visible = false;
        DDLD_tipovehiculo.Visible = false;
        LB_tipodevehiculoperfil.Visible = false;
        LB_actividadcomercial.Visible = false;
        TB_actividadcomercialperfil.Visible = false;
        BTN_guardar.Visible = false;
        BTN_cancelar.Visible = false;

     }

     protected void rolCliente(){
        TB_tipodevehiculoperfil.Visible = false;
        DDLD_tipovehiculo.Visible = false;
        LB_tipodevehiculoperfil.Visible = false;
        LB_actividadcomercial.Visible = false;
        TB_actividadcomercialperfil.Visible = false;
        BTN_guardar.Visible = false;
        BTN_cancelar.Visible = false;

    }
      protected void rolDomiciliario(){
        TB_tipodevehiculoperfil.Visible = true;
        TB_tipodevehiculoperfila.Visible = true;
        DDLD_tipovehiculo.Visible = true;
        LB_tipodevehiculoperfil.Visible = true;
        LB_actividadcomercial.Visible = false;
        TB_actividadcomercialperfil.Visible = false;
        BTN_guardar.Visible = false;
        BTN_cancelar.Visible = false;
        BTN_guardar.Visible = false;
        BTN_cancelar.Visible = false;

    }
      protected void rolAliado(){
        TB_tipodevehiculoperfil.Visible = false;
        DDLD_tipovehiculo.Visible = false;
        LB_tipodevehiculoperfil.Visible = false;
        LB_actividadcomercial.Visible = true;
        TB_actividadcomercialperfil.Visible = true;
        LB_apellido.Visible = false;
        TB_apellidoperfil.Visible = false;        
        BTN_guardar.Visible = false;
        BTN_cancelar.Visible = false;

    }
    protected void BTN_cancelar_Click(object sender, EventArgs e){
        TB_nombreperfil.Enabled = false;
        TB_apellidoperfil.Enabled = false;
        TB_correoperfil.Enabled = false;
        TB_contraseniaperfil.Enabled = false;
        TB_direccionperfil.Enabled = false;
        TB_telefonoperfil.Enabled = false;
        TB_documentoperfil.Enabled = false;
        TB_tipodevehiculoperfil.Enabled = false;
        BTN_editar.Visible = true;
        


    }
    protected void BTN_editar_Click(object sender, EventArgs e){

        //
        TB_nombreperfila.Visible = true;
        TB_apellidoperfila.Visible = true;
        TB_correoperfila.Visible = true;
        TB_contraseniaperfila.Visible = true;
        TB_direccionperfila.Visible = true;
        TB_telefonoperfila.Visible = true;
        TB_documentoperfila.Visible = true;
        LB_actualizarfoto.Visible = true;
        FUD_imagenperfil.Visible = true;
        if (((UUsuario)Session["user"]).Id_rol == 2)
        {
            TB_apellidoperfila.Visible = false;
        }
        //
        BTN_guardar.Visible = true;
        BTN_cancelar.Visible = true;
        BTN_editar.Visible = false;
        //
        TB_nombreperfila.Text = TB_nombreperfil.Text;
        TB_apellidoperfila.Text = TB_apellidoperfil.Text;
        TB_correoperfila.Text = TB_correoperfil.Text;
        TB_contraseniaperfila.Text = TB_contraseniaperfil.Text;
        TB_direccionperfila.Text = TB_direccionperfil.Text;
        TB_telefonoperfila.Text = TB_telefonoperfil.Text;
        TB_documentoperfila.Text = TB_documentoperfil.Text;
        TB_tipodevehiculoperfila.Text = TB_tipodevehiculoperfil.Text;
        TB_urlfotoa.Text = TB_urlfoto.Text;
        //

       

    }//
    protected void mostrar(){
        //DAOUsuario us = new DAOUsuario();
        UUsuario usuario1 = new UUsuario();
        if (Session["user"] == null){
            redireccion1 = lperfil1.mostrar1();
            Response.Redirect(redireccion1);
        } else{
        usuario1 = lperfil1.mostrar(((UUsuario)Session["user"]).Id);
        TB_nombreperfil.Text = usuario1.Nombre;
        TB_apellidoperfil.Text = usuario1.Apellido;
        TB_correoperfil.Text = usuario1.Correo;
        TB_contraseniaperfil.Text = usuario1.Contrasenia;
        TB_direccionperfil.Text = usuario1.Direccion;
        TB_telefonoperfil.Text = usuario1.Telefono;
        TB_documentoperfil.Text = usuario1.Documento;
        TB_tipodevehiculoperfil.Text = usuario1.Tipovehiculo;
        TB_actividadcomercialperfil.Text = usuario1.Actividadcomercial;
        imagen_perfil.ImageUrl = usuario1.Imagenperfil;
        TB_urlfoto.Text = usuario1.Imagenperfil;
        }
    }

    String seleccion;
    protected void DDLD_tipovehiculo_SelectedIndexChanged(object sender, EventArgs e){
        seleccion = DDLD_tipovehiculo.SelectedItem.Value;
        TB_tipodevehiculoperfila.Text = seleccion;
    }//   
   

    protected void BTN_guardar_Click(object sender, EventArgs e){
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FUD_imagenperfil.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FUD_imagenperfil.PostedFile.FileName);
        string saveLocation = Server.MapPath("~\\imagenes_de_perfil") + "\\" + nombreArchivo;
        string saveLocation1 = Server.MapPath("~\\Aliado\\logo") + "\\" + nombreArchivo;
         
        if (FUD_imagenperfil.HasFile){
            if (!(extension.Equals(".jpg") || extension.Equals(".JPEG") || extension.Equals(".png"))){
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
                return;
            }
            if (System.IO.File.Exists(saveLocation)){
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                return;
            }
            TB_urlfoto.Text = "~\\imagenes_de_perfil" + "\\" + nombreArchivo; ;
        }else{
           TB_urlfoto.Text = "~/imagenes_de_perfil/perfilusuario.png";
        }

        TB_urlfotoa.Text = TB_urlfoto.Text;

        try{
       // DAOUsuario us = new DAOUsuario();
        UUsuario usuario1 = new UUsuario();
        usuario1.Id = ((UUsuario)Session["user"]).Id;
        usuario1.Nombre = TB_nombreperfila.Text;
        usuario1.Apellido = TB_apellidoperfila.Text;
        usuario1.Correo = TB_correoperfila.Text;
        usuario1.Contrasenia = TB_contraseniaperfila.Text;
        usuario1.Direccion = TB_direccionperfila.Text;
        usuario1.Telefono = TB_telefonoperfila.Text;
        usuario1.Documento = TB_documentoperfila.Text;
        usuario1.Tipovehiculo = TB_tipodevehiculoperfila.Text;
        usuario1.Actividadcomercial = TB_actividadcomercialperfil.Text;            
        usuario1.Imagenperfil= TB_urlfotoa.Text;
            lperfil1.BTN_guardar(usuario1);
       // us.actualizarperfil(usuario1);
            if (((UUsuario)Session["user"]).Id_rol == 2){//
                if (!(TB_urlfoto.Text == ((UUsuario)Session["user"]).Imagenperfil)){//
                    FUD_imagenperfil.PostedFile.SaveAs(saveLocation1);
                }//
               
            }else {//
                if (!(TB_urlfoto.Text == "~/imagenes_de_perfil/perfilusuario.png")){//
                    FUD_imagenperfil.PostedFile.SaveAs(saveLocation);
                }//
            }//
            Response.Redirect("Perfil.aspx");
        
        }
        catch (Exception ex)
        { return; }
    }//


   
}//finalclase


   







