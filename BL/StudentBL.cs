using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class StudentBL
    {
        public static List<DTO.StudentDTO> GetAllStudents()
        {
            return Convert.StudentConvert.ToDtoListStudents(DAL.StudentDal.SelectStudents());
        }

        public static void IsBeginingOfYear()
        {
            StudentDal.IsBeginingOfYear();
        }
        public static string DeleteStudent(int studentId)
        {
            return DAL.StudentDal.DeleteStudent(studentId);
        }
        public static void FillCoursestudentsLeft()
        {
            StudentDal.FillCoursestudentsLeft();
        }
     
        public static void FillNumStudentsTeaching()
        {
            StudentDal.FillNumStudentsTeaching();
        }
        public static void FillStudentStandard()
        {
            StudentDal.FillStudentStandard();
        }
        public static void DeleteStudent()
        {
            StudentDal.DeleteStudent();
        }
        public static void DeleteGroup()
        {
            StudentDal.DeleteGroup();
        }
        public static IDictionary<string, int> GetNumStudentsLeft()
        {
            return StudentDal.GetNumStudentsLeft();
        }
        public static IDictionary<int, int> GetNumLeftTeaching()
        {
            return StudentDal.GetNumLeftTeaching();
        }

        public static IDictionary<int, int> GetNumEngagedTeaching()
        {
            return StudentDal.GetNumEngagedTeaching();
        }

        public static string PutStudent(DTO.StudentDTO student)
        {
            return DAL.StudentDal.PutStudent(Convert.StudentConvert.ToDalStudent(student));

            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
        public static string PutStudentEngaged(DTO.StudentDTO student)
        {
            return DAL.StudentDal.EngagedStudent(Convert.StudentConvert.ToDalStudent(student));

            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
        public static string SaveFileToDatabase(string filePath)
        {
            return DAL.DataDal.SaveFileToDatabase(filePath);
        }
        public static string UpdateStudentCourse(DTO.StudentDTO student, string courseName, string teacingName)
        {
            return DAL.StudentDal.UpdateStudentCourse(Convert.StudentConvert.ToDalStudent(student), courseName, teacingName);
        }
        //public static string UpdateStudentCourse(string studentTz, string courseName, string teacingName)
        //{
        //    return DAL.StudentDal.UpdateStudentCourse(studentTz, courseName, teacingName);
        //}
        public static string PostStudent(DTO.StudentDTO student)
        {
            return DAL.StudentDal.AddStudent(Convert.StudentConvert.ToDalStudent(student));

        }

        public static List<DTO.StudentDTO> SplitingToGroups1()
        {
            return Convert.StudentConvert.ToDtoListStudents(StudentDal.SplitingToGroups1());
        }
        public static List<GroupDetails> GetStudentGroup()
        {
            return StudentDal.GetStudentGroup();
        }
    }
}