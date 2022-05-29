using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
  public class TeacherConvert
    {
        public static DAL.Teacher ToDalTeacher(DTO.TeacherDTO cDto)
        {
            DAL.Teacher cDal = new DAL.Teacher();
            cDal.TeacherId = cDto.TeacherId;
            cDal.TeacherFirstName = cDto.TeacherFirstName;
            cDal.TeacherLastName = cDto.TeacherLastName;
            cDal.TeacherTz = cDto.TeacherTz;
            cDal.IsActive = cDto.IsActive;
            cDal.TeachingId = cDto.TeachingId;
            cDal.PhoneNumber = cDto.PhoneNumber;
            cDal.Adress = cDto.Adress;
            cDal.Email = cDto.Email;
            cDal.TeacherGroup = cDto.TeacherGroup;
            //cDal.PositionPrecent = cDto.PositionPrecent;
            cDal.Permission = cDto.Permission;
            cDal.PositionHours = cDto.PositionHours;
            cDal.TeacherStandard = cDto.TeacherStandard;
    
            return cDal;
        }

        public static DTO.TeacherDTO ToDtoTeacher(DAL.Teacher cDal)
        {
            DTO.TeacherDTO cDto = new DTO.TeacherDTO();
            cDto.TeacherId = cDal.TeacherId;
            cDto.TeacherFirstName = cDal.TeacherFirstName;
            cDto.TeacherLastName = cDal.TeacherLastName;
            cDto.TeacherTz = cDal.TeacherTz;
            cDto.IsActive = cDal.IsActive;
            cDto.TeachingId = cDal.TeachingId;
            cDto.PhoneNumber = cDal.PhoneNumber;
            cDto.Adress = cDal.Adress;
            cDto.Email = cDal.Email;
            //cDto.PositionPrecent = cDal.PositionPrecent;
            cDto.Permission = cDal.Permission;
            cDto.PositionHours = cDal.PositionHours;
            cDto.TeacherStandard = cDal.TeacherStandard;
            cDto.TeacherGroup = cDal.TeacherGroup;
            return cDto;
        }
        public static List<DAL.Teacher> ToDalListTeachers(List<DTO.TeacherDTO> cDto)
        {
            List<DAL.Teacher> cDal = new List<DAL.Teacher>();
            foreach (var item in cDto)
            {
                cDal.Add(ToDalTeacher(item));
            }
            return cDal;
        }
        public static List<DTO.TeacherDTO> ToDtoListTeachers(List<DAL.Teacher> cDal)
        {
            List<DTO.TeacherDTO> cDto = new List<DTO.TeacherDTO>();
            foreach (var item in cDal)
            {
                cDto.Add(ToDtoTeacher(item));
            }
            return cDto;
        }
    }
}
