﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;
namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Domiciliario
    /// </summary>
    [Route("api/[controller]")]
    public class DomiciliarioController : ApiController{
        /// <summary>
        /// Este metodo nos permite cambiar el estado de los domicilios pendientes de aprobar
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/Domiciliario/PutDDL_Estado")]
        public void DDL_Estado([FromBody] JObject Vs_entrada)
        {
            UPedido pedido = new UPedido();
            pedido.Id_pedido= int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Domiciliario_id= int.Parse(Vs_entrada["Domiciliario_id"].ToString());
            string idseleccion= Vs_entrada["Estado_domicilio_id"].ToString();
            new LDomiciliario().DDL_Estado(pedido,idseleccion);
        }
        //
        /// <summary>
        /// Este metodo nos permite cambiar el estado de los domicilios tomados "Mis pedidos"
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        
        [Authorize]
        [HttpPut]
        [Route("api/Domiciliario/PutDDL_Estado0")]
        public void DDL_Estado0([FromBody] JObject Vs_entrada){
            UPedido pedido = new UPedido();
            pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Domiciliario_id = int.Parse(Vs_entrada["Domiciliario_id"].ToString());
            string idseleccion = Vs_entrada["Estado_domicilio_id"].ToString();
            new LDomiciliario().DDL_Estado0(pedido,idseleccion);

        }
        //
    }
}
