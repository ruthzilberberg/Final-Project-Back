using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class TeachingAvailabilityBL
    {
        public static List<DTO.TeachingAvailabilityDTO> GetAllTeachingAvailabilities()
        {
            return convert.TeachingAvailabilityConvert.ToDtoListTeachingAvailabilities(DAL.TeachingAvailabilityDal.SelectTeachingAvailabilities());
        }
        public static string PutTeachingAvailability(DTO.TeachingAvailabilityDTO teacher)
        {
            return DAL.TeachingAvailabilityDal.UpdateTeachingAvailabilities(convert.TeachingAvailabilityConvert.ToDalTeachingAvailability(teacher));


            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
        public static string PostTeachingAvailability(TeachingAvailabilityDTO teacher)
        {
            return DAL.TeachingAvailabilityDal.AddTeachingAvailabilities(convert.TeachingAvailabilityConvert.ToDalTeachingAvailability(teacher));

        }
        
        public static string DeleteTeachingAvailability(int teacherId)
        {
            return DAL.TeachingAvailabilityDal.DeleteTeachingAvailabilities(teacherId);
        }
        public static TeachingAvailabilityDTO GetAvailability(int teacherId)
        {
            return convert.TeachingAvailabilityConvert.ToDtoTeachingAvailability(DAL.TeachingAvailabilityDal.GetAvailability(teacherId));
        }
    }
}
