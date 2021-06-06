using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;
using System.Drawing;
using System.IO;
using System.Web;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Aliado
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class AliadoController : ApiController{

        /// <summary>
        /// Guardar un producto
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// <returns>
        /// Nombre producto
        /// </returns>
        /// 
        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public bool SaveImage(string ImgStr, string ImgName)
        {
            String path = HttpContext.Current.Server.MapPath("~/ImageStorage"); //Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }


        //
        //[HttpPost]
        //[Route("api/perfil/postSubirFoto")]
        //public UPerfil postSubirFoto([FromBody] JObject foto)
        //{
        //    UPerfil perfil = new UPerfil();
        //    URegistro usuario = new URegistro();
        //    String imagenPerfil = foto["imagen"].ToString();

        //    byte[] fotoPerfil = Convert.FromBase64String(imagenPerfil);

        //    usuario.Usuario = foto["usuario"].ToString();
        //    perfil = new LPerfil().cargardatos(usuario);
        //    usuario.Id = perfil.Datos.Id;
        //    string nombreArchivo = usuario.Usuario + "Perfil2";
        //    string ext = foto["extension"].ToString();
        //    string direccion = "~\\Views\\imgusuarios\\" + nombreArchivo + ext;
        //    string imagenEliminar = perfil.Datos.Fotoperfil;
        //    imagenEliminar = HttpContext.Current.Server.MapPath(imagenEliminar);

        //    return new LPerfil().subirFoto(fotoPerfil, usuario, direccion, ext, imagenEliminar);
        //}
        //
        [Authorize]
        [HttpPost]
        [Route("api/Aliado/PostLBTN_guardarproducto")]
        public string guardarproducto([FromBody] JObject Vs_entrada){

            try
            {
                if (!ModelState.IsValid)
                {
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return error;
                }

                string imagen = Vs_entrada["Imagen_producto"].ToString();

                byte[] Foto_producto = Convert.FromBase64String(imagen);
                string Nombre_producto = Vs_entrada["Nombre_Producto"].ToString() + DateTime.Now;                
                string extension = Vs_entrada["extension"].ToString();
                string direccion = "~\\AliadoAppi\\imagenesproducto\\" + Nombre_producto+extension;
                UProducto producto = new UProducto();
                producto.Nombre_producto = Vs_entrada["Nombre_Producto"].ToString();
                producto.Descripcion_producto = Vs_entrada["Descripcion_producto"].ToString();
                producto.Imagen_producto1 = direccion;
                producto.Precio_producto = double.Parse(Vs_entrada["Precio_producto"].ToString());
                producto.Estado_producto = 1;
                producto.Id_aliado = int.Parse(Vs_entrada["Id"].ToString());

                return new LAliado().LBTN_guardarproducto(Foto_producto, producto, extension, direccion);
            }
            catch (Exception ex)
            {
                return "hay un problema interno: " + ex.StackTrace;
            }
        }               
        /// <summary>
        /// Editar o activar un producto
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Authorize]
        [Route("api/Aliado/PostCambiarOEditarProductos")]
        public UProducto PostCambiarOEditarProductos([FromBody] JObject Vs_entrada){
            //try
            //{
            UProducto producto1 = new UProducto();
            producto1.Id = int.Parse(Vs_entrada["Id"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            int idmostrar = producto1.Id;
            return new LAliado().LGV_Producto(producto1, comandname, idmostrar).UmacUproducto1;
            //}
            //catch (Exception ex){
            //    return;
            //}
        }//

         /// <summary>
         /// Muestra un producto
         /// </summary>
         /// <param name="id3"></param>
         /// <returns></returns>
         /// 
        [Authorize]
        [HttpGet]
        [Route("api/Aliado/GetLmostrar")]
        public UProducto Lmostrar(int id3){
            return new LAliado().Lmostrar(id3); ;
        }
        //
        /// <summary>
        /// Editar variables de un producto
        /// </summary>
        /// <param name="producto"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/Aliado/PostLBTN_GuardarCambios")]
        public IHttpActionResult LBTN_GuardarCambios(UProducto producto){
            try
            {
                if (!ModelState.IsValid)
                {
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
               
               
                if (producto==null)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                    
                    return Ok(new LAliado().LBTN_GuardarCambios(producto));
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
          
        }
        /// <summary>
        /// Permite activar un producto
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/Aliado/PostLGV_Productosdesactivado")]
        public UProducto LGV_Productosdesactivado([FromBody] JObject Vs_entrada){
            UProducto producto1 = new UProducto();
            producto1.Id = int.Parse(Vs_entrada["Id"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            int idmostrar = producto1.Id;
            return new LAliado().LGV_Productosdesactivado(producto1, comandname, idmostrar).UmacUproducto1;
        }
        //
    }
}
