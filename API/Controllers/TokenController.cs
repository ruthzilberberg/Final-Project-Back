using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("token")]

    public class TokenController : ApiController
    {
        [HttpGet]
        public string Token()
        { string name = "jbkl"; string tz = "bjk.k";

            return BL.Token.AddUser(tz);
        }

    }
}
