using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_Aliado : System.Web.UI.Page
{
    UMac datos1 = new UMac();
    LAliado Laliado1 = new LAliado();
    string redireccion1;
    protected void Page_Load(object sender, EventArgs e){
        if (Session["user"] != null){
            if (((UUsuario)Session["user"]).Id_rol != 2){
              Response.Redirect("AccesoDenegado.aspx");
            }
            
        } else {
            Response.Redirect("AccesoDenegado.aspx");
        }

        LB_productosdesactivados.Visible = false;
        GV_Productosdesactivado.Visible = false;

    }//

    protected void BTN_guardarproducto_Click(object sender, EventArgs e){
        ClientScriptManager cm = this.ClientScript;

        string nombreArchivo = System.IO.Path.GetFileName(FP_imagen1.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FP_imagen1.PostedFile.FileName);
        string saveLocation = Server.MapPath("~\\Aliado\\imagenesproducto") + "\\" + nombreArchivo;
        if (!(extension.Equals(".jpg") || extension.Equals(".JPEG") || extension.Equals(".png") || extension.Equals(".PNG") || extension.Equals(".JPG")))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido, la imagen tiene que ser formato jpg, JPEG o png');</script>");
            return;
        }
        if (System.IO.File.Exists(saveLocation)) {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre, cambielo y entente de nuevo');</script>");
            return;
        }
         //prueba   
        try {
            UProducto producto1 = new UProducto();
            producto1.Nombre_producto = TB_nombreproducto.Text;
            producto1.Descripcion_producto = TB_descripcionproducto.Text;
            producto1.Precio_producto = Double.Parse(TB_precioproducto.Text);
            producto1.Imagen_producto1 = "~\\Aliado\\imagenesproducto" + "\\" + nombreArchivo; ;
            producto1.Estado_producto = 1;// 1=estado activado del producto 2=desactivado
            producto1.Id_aliado = (((UUsuario)Session["user"]).Id);
            redireccion1= Laliado1.LBTN_guardarproducto(producto1);
            FP_imagen1.PostedFile.SaveAs(saveLocation);
            Response.Redirect(redireccion1);
        }
        catch (Exception ex)
        { return; }//
    }//
    

    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //ClientScriptManager cm = this.ClientScript;
        //DAOProductos us = new DAOProductos();
        //UProducto producto1 = new UProducto();
        //producto1.Id = int.Parse(e.CommandArgument.ToString());

        //if (e.CommandName == "Editar")
        //{
        //    BTN_guardarproducto.Visible = false;
        //    BTN_GuardarCambios.Visible = true;
        //    mostrar(int.Parse(e.CommandArgument.ToString()));
        //    GV_Productos.DataBind();
        //}
        //else if (e.CommandName == "Desactivar"){
        //    us.Desactivarproducto(producto1);
        //    GV_Productos.DataBind();
        //}
        UProducto producto1 = new UProducto();
        producto1.Id = int.Parse(e.CommandArgument.ToString());
        string comanddame=e.CommandName;
        int idmostrar= int.Parse(e.CommandArgument.ToString());
        datos1=Laliado1.LGV_Producto(producto1,comanddame,idmostrar);
       
        BTN_guardarproducto.Visible =datos1.Falso;
        BTN_GuardarCambios.Visible = datos1.Verdadero;
        GV_Productos.DataBind();
    }//
    
   
    protected void mostrar(int id3)
    {
        UProducto productos2 = new UProducto();
        productos2 = Laliado1.Lmostrar(id3);
        TB_nombreproducto.Text = productos2.Nombre_producto;
        TB_descripcionproducto.Text = productos2.Descripcion_producto;
        TB_precioproducto.Text = productos2.Precio_producto.ToString();
        TB_Url.Text = productos2.Imagen_producto1;
        TBX_Id.Text =  productos2.Id.ToString();
        TBX_estado.Text = productos2.Estado_producto.ToString();
    }

    public void vaciar(){
        TB_nombreproducto.Text = "";
        TB_descripcionproducto.Text = "";
        TB_precioproducto.Text = "";
    }
    protected void BTN_GuardarCambios_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        string nombreArchivo = System.IO.Path.GetFileName(FP_imagen1.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FP_imagen1.PostedFile.FileName);
        string saveLocation = Server.MapPath("~\\Aliado\\imagenesproducto") + "\\" + nombreArchivo;

        if (FP_imagen1.HasFile)  {
            if (!(extension.Equals(".jpg") || extension.Equals(".JPEG") || extension.Equals(".png")))  {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
                return;
            }
            if (System.IO.File.Exists(saveLocation))  {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                return;
            }
            TB_Url.Text = "~\\imagenes_de_perfil" + "\\" + nombreArchivo; ;
        } else{  }

        try  {
            UProducto producto1 = new UProducto();
            producto1.Id = int.Parse(TBX_Id.Text);
            producto1.Nombre_producto = TB_nombreproducto.Text;
            producto1.Descripcion_producto = TB_descripcionproducto.Text;
            producto1.Precio_producto = Double.Parse(TB_precioproducto.Text);
            producto1.Imagen_producto1 = TB_Url.Text;
            producto1.Estado_producto = int.Parse(TBX_estado.Text);
            producto1.Id_aliado = (((UUsuario)Session["user"]).Id);

            redireccion1= Laliado1.LBTN_GuardarCambios(producto1);
            Response.Redirect(redireccion1);
            vaciar();
            if (!(TB_Url.Text == ((UUsuario)Session["user"]).Imagenperfil))  {//
                FP_imagen1.PostedFile.SaveAs(saveLocation);
            }//

        }
        catch (Exception ex)
        { return; }//
    }

    protected void GV_Productosdesactivado_RowCommand(object sender, GridViewCommandEventArgs e){
        ////DAOProductos us = new DAOProductos();
        //UProducto producto1 = new UProducto();
        //producto1.Id = int.Parse(e.CommandArgument.ToString());
        //string comanddame = e.CommandName;
        //int idmostrar = int.Parse(e.CommandArgument.ToString());
        //if (e.CommandName == "Editar")
        //{
        //    BTN_guardarproducto.Visible = false;
        //    BTN_GuardarCambios.Visible = true;
        //    mostrar(int.Parse(e.CommandArgument.ToString()));
        //    GV_Productos.DataBind();
        //}
        //else if (e.CommandName == "Activar")
        //{
        //    us.Activarproducto(producto1);
        //    GV_Productos.DataBind();
        //}
        UProducto producto1 = new UProducto();
        producto1.Id = int.Parse(e.CommandArgument.ToString());
        string comanddame = e.CommandName;
        int idmostrar = int.Parse(e.CommandArgument.ToString());
        datos1 = Laliado1.LGV_Producto(producto1, comanddame, idmostrar);
        BTN_guardarproducto.Visible = datos1.Falso;
        BTN_GuardarCambios.Visible = datos1.Verdadero;
        GV_Productosdesactivado.DataBind();
    }

    protected void BTN_productosactivados_Click(object sender, EventArgs e){
        GV_Productosdesactivado.Visible = false;
        LB_productosdesactivados.Visible = false;
        LB_productosactivos.Visible = true;
        //  BTN_productosdesactivados.Visible = false;
        GV_Productos.Visible = true;
    }

    protected void BTN_productosdesactivados_Click(object sender, EventArgs e){
        GV_Productosdesactivado.Visible =true;
        LB_productosactivos.Visible = false;
        LB_productosdesactivados.Visible = true;
       // BTN_productosdesactivados.Visible = false;
        GV_Productos.Visible = false;
    }
}