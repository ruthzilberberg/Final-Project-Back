using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentTz { get; set; }
        public int Grade { get; set; }
        public int Class { get; set; }
        public bool IsEngaged { get; set; }
        public bool IsIncludingTeaching { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> GroupNumber { get; set; }
        public Nullable<double> StudentStandard { get; set; }


    }
}
