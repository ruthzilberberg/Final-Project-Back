using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    // [RoutePrefix("teacher")]
    public class TeacherController : ApiController
    {
        [Route("teachers")]
        [HttpGet]

        public IHttpActionResult GetTeachers()
        {

            try
            {
                var q = BL.TeacherBL.GetAllTeachers();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("teacher/{teacherTz}")]
        [HttpGet]
        public IHttpActionResult GetTeacher(string teacherTz)
        {
            try
            {
                var q = BL.TeacherBL.GetTeacher(teacherTz);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("groupTeacher")]
        [HttpGet]
        public IHttpActionResult GetGroupTeacher()
        {
            try
            {
                var q = BL.TeacherBL.GetGroupsForTeachers();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //coordinator or secrartery update teacher
        [Route("teacher")]
        [HttpPut]
        public string PutTeacher( DTO.TeacherDTO teacher)
        {
            try
            {
                return TeacherBL.PutTeacher(teacher);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        //[Route("teachers")]
        //[HttpPut]
        //public string PutTeacher(List<DTO.TeacherDTO> teachers)
        //{
        //    try
        //    {
        //        return TeacherBL.UpdateTeachingId(teachers);
        //    }

        //    catch
        //    {
        //        return "שגיאת מערכת";
        //    }
        //}
        [Route("putTeachingId")]
        [HttpPut]
        public string PutTeachingId(TeacherDTO teacher)
        {
            try
            {
                return TeacherBL.PutTeachingId(teacher);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("calculateStandard")]
        [HttpPut]
        public string CalculateStandard(DTO.TeacherDTO teacher)
        {
            try
            {
                return TeacherBL.CalculateStandard(teacher);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }

        [Route("teacher")]
        [HttpPost]
        public IHttpActionResult PostTeacher(DTO.TeacherDTO teacher)
        {
            try
            {
                var q = BL.TeacherBL.PostTeacher(teacher);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("teacher/{teacherId}")]
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int teacherId)
        {
            try
            {
                var q = BL.TeacherBL.DeleteTeacher(teacherId);
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