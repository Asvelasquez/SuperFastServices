using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace ApiApplication.Controllers
{ 
    [Route("api/[controller]")]
    public class CarritoController : ApiController
    {
        [HttpGet]
        [Route("api/Carrito/getLmostrarpreciototal1")]
        public List<UPedido> Lmostrarpreciototal1(int idusuario)
        {
            //return new  pedido3 = dpedido.preciototal(idusuario);
            return new LCarrito().Lmostrarpreciototal1(idusuario);
        }
    }
}
