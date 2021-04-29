using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;

namespace ApiApplication.Controllers {
    [Route("api/[controller]")]
    public class InicioController : ApiController{
        //
        [HttpGet]
        [Route("api/Inicio/GetDL_Productos1")]
        public List<UPedido> DL_Productos1(int idsesion){
            return new LInicio().DL_Productos1(idsesion);
        }
        //
        [HttpGet]
        [Route("api/Inicio/GetDL_Productos2")]
        public void DL_Productos2(UDetalle_pedido det_pedido){
            new LInicio().DL_Productos2(det_pedido);
        }
        //
        [HttpGet]
        [Route("api/Inicio/Getmostrarcantidadtotal")]
        public string mostrarcantidadtotal(int idusuario){

            return new LInicio().mostrarcantidadtotal(idusuario);

        }
        //
    }
}
