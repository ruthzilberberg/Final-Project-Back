using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class TeachingGroupBL
    {
        public static List<DTO.TeachingGroupDTO> GetAllTeachingGroups()
        {
            return convert.TeachingGroupConvert.ToDtoListTeachingGroups(DAL.TeachingGroupDal.SelectTeachingGroups());
        }
        public static string PutTeachingGroup(DTO.TeachingGroupDTO teacher)
        {
            return DAL.TeachingGroupDal.UpdateTeachingGroup(convert.TeachingGroupConvert.ToDalTeachingGroup(teacher));


            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
        public static string PostTeachingGroup(DTO.TeachingGroupDTO teacher)
        {
            return DAL.TeachingGroupDal.AddTeachingGroup(convert.TeachingGroupConvert.ToDalTeachingGroup(teacher));

        }

        public static string DeleteTeachingGroup(int teacherId)
        {
            return DAL.TeachingGroupDal.DeleteTeachingGroup(teacherId);
        }
    }
}
