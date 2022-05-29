using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TeachingGroupDTO
    {
        public int TeachingId { get; set; }
        public string TeachingName { get; set; }
        public Nullable<bool> Sunday { get; set; }
        public Nullable<bool> Monday { get; set; }
        public Nullable<bool> Tuesday { get; set; }
        public Nullable<bool> Wednesday { get; set; }
        public Nullable<bool> Thursday { get; set; }
        public Nullable<bool> Friday { get; set; }
        public Nullable<int> TeachingGroupGrade { get; set; }
    }
}
