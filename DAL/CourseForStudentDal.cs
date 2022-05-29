using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseForStudentDal
    {
        public static List<CourseForStudent> SelectCourseForStudents()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                return st.CourseForStudents.ToList();

            }
        }
        public static string FillCourseStudent()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var courseStudent = st.CourseForStudents.ToList();
                    var coursesName = st.Courses.ToList();
                    for (int i = 0; i < courseStudent.Count(); i++)
                    {
                        var courseId = courseStudent.ElementAt(i).CourseId;
                        StaticVariabls.CourseStudent.Add(courseStudent[i].StudentId, coursesName.FirstOrDefault(c => c.CourseId == courseId).CourseName);
                    }
                    return "";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static IDictionary<int, string> GetCourseStudent()
        {
         
            return StaticVariabls.CourseStudent;

        }
        public static void FillTeachingStudent()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var teachingStudent = st.CourseForStudents.ToList();
                    var teachingName = st.TeachingGroups.ToList();
                    for (int i = 0; i < teachingStudent.Count(); i++)
                    {
                        var teachingId = teachingStudent.ElementAt(i).TeachingId;
                        StaticVariabls.TeachingStudent.Add(teachingStudent[i].StudentId, st.TeachingGroups.FirstOrDefault(t => t.TeachingId == teachingId).TeachingName);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static IDictionary<int, string> GetTeachingStudent()
        {
           
            return StaticVariabls.TeachingStudent;

        }
        public static string DeleteStudentCourse(int studentId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.CourseForStudents.FirstOrDefault(s => s.StudentId == studentId);
                    if (q == null)
                        return "false";
                    st.CourseForStudents.Remove(q);
                   st.SaveChanges();
                    return "true";
                }
            }
            catch
            {
                return "false";
            }
        }

    }
}
