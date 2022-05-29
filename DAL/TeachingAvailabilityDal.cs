using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeachingAvailabilityDal
    {
        public static List<TeachingAvailability> SelectTeachingAvailabilities()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                return st.TeachingAvailabilities.ToList();

            }
        }
        public static TeachingAvailability GetAvailability(int teacherId)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.TeachingAvailabilities.FirstOrDefault(a => a.TeacherId == teacherId);
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
        public static string AddTeachingAvailabilities(TeachingAvailability teacher)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return null;
                    st.TeachingAvailabilities.Add(teacher);
                    st.SaveChanges();
                    return "המזכירה נוספה למערכת";
                }
            }
            catch (Exception e)
            {
                return "(AddSecretary)שגיאה במערכת";
            }
        }

        public static string DeleteTeachingAvailabilities(int teacherId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Secretaries.FirstOrDefault(c => c.SecretaryId == secretaryId);
                    //if (q == null)
                    //    return "מזהה מזכירה שגוי";
                    //st.Secretaries.Remove(q);
                    //st.SaveChanges();
                    return "המזכירה נמחקה למערכת";
                }
            }
            catch
            {
                return "(DeleteSecretary)שגיאה במערכת";
            }
        }

        public static string UpdateTeachingAvailabilities(TeachingAvailability teaching)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == teaching.TeacherId);
                    if (q == null)
                    {
                        var q2 = st.Teachers.FirstOrDefault(t => t.TeacherId == teaching.TeacherId);
                        if (q2 == null)
                            return "מזהה מורה שגוי";
                        else
                        {
                            st.TeachingAvailabilities.Add(teaching);
                        }

                    }
                    else { 
                    q.Sunday = teaching.Sunday;
                    q.Monday = teaching.Monday;
                    q.Tuesday = teaching.Tuesday;
                    q.Wednesday = teaching.Wednesday;
                    q.Thursday = teaching.Thursday;
                    q.Friday = teaching.Friday;
                    }
                    st.SaveChanges();
                    return "זמינות המורה התעדכן במערכת";
                }
            }
            catch
            {
                return "(UpdateTeachingAvailabilities)שגיאה במערכת";
            }

        }

    }
}
