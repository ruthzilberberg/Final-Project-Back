using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    //[RoutePrefix("user")]
    public class UserController : ApiController
    {
        [Route("users")]
        [HttpGet]
        public string Token(string name)
        {
            
            return BL.Token.AddUser( name);
        }


        [Route("user/{userTz}")]
        [HttpGet]
        public IHttpActionResult GetUsers(string userTz)
        {
            try
            {
                var q1 = BL.TeacherBL.GetTeacher(userTz);
               var q2 = BL.SecretaryBL.GetSecretary(userTz);
                if (q1 != null)
                    return Ok(q1);
              else if (q2 != null)
                  return Ok(q2);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}