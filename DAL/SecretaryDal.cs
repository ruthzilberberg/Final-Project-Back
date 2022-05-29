using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class SecretaryDal
    {
        public static List<Secretary> SelectSecretaries()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                return st.Secretaries.ToList();

            }
        }
        public static Secretary GetSecretary(string secretaryTz)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Secretaries.FirstOrDefault(s => s.SecretaryTz == secretaryTz);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string AddSecretary(Secretary secretary)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return null;
                    st.Secretaries.Add(secretary);
                    st.SaveChanges();
                    return "המזכירה נוספה למערכת";
                }
            }
            catch (Exception e)
            {
                return "(AddSecretary)שגיאה במערכת"; 
            }
        }

        public static string DeleteSecretary(int secretaryId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Secretaries.FirstOrDefault(c => c.SecretaryId == secretaryId);
                    if (q == null)
                        return "מזהה מזכירה שגוי";
                    st.Secretaries.Remove(q);
                    //st.SaveChanges();
                    return "המזכירה נמחקה מהמערכת";
                }
            }
            catch
            {
                return "(DeleteSecretary)שגיאה במערכת";
            }
        }

        public static string UpdateSecretary(Secretary secretary)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Secretaries.FirstOrDefault(s =>s.SecretaryId == secretary.SecretaryId);
                    if (q == null)
                        return " מזהה מזכירה שגוי";
                    q.SecretaryTz = secretary.SecretaryTz;
                    q.SecretaryFirstName = secretary.SecretaryFirstName;
                    q.SecretaryLastName = secretary.SecretaryLastName;
                    q.IsActive = secretary.IsActive;
                    q.PhoneNumber = secretary.PhoneNumber;
                    q.Adress = secretary.Adress;
                    q.Email = secretary.Email;
                    q.Password = secretary.Password;
                    
                    st.SaveChanges();
                    return "פרטי מזכירה התעדכנו במערכת";
                }
            }
            catch
            {
                return "(UpdateSecretary)שגיאה במערכת";
            }

        }
    }
}
