using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 
    public class GroupDetails
    {
        public int TeachingId { get; set; }
        public int GroupNumber { get; set; }
        public int NumOfStudent { get; set; }
        public int Grade { get; set; }
        public float StandardOfGroup { get; set; }
        public GroupDetails(int TeachingId, int GroupNumber, int NumOfStudent, int Grade, float StandardOfGroup)
        {
            this.TeachingId = TeachingId;
            this.GroupNumber = GroupNumber;
            this.NumOfStudent = NumOfStudent;
            this.Grade = Grade;
            this.StandardOfGroup = StandardOfGroup;
        }
     public static List<GroupDetails> studentGroup = new List<GroupDetails>();
     
        //public GroupDetails()
        //{
        //}
    }
}
