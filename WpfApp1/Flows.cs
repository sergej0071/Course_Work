using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;
using Spire.Xls.Core;

namespace Schedule
{
    class Flows : LoadFiles
    {
        public int Speciality { set; get; } // номер специальности
        public int Course { set; get; } // номер курса

        public List<Group> Groups;

        public ExpectedSchedule expectedSchedule;

        public static string Faculty = "KNT"; // название факультета, может быть использовано для работы с несколькими факультетами 
        public List<Curriculum> CurriculumDataTable;    // Таблица данных (1 - порядковый номер, 2 - низвание дисциплины,
                                                        // 3 - номер факультета, 4 - часы лекций, 
                                                        // 5 - часы практики, 6 - тип аудитории)                                 

        private Flows() // конструктор
        {
            Speciality = 0;
            Course = 0;
            Groups = new List<Group>();

            expectedSchedule = new ExpectedSchedule();

            CurriculumDataTable = new List<Curriculum>();
        }

        public Flows(int Specality, int Course) // конструктор, принимает значения номера специальности и курса
        {
            FillDataWithName(Specality, Course);
            //InitializeGroups(groups);
        }

        public Flows(string spec_course_name) // конструктор, принимает строку в форме Sp_ddd_course_ddd
        {
            FillDataWithName("Sp_121_course_2");
            //InitializeGroups(groups);
        }

        //public void InitializeGroups(List<TestGroup> groups) // заполнение списка групп группами данного потока
        //{
        //    Groups = new List<Group>();

        //    foreach(TestGroup tg in groups)
        //    {
        //        if (tg.Course == Course && tg.Speciality == Speciality)
        //        {
        //            Groups.Add(new Group(tg.Departmant, tg.NumberName, tg.Population));
        //        }
        //    }
        //}
        
        private void FillDataWithName(int Speciality, int Course) // функция заполняет данными для указанной специальности и курса
        {
            this.Speciality = Speciality;
            this.Course = Course;

            expectedSchedule = new ExpectedSchedule();

            string curric_name = "Sp_" + Speciality.ToString() + "_course_" + Course.ToString(); // строка по которой будет найдена нужная таблица

            FillData(curric_name); // заполняет CurriculumDataTable
            FillGroups(); // заполняет Groups;
        }

        private void FillDataWithName(string spec_course_name) // функция заполняет данными для указанной специальности и курса
        {
            // Sp_ddd_course_ddd

            // извлечем из строки номер специальности и курса для полей Specialty и Course
            string SpecialityStr = "";
            string CourseStr = "";

            string curric_name = spec_course_name; // для функции FillData
            spec_course_name = spec_course_name.Substring(3); // spec_course_name = ddd _course_ddd

            int i = 0;
            while (spec_course_name[i].ToString() != "_")
            {
                SpecialityStr += spec_course_name[i];
                i++;
            }

            i = spec_course_name.Length - 1;

            while (spec_course_name[i].ToString() != "_")
            {
                CourseStr += spec_course_name[i];
                i--;
            }

            // конвертируем в числовой формат
            this.Speciality = Convert.ToInt32(SpecialityStr);
            this.Course = Convert.ToInt32(CourseStr);

            expectedSchedule = new ExpectedSchedule();

            FillData(curric_name); // заполняет CurriculumDataTable
            FillGroups(); // заполняет Groups;
        }

        private void FillData(string curric_name) // заполняет CurriculumDataTable данными из БД по curric_name
        {
            DataTable dataTable = loadTable(curric_name);

            CurriculumDataTable = new List<Curriculum>();

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
            {
                Curriculum temp = new Curriculum(dataTable.Rows[rowCounter][0].ToString(), int.Parse(dataTable.Rows[rowCounter][1].ToString()),
                    double.Parse(dataTable.Rows[rowCounter][2].ToString()), double.Parse(dataTable.Rows[rowCounter][3].ToString()), int.Parse(dataTable.Rows[rowCounter][4].ToString()));

                CurriculumDataTable.Add(temp);
            }

        }

        private void FillGroups()
        {
            DataTable dataTable = loadTable("Groups");

            Groups = new List<Group>();

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
            {
                if (this.Course == int.Parse(dataTable.Rows[rowCounter][0].ToString()) && this.Speciality == int.Parse(dataTable.Rows[rowCounter][2].ToString()))
                {
                    Groups.Add(new Group(int.Parse(dataTable.Rows[rowCounter][0].ToString()), int.Parse(dataTable.Rows[rowCounter][3].ToString()), int.Parse(dataTable.Rows[rowCounter][4].ToString())));
                }
            }
        }

        public static int NumOfSpecialitiesOnCourse(List<Flows> flows, int course) // общее кол-во специальностей на заданном кусре для заданных потоков
        {
            int N = 0;
            foreach (Flows flow in flows)
            {
                if (flow.Course == course)
                {
                    N++;
                }
            }

            return N;
        }

        public static void ChangePractiseStatusForSubjectForFlows(List<Flows> flows, string Subject) // сделать возможность проведение практик по заданному пердмету у нескольких потоков (например физкульт.)
        {
            foreach(Flows flow in flows)
            {
                foreach(Curriculum cur in flow.CurriculumDataTable)
                {
                    if (!cur.IsPractUsed && !cur.IsLectUsed) // если предмет уже фигурирует в расписании изменить его статус нельзя
                    {
                        if (cur.NameOfSubject == Subject)
                        {
                            cur.PractForTwoFlows = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Этот предмет уже вставлен в расписание. Обнулите расписание и измените статус предмета");
                    }
                }
            }
        }

        public int PeopleOnFlow() // кол-во студентов на потоке
        {
            if (Groups.Count != 0)
            {
                int sum = 0;
                foreach (Group gr in Groups)
                {
                    sum += gr.Population;
                }
                return sum;
            }
            else
            {
                return 0;
            }
        }

        public static Group GetGroupDueToGroup(List<Flows> flows, Group group)
        {
            foreach(Flows flow in flows)
            {
                foreach(Group gr in flow.Groups)
                {
                    if (gr.Equals(group))
                    {
                        return gr;
                    }
                }
            }

            return new Group();
        }

        public static Flows GetFlowDueToGroup(List<Flows> flows, Group group)
        {
            foreach (Flows flow in flows)
            {
                foreach (Group gr in flow.Groups)
                {
                    if (gr.Equals(group))
                    {
                        return flow;
                    }
                }
            }

            return new Flows();
        }

        public static void SetExpectedSchedule(List<Flows> flows, int Course, int Speciality, Dictionary<int, int> es)
        {
            foreach(Flows flow in flows)
            {
                if (flow.Course == Course && flow.Speciality == Speciality)
                {
                    flow.expectedSchedule.Set(flow.Course, flow.Speciality, es);

                    break;
                }
            }
        }

        public void WtiteInConsole() // функция вывода в консоль
        {
            Console.WriteLine("\nSp_" + Speciality.ToString() + "_сourse_" + Course.ToString()); // вывод спец. и кусра

            foreach (Curriculum cdt in CurriculumDataTable) // вывод CurriculumDataTable
            {
                cdt.WriteInConsole();
            }
        }

        public void WriteUsedParam() // функция вывода в консоль
        {
            Console.WriteLine("\nSp_" + Speciality.ToString() + "_сourse_" + Course.ToString()); // вывод спец. и кусра

            foreach (Curriculum cdt in CurriculumDataTable) // вывод CurriculumDataTable
            {
                cdt.WriteUsedParam();
            }
        }

        public void WriteScheduleInConsole()
        {
            Console.WriteLine("\nSp_" + Speciality.ToString() + "_сourse_" + Course.ToString());
            foreach(Group group in Groups)
            {
                group.WriteInConsole();
            }
        }
    }
}
