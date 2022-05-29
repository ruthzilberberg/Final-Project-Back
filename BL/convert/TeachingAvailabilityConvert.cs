using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
  public class TeachingAvailabilityConvert
    {
        public static DAL.TeachingAvailability ToDalTeachingAvailability(DTO.TeachingAvailabilityDTO tDto)
        {
            DAL.TeachingAvailability tDal = new DAL.TeachingAvailability();
            tDal.AvailabilityId = tDto.AvailabilityId;
            tDal.TeacherId= tDto.TeacherId;
            tDal.Sunday = tDto.IsSunday;
            tDal.Monday = tDto.IsMonday;
            tDal.Tuesday = tDto.IsTuesday;
            tDal.Wednesday = tDto.IsWednesday;
            tDal.Thursday = tDto.IsThursday;
            tDal.Friday = tDto.IsFriday;
            return tDal;
        }
        public static DTO.TeachingAvailabilityDTO ToDtoTeachingAvailability(DAL.TeachingAvailability tDal)
        {
            DTO.TeachingAvailabilityDTO tDto = new DTO.TeachingAvailabilityDTO();
            tDto.AvailabilityId=tDal.AvailabilityId ;
            tDto.TeacherId=tDal.TeacherId  ;
            tDto.IsSunday= tDal.Sunday ;
            tDto.IsMonday= tDal.Monday  ;
            tDto.IsTuesday=tDal.Tuesday  ;
            tDto.IsWednesday=tDal.Wednesday ;
            tDto.IsThursday=tDal.Thursday ;
            tDto.IsFriday=tDal.Friday ;

            return tDto;
        }
        public static List<DAL.TeachingAvailability> ToDalListTeachingAvailabilities(List<DTO.TeachingAvailabilityDTO> tDto)
        {
            List<DAL.TeachingAvailability> tDal = new List<DAL.TeachingAvailability>();
            foreach (var item in tDto)
            {
                tDal.Add(ToDalTeachingAvailability(item));
            }
            return tDal;
        }
        public static List<DTO.TeachingAvailabilityDTO> ToDtoListTeachingAvailabilities(List<DAL.TeachingAvailability> tDal)
        {
            List<DTO.TeachingAvailabilityDTO> tDto = new List<DTO.TeachingAvailabilityDTO>();
            foreach (var item in tDal)
            {
                tDto.Add(ToDtoTeachingAvailability(item));
            }
            return tDto;
        }
    }
}
