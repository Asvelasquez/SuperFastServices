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

namespace ApiApplication.Controllers
{
    /// <summary>
    ///Este metodo nos permite acceder a los servicios del usuario administrador
    /// </summary> 
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class AdministradorController : ApiController
    {
        /// <summary>
        /// permite aprobar la solicitud de registro de un domiciliario
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [Authorize]
        [HttpPut]
        [Route("api/Administrador/PutLGV_domiciliariiosaprobar")]
        public IHttpActionResult LGV_domiciliariiosaprobar([FromBody] JObject Vs_entrada){
            //ladministrador1.LGV_domiciliariiosaprobar(usuario3, Lcorreo, comandname);
            UUsuario usuario3 = new UUsuario();
            try{
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                //   UUsuario user = await new LUser().LG_Principal2(login);
                usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
                String Lcorreo = Vs_entrada["correo"].ToString();
                String comandname = Vs_entrada["comandname"].ToString();
                if (String.IsNullOrEmpty(Lcorreo)|| String.IsNullOrEmpty(comandname)|| usuario3.Id==0){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else { 
                    new Ladministrador().LGV_domiciliariiosaprobar(usuario3, Lcorreo, comandname);
                    return Ok();
                }                  

            }
            catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
            
        }

        //
        /// <summary>
        /// permite aprobar la solicitud de registro de un aliado
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [Authorize]
        [HttpPut]
        [Route("api/Administrador/putLGV_aliadoaprobar")]
        public IHttpActionResult LGV_aliadoaprobar([FromBody] JObject Vs_entrada){
            UUsuario usuario3 = new UUsuario();
            try{
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                //   UUsuario user = await new LUser().LG_Principal2(login);
                usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
                String Lcorreo = Vs_entrada["correo"].ToString();
                String comandname = Vs_entrada["comandname"].ToString();
                if (String.IsNullOrEmpty(Lcorreo) || String.IsNullOrEmpty(comandname) || usuario3.Id == 0){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new Ladministrador().LGV_aliadoaprobar(usuario3, Lcorreo, comandname);
                    return Ok();
                }
            }
            catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

        }
        //
        /// <summary>
        /// permite rechazar la solicitud de registro de un aliado
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [Authorize]
        [HttpPut]
        [Route("api/user/PutLGV_aliadorechazado")]
        public IHttpActionResult LGV_aliadorechazado([FromBody] JObject Vs_entrada){
            UUsuario usuario3 = new UUsuario();
            try{
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                //   UUsuario user = await new LUser().LG_Principal2(login);
                usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
                String Lcorreo = Vs_entrada["correo"].ToString();
                String comandname = Vs_entrada["comandname"].ToString();
                if (String.IsNullOrEmpty(Lcorreo) || String.IsNullOrEmpty(comandname) || usuario3.Id == 0){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else{
                    new Ladministrador().LGV_aliadorechazado(usuario3, Lcorreo, comandname);
                    return Ok();
                }
            }catch (Exception ex)            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

        }
        //
        /// <summary>
        /// permite rechazar la solicitud de registro de un aliado
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [Authorize]
        [HttpPut]
        [Route("api/user/PutLGV_domiciliariorechazado")]
        public IHttpActionResult LGV_domiciliariorechazado([FromBody] JObject Vs_entrada){
            UUsuario usuario3 = new UUsuario();
            try{
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                //   UUsuario user = await new LUser().LG_Principal2(login);
                usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
                String Lcorreo = Vs_entrada["correo"].ToString();
                String comandname = Vs_entrada["comandname"].ToString();
                if (String.IsNullOrEmpty(Lcorreo) || String.IsNullOrEmpty(comandname) || usuario3.Id == 0){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else {
                    new Ladministrador().LGV_domiciliariorechazado(usuario3, Lcorreo, comandname);
                    return Ok();
                }
            }catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
          
            
        }
        //
        /// <summary>
        /// permite ver la lista de aliados aceptados
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/user/PutLGV_solicitudaliadosaceptados")]
        public IHttpActionResult LGV_solicitudaliadosaceptados([FromBody] JObject Vs_entrada){
            UUsuario usuario3 = new UUsuario();
            try{
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                //   UUsuario user = await new LUser().LG_Principal2(login);
                usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
                String Lcorreo = Vs_entrada["correo"].ToString();
                String comandname = Vs_entrada["comandname"].ToString();
                if (String.IsNullOrEmpty(Lcorreo) || String.IsNullOrEmpty(comandname) || usuario3.Id == 0) { 
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new Ladministrador().LGV_solicitudaliadosaceptados(usuario3, Lcorreo, comandname);
                    return Ok();
                }
            }catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
        }
        //
        /// <summary>
        /// permite ver la lista de domiciliarios aceptados
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/user/PutLGV_domiciliariosaceptados")]
        public IHttpActionResult LGV_domiciliariosaceptados([FromBody] JObject Vs_entrada){
            UUsuario usuario3 = new UUsuario();
            try{
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                //   UUsuario user = await new LUser().LG_Principal2(login);
                usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
                String Lcorreo = Vs_entrada["correo"].ToString();
                String comandname = Vs_entrada["comandname"].ToString();
                if (String.IsNullOrEmpty(Lcorreo) || String.IsNullOrEmpty(comandname) || usuario3.Id == 0){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new Ladministrador().LGV_domiciliariosaceptados(usuario3, Lcorreo, comandname);
                    return Ok();
                }
            }catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
            //////////            
        }
        //

        //
    }// AdministradorController
}
