using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
  //  [RoutePrefix("TeachingAvailability")]

    public class TeachingAvailabilityController:ApiController
    {
        
         [Route("get")]
            [HttpGet]

            public IHttpActionResult GetTeachingAvailabilities()
            {
                try
                {
                    var q = BL.TeachingAvailabilityBL.GetAllTeachingAvailabilities();
                    if (q != null)
                        return Ok(q);
                    return NotFound();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
        [Route("availability/{teacherId}")]
        [HttpGet]

        public IHttpActionResult GetAvailability(int teacherId)
        {
            try
            {
                var q = BL.TeachingAvailabilityBL.GetAvailability(teacherId);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("teachingAvailability")]
        [HttpPut]
        public string PutTeachingAvailability(TeachingAvailabilityDTO teachingAvailability)
        {
            try
            {
                return TeachingAvailabilityBL.PutTeachingAvailability(teachingAvailability);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
    }
    
}