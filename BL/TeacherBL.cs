using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class TeacherBL
    {

        public static List<DTO.TeacherDTO> GetAllTeachers()
        {
            return convert.TeacherConvert.ToDtoListTeachers(DAL.TeacherDal.SelectTeachers());
        }
        public static TeacherDTO GetTeacher(string teacherTz)
        {
            var teacherDal = DAL.TeacherDal.GetTeacher(teacherTz);
            if (teacherDal != null)
                return convert.TeacherConvert.ToDtoTeacher(teacherDal);
            return null;
            //return convert.TeacherConvert.ToDtoTeacher(DAL.TeacherDal.GetTeacher(teacherTz));
        }

        public static string PutTeacher(DTO.TeacherDTO teacher)
        {
            return DAL.TeacherDal.PutTeacher(convert.TeacherConvert.ToDalTeacher(teacher));


            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
        public static string PutTeachingId(TeacherDTO teacher)
        {
            return DAL.TeacherDal.PutTeachingId(convert.TeacherConvert.ToDalTeacher(teacher));


            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }

        public static string CalculateStandard(DTO.TeacherDTO teacher)
        {
            return DAL.TeacherDal.CalculateStandard(convert.TeacherConvert.ToDalTeacher(teacher));
            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
        public static bool PostTeacher(TeacherDTO teacher)
        {
            return DAL.TeacherDal.AddTeacher(convert.TeacherConvert.ToDalTeacher(teacher));

        }
        //public static string UpdateTeachingId(List<DTO.TeacherDTO> teachers)
        //{
        //    return DAL.TeacherDal.UpdateTeachingId(convert.TeacherConvert.ToDalListTeachers(teachers));
        //    //return convert.TeacherConvert.ToDalListTeachers(DAL.TeacherDal.UpdateTeachingId(teachers));
        //}

        public static List<GroupDetails> GetGroupsForTeachers()
        {
            return TeacherDal.GetGroupsForTeachers();
        }
        public static string DeleteTeacher(int teacherId)
        {
            return DAL.TeacherDal.DeleteTeacher(teacherId);
        }
    }
}
