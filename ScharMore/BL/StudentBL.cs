using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
   public class StudentBL
    {
        public static List<DTO.StudentDTO> GetAllStudents()
        {
            return Convert.StudentConvert.ToDtoListStudents(DAL.StudentDal.SelectStudents());
        }
       
      
    }
}
