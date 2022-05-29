using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CourseForStudentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int TeachingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
