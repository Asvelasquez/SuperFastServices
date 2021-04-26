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
        [Route("api/Aliado/PostLGV_Producto")]
        public UMac LGV_Producto(UProducto producto1, string error, int idmostrar){
            return new LAliado().LGV_Producto(producto1, error, idmostrar);
        }//
        //
        [HttpPost]
        [Route("api/Aliado/PostLmostrar")]
        public UProducto Lmostrar(int id3){
            return new LAliado().Lmostrar(id3); ;
        }
        //
        [HttpPost]
        [Route("api/Aliado/PostLBTN_GuardarCambios")]
        public string LBTN_GuardarCambios(UProducto producto2){
            return new LAliado().LBTN_GuardarCambios(producto2);
        }
        //
        [HttpPost]
        [Route("api/Aliado/PostLBTN_GuardarCambios")]
        public UMac LGV_Productosdesactivado(UProducto producto1, string error, int idmostrar){
            return new LAliado().LGV_Productosdesactivado(producto1,error, idmostrar);
        }
        //
    }
}
