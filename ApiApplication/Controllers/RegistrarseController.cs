using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite a cualquier usuario cambiar su informacion privada
    /// </summary>
    [Route("api/[controller]")]
    public class RegistrarseController : ApiController{
        /// <summary>
        /// Este metodo Permite validar que el correo registrado no exista en la base de datos
        /// </summary>
        /// <param name="correo"></param>
        [HttpGet]
        [Route("api/Registrar/GetValidar_correo")]
        public UUsuario Validar_correo(string correo){
            return new LRegistrarse().LBT_Registrar(correo);
        }
        //
        /// <summary>
        /// Este metodo Permite registrar un usuario normal
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/Registrar/PostInsertar_Usuario")]
        public void Insertar_Usuario(UUsuario usuario){
            new LRegistrarse().LBT_Registrar1(usuario);
        }
        //
    }
}
