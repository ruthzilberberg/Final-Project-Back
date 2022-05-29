using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
    public class CourseConvert
    {//getworker
        public static DAL.Course ToDalCourse(DTO.CourseDTO cDto)
        {
            DAL.Course cDal = new DAL.Course();
            cDal.CourseId = cDto.CourseId;
            cDal.CourseName = cDto.CourseName;
            cDal.CourseType = cDto.CourseType;
           
            return cDal;
        }
        //getworkerdto
        public static DTO.CourseDTO ToDtoCourse(DAL.Course cDal)
        {
            DTO.CourseDTO cDto = new DTO.CourseDTO();
            cDto.CourseId = cDal.CourseId;
            cDto.CourseName = cDal.CourseName;
            cDto.CourseType = cDal.CourseType;
            
            return cDto;
        }
        //getlistworkerdto
        public static List<DAL.Course> ToDalListCourses(List<DTO.CourseDTO> cDto)
        {
            List<DAL.Course> cDal = new List<DAL.Course>();
            foreach (var item in cDto)
            {
                cDal.Add(ToDalCourse(item));
            }
            return cDal;
        }
        public static List<DTO.CourseDTO> ToDtoListCourses(List<DAL.Course> cDal)
        {
            List<DTO.CourseDTO> cDto = new List<DTO.CourseDTO>();
            foreach (var item in cDal)
            {
                cDto.Add(ToDtoCourse(item));
            }
            return cDto;
        }
    }
}

