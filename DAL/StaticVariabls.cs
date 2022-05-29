using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
 public static  class  StaticVariabls
    {
        //public static int numOfStudentInClass { set; get; }
      
        public static Dictionary<int, int> NumStudentsInBegining = new Dictionary<int, int>();
        public static Dictionary<string, int> NumStudentsLeft = new Dictionary<string, int>();
        public static Dictionary<int, int> NumLeftTeaching = new Dictionary<int, int>();
        public static Dictionary<int, int> CalculateNumLeftTeaching = new Dictionary<int, int>();
        public static Dictionary<int, int> NumEngagedTeaching = new Dictionary<int, int>();
        public static Dictionary<int, int> CalculateNumEngagedTeaching = new Dictionary<int, int>();
        public static Dictionary<int, string> CourseStudent = new Dictionary<int, string>();
        public static Dictionary<int, string> TeachingStudent = new Dictionary<int, string>();
        public static int minNumOfStudentInClass { set; get; }
        public static int maxNumOfStudentInClass { set; get; }
        public static int maxAboveMax { set; get; }
        public static int minNumOfStudentInTeaching2 { set; get; }
        public static int maxNumOfStudentInTeaching2 { set; get; }

        public static double maxPositionHours { set; get; }
        public static int numYears { set; get; }

        static StaticVariabls()
        {
            maxAboveMax = 1;
            //numOfStudentInClass = 25;
            minNumOfStudentInClass = 18;
            maxNumOfStudentInClass = 25;
            minNumOfStudentInTeaching2 = 17;
            maxNumOfStudentInTeaching2 = 20;
            maxPositionHours= 29.4;
            numYears = 0;
            //NumStudentsLeft.Add("אנגלית", 50);
            //NumStudentsLeft.Add("תפירה לעסקים ולהוראה", 25);
        }

    }
}
