using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("teachingGroup")]
    public class TeachingGroupController:ApiController
    {
        [Route("getAllTeachingGroups")]
        [HttpGet]

        public IHttpActionResult GetTeachingGroups()
        {

            try
            {
                var q = BL.TeachingGroupBL.GetAllTeachingGroups();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }

}
