﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de generar token
    /// </summary>
    [Route("api/[controller]")]
    public class GenerarTokenController : ApiController{

        /// <summary>
        /// Este metodo nos permite Generar un token para recuperar la coontraseña
        /// </summary>
        /// <param name="TB_Correo"></param>
        [HttpGet]
        [Route("api/GenerarToken/PostLB_Recuperar")]
        public string LB_Recuperar(string TB_Correo)
        {
            return new LGenerarToken().LB_Recuperar(TB_Correo);
        }




    }
}
