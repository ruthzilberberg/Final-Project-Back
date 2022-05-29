using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
  public  class SecretaryBL
    {
      
        public static List<DTO.SecretaryDTO> GetAllSecretaries()
        {
            return convert.SecretaryConvert.ToDtoListSecretaries(DAL.SecretaryDal.SelectSecretaries());
        }
        public static SecretaryDTO GetSecretary(string secretaryTz)
        {
            var secretaryDal = DAL.SecretaryDal.GetSecretary(secretaryTz);
            if(secretaryDal != null)
            return convert.SecretaryConvert.ToDtoSecretary(secretaryDal);
            return null;
        }

        //public static void SendMail()
        //{
        //    Mail.SendMail();
        //}
        public static string DeleteSecretary(int secretaryId)
        {
            return DAL.SecretaryDal.DeleteSecretary(secretaryId);
        }

        public static string PostSecretary(SecretaryDTO secretary)
        {
            return DAL.SecretaryDal.AddSecretary(convert.SecretaryConvert.ToDalSecretary(secretary));

        }

        public static string PutSecretary(SecretaryDTO newSecretary)
        {
            return DAL.SecretaryDal.UpdateSecretary(convert.SecretaryConvert.ToDalSecretary(newSecretary));

            //return UserConverter.ReturnUserDTO(UserDAL.PostUser(Converters.UserConverter.ReturnUserDAL(newUser)));
        }
    }
}
