using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class TeacherDal
    {
        public static List<Teacher> SelectTeachers()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                return st.Teachers.ToList();

            }
        }
        public static Teacher GetTeacher(string teacherTz)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacherTz);
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
        public static bool AddTeacher(Teacher teacher)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return null;
                    st.Teachers.Add(teacher);
                    st.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static string PutTeacher(Teacher teacher)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
                    if (q == null)
                        return " מזהה מורה שגוי";
                    q.TeacherTz = teacher.TeacherTz;
                    q.TeacherFirstName = teacher.TeacherFirstName;
                    q.TeacherLastName = teacher.TeacherLastName;
                    q.IsActive = teacher.IsActive;
                    q.TeachingId = teacher.TeachingId;
                    q.PhoneNumber = teacher.PhoneNumber;
                    q.Adress = teacher.Adress;
                    q.Email = teacher.Email;
                    q.Permission = teacher.Permission;
                    if (teacher.PositionHours > StaticVariabls.maxPositionHours)
                        return "שעות משרה גבוהות מהמותר";
                    q.PositionHours = teacher.PositionHours;
                    q.TeacherGroup = teacher.TeacherGroup;
                    q.PositionHours = teacher.PositionHours;
                    st.SaveChanges();
                    return "פרטי המורה התעדכנו במערכת";
                }
            }
            catch
            {
                return "(UpdateTeacher)שגיאה במערכת";
            }

        }
        public static string DeleteTeacher(int teacherId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
                    if (q == null)
                        return "מזהה מורה שגוי";
                    st.Teachers.Remove(q);
                    //st.SaveChanges();
                    return "המורה נמחקה מהמערכת";
                }
            }
            catch
            {
                return "(DeleteTeacher)שגיאה במערכת";
            }
        }
        //in the begining of the year
        public static string CalculateStandard(Teacher teacher)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {

                    double positionHours = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz).PositionHours;
                    //var teacherGroup = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz).TeacherGroup;
                    double newPositionHours = positionHours + GroupDetails.studentGroup.FirstOrDefault(std => std.GroupNumber == teacher.TeacherGroup).StandardOfGroup;
                    if (newPositionHours <= StaticVariabls.maxPositionHours)
                    {
                        var teacherTz = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz);
                        teacherTz.TeacherGroup = teacher.TeacherGroup;
                        teacherTz.PositionHours = newPositionHours;
                        if (teacherTz.TeacherStandard==null)
                        teacherTz.TeacherStandard =  GroupDetails.studentGroup.FirstOrDefault(std => std.GroupNumber == teacher.TeacherGroup).StandardOfGroup;
                        else
                            teacherTz.TeacherStandard = teacherTz.TeacherStandard + GroupDetails.studentGroup.FirstOrDefault(std => std.GroupNumber == teacher.TeacherGroup).StandardOfGroup;
                        st.SaveChanges();
                        return "שעות משרה התעדכנו במערכת";
                    }
                    return "שעות משרה גבוהות מהמותר";
                }
            }
            catch
            {
                return "(CalculateStandard)שגיאה במערכת";
            }
        }
        public static string UpdateStandard(Teacher teacher, Student student)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var teaching = st.CourseForStudents.FirstOrDefault(s => s.StudentId == student.StudentId).TeachingId;
                    var standard = st.TeachingGroups.FirstOrDefault(t => t.TeachingId == teaching).TeachingGroupStandard;
                    var newP = teacher.PositionHours - standard;
                    var newPositionHours = newP + 0.3;
                    var teacherTz = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz);
                    teacherTz.PositionHours = Convert.ToDouble(newPositionHours);
                    teacherTz.TeacherStandard = teacherTz.TeacherStandard - standard + 0.3;
                    st.SaveChanges();
                    return "תקן מורה התעדכן";
                }
            }
            catch
            {
                return "(UpdateStandard)שגיאה במערכת";
            }
        }
        public static string UpdateLeftStandard(Teacher teacher, Teacher newTeacher, Student student)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var teaching = st.CourseForStudents.FirstOrDefault(s => s.StudentId == student.StudentId).TeachingId;
                    var standard = st.TeachingGroups.FirstOrDefault(t => t.TeachingId == teaching).TeachingGroupStandard;
                    var newP = teacher.PositionHours - standard;
                    var newPositionHours = newP + 0.2;
                    var teacherTz = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz);
                    teacherTz.PositionHours = Convert.ToDouble(newPositionHours);
                    teacherTz.TeacherStandard = teacherTz.TeacherStandard - standard + 0.2;
                    newTeacher.PositionHours = newTeacher.PositionHours + 0.25;
                    newTeacher.TeacherStandard = newTeacher.TeacherStandard + 0.25;
                    st.SaveChanges();
                    return "תקן מורה התעדכן";
                }
            }
            catch
            {
                return "(UpdateStandard)שגיאה במערכת";
            }
        }
      
        public static string PutTeachingId(Teacher teacher)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //foreach (var teacher in Teachers)
                    //{
                    var q = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz);
                    if (q == null)
                        return " ת.ז שגויה";
                    q.TeacherTz = teacher.TeacherTz;
                    q.TeacherFirstName = teacher.TeacherFirstName;
                    q.TeacherLastName = teacher.TeacherLastName;
                    q.IsActive = teacher.IsActive;
                    q.PhoneNumber = teacher.PhoneNumber;
                    q.Adress = teacher.Adress;
                    q.Email = teacher.Email;
                    q.Permission = teacher.Permission;
                    if (teacher.PositionHours > StaticVariabls.maxPositionHours)
                        return "שעות משרה גבוהות מהמותר";
                    q.PositionHours = teacher.PositionHours;
                    q.TeacherGroup = teacher.TeacherGroup;
                    q.PositionHours = teacher.PositionHours;
                    bool flag = true;
                    bool[] arrDays = new bool[7];
                    TeachingGroup group = new TeachingGroup();
                   // group = st.TeachingGroups.FirstOrDefault(grp => grp.TeachingId == teacher.TeachingId && grp.TeachingGroupGrade == teacher.TeachingGrade);
                    group = st.TeachingGroups.FirstOrDefault(grp => grp.TeachingId == teacher.TeachingId );
                   // group = st.TeachingGroups.FirstOrDefault(grp => grp.TeachingId == teacher.TeachingId);
                    TeachingAvailability teacherAv = new TeachingAvailability();
                    var teacherId = st.Teachers.FirstOrDefault(t => t.TeacherTz == teacher.TeacherTz).TeacherId;
                    teacherAv = st.TeachingAvailabilities.FirstOrDefault(tch => tch.TeacherId == teacherId);
                    //if (!(group.Sunday == true && teacherAv.Sunday == true))
                    if (group.Sunday == true)
                    {

                        if (teacherAv.Sunday == false)
                            flag = false;
                        else
                            arrDays[1] = true;
                    }
                    //if (!(flag == true && group.Monday == true && teacherAv.Monday == true))
                    //{
                    //    arrDays[2] = true;
                    //    flag = false;
                    //}
                    if (group.Monday == true && flag == true)
                    {
                        if (teacherAv.Monday == false)
                            flag = false;
                        else
                            arrDays[2] = true;
                    }
                    if (group.Tuesday == true && flag == true)
                    {
                        if (teacherAv.Tuesday == false)
                            flag = false;
                        else
                            arrDays[3] = true;
                    }
                    if (group.Wednesday == true && flag == true)
                    {
                        if (teacherAv.Wednesday == false)
                            flag = false;
                        else
                            arrDays[4] = true;
                    }
                    if (group.Thursday == true && flag == true)
                    {
                        if (teacherAv.Thursday == false)
                            flag = false;
                        else
                            arrDays[5] = true;
                    }
                    if (group.Friday == true && flag == true)
                    {
                        if (teacherAv.Friday == false)
                            flag = false;
                        else
                            arrDays[6] = true;
                    }
                    if (flag)
                    {
                        //if (teacher.TeachingId != 0)
                        //    q.TeachingId = teacher.TeachingId;
                        if (q.TeachingId ==0)
                            q.TeachingId = teacher.TeachingId;
                        else
                        {
                            Teacher newTeacher = new Teacher();
                            newTeacher = q;
                            newTeacher.TeachingId = teacher.TeachingId;
                            q = newTeacher;
                            st.Teachers.Add(q);
                        }
                        for (int i = 1; i <= arrDays.Length; i++)
                        {
                            if (arrDays[1])
                                st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == q.TeacherId).Sunday = false;
                            if (arrDays[2])
                                st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == q.TeacherId).Monday = false;
                            if (arrDays[3])
                                st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == q.TeacherId).Tuesday = false;
                            if (arrDays[4])
                                st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == q.TeacherId).Wednesday = false;
                            if (arrDays[5])
                                st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == q.TeacherId).Thursday = false;
                            if (arrDays[6])
                                st.TeachingAvailabilities.FirstOrDefault(t => t.TeacherId == q.TeacherId).Friday = false;
                        }

                        st.SaveChanges();
                        return "סוג הוראה למורה התעדכן במערכת";
                    }
                    return "ימי הנחית ההוראה לסוג הוראה זה תפוסים";
                }

                //}
            }
            catch
            {
                return "(UpdateTeachingId)שגיאה במערכת";
            }

        }


        public static List<Teacher> DivisionOfTeachers()
        {

            using (StandardEntities2 st = new StandardEntities2())
            {


            }
            return new List<Teacher>();
        }
        public static List<GroupDetails> GetGroupsForTeachers()
        {

            try
            {
                return GroupDetails.studentGroup;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}

