using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDal
    {
        public static List<Student> SelectStudents()
        {
            using (StandardEntities st = new StandardEntities())
            {
                return st.Students.ToList();

            }
        }

    }
}
