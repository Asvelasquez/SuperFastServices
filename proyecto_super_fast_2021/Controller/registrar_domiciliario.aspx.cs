using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;


public partial class View_registrar_domiciliario : System.Web.UI.Page
{
    Lregistar_domiciliario lregistar_Domiciliario1 = new Lregistar_domiciliario();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void BTND_registrar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FUD_hojavida.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FUD_hojavida.PostedFile.FileName);
        string saveLocation = Server.MapPath("~\\Hojas_de_vida") + "\\" + nombreArchivo;
        if (!(extension.Equals(".PDF") || extension.Equals(".pdf"))){
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
            return;
        }
        if (System.IO.File.Exists(saveLocation)){
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
            return;}

        try{
           
          //  cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
           
            UUsuario domiciliario = new UUsuario();
            domiciliario.Nombre = TBD_nombre.Text;
            domiciliario.Apellido = TBD_apellido.Text;
            domiciliario.Correo = TBD_correo.Text;
            domiciliario.Contrasenia = TBD_contrasena.Text;
            domiciliario.Documento = TBD_ndocumento.Text;
            domiciliario.Telefono = TBD_telefono.Text;
            domiciliario.Hojavida = "~\\Hojas_de_vida" + "\\" + nombreArchivo; ;
            domiciliario.Tipovehiculo = DDLD_tipovehiculo.Text;
            int rol3 = 3,aprob=0;
            domiciliario.Id_rol = rol3;
            domiciliario.Aprobacion = aprob;
            domiciliario.Auditoria = TBD_nombre.Text;
            UUsuario validarUsuario = lregistar_Domiciliario1.LBTND_registrar2(TBD_correo.Text);
            lregistar_Domiciliario1.LBTND_registrar(TBD_correo.Text);
          


            if (!CB_Terminos.Checked){
              //  LB_Mensaje.Text = "acepte terminos y condiciones";
                 cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('acepte terminos y condiciones');</script>");
            }
            else {    
                if (validarUsuario != null){
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('correo registrado,ingrese uno diferente');</script>");
            }else {
              
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su solicitud sera revisada y respondida al correo que ingreso');</script>");
                    lregistar_Domiciliario1.LBTND_registrar1(domiciliario);
                    FUD_hojavida.PostedFile.SaveAs(saveLocation);
                   // vaciar();
                   // Response.Redirect("registrar_domiciliario.aspx");
               }

            }

        }
        catch (Exception ex)
        { return; }


    }
    public void vaciar()
    {
         TBD_nombre.Text="";
        TBD_apellido.Text = "";
       TBD_correo.Text = "";
         TBD_contrasena.Text = "";
         TBD_ndocumento.Text = "";
         TBD_telefono.Text = "";
        FUD_hojavida = null;
       DDLD_tipovehiculo.Text = "";
       
        
    }
}