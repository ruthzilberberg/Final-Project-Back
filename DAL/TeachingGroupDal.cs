using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class TeachingGroupDal
    {
        public static List<TeachingGroup> SelectTeachingGroups()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                return st.TeachingGroups.ToList();

            }
        }
        public static string AddTeachingGroup(TeachingGroup teacher)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return null;
                    st.TeachingGroups.Add(teacher);
                    st.SaveChanges();
                    return "המזכירה נוספה למערכת";
                }
            }
            catch (Exception e)
            {
                return "(AddSecretary)שגיאה במערכת";
            }
        }

        public static string DeleteTeachingGroup(int teacherId)
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

        public static string UpdateTeachingGroup(TeachingGroup teacher)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return "הקורס לא נמצא במערכת";
                    //q.CourseName = course.CourseName;
                    //q.CourseType = course.CourseType;
                    //st.SaveChanges();
                    return "הקורס התעדכן מהמערכת";
                }
            }
            catch
            {
                return "(UpdateCourse)שגיאה במערכת";
            }

        }
    }
}
