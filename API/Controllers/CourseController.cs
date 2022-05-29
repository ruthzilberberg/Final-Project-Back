using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
  
    public class CourseController : ApiController
    {

        [Route("course")]
        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            try
            {
                var q = BL.CourseBL.GetAllCourses();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("course/{courseId}")]
        [HttpGet]

        public IHttpActionResult GetCourse(int courseId)
        {
            try
            {
                var q = BL.CourseBL.GetCourse(courseId);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       
        [Route("course")]
        [HttpPost]
        public IHttpActionResult PostCourse([FromBody]CourseDTO course)
        {
            try
            {
                var q = BL.CourseBL.PostCourse(course);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("course/{courseId}")]
        [HttpDelete]
        public IHttpActionResult DeleteCourse(int courseId)
        {
            try
            {
                var q = BL.CourseBL.DeleteCourse(courseId);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

      
        [Route("course")]
        [HttpPut]
        public string PutCourse(CourseDTO course)
        {
            try
            {
                return CourseBL.PutCourse(course);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
    }
}
