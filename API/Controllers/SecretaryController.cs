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
   // [EnableCors(origins: "*", headers: "*", methods: "*")]

   // [RoutePrefix("Secretary")]

    public class SecretaryController:ApiController
    {
        
       

            [Route("secretaries")]
            [HttpGet]

            public IHttpActionResult GetSecretaries()
            {
                try
                {
                    var q = BL.SecretaryBL.GetAllSecretaries();
                    if (q != null)
                        return Ok(q);
                    return NotFound();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
        [Route("secretary/{id}")]
        [HttpGet]
        public IHttpActionResult GetSecretary(string id)
        { 
            try
            {
                string secretaryTz = id;
                var q = BL.SecretaryBL.GetSecretary(secretaryTz);
                if (q != null)
                    return Ok(q);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Route("mail")]
        //[HttpGet]
        //public static void GetMailDriverToConfirm()
        //{

        //   BL.SecretaryBL.SendMail();
        //}
    

    [Route("secretary")]
    [HttpPost]
    public IHttpActionResult PostSecretary([FromBody]SecretaryDTO secretary)
    {
        try
        {
            var q = BL.SecretaryBL.PostSecretary(secretary);
            if (q != null)
                return Ok(q);
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("secretary/{secretaryId}")]
    [HttpDelete]
    public IHttpActionResult DeleteSecretary(int secretaryId)
    {
        try
        {
            var q = BL.SecretaryBL.DeleteSecretary(secretaryId);
            if (q != null)
                return Ok(q);
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }


    [Route("secretary")]
    [HttpPut]
    public string PutSecretary(SecretaryDTO secretary)
    {
        try
        {
            return SecretaryBL.PutSecretary(secretary);
        }

        catch
        {
            return "שגיאת מערכת";
        }
    }
}
}