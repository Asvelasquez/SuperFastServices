using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace ApiApplication.Controllers{
    [Route("api/[controller]")]
    public class AdministradorController : ApiController {
      


        [HttpPost]
        [Route("api/Administrador/PostLGV_domiciliariiosaprobar")]               
        public void LGV_domiciliariiosaprobar(UUsuario usuario3, string Lcorreo, string comandname){
            //ladministrador1.LGV_domiciliariiosaprobar(usuario3, Lcorreo, comandname);
           new Ladministrador().LGV_domiciliariiosaprobar(usuario3, Lcorreo, comandname);
        }
        
        //
        [HttpPost]
        [Route("api/Administrador/PostLGV_aliadoaprobar")]
        public void LGV_aliadoaprobar(UUsuario usuario3, string Lcorreo, string comandname){
            new Ladministrador().LGV_aliadoaprobar(usuario3, Lcorreo, comandname);
        }
        //
        [HttpPost]
        [Route("api/user/PostLGV_aliadorechazado")]
        public void LGV_aliadorechazado(UUsuario usuario3, string Lcorreo, string comandname){
            new Ladministrador().LGV_aliadorechazado(usuario3, Lcorreo, comandname);
        }
        //
        [HttpPost]
        [Route("api/user/PostLGV_domiciliariorechazado")]
        public void LGV_domiciliariorechazado(UUsuario usuario3, string Lcorreo, string comandname){
            new Ladministrador().LGV_domiciliariorechazado(usuario3, Lcorreo, comandname);
        }
        //
        [HttpPost]
        [Route("api/user/PostLGV_solicitudaliadosaceptados")]
        public void LGV_solicitudaliadosaceptados(UUsuario usuario3, string Lcorreo, string comandname){
            new Ladministrador().LGV_solicitudaliadosaceptados(usuario3, Lcorreo, comandname);
        }
        //
        [HttpPost]
        [Route("api/user/PostLGV_domiciliariosaceptados")]
        public void LGV_domiciliariosaceptados(UUsuario usuario3, string Lcorreo, string comandname){
            new Ladministrador().LGV_domiciliariosaceptados(usuario3, Lcorreo, comandname);
        }
        //
      
        //
    }// AdministradorController
}
