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
    public class AliadoController : ApiController{
        

        [HttpPost]
        [Route("api/Aliado/PostLBTN_guardarproducto")]      
        public string LBTN_guardarproducto(UProducto producto2){
            return new LAliado().LBTN_guardarproducto(producto2);   
        }
        //
        [HttpPost]
        [Route("api/Aliado/Lmostrar")]
        public UProducto Lmostrar(int id3){
            return new LAliado().Lmostrar(id3); ;
        }
        //
    }
}
