using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
    class CourseForStudentConvert
    {
        public static DAL.CourseForStudent ToDalCourseForStudent(DTO.CourseForStudentDTO cDto)
        {
            DAL.CourseForStudent cDal = new DAL.CourseForStudent();
            cDal.StudentId = cDto.StudentId;
            cDal.CourseId = cDto.CourseId;
            cDal.TeachingId = cDto.TeachingId;
            cDal.StartDate = cDto.StartDate;
            cDal.EndDate = cDto.EndDate;

            return cDal;
        }
        public static DTO.CourseForStudentDTO ToDtoCourseForStudent(DAL.CourseForStudent cDal)
        {
            DTO.CourseForStudentDTO cDto = new DTO.CourseForStudentDTO();
            cDto.StudentId = cDal.StudentId;
            cDto.CourseId = cDal.CourseId;
            cDto.TeachingId = cDal.TeachingId;
            cDto.StartDate = cDal.StartDate;
            cDto.EndDate = cDal.EndDate;
            return cDto;
        }
        public static List<DAL.CourseForStudent> ToDalListCourseForStudents(List<DTO.CourseForStudentDTO> cDto)
        {
            List<DAL.CourseForStudent> cDal = new List<DAL.CourseForStudent>();
            foreach (var item in cDto)
            {
                cDal.Add(ToDalCourseForStudent(item));
            }
            return cDal;
        }
        public static List<DTO.CourseForStudentDTO> ToDtoListCourseForStudents(List<DAL.CourseForStudent> cDal)
        {
            List<DTO.CourseForStudentDTO> cDto = new List<DTO.CourseForStudentDTO>();
            foreach (var item in cDal)
            {
                cDto.Add(ToDtoCourseForStudent(item));
            }
            return cDto;
        }
    }
}

