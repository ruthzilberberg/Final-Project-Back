using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class StudentDTO
    {
        public int StudenId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentTz { get; set; }
        public string Grade { get; set; }
        public string Class { get; set; }
        public bool IsEngaged { get; set; }
       public bool IsIncludingTeaching { get; set; } 
        public bool IsActive { get; set; }


    }
}
