using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Aliado
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class AliadoController : ApiController{   
        /// <param name="producto2"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Aliado/PostLBTN_guardarproducto")]      
        public string LBTN_guardarproducto(UProducto producto2){
            return new LAliado().LBTN_guardarproducto(producto2);   
        }
        /// <summary>
        /// Editar o activar un producto
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// <returns></returns>
        /// 
     
        [HttpPost]
        [Route("api/Aliado/PostLGV_Producto ")]
        public UProducto LGV_Producto([FromBody] JObject Vs_entrada){
            UProducto producto1 = new UProducto();           
            producto1.Id = int.Parse(Vs_entrada["Id"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            int idmostrar = producto1.Id;            
            return new LAliado().LGV_Producto(producto1, comandname, idmostrar).UmacUproducto1;
        }//
        /// <summary>
        /// Muestra un producto
        /// </summary>
        /// <param name="id3"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Aliado/GetLmostrar")]
        public UProducto Lmostrar(int id3){
            return new LAliado().Lmostrar(id3); ;
        }
        //
        /// <summary>
        /// Editar variables de un producto
        /// </summary>
        /// <param name="producto"></param>
        [HttpPost]
        [Route("api/Aliado/PostLBTN_GuardarCambios")]
        public string LBTN_GuardarCambios(UProducto producto){
            return new LAliado().LBTN_GuardarCambios(producto);
        }
        /// <summary>
        /// Permite activar un producto
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Aliado/PostLGV_Productosdesactivado")]
        public UProducto LGV_Productosdesactivado([FromBody] JObject Vs_entrada){
            UProducto producto1 = new UProducto();
            producto1.Id = int.Parse(Vs_entrada["Id"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            int idmostrar = producto1.Id;
            return new LAliado().LGV_Productosdesactivado(producto1, comandname, idmostrar).UmacUproducto1;
        }
        //
    }
}
