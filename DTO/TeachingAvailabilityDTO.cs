using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TeachingAvailabilityDTO
    {
        public int AvailabilityId { get; set; }
        public int TeacherId { get; set; }
        public bool IsSunday { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
    }
}
