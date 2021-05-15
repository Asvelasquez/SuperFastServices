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
    /// Este metodo Permite a cualquier usuario registrarse en la plataforma
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class RegistrarseController : ApiController{
        //
        /// <summary>
        /// Este metodo Permite registrar un usuario normal
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [HttpPost]
        [Route("api/Registrar/PostInsertar_Usuario")]
        public string Insertar_Usuario([FromBody] JObject Vs_entrada)
        {
           
            string correo,respuesta;
            correo = Vs_entrada["correo"].ToString();
            UUsuario validarUsuario = new LRegistrarse().LBT_Registrar(correo);
            if (validarUsuario!=null)
            {
                respuesta = "correo registrado,ingrese uno diferente";
            }
            else
            {
                UUsuario usuario = new UUsuario();
                usuario.Nombre = Vs_entrada["nombre"].ToString();
                usuario.Apellido = Vs_entrada["apellido"].ToString();
                usuario.Correo = Vs_entrada["correo"].ToString();
                usuario.Contrasenia = Vs_entrada["contrasenia"].ToString();
                usuario.Telefono = Vs_entrada["telefono"].ToString();
                usuario.Direccion = Vs_entrada["direccion"].ToString();
                usuario.Imagenperfil = Vs_entrada["imagenperfil"].ToString();
                usuario.Auditoria = Vs_entrada["nombre"].ToString();
                usuario.Id_rol = int.Parse(Vs_entrada["id_rol"].ToString());
                usuario.Aprobacion = int.Parse(Vs_entrada["aprobacion"].ToString());
                new LRegistrarse().LBT_Registrar1(usuario);
                respuesta = "registro exitoso";
            }
            return respuesta;
        }
        //
    }
}
