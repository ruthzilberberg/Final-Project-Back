using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using DTO;
using System.Configuration;

namespace DAL
{
    public class StudentDal
    {

        /// <summary>
        /// spliting students in grade 5 to groups regular teaching
        /// </summary>
        /// <returns> List Student </returns>
        public static List<Student> SplitingToGroups1()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                Dictionary<int, int> StudentsWithoutGroup = new Dictionary<int, int>();
                int teachingId = 1; //הוראה רגילה 
                int grade = 5;
                int numOfGroups = 1;
                List<Student> firstYearStudents = st.Students.Where(std => std.Grade == grade).ToList();//.OrderBy(std=>std.Class).ToList();
                List<Student> teaching1 = (from item in firstYearStudents
                                           join item2 in st.CourseForStudents
                                           on item.StudentId equals item2.StudentId
                                           where item2.TeachingId == teachingId
                                           select item).ToList();
                teaching1.OrderBy(sd => sd.Class);
                var lastStudentsInClasses = (from item in teaching1
                                             group item by item.Class into grouped
                                             let last = grouped.Last()
                                             select new
                                             {
                                                 classNum = last.Class,
                                                 Index = teaching1.TakeWhile(lst => lst != last).Count()
                                             }).ToList();
                //lastStudentsInClasses.RemoveAt(0);
                lastStudentsInClasses.OrderBy(cls => cls.classNum);
                //Index אינדקס של בת אחרונה בכל כיתה   
                int indexOfFirstStudent = 0;
                if (lastStudentsInClasses.ElementAt(0).Index >= StaticVariabls.minNumOfStudentInClass && lastStudentsInClasses.ElementAt(0).Index <= StaticVariabls.maxNumOfStudentInClass)
                {
                    while (indexOfFirstStudent <= lastStudentsInClasses.ElementAt(0).Index)
                        teaching1.ElementAt(indexOfFirstStudent++).GroupNumber = numOfGroups;
                    FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInClasses.ElementAt(0).Index, grade);
                    numOfGroups++;
                    //  indexOfFirstStudent += lastStudentsInClasses.ElementAt(indexOfFirstStudent).Index;
                }
                else
                {
                    StudentsWithoutGroup.Add(lastStudentsInClasses.ElementAt(0).classNum, lastStudentsInClasses.ElementAt(0).Index);
                    indexOfFirstStudent += lastStudentsInClasses.ElementAt(0).Index;
                }

                for (int i = 1; i < lastStudentsInClasses.Count(); i++)
                {
                    var numOfStudentInClass = lastStudentsInClasses.ElementAt(i).Index - lastStudentsInClasses.ElementAt(i - 1).Index;
                    if (numOfStudentInClass >= StaticVariabls.minNumOfStudentInClass && numOfStudentInClass <= StaticVariabls.maxNumOfStudentInClass)
                    {

                        while (indexOfFirstStudent <= lastStudentsInClasses.ElementAt(i).Index)
                            teaching1.ElementAt(indexOfFirstStudent++).GroupNumber = numOfGroups;
                        FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInClasses.ElementAt(i).Index - lastStudentsInClasses.ElementAt(i - 1).Index, grade);
                        numOfGroups++;
                    }
                    else
                    {
                        StudentsWithoutGroup.Add(lastStudentsInClasses.ElementAt(i).classNum, lastStudentsInClasses.ElementAt(i).Index - lastStudentsInClasses.ElementAt(i - 1).Index);
                        indexOfFirstStudent += lastStudentsInClasses.ElementAt(i).Index;
                    }
                    // int index1 = c.TakeWhile()//TakeWhile(lst => lst != last).Count()

                }

                ///////////////////////////////////////////////////
                Dictionary<int, int> SortStudents = new Dictionary<int, int>();
                //SortStudents = StudentsWithoutGroup;

                //var cc = StudentsWithoutGroup.Keys.Where(k => k < 9).Max();

                //Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
                //foreach (var clss in StudentsWithoutGroup)
                //{
                //    if (dic.ContainsKey(clss.Value))
                //    {

                //        var values = (List<int>)dic[clss.Value];
                //        values.Add(clss.Key);
                //        dic[clss.Value] = values;
                //    }
                //    else
                //    {
                //        dic.Add(clss.Value, new List<int> { clss.Key });
                //    }
                //}
                //StaticData stData = st.StaticDatas.OrderBy(x => x.UpdateDate).Last();

                //foreach (var item in dic)
                //{

                //    var key = dic.Keys.Where(k => k < stData.MaxStudentInTeaching - item.Key).Max();
                //    //לכתוב לכל תלמידה את הקבןצה שלה
                //    //dic[key][0];
                //    dic[key].Remove(dic[key][0]);
                //    if (dic[key].Count == 0)
                //    {
                //        dic.Remove(key);
                //    }
                //}



                //////////////////////////////////////////

                //var countStudentGroups = SortStudents.Count();
                //if (countStudentGroups % 2 != 0)
                //{

                //    for (int i = 0; i < SortStudents.Last().Value; i++)
                //        teaching1.FirstOrDefault(std => std.Class == SortStudents.Last().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                //    numOfGroups++;
                //    SortStudents.Remove(SortStudents.Last().Key);
                //}
                //else
                //{


                //  SortStudents = StudentsWithoutGroup;
                //SortStudents.OrderBy(student => student.Value);
                SortStudents = (from pair in StudentsWithoutGroup
                                orderby pair.Value ascending
                                select pair).ToDictionary(t => t.Key, t => t.Value);
                //Dictionary<int, int> SortStudents = dict.ToDictionary(t => t.Key, t => t.Value);

                int numOfStudents = 0;
                //int indexOfStudents = 0;
                int extraStudents = 0;
                while (SortStudents.Count() > 0)
                {
                    if (SortStudents.First().Value + SortStudents.Last().Value <= StaticVariabls.maxNumOfStudentInClass + StaticVariabls.maxAboveMax)
                    {
                        for (int i = 0; i < SortStudents.First().Value; i++)
                        {
                            //var enumerator =SortStudents.Keys.SkipWhile(k => k != myKey);

                            teaching1.FirstOrDefault(std => std.Class == SortStudents.First().Key && std.GroupNumber == null).GroupNumber = numOfGroups;


                            numOfStudents++;
                        }
                        for (int i = 0; i < SortStudents.Last().Value; i++)
                        {

                            teaching1.FirstOrDefault(s => s.Class == SortStudents.Last().Key).GroupNumber = numOfGroups;
                            //FillNumStudentsInBegining(teachingId,numOfGroups, SortStudents.Last().Value, grade);
                            //FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInClasses.ElementAt(0).Index, grade);
                            numOfStudents++;
                        }
                        SortStudents.Remove(SortStudents.Last().Key);
                        SortStudents.Remove(SortStudents.First().Key);

                        while (numOfStudents < StaticVariabls.minNumOfStudentInClass)
                        {
                            extraStudents = StaticVariabls.maxNumOfStudentInClass + StaticVariabls.maxAboveMax - numOfStudents;
                            if (SortStudents.First().Value <= extraStudents)
                                for (int i = 0; i < SortStudents.First().Value; i++)
                                {
                                    teaching1.FirstOrDefault(std => std.Class == SortStudents.First().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                                    //FillNumStudentsInBegining(teachingId,numOfGroups, lastStudentsInClasses.ElementAt(0).Index,grade);
                                    numOfStudents++;
                                }
                            SortStudents.Remove(SortStudents.First().Key);
                        }
                        FillNumStudentsInBegining(teachingId, numOfGroups, numOfStudents, grade);
                        numOfGroups++;
                        extraStudents = 0;
                        numOfStudents = 0;
                    }
                    else
                    {
                        for (int i = 0; i < SortStudents.Last().Value; i++)
                            teaching1.FirstOrDefault(std => std.Class == SortStudents.Last().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                        FillNumStudentsInBegining(teachingId, numOfGroups, SortStudents.Last().Value, grade);
                        /*FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInClasses.ElementAt(0).Index, grade)*/
                        ;
                        numOfGroups++;
                        SortStudents.Remove(SortStudents.Last().Key);

                    }
                }
                st.SaveChanges();
               
                SplitingToGroups2(numOfGroups, firstYearStudents, grade);
                teachingId = 3;//מרוכזת
                List<CourseForStudent> teaching3 = (from item in firstYearStudents
                                join item2 in st.CourseForStudents
                                on item.StudentId equals item2.StudentId
                                where item2.TeachingId == teachingId
                                select item2).ToList();
                //List<CourseForStudent> teaching3_normal = new List<CourseForStudent>();
                //foreach (var item in teaching3)
                //{
                //    teaching3_normal.Add(item);
                //}
                SplitingToGroups3(firstYearStudents, numOfGroups, teaching3, teachingId, grade);
                return st.Students.ToList();

            }

        }
        /// <summary>
        /// order by Greedy Algorithm spliting students in grade 5 to groups tichunim teaching
        /// </summary>
        /// <param name="numOfGroups"></param>
        /// <param name="gradeStudents"></param>
        /// <param name="grade"></param>
        /// <returns>List Student</returns>
        public static List<Student> SplitingToGroups2(int numOfGroups, List<Student> gradeStudents, int grade)
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                // Dictionary<int, List<int>> Students = new Dictionary<int, List<int>>();

                //if (grade == 5)
                int teachingId = 2;//תיכונים
                //else
                //    teachingId = 8;
                Dictionary<int, int> Students = new Dictionary<int, int>();
                //List<Student> firstYearStudents = st.Students.Where(std => std.Grade == 5).ToList();
                List<Student> teaching2 = (from item in gradeStudents
                                join item2 in st.CourseForStudents
                                on item.StudentId equals item2.StudentId
                                where item2.TeachingId == teachingId
                                select item).ToList();
                teaching2.OrderBy(sd => sd.Class);
                var lastStudentsInClasses = (from item in teaching2
                                             group item by item.Class into grouped
                                             let last = grouped.Last()
                                             select new
                                             {
                                                 classNum = last.Class,
                                                 Index = teaching2.TakeWhile(lst => lst != last).Count()
                                             }).ToList();
                lastStudentsInClasses.OrderBy(cls => cls.classNum);
               
                    Students.Add(lastStudentsInClasses.ElementAt(0).classNum, lastStudentsInClasses.ElementAt(0).Index);
              
                for(int i=1;i< lastStudentsInClasses.Count();i++)
                { 
                Students.Add(lastStudentsInClasses.ElementAt(i).classNum, lastStudentsInClasses.ElementAt(i).Index - lastStudentsInClasses.ElementAt(i - 1).Index);
                }
                Dictionary<int, int> SortStudents = new Dictionary<int, int>();
                SortStudents = (from pair in Students
                             orderby pair.Value descending
                                select pair).ToDictionary(t => t.Key, t => t.Value);
                var countStudentGroups = SortStudents.Sum(c => c.Value);
                // אם  אפשרי להכניס את כל הבנות שבהוראה לתיכונים לקבוצה אחת 
                if (countStudentGroups <= StaticVariabls.maxNumOfStudentInTeaching2 + StaticVariabls.maxAboveMax)
                {
                    int i;
                    for (i = 0; i < teaching2.Count(); i++)
                        teaching2.ElementAt(i).GroupNumber = numOfGroups;
                    FillNumStudentsInBegining(teachingId, numOfGroups, i, grade);
                }
                //אחרת נחלק את הבנות לשתי קבוצות
                //numOfStudents-כמות רצויה לקבוצה
                else
                {
                    int numOfStudents = countStudentGroups / 2;
                    int numOfTichonStudents = 0;
                    for (int j = 0; j < SortStudents.Count();)
                        if (SortStudents.ElementAt(j).Value <= numOfStudents)
                        {
                            int i = 0;
                            //טעות---numOfStudents = numOfStudents - SortStudents.First().Value;
                            //תיקון
                            numOfStudents = numOfStudents - SortStudents.ElementAt(j).Value;
                            for (i = 0; i < SortStudents.ElementAt(j).Value; i++)
                            {
                                teaching2.FirstOrDefault(std => std.Class == SortStudents.ElementAt(j).Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                            }
                            SortStudents.Remove(SortStudents.ElementAt(j).Key);
                            numOfTichonStudents += i;
                        }
                        else
                        {
                            j++;
                        }
                    FillNumStudentsInBegining(teachingId, numOfGroups, numOfTichonStudents, grade);
                    numOfGroups++;
                    for (int i = 0; i < SortStudents.Count(); i++)
                        for (int j = 0; j < SortStudents.ElementAt(i).Value; j++)
                            teaching2.FirstOrDefault(std => std.Class == SortStudents.ElementAt(i).Key).GroupNumber = numOfGroups;

                }
                st.SaveChanges();
               return st.Students.ToList();
            }
        }
        /// <summary>
        ///  spliting students in grade 5 and 6 to groups merukezet teaching and students in grade 6 to groups regular teaching
        /// </summary>
        /// <param name="gradeStudents"></param>
        /// <param name="numOfGroups"></param>
        /// <param name="teaching"></param>
        /// <param name="teachingId"></param>
        /// <param name="grade"></param>
        /// <returns>List Student</returns>
        public static List<Student> SplitingToGroups3(List<Student> gradeStudents, int numOfGroups, List<CourseForStudent> teachings, int teachingId, int grade)
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                Dictionary<int, int> StudentsGroup = new Dictionary<int, int>();
                //var teaching3 = from item in gradeStudents
                //                join item2 in st.CourseForStudents
                //                on item.StudentId equals item2.StudentId
                //                where item2.TeachingId == 3
                //                select item2;
                //teaching.OrderBy(sd => sd.CourseId).ToList();
                numOfGroups = 9;
                List<CourseForStudent> teaching = teachings.OrderBy(sd => sd.CourseId)
                  
                   .ToList();
                var lastStudentsInCourses =( from item2 in teaching
                                            group item2 by item2.CourseId into grouped
                                            let last = grouped.Last()
                                            select new
                                            {
                                                classNum = last.CourseId,
                                                Index = teaching.TakeWhile(lst => lst != last).Count()
                                            }).ToList();
                numOfGroups = 9;
                lastStudentsInCourses.OrderBy(cls => cls.classNum);
                int indexOfFirstStudent = 0;

                if (lastStudentsInCourses.ElementAt(0).Index >= StaticVariabls.minNumOfStudentInClass && lastStudentsInCourses.ElementAt(0).Index <= StaticVariabls.maxNumOfStudentInClass)
                {
                    while (indexOfFirstStudent <= lastStudentsInCourses.ElementAt(0).Index)
                        //gradeStudents[teaching.ElementAt(indexOfFirstStudent++).StudentId].GroupNumber = numOfGroups;
                        gradeStudents.FirstOrDefault(grd => grd.StudentId == teaching.ElementAt(indexOfFirstStudent++).StudentId && grd.GroupNumber ==null).GroupNumber = numOfGroups;
                    FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInCourses.ElementAt(0).Index, grade);
                    numOfGroups++;
                }
                else
                {
                    StudentsGroup.Add(lastStudentsInCourses.ElementAt(0).classNum, lastStudentsInCourses.ElementAt(0).Index);
                    indexOfFirstStudent += lastStudentsInCourses.ElementAt(0).Index;
                }

                for (int i = 1; i < lastStudentsInCourses.Count(); i++)
                {
                    var numOfStudentInClass = lastStudentsInCourses.ElementAt(i).Index - lastStudentsInCourses.ElementAt(i - 1).Index;
                    if (numOfStudentInClass >= StaticVariabls.minNumOfStudentInClass && numOfStudentInClass <= StaticVariabls.maxNumOfStudentInClass)
                    {
                        while (indexOfFirstStudent <= lastStudentsInCourses.ElementAt(i).Index)
                            //gradeStudents[teaching.ElementAt(indexOfFirstStudent++).StudentId].GroupNumber = numOfGroups;
                            gradeStudents.FirstOrDefault(grd => grd.StudentId == teaching.ElementAt(indexOfFirstStudent++).StudentId && grd.GroupNumber ==null).GroupNumber = numOfGroups;
                        //gradeStudents.FirstOrDefault(grade => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grade.StudentId).GroupNumber = numOfGroups;
                        FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInCourses.ElementAt(i).Index, grade);
                        numOfGroups++;
                    }
                    else
                    {
                        StudentsGroup.Add(lastStudentsInCourses.ElementAt(i).classNum, lastStudentsInCourses.ElementAt(i).Index - lastStudentsInCourses.ElementAt(i-1).Index);
                        indexOfFirstStudent += lastStudentsInCourses.ElementAt(i).Index;
                    }
                }
                Dictionary<int, int> SortStudents = new Dictionary<int, int>();
                SortStudents = (from pair in StudentsGroup
                                orderby pair.Value ascending
                                select pair).ToDictionary(t => t.Key, t => t.Value);
                //var countStudentGroups = SortStudents.Count();
                //if (countStudentGroups % 2 != 0)
                //{

                //    for (int i = 0; i < SortStudents.Last().Value; i++)
                //        teaching1.FirstOrDefault(std => std.Class == SortStudents.Last().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                //    numOfGroups++;
                //    SortStudents.Remove(SortStudents.Last().Key);
                //}
                //else
                //{
                int numOfStudents = 0;
                //int indexOfStudents = 0;
                int extraStudents = 0;
                while (SortStudents.Count() > 0)
                {
                    if (SortStudents.First().Value + SortStudents.Last().Value <= StaticVariabls.maxNumOfStudentInClass + StaticVariabls.maxAboveMax)
                    {
                        for (int i = 0; i < SortStudents.First().Value; i++)
                        {
                            //var enumerator =SortStudents.Keys.SkipWhile(k => k != myKey);
                            //מכניס לכל התלמידות מס' קבוצה
                            gradeStudents.FirstOrDefault(grd => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grd.StudentId && grd.GroupNumber == null).GroupNumber = numOfGroups;
                            //teaching.FirstOrDefault(std => std.CourseId == SortStudents.First().Key && std.GroupNumber == 0).GroupNumber = numOfGroups;


                            numOfStudents++;
                        }
                        for (int i = 0; i < SortStudents.Last().Value; i++)
                        {
                            gradeStudents.FirstOrDefault(grd => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grd.StudentId && grd.GroupNumber == null).GroupNumber = numOfGroups;
                            numOfStudents++;
                        }
                        SortStudents.Remove(SortStudents.First().Key);
                        SortStudents.Remove(SortStudents.Last().Key);

                        while (numOfStudents < StaticVariabls.minNumOfStudentInClass)
                        {
                            extraStudents = StaticVariabls.maxNumOfStudentInClass + StaticVariabls.maxAboveMax - numOfStudents;
                            if (SortStudents.First().Value <= extraStudents)
                                for (int i = 0; i < SortStudents.First().Value; i++)
                                {
                                    gradeStudents.FirstOrDefault(grd => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grd.StudentId && grd.GroupNumber == null).GroupNumber = numOfGroups;
                                    numOfStudents++;
                                }
                            SortStudents.Remove(SortStudents.First().Key);
                        }
                        FillNumStudentsInBegining(teachingId, numOfGroups, numOfStudents, grade);
                        numOfGroups++;
                        extraStudents = 0;
                        numOfStudents = 0;
                    }
                    else
                    {
                        for (int i = 0; i < SortStudents.Last().Value; i++)
                            gradeStudents.FirstOrDefault(grd => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grd.StudentId && grd.GroupNumber ==null).GroupNumber = numOfGroups;
                        //FillNumStudentsInBegining(teachingId, numOfGroups, SortStudents.Last().Value, grade);
                        numOfGroups++;
                        SortStudents.Remove(SortStudents.Last().Key);

                    }
                }
                st.SaveChanges();
                //SortStudents.OrderByDescending(student => student.Value);
                //var countStudentGroups = SortStudents.Count();
                //if (countStudentGroups % 2 != 0)
                //{
                //    //List<Student> lastClassStudents = new List<Student>();
                //    //lastClassStudents=gradeStudents.FirstOrDefault(grade=>teaching.FirstOrDefault(std=>std.CourseId==SortStudents.Last().Key).StudentId==grade.StudentId).GroupNumber= numOfGroups;
                //    for (int i = 0; i < SortStudents.Last().Value; i++)
                //        //teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key && gradeStudents.FirstOrDefault(grad=>grad.StudentId==std.StudentId).GroupNumber== null). = numOfGroups;
                //        gradeStudents.FirstOrDefault(grade => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grade.StudentId).GroupNumber = numOfGroups;
                //    numOfGroups++;
                //    SortStudents.Remove(SortStudents.Last().Key);

                //}
                //else
                //{
                //    while (SortStudents.Count() > 0)
                //        if (SortStudents.First().Value + SortStudents.Last().Value <= StaticVariabls.maxNumOfStudentInClass + StaticVariabls.maxAboveMax)
                //        {
                //            for (int i = 0; i < SortStudents.First().Value; i++)
                //                gradeStudents.FirstOrDefault(grade => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grade.StudentId).GroupNumber = numOfGroups;
                //            //teaching.FirstOrDefault(std => std.CourseId == SortStudents.First().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                //            for (int i = 0; i < SortStudents.Last().Value; i++)
                //                gradeStudents.FirstOrDefault(grade => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grade.StudentId).GroupNumber = numOfGroups;
                //            //teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                //            numOfGroups++;
                //            SortStudents.Remove(SortStudents.First().Key);
                //            SortStudents.Remove(SortStudents.Last().Key);
                //        }
                //        else
                //        {
                //            for (int i = 0; i < SortStudents.Last().Value; i++)
                //                gradeStudents.FirstOrDefault(grade => teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key).StudentId == grade.StudentId).GroupNumber = numOfGroups;
                //            //teaching.FirstOrDefault(std => std.CourseId == SortStudents.Last().Key && std.GroupNumber == null).GroupNumber = numOfGroups;
                //            numOfGroups++;
                //            SortStudents.Remove(SortStudents.Last().Key);

                //        }
                //}
                //st.SaveChanges();
                return st.Students.ToList();
            }

        }
        /// <summary>
        ///  spliting students in grade 5  to groups Special Education teaching 
        /// </summary>
        /// <param name="numOfGroups"></param>
        /// <param name="gradeStudents"></param>
        /// <param name="grade"></param>
        /// <returns>List Student </returns>
        public static List<Student> SplitingToGroups4(int numOfGroups, List<Student> gradeStudents, int grade)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    int teachingId;
                    if (grade == 5)
                        teachingId = 4;
                    else
                        teachingId = 11;
                    var teaching4 = from item in gradeStudents
                                    join item2 in st.CourseForStudents
                                    on item.StudentId equals item2.StudentId
                                    where item2.TeachingId == teachingId
                                    select item2;
                    teaching4.OrderBy(sd => sd.CourseId);
                    var lastStudentsInCourses = from item2 in teaching4
                                                group item2 by item2.CourseId into grouped
                                                let last = grouped.Last()
                                                select new
                                                {
                                                    classNum = last.CourseId,
                                                    Index = teaching4.TakeWhile(lst => lst != last).Count()
                                                };
                    lastStudentsInCourses.OrderBy(cls => cls.classNum);
                    int indexOfFirstStudent = 0;
                    int telem = 8;
                    int music = 12;
                    int numOfGroupsTelemMusic = 0;
                    int flag = 0;
                    int numOfStudentsTelemMusic = 0;
                    for (int i = 0; i < lastStudentsInCourses.Count(); i++)
                    {
                        if (lastStudentsInCourses.ElementAt(i).classNum == telem || lastStudentsInCourses.ElementAt(i).classNum == music)
                        {
                            if (flag == 0)
                            {
                                while (indexOfFirstStudent <= lastStudentsInCourses.ElementAt(i).Index)
                                    gradeStudents.FirstOrDefault(grd => grd.StudentId == teaching4.ElementAt(indexOfFirstStudent++).StudentId && grd.GroupNumber == 0).GroupNumber = numOfGroups;
                                numOfGroupsTelemMusic = numOfGroups;
                                numOfStudentsTelemMusic = indexOfFirstStudent;
                            }
                            else if (flag == 1)
                            {
                                while (indexOfFirstStudent <= lastStudentsInCourses.ElementAt(i).Index)
                                    gradeStudents.FirstOrDefault(grd => grd.StudentId == teaching4.ElementAt(indexOfFirstStudent++).StudentId && grd.GroupNumber == 0).GroupNumber = numOfGroupsTelemMusic;
                                FillNumStudentsInBegining(teachingId, numOfStudentsTelemMusic, lastStudentsInCourses.ElementAt(i).Index, grade);
                                numOfGroups++;
                            }
                            else
                            {
                                while (indexOfFirstStudent <= lastStudentsInCourses.ElementAt(i).Index)
                                    gradeStudents.FirstOrDefault(grd => grd.StudentId == teaching4.ElementAt(indexOfFirstStudent++).StudentId && grd.GroupNumber == 0).GroupNumber = numOfGroupsTelemMusic;
                                FillNumStudentsInBegining(teachingId, numOfGroups, lastStudentsInCourses.ElementAt(i).Index, grade);
                                numOfGroups++;
                            }
                        }
                    }
                    st.SaveChanges();
                    return st.Students.ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// spliting students in grade 6 to groups teaching ,send List to  other method that spliting to groups
        /// </summary>
        /// <returns></returns>
        public static List<Student> SplitingToGroupsGrade6()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    int numOfGroups = 120;
                    int grade = 6;
                    int teachingId = 1;
                    List<Student> SecondYearStudents = st.Students.Where(std => std.Grade == grade).ToList();
                    //List<Student> IncludingTeaching = SecondYearStudents.Where(std => std.IsIncludingTeaching == true).ToList();
                    //SecondYearStudents.Remove(IncludingTeaching);
                    var teaching1 = from item in SecondYearStudents
                                    join item2 in st.CourseForStudents
                                        on item.StudentId equals item2.StudentId
                                    where item2.TeachingId == teachingId && item.IsIncludingTeaching == false
                                    select item2;
                    var includeTeach = from item in SecondYearStudents
                                       join item2 in st.CourseForStudents
                                         on item.StudentId equals item2.StudentId
                                       where item2.TeachingId == teachingId && item.IsIncludingTeaching == true
                                       select item2;
                    List<CourseForStudent> teaching1_normal = new List<CourseForStudent>();
                    foreach (var item in teaching1)
                    {
                        teaching1_normal.Add(item);
                    }
                    SplitingToGroups3(SecondYearStudents, numOfGroups, teaching1_normal, teachingId, grade);
                    List<CourseForStudent> IncludingTeachingNormal = new List<CourseForStudent>();
                    foreach (var item in includeTeach)
                    {
                        IncludingTeachingNormal.Add(item);
                    }
                    SplitingToGroups3(SecondYearStudents, numOfGroups, IncludingTeachingNormal, teachingId, grade);


                    st.SaveChanges();
                    return st.Students.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// update EngagedStudent, check if the date before Chanuka,if true send to the method TeacherDal.CalculateStandard()
        /// </summary>
        /// <param name="student"></param>
        /// <returns>state</returns>
        public static string EngagedStudent(Student student)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                    if (q == null)
                        return " מזהה תלמידה לא נמצא במערכת";

                    q.IsEngaged = true;
                    int teachingId = st.CourseForStudents.FirstOrDefault(c => c.StudentId == student.StudentId).TeachingId;
                    if (teachingId == 1 || teachingId == 2 || teachingId == 5 || teachingId == 8)
                    {
                        //StaticData stData = st.StaticDatas.OrderBy(x => x.UpdateDate).LastOrDefault();

                        // q.StudentStandard = stData.EngagedStandard;
                        // ConfigurationManager.AppSettings["EngagedStandard"];
                        // System.Configuration.ConfigurationManager.AppSettings("MyAppSetting")
                        q.StudentStandard = 0.3;
                        st.SaveChanges();
                        DateTime myDate = DateTime.Today;
                        var ci = CultureInfo.CreateSpecificCulture("he-IL");
                        ci.DateTimeFormat.Calendar = new HebrewCalendar();
                        myDate.ToString("d MMM, yyyy", ci);
                        HebrewCalendar hc = new HebrewCalendar();
                        DateTime date1 = new DateTime(5781 + StaticVariabls.numYears, 3, 25, hc);
                        if (myDate < date1)
                        {
                            int groupNumber = Convert.ToInt32(student.GroupNumber);
                           
                            TeacherDal.UpdateStandard(st.Teachers.FirstOrDefault(t => t.TeacherGroup==groupNumber), student);
                        }
                        UpdateNumEngagedTeaching(teachingId);
                    }


                    st.SaveChanges();
                    return "התלמידה הוגדרה כמאורסת";
                }
            }
            catch
            {
                return "(EngagedStudent)שגיאה במערכת";
            }
        }
        /// <summary>
        /// update course and teachingId for studend and send to the method TeacherDal.CalculateStandard()
        /// </summary>
        /// <param name="student"></param>
        /// <param name="courseName"></param>
        /// <param name="teacingName"></param>
        /// <returns>state</returns>
        public static string UpdateStudentCourse(Student student, string courseName, string teacingName)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                  var group = st.Students.FirstOrDefault(c => c.StudentId == student.StudentId).GroupNumber;
                    var q1 = st.CourseForStudents.FirstOrDefault(c => c.StudentId == student.StudentId);
                    var q = st.Students.FirstOrDefault(c => c.StudentId == student.StudentId);
                    if (q == null)
                        return " מזהה תלמידה שגוי";
                    
                    int courseId = st.Courses.FirstOrDefault(c => c.CourseName == courseName).CourseId;
                    int teachingId = st.TeachingGroups.FirstOrDefault(t => t.TeachingName == teacingName).TeachingId;
                    q1.CourseId = courseId;
                    q1.TeachingId = teachingId;
                   // StaticVariabls.TeachingStudent.ElementAt(student.StudentId).Value = teacingName;
                  StaticVariabls.TeachingStudent[student.StudentId] = teacingName;
                    StaticVariabls.CourseStudent[student.StudentId] = courseName;
                    st.Students.FirstOrDefault(c => c.StudentId == student.StudentId).GroupNumber = student.GroupNumber;
                    //TeacherDal.CalculateStandard(st.Teachers.FirstOrDefault(t => t.TeacherGroup == student.GroupNumber));
                    var course = (from item in st.Courses
                                  join item2 in st.CourseForStudents
                                  on item.CourseId equals item2.CourseId
                                  where item2.StudentId == q.StudentId
                                  select item.CourseName).Single();
                    UpdateNumStudentsLeft(course);
                    UpdateNumLeftTeaching(teachingId);
                    UpdateNumEngagedTeaching(teachingId);
                    q.StudentStandard = student.StudentStandard;
                    st.SaveChanges();
                    int groupNumber = Convert.ToInt32(student.GroupNumber);
                    group= Convert.ToInt32(group);
                    TeacherDal.UpdateLeftStandard(st.Teachers.FirstOrDefault(t => t.TeacherGroup == group), st.Teachers.FirstOrDefault(t => t.TeacherGroup == groupNumber),student);
                    q.StudentTz = student.StudentTz;
                    q.StudentFirstName = student.StudentFirstName;
                    q.StudentLastName = student.StudentLastName;
                    q.IsActive = student.IsActive;
                    q.Grade = student.Grade;
                    q.Class = student.Class;
                    q.IsEngaged = student.IsEngaged;
                    q.IsIncludingTeaching = student.IsIncludingTeaching;
                    q.GroupNumber = student.GroupNumber;
                    q.StudentStandard = student.StudentStandard;
                    st.SaveChanges(); 
                    return "הקורס התעדכן במערכת";
                }
            }
            catch
            {
                return "הקורס התעדכן";
            }

        }


        /// <summary>
        /// fill List GroupDetails,the details is sending to the method when the coordinator activate the methods SplitingToGroups5
        /// </summary>
        /// <param name="teachingId"></param>
        /// <param name="numOfGroups"></param>
        /// <param name="numStudentsInGroup"></param>
        /// <param name="grade"></param>
        public static void FillNumStudentsInBegining(int teachingId, int numOfGroups, int numStudentsInGroup, int grade)
        {

            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var teachingGroupStandard = st.TeachingGroups.FirstOrDefault(std => std.TeachingId == teachingId).TeachingGroupStandard;
                    GroupDetails.studentGroup.Add(new GroupDetails(teachingId, numOfGroups, numStudentsInGroup, grade, Convert.ToSingle(numStudentsInGroup * teachingGroupStandard)));
                    GroupDetails.studentGroup.OrderBy(g => g.TeachingId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static List<GroupDetails> GetStudentGroup()
        {

            return GroupDetails.studentGroup.ToList();
        }
        /// <summary>
        /// calculate percent num students left in teaching in the end of the year compare to the begining of the year 
        /// </summary>
        /// <param name="teachingId"></param>
        public static void CalculateNumStudentsTeaching(int teachingId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var x = StaticVariabls.NumLeftTeaching.ElementAt(teachingId).Value * 100;
                    //var y = GroupDetails.studentGroup.ElementAt(teachingId).NumOfStudent;
                    //StaticVariabls.CalculateNumLeftTeaching[StaticVariabls.NumLeftTeaching.ElementAt(teachingId).Key] = x / y;
                    int sum = 0;
                    var x = StaticVariabls.NumLeftTeaching.ElementAt(teachingId).Value * 100;
                    for (int i = 0; i < GroupDetails.studentGroup.Count(); i++)
                    {
                        var details = GroupDetails.studentGroup.ElementAt(i);
                        if (details.TeachingId == teachingId)
                            sum += details.NumOfStudent;
                    }
                    //var y = GroupDetails.studentGroup.ElementAt(teachingId).NumOfStudent;
                    StaticVariabls.CalculateNumLeftTeaching[StaticVariabls.NumLeftTeaching.ElementAt(teachingId).Key] = x / sum;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// calculate percent num students engaged in teaching in the end of the year compare to the begining of the year 
        /// </summary>
        /// <param name="teachingId"></param>

        public static void CalculateNumEngagedTeaching(int teachingId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    int sum = 0;
                    var x = StaticVariabls.NumEngagedTeaching.ElementAt(teachingId).Value * 100;
                    for (int i = 0; i < GroupDetails.studentGroup.Count(); i++)
                    {
                        var details = GroupDetails.studentGroup.ElementAt(i);
                        if (details.TeachingId == teachingId)
                            sum += details.NumOfStudent;
                    }
                    //var y = GroupDetails.studentGroup.ElementAt(teachingId).NumOfStudent;
                    StaticVariabls.CalculateNumLeftTeaching[StaticVariabls.NumEngagedTeaching.ElementAt(teachingId).Key] = x / sum;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// fill dictionary NumStudentsLeft the key :coursesName,and the value:0 -students left course
        /// </summary>
        public static void FillCoursestudentsLeft()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var coursesName = st.Courses.ToList();
                    for (int i = 0; i < coursesName.Count(); i++)
                    {
                        StaticVariabls.NumStudentsLeft.Add(coursesName[i].CourseName, 20);
                    }
                    GroupDetails.studentGroup.Add(new GroupDetails(1, 1, 18, 5,8.1f));
                    GroupDetails.studentGroup.Add(new GroupDetails(1, 2, 16, 5, 7.2f));
                    GroupDetails.studentGroup.Add(new GroupDetails(1, 3, 15, 5, 6.75f));
                    GroupDetails.studentGroup.Add(new GroupDetails(1, 4, 25, 5,11.25f));
                    GroupDetails.studentGroup.Add(new GroupDetails(1, 5, 26, 5, 11.7f));
                    GroupDetails.studentGroup.Add(new GroupDetails(1, 6, 13, 5, 5.85f));
                    GroupDetails.studentGroup.Add(new GroupDetails(2, 7, 21, 5, 9.45f));
                    GroupDetails.studentGroup.Add(new GroupDetails(2, 8, 17, 5, 7.65f));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// fill dictionaries the key :teachingId,and the value:0 -students left teaching
        /// </summary>

        public static void FillNumStudentsTeaching()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {

                    var teachingId = st.TeachingGroups.ToList();
                    for (int i = 0; i < teachingId.Count(); i++)
                    {
                        StaticVariabls.NumLeftTeaching.Add(teachingId[i].TeachingId, 0);
                        StaticVariabls.NumEngagedTeaching.Add(teachingId[i].TeachingId, 0);
                        StaticVariabls.CalculateNumLeftTeaching.Add(teachingId[i].TeachingId, 10);
                        StaticVariabls.CalculateNumEngagedTeaching.Add(teachingId[i].TeachingId, 15);
                    }
                }
                StaticVariabls.NumLeftTeaching.OrderBy(t => t.Key);
                StaticVariabls.NumEngagedTeaching.OrderBy(t => t.Key);
                StaticVariabls.CalculateNumLeftTeaching.OrderBy(t => t.Key);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// when student left course this metod updete the dictionary NumStudentsLeft
        /// </summary>
        /// <param name="courseName"></param>
        public static void UpdateNumStudentsLeft(string courseName)
        {
            StaticVariabls.NumStudentsLeft[courseName]++;

        }
        /// <summary>
        /// when student left teching this metod updete the dictionary NumLeftTeaching
        /// </summary>
        public static void UpdateNumLeftTeaching(int teachingId)
        {
            StaticVariabls.NumLeftTeaching[teachingId]++;
            CalculateNumStudentsTeaching(teachingId);
        }
        /// <summary>
        /// when student engaged in teching this metod updete the dictionary NumEngagedTeaching
        /// 
        public static void UpdateNumEngagedTeaching(int teachingId)
        {
            StaticVariabls.NumEngagedTeaching[teachingId]++;
            CalculateNumEngagedTeaching(teachingId);
        }
        /// <summary>
        /// get the dictionary that NumStudentsLeft-num of students that left course
        /// </summary>
        /// <returns>NumStudentsLeft</returns>
        public static IDictionary<string, int> GetNumStudentsLeft()
        {
            return StaticVariabls.NumStudentsLeft;

        }
        /// <summary>
        /// get the dictionary that CalculateNumEngagedTeaching-percent num students engaged in teaching in the end of the year compare to the begining of the year
        /// </summary>
        /// <returns>CalculateNumEngagedTeaching</returns>
        public static IDictionary<int, int> GetNumEngagedTeaching()
        {
            return StaticVariabls.CalculateNumEngagedTeaching;

        }
        /// <summary>
        /// get the dictionary that CalculateNumLeftTeaching-percent num students left in teaching in the end of the year compare to the begining of the year
        /// </summary>
        /// <returns>CalculateNumEngagedTeaching</returns>
        public static IDictionary<int, int> GetNumLeftTeaching()
        {
            return StaticVariabls.CalculateNumLeftTeaching;

        }
        /// <summary>
        /// check if it is the begining of the year,if true send to method SplitingToGroupsYear()
        /// </summary>
        public static void IsBeginingOfYear()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    Task.Delay(TimeSpan.FromDays(1)).ContinueWith((x) => IsBeginingOfYear());
                    //if (DateTime.Today == st.Data1.ElementAt(0).BeginingOfYear)
                    //{
                    //    SplitingToGroupsYear();
                    //    //st.Data1.ElementAt(0).BeginingOfYear
                    //}
                }
            }
            catch
            {

            }

        }
        /// <summary>
        /// this  method append every beginng the year
        /// </summary>
        public static void SplitingToGroupsYear()
        {


            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {

                    List<Student> students = new List<Student>();
                    List<CourseForStudent> student = new List<CourseForStudent>();
                    students = st.Students.ToList();
                    for (int i = 0; i < students.Count(); i++)
                    {
                        if (students[i].Grade == 6)
                        {
                            students[i].IsActive = false;
                            students[i].Grade = 0;
                        }
                        else if (students[i].Grade == 5)
                            students[i].Grade = 6;

                    }
                    int teachingId = 8;
                    var teaching = from item in students
                                   join item2 in st.CourseForStudents
                                   on item.StudentId equals item2.StudentId
                                   where item2.TeachingId >= teachingId
                                   select item2;
                    for (int i = 0; i < student.Count(); i++)
                    {
                        var numOfGroup = students.FirstOrDefault(std => std.StudentId == teaching.ElementAt(i).StudentId).GroupNumber;
                        numOfGroup = numOfGroup + 100;
                    }
                    GetNumEngagedTeaching();
                    GetNumLeftTeaching();
                    StaticVariabls.numYears++;
                    for (int i = 0; i < GroupDetails.studentGroup.Count(); i++)
                    {
                        GroupDetails.studentGroup.ElementAt(i).GroupNumber = 0;
                        GroupDetails.studentGroup.ElementAt(i).Grade = 0;
                        GroupDetails.studentGroup.ElementAt(i).NumOfStudent = 0;
                        GroupDetails.studentGroup.ElementAt(i).TeachingId = 0;
                        GroupDetails.studentGroup.ElementAt(i).StandardOfGroup = 0;
                    }



                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public static void FillStudentStandard()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    List<Student> students = new List<Student>();
                    students = st.Students.ToList();
                    for (int i = 0; i < students.Count(); i++)
                    {
                        int stdId = students[i].StudentId;
                        int teachingId = st.CourseForStudents.FirstOrDefault(std => std.StudentId == stdId).TeachingId;//st.CourseForStudents.FirstOrDefault(c => c.StudentId == students[i].StudentId).TeachingId;
                        students[i].StudentStandard = st.TeachingGroups.FirstOrDefault(t => t.TeachingId == teachingId).TeachingGroupStandard;
                    }
                    st.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// get List of students
        /// </summary>
        /// <returns> List Student </returns>
        public static List<Student> SelectStudents()
        {
            using (StandardEntities2 st = new StandardEntities2())
            {
                return st.Students.ToList();

            }
        }
        /// <summary>
        /// updete details studnd
        /// </summary>
        /// <param name="student"></param>
        /// <returns>state</returns>
        public static string PutStudent(Student student)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Students.FirstOrDefault(t => t.StudentId == student.StudentId);
                    if (q == null)
                        return " מזהה תלמידה שגוי";
                    q.StudentTz = student.StudentTz;
                    q.StudentFirstName = student.StudentFirstName;
                    q.StudentLastName = student.StudentLastName;
                    q.IsActive = student.IsActive;
                    q.Grade = student.Grade;
                    q.Class = student.Class;
                    q.IsEngaged = student.IsEngaged;
                    q.IsIncludingTeaching = student.IsIncludingTeaching;
                    q.GroupNumber = student.GroupNumber;
                    q.StudentStandard = student.StudentStandard;

                    st.SaveChanges();
                    return "פרטי התלמידה התעדכנו במערכת";
                }
            }
            catch
            {
                return "(UpdateStudent)שגיאה במערכת";
            }

        }
        /// <summary>
        /// delete student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>state</returns>
        public static string DeleteStudent(int studentId)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    var q = st.Students.FirstOrDefault(s => s.StudentId == studentId);
                    if (q == null)
                        return " מזהה תלמידה שגוי";
                    CourseForStudentDal.DeleteStudentCourse(studentId);
                    st.Students.Remove(q);
                    st.SaveChanges();
                    return "התלמידה נמחקה מהמערכת";
                }
            }
            catch
            {
                return "(DeleteStudent)שגיאה במערכת";
            }
        }
        public static string DeleteStudent()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                   
                    for (int num= 3398;num<= 4165;num++)
                    {
                    var q = st.Students.FirstOrDefault(s => s.StudentId == num);
                        st.Students.Remove(q);
                    }
                    //if (q == null)
                    //    return " מזהה תלמידה שגוי";
                    //CourseForStudentDal.DeleteStudentCourse(studentId);
                    // var q = 2000;
                   
                    st.SaveChanges();
                    return "התלמידה נמחקה מהמערכת";
                }
            }
            catch
            {
                return "(DeleteStudent)שגיאה במערכת";
            }
        }
        public static string DeleteGroup()
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {


                    List<Student> students = new List<Student>();
                    students = st.Students.ToList();
                    for (int i = 0; i < students.Count(); i++)
                    {

                        students[i].GroupNumber=null;
                    }
                    st.SaveChanges();

                    st.SaveChanges();
                    return "התלמידה נמחקה מהמערכת";
                }
            }
            catch
            {
                return "(DeleteStudent)שגיאה במערכת";
            }
        }
        /// <summary>
        /// add student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>true or false</returns>
        public static string AddStudent(Student student)
        {
            try
            {
                using (StandardEntities2 st = new StandardEntities2())
                {
                    //var q = st.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                    //if (q == null)
                    //    return null;
                    st.Students.Add(student);
                    st.SaveChanges();
                    return "התלמידה נוספה למערכת";
                }
            }
            catch (Exception e)
            {
                return "(AddStudent)שגיאה במערכת";
            }
        }


    }
}



