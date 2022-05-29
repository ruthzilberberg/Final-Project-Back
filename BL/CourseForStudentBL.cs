using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class CourseForStudentBL
    {
        public static List<DTO.CourseForStudentDTO> GetAllCourseForStudents()
        {
            return convert.CourseForStudentConvert.ToDtoListCourseForStudents(DAL.CourseForStudentDal.SelectCourseForStudents());
        }
        public static string FillCourseStudent()
        {
         return  CourseForStudentDal.FillCourseStudent();
        }
        public static IDictionary<int, string> GetCourseStudent()
        {
            return CourseForStudentDal.GetCourseStudent();
        }
        public static void FillTeachingStudent()
        {
            CourseForStudentDal.FillTeachingStudent();
        }
        public static IDictionary<int, string> GetTeachingStudent()
        {
            return CourseForStudentDal.GetTeachingStudent();
        }
    }
}
