using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
    class StudentCourseConvert
    {
       
        public static DTO.StudentCourseDTO ToDtoStudent(DAL.Student sDal)
        {
            DTO.StudentCourseDTO sDto = new DTO.StudentCourseDTO();
            sDto.StudentId = sDal.StudentId;
            sDto.StudentFirstName = sDal.StudentFirstName;
            sDto.StudentLastName = sDal.StudentLastName;
            sDto.StudentTz = sDal.StudentTz;
            sDto.IsEngaged = sDal.IsEngaged;
            sDto.IsActive = sDal.IsActive;
            sDto.Grade = sDal.Grade;
            sDto.IsIncludingTeaching = sDal.IsIncludingTeaching;
            sDto.GroupNumber = sDal.GroupNumber;
            //sDto.TeachingName=sDal.
     
            return sDto;
        }
        
        public static List<DTO.StudentCourseDTO> ToDtoListStudents(List<DAL.Student> sDal)
        {
            List<DTO.StudentCourseDTO> sDto = new List<DTO.StudentCourseDTO>();
            foreach (var item in sDal)
            {
                sDto.Add(ToDtoStudent(item));
            }
            return sDto;
        }
    }
}

