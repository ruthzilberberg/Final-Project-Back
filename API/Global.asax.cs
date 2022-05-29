using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //BL.StudentBL.DeleteStudent();
          // BL.StudentBL.DeleteGroup();
           // BL.StudentBL.FillStudentStandard();
            BL.StudentBL.IsBeginingOfYear();
            BL.StudentBL.FillCoursestudentsLeft();
            BL.StudentBL.FillNumStudentsTeaching();

            BL.CourseForStudentBL.FillCourseStudent();
            BL.CourseForStudentBL.FillTeachingStudent();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        protected void Application_BeginRequest()
        {
           Response.AddHeader("Access-Control-Allow-Origin", "*");
            Response.AddHeader("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE");
            Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept"
);

            if (Request.Headers.AllKeys.Contains("Origin", StringComparer.CurrentCultureIgnoreCase)
                && Request.HttpMethod == "OPTIONS")
            {
                Response.End();
            }


        }
    }
}
