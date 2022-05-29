using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string TeacherTz { get; set; }
        public bool IsActive { get; set; }
        public int TeachingId { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Nullable<int> Permission { get; set; }
        public double PositionHours { get; set; }
        public Nullable<int> TeacherGroup { get; set; }
        public Nullable<double> TeacherStandard { get; set; }
    }
}
