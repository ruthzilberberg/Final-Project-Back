using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseDal
    {
        public static List<Course> SelectCourses()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    return st.Courses.ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static Course GetCourse(int courseId)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Courses.FirstOrDefault(c => c.CourseId == courseId);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
        public static string AddCourse(Course course)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return null;
                   st.Courses.Add(course);
                   st.SaveChanges();
                    return "הקורס נוסף למערכת";
                }
            }
            catch (Exception e)
            {
                return "(AddCourse)שגיאת מערכת";
            }
        }

        public static string DeleteCourse(int courseId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Courses.FirstOrDefault(c => c.CourseId == courseId);
                    if (q == null)
                       return " מזהה התמחות שגוי"; ;
                    st.Courses.Remove(q);
                   //st.SaveChanges();
                    return "ההתמחות נמחקה מהמערכת";
                }
            }
            catch
            {
                return "(DeleteCourse)שגיאת מערכת";
            }
        }
          
        public static string UpdateCourse(Course course)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    if (q == null)
                        return "הקורס לא נמצא במערכת";
                    q.CourseName = course.CourseName;
                    q.CourseType = course.CourseType;
                    st.SaveChanges();
                    return "הקורס התעדכן במערכת";
                }
            }
            catch
            {
                return "(UpdateCourse)שגיאה במערכת";
            }

        }
        
    }
}

