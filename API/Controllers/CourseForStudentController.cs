using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("courseForStudent")]

    public class CourseForStudentController : ApiController
    {

        [Route("get")]
        [HttpGet]

        public IHttpActionResult GetCourseForStudents()
        {
            try
            {
                var q = BL.CourseForStudentBL.GetAllCourseForStudents();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("getCourseStudent")]
        [HttpGet]

        public IHttpActionResult GetCourseForStudent()
        {

            try
            {
                var q = BL.CourseForStudentBL.GetCourseStudent();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("getTeachingStudent")]
        [HttpGet]

        public IHttpActionResult GetTeachingStudent()
        {

            try
            {
                var q = BL.CourseForStudentBL.GetTeachingStudent();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("fillCourseStudent")]
        [HttpGet]

        public IHttpActionResult FillCourseStudent()
        {

            try
            {
                var q = BL.CourseForStudentBL.FillCourseStudent();
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