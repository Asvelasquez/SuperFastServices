using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceceder a los servicios del perfil
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class PerfilController : ApiController{
        /// <summary>
        /// Este metodo permite a cualquier usuario ver su informacion personal
        /// </summary>
        /// <param name="id"></param>
        /// 

        [HttpGet]
        [Route("api/Perfil/Getmostrarperfil")]
        public UUsuario mostrarperfil(int id){
            return new LPerfil().mostrar(id);
        }
        //
        /// <summary>
        /// Este metodo Permite a cualquier usuario cambiar su informacion privada
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/Perfil/PostBTN_guardar")]
        public void BTN_guardar(UUsuario usuario){
            new LPerfil().BTN_guardar(usuario);
        }
        //
    }
}
