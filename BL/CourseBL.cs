using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CourseBL
    {
        public static List<DTO.CourseDTO> GetAllCourses()
        {
            return convert.CourseConvert.ToDtoListCourses(DAL.CourseDal.SelectCourses());
        }

        public static CourseDTO GetCourse(int courseId)
        {
            return convert.CourseConvert.ToDtoCourse(DAL.CourseDal.GetCourse(courseId));
        }
     
        public static string DeleteCourse(int courseId)
        {
            return DAL.CourseDal.DeleteCourse(courseId);
        }
       
        public static string PostCourse(CourseDTO course)
        {
            return DAL.CourseDal.AddCourse(convert.CourseConvert.ToDalCourse(course));

        }
      
        public static string PutCourse(DTO.CourseDTO newCourse)
        {
            return DAL.CourseDal.UpdateCourse(convert.CourseConvert.ToDalCourse(newCourse));

            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
    }
}

