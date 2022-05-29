using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API1.Controllers;
//using API.Models;
using DTO;

namespace API1.Controllers
{
//[EnableCors(origns:"*",headers:"*",method:"*")]
   [RoutePrefix("student")]
    public class StudentsController : ApiController
    {
       
        //[Route("get")]
        //[HttpGet]
       
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
        //[Route("get")]
        //[HttpGet]

        //public IHttpActionResult GetStudentById()
        //{
        //    try
        //    {
        //        var q = BL.StudentBL.GetStudentById();
        //        if (q != null)
        //            return Ok(q);
        //        return NotFound();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //}
    }
}


