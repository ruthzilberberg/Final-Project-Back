using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL.Convert
{
 public  class StudentConvert
    {
        public static DAL.Student ToDalStudent(DTO.StudentDTO sDto)
        {
            DAL.Student sDal= new DAL.Student();
            sDal.StudentId = sDto.StudenId;
            sDal.StudentFirstName = sDto.StudentFirstName;
            sDal.StudentLastName = sDto.StudentLastName;
            sDal.StudentTz = sDto.StudentTz;
            sDal.IsEngaged = sDto.IsEngaged;
            sDal.IsActive = sDto.IsActive;
            sDal.Grade = sDto.Grade;
            sDal.IsIncludingTeaching = sDal.IsIncludingTeaching;
            return sDal;
        }
        public static DTO.StudentDTO ToDtoStudent(DAL.Student sDal)
        {
          DTO.StudentDTO sDto = new DTO.StudentDTO();
            sDto.StudenId= sDal.StudentId;
            sDto.StudentFirstName = sDal.StudentFirstName;
            sDto.StudentLastName = sDal.StudentLastName;
            sDto.StudentTz = sDal.StudentTz;
            sDto.IsEngaged = sDal.IsEngaged;
            sDto.IsActive = sDal.IsActive;
            sDto.Grade = sDal.Grade;
            sDto.IsIncludingTeaching = sDal.IsIncludingTeaching;
            return sDto;
        }
        public static List<DAL.Student> ToDalListStudents(List<DTO.StudentDTO> sDto)
        {
            List<DAL.Student> sDal = new List<DAL.Student>();
            foreach (var item in sDto)
            {
                sDal.Add(ToDalStudent(item));
            }
            return sDal;
        }
        public static List<DTO.StudentDTO> ToDtoListStudents(List<DAL.Student> sDal)
        {
            List<DTO.StudentDTO> sDto = new List<DTO.StudentDTO>();
            foreach (var item in sDal)
            {
                sDto.Add(ToDtoStudent(item));
            }
            return sDto;
        }
    }
    
}
