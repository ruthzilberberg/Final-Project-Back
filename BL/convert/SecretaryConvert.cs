using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.convert
{
    public class SecretaryConvert
    {
        public static DAL.Secretary ToDalSecretary(DTO.SecretaryDTO sDto)
        {
            DAL.Secretary sDal = new DAL.Secretary();
            sDal.SecretaryId = sDto.SecretaryId;
            sDal.SecretaryFirstName = sDto.SecretaryFirstName;
            sDal.SecretaryLastName = sDto.SecretaryLastName;
            sDal.SecretaryTz = sDto.SecretaryTz;
            sDal.IsActive = sDto.IsActive;
            sDal.PhoneNumber = sDto.PhoneNumber;
            sDal.Adress = sDto.Adress;
            sDal.Email = sDto.Email;
            sDal.Permission = sDto.Permission;
            sDal.Password = sDto.Password;
            return sDal;
        }

        public static DTO.SecretaryDTO ToDtoSecretary(DAL.Secretary sDal)
        {
            DTO.SecretaryDTO sDto = new DTO.SecretaryDTO();
            sDto.SecretaryId = sDal.SecretaryId;
            sDto.SecretaryFirstName = sDal.SecretaryFirstName;
            sDto.SecretaryLastName = sDal.SecretaryLastName;
            sDto.SecretaryTz = sDal.SecretaryTz;
            sDto.IsActive = sDal.IsActive;
            sDto.PhoneNumber = sDal.PhoneNumber;
            sDto.Adress = sDal.Adress;
            sDto.Email = sDal.Email;
            sDto.Permission = sDal.Permission;
            sDto.Password = sDal.Password;
            return sDto;
        }
        public static List<DAL.Secretary> ToDalListSecretaries(List<DTO.SecretaryDTO> sDto)
        {
            List<DAL.Secretary> sDal = new List<DAL.Secretary>();
            foreach (var item in sDto)
            {
                sDal.Add(ToDalSecretary(item));
            }
            return sDal;
        }
        public static List<DTO.SecretaryDTO> ToDtoListSecretaries(List<DAL.Secretary> sDal)
        {
            List<DTO.SecretaryDTO> sDto = new List<DTO.SecretaryDTO>();
            foreach (var item in sDal)
            {
                sDto.Add(ToDtoSecretary(item));
            }
            return sDto;
        }
    }
}