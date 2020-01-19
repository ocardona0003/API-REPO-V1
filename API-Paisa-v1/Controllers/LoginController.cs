using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using API_Paisa_v1.Models;


namespace API_Paisa_v1.Controllers
{    

    [AllowAnonymous] // Todo el controlador no requiere token, puesto que es el que valida las credenciales.
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private paisaEntities db;

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(sp_P_SEC_Usuario2_Result login)
        {
            try
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                //TODO: Validate credentials Correctly, this code is only for demo !!
                db = new paisaEntities();

                var user = db.sp_P_SEC_Usuario2(login.codUsuario, login.codUsuario2);
        
                var userCatch = new sp_P_SEC_Usuario2_Result();
                userCatch = user.FirstOrDefault();
                if (!userCatch.nombreCompleto.Equals(string.Empty))
                {
                    var token = TokenGenerator.GenerateTokenJwt(login.codUsuario);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }           
        
            
        }
    }
}

  
