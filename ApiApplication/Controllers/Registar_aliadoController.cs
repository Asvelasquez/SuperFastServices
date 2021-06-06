using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Logica;
using Newtonsoft.Json.Linq;
using Utilitarios;
namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicios de registrar un aliado
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class Registar_aliadoController : ApiController{
        /// <summary>
        /// Este metodo Permite comparar que el correo que estan registrando no exista en la base de datos
        /// </summary>
        /// <param name="correo"></param>
        [HttpGet]
        [Route("api/Registrar_aliado/GetLBTN_registrar")]
        public UUsuario LBTN_registrar(string correo){
            UUsuario usuario = new UUsuario();
            try{
                if (correo!=null){
                    usuario = new LRegistrar_aliado().LBTN_registrar(correo);
                }
            }
            catch { }
            return usuario;
        }
        /// <summary>
        /// Este metodo Permite Registrar a un usuario tipo aliado
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [HttpPost]
        [Route("api/Registrar_aliado/PostLBTN_registrar1")]
        public string LBTN_registrar1([FromBody] JObject Vs_entrada)
        {
            string correo,respuesta;
            
            try
            {
                correo = Vs_entrada["correo"].ToString();                
                UUsuario validarUsuario = new LRegistrarse().LBT_Registrar(correo);
                if (validarUsuario != null)
                {
                    return "correo registrado,ingrese uno diferente";
                }
                else{
                    String imagenlogo = Vs_entrada["imagen_logo"].ToString();
                    byte[] Foto_logo = Convert.FromBase64String(imagenlogo);
                    string Nombre_Logo = Vs_entrada["nombre"].ToString();
                    string extension_logo = Vs_entrada["extension_logo"].ToString();
                    string direccion_logo = "~\\AliadoAppi\\logo\\" + Nombre_Logo +"."+extension_logo;

                    String rutpdf = Vs_entrada["rut"].ToString();
                    byte[] rut = Convert.FromBase64String(rutpdf);
                    string Nombre_rut = Vs_entrada["nombre"].ToString();
                    string extension_rut = Vs_entrada["extension_rut"].ToString();
                    string direccion_rut = "~\\AliadoAppi\\rutaliado\\" + Nombre_rut+"."+ extension_rut;
                    UUsuario usuario = new UUsuario();
                    usuario.Nombre = Vs_entrada["nombre"].ToString();
                    usuario.Documento = Vs_entrada["documento"].ToString();
                    usuario.Correo = Vs_entrada["correo"].ToString();
                    usuario.Contrasenia = Vs_entrada["contrasenia"].ToString();
                    usuario.Telefono = Vs_entrada["telefono"].ToString();
                    usuario.Direccion = Vs_entrada["direccion"].ToString();
                    usuario.Actividadcomercial= Vs_entrada["actividad_comercial"].ToString();
                    usuario.Imagenperfil = direccion_logo;
                    usuario.Rut = direccion_rut;
                    usuario.Id_rol = 2;
                    usuario.Aprobacion = 0;
                    usuario.Auditoria = Vs_entrada["nombre"].ToString();
                    return new LRegistrar_aliado().LBTN_registrar1(Foto_logo,rut,usuario, extension_logo, extension_rut, direccion_logo, direccion_rut);
                   
                }
            }
            catch (Exception ex)
            {
                return "hay un problema interno: " + ex.StackTrace;
            }

        }
        //

    }
  //  new LRegistrar_aliado().LBTN_registrar1(aliado1);
}
