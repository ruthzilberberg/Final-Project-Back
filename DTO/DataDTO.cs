using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DataDTO
    {
        public int MinStudentInTeaching { get; set; }
        public int MaxStudentInTeaching { get; set; }
        public int minStudentInTichunim { get; set; }
        public int maxStudentInTichunim { get; set; }
        public double maxPositionHours { get; set; }
        public Nullable<System.DateTime> BeginingOfYear { get; set; }
        public Nullable<double> EngagedStandard { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
