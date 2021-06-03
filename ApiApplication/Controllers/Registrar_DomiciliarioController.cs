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
        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetRegitrar_domiciliario")]
        public string Regitrar_domiciliario([FromBody] JObject Vs_entrada){
            string correo;
            try{
                correo = Vs_entrada["correo"].ToString();
                UUsuario validarUsuario = new LRegistrarse().LBT_Registrar(correo);
                if (validarUsuario != null){
                    return "correo registrado,ingrese uno diferente";
                }else{
                    UUsuario usuario = new UUsuario();
                    usuario.Nombre = Vs_entrada["nombre"].ToString();
                    usuario.Apellido = Vs_entrada["apellido"].ToString();
                    usuario.Correo = Vs_entrada["correo"].ToString();
                    usuario.Contrasenia = Vs_entrada["contrasenia"].ToString();
                    usuario.Documento = Vs_entrada["documento"].ToString();
                    usuario.Telefono = Vs_entrada["telefono"].ToString();
                    usuario.Hojavida = Vs_entrada["hojavida"].ToString();
                    usuario.Tipovehiculo = Vs_entrada["tipovehiculo"].ToString();
                    usuario.Id_rol = int.Parse(Vs_entrada["id_rol"].ToString());
                    usuario.Aprobacion = int.Parse(Vs_entrada["aprobacion"].ToString());
                    usuario.Auditoria = Vs_entrada["nombre"].ToString();
                    new Lregistar_domiciliario().LBTND_registrar1(usuario);
                    return "registro exitoso";
                }
            }catch (Exception ex){
                return "hay un problema interno: " + ex.StackTrace;
            }
            
        }
        //

        //
    }
}
