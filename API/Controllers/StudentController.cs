using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
 // [RoutePrefix("student")]

    public class StudentController : ApiController
    {

        [Route("getAllStudents")]
        [HttpGet]

        public IHttpActionResult GetStudents()
        {

            try
            {
                var q = BL.StudentBL.GetAllStudents();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("splitingToGroups")]
        [HttpGet]

        public IHttpActionResult SplitingToGroups()
        {

            try
            {
                var q = BL.StudentBL.SplitingToGroups1();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("getStudentGroup")]
        [HttpGet]

        public IHttpActionResult GetStudentGroup()
        {

            try
            {
                var q = BL.StudentBL.GetStudentGroup();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("getNumStudentsLeft")]
        [HttpGet]

        public IHttpActionResult  GetNumStudentsLeft()
        {

            try
            {
                var q = BL.StudentBL.GetNumStudentsLeft();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("getNumLeftTeaching")]
        [HttpGet]

        public IHttpActionResult GetNumLeftTeaching()
        {

            try
            {
                var q = BL.StudentBL.GetNumLeftTeaching();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("getNumEngagedTeaching")]
        [HttpGet]

        public IHttpActionResult GetNumEngagedTeaching()
        {

            try
            {
                var q = BL.StudentBL.GetNumEngagedTeaching();
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Route("student")]
        [HttpPut]
        public string PutStudent(StudentDTO student)
        {
            try
            {
                return StudentBL.PutStudent(student);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("engagedStudent")]
        [HttpPut]
        public string PutStudentEngaged(StudentDTO student)
        {
            try
            {
                return StudentBL.PutStudentEngaged(student);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("studentCourse")]
        [HttpPut]
        public string UpdateStudentCourse1(StudentDTO student,string courseName,string teachingName)
        {
            try
            {
                return StudentBL.UpdateStudentCourse(student,courseName,teachingName);
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        //[Route("stre/{str}")]
        //[HttpGet]
        //public string stre(string str)
        //{
        //    //string st = "1,2,4";
        //    List<string> st1= str.Split(',').ToList();
        //    try
        //    {
        //        return StudentBL.UpdateStudentCourse(st1[0], st1[1], st1[2]);
        //    }

        //    catch
        //    {
        //        return "שגיאת מערכת";
        //    }
        //}

        [Route("studentCourse")]
        [HttpPut]
        public string UpdateStudentCourse(List<string> s )
        {
            try
            {
                //for (int i = 0; i < list.Length; i++)
                //{
                //    Console.Write(list[i] + " ");
                //}
                //return StudentBL.UpdateStudentCourse(student, courseName, teachingName);
                return " ";
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("studentCourse")]
        [HttpPut]
        public string UpdateStudentCourse(params string[] s)
        {
            try
            {
                //for (int i = 0; i < list.Length; i++)
                //{
                //    Console.Write(list[i] + " ");
                //}
                //return StudentBL.UpdateStudentCourse(student, courseName, teachingName);
                return " ";
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("studentCourse")]
        [HttpPut]
        public string UpdateStudentCourse2(StudentDTO student, string courseName)
        {
            try
            {
                //return StudentBL.UpdateStudentCourse(student, courseName, teachingName);
                return " ";
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("studentCourse")]
        [HttpPut]
        public string UpdateStudentCourse(string s,string c)
        {
            try
            {
                //return StudentBL.UpdateStudentCourse(student, courseName, teachingName);
                return " ";
            }

            catch
            {
                return "שגיאת מערכת";
            }
        }
        [Route("saveFileToDatabase")]
        [HttpPost]
        public string SaveFileToDatabase(string filePath)
        {
            try
            {
                StudentBL.SaveFileToDatabase(filePath);
                return " ";
            }

            catch
            {
                return " ";
            }
        }

        [Route("student")]
        [HttpPost]
        public IHttpActionResult PostStudent([FromBody]StudentDTO student)
        {
            try
            {
                var q = BL.StudentBL.PostStudent(student);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("student/{studentId}")]
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int studentId)
        {
            try
            {
                var q = BL.StudentBL.DeleteStudent(studentId);
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