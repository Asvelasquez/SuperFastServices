using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicios de registrar un domiciliario
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class Registrar_DomiciliarioController : ApiController{
        //
        /// <summary>
        /// Este metodo Permite registrar un usuario tipo domiciliario
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [HttpPost]
        [Route("api/Registrar_Domiciliario/Registrar_domiciliario")]
        public string Registrar_domiciliario([FromBody] JObject Vs_entrada){
            string correo;
            try{
               
                correo = Vs_entrada["correo"].ToString();
                UUsuario validarUsuario = new LRegistrarse().LBT_Registrar(correo);
                if (validarUsuario != null){
                    return "correo registrado,ingrese uno diferente";
                }else{
                    UUsuario usuario = new UUsuario();
                    String archivo = Vs_entrada["archivo"].ToString();

                    byte[] hoja_vida = Convert.FromBase64String(archivo);
                  
                    string nombredocumento = Vs_entrada["nombre"].ToString();
                    string extension = Vs_entrada["extension"].ToString();
                    string direccion = "~\\Domiciliario\\HojaVida\\" + nombredocumento + extension;
                  
                    usuario.Nombre = Vs_entrada["nombre"].ToString();
                    usuario.Apellido = Vs_entrada["apellido"].ToString();
                    usuario.Correo = Vs_entrada["correo"].ToString();
                    usuario.Contrasenia = Vs_entrada["contrasenia"].ToString();
                    usuario.Documento = Vs_entrada["documento"].ToString();
                    usuario.Telefono = Vs_entrada["telefono"].ToString();
                    usuario.Hojavida = direccion;
                    usuario.Tipovehiculo = Vs_entrada["tipovehiculo"].ToString();
                    usuario.Id_rol = 3;
                    usuario.Aprobacion = 0;
                    usuario.Auditoria = Vs_entrada["nombre"].ToString();
                  return  new Lregistar_domiciliario().GuardarHojaVida(hoja_vida,usuario,extension,direccion);
                   
                }
            }catch (Exception ex){
                return "hay un problema interno: " + ex.StackTrace;
            }
            
        }
        //

        //
    }
}
