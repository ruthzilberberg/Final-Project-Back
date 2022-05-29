using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
   public class TeachingGroupConvert
    {
        public static DAL.TeachingGroup ToDalTeachingGroup(DTO.TeachingGroupDTO cDto)
        {
            DAL.TeachingGroup cDal = new DAL.TeachingGroup();
            cDal.TeachingId = cDto.TeachingId;
            cDal.TeachingName= cDto.TeachingName;
        
            return cDal;
        }
        public static DTO.TeachingGroupDTO ToDtoTeachingGroup(DAL.TeachingGroup cDal)
        {
            DTO.TeachingGroupDTO cDto = new DTO.TeachingGroupDTO();
            cDto.TeachingId = cDal.TeachingId;
            cDto.TeachingName = cDal.TeachingName;
          
            return cDto;
        }
        public static List<DAL.TeachingGroup> ToDalListTeachingGroups(List<DTO.TeachingGroupDTO> cDto)
        {
            List<DAL.TeachingGroup> cDal = new List<DAL.TeachingGroup>();
            foreach (var item in cDto)
            {
                cDal.Add(ToDalTeachingGroup(item));
            }
            return cDal;
        }
        public static List<DTO.TeachingGroupDTO> ToDtoListTeachingGroups(List<DAL.TeachingGroup> cDal)
        {
            List<DTO.TeachingGroupDTO> cDto = new List<DTO.TeachingGroupDTO>();
            foreach (var item in cDal)
            {
                cDto.Add(ToDtoTeachingGroup(item));
            }
            return cDto;
        }
    }
}
