using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Steps
    {
        private static bool MinLoadAud(Auditorium a, int people, List<Auditorium> audit) // определяет является ли данная аудитория минимально загруженной среди таких же аудиторий
        {
            foreach (Auditorium el in audit)
            {
                if (el.Department == a.Department && el.TypeOfAuditorium == a.TypeOfAuditorium && el.Сapacity >= people)
                {
                    if (!el.Equals(a)) // если взятая аудитория не она же сама
                    {
                        if (a.Load > el.Load) // если есть аудитория у которой меньше загруженность возвращаем false
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool MinLoadProf(Professor p, bool IsRankHigh, List<Professor> prof) // определяет является ли профессор минимально загруженным среди такиих же профес.
        {
            foreach (Professor el in prof)
            {
                if (el.Department == p.Department)
                {
                    if (IsRankHigh) // если искомый преподаватель доцент или профессор
                    {
                        if (el.Rank == (int)ProfesorRank.Profesor || el.Rank == (int)ProfesorRank.Docent)
                        {
                            if (!el.Equals(p)) // если препод. не он же сам
                            {
                                if (p.Load > el.Load) // если есть препод. у которого меньше загруженность возвращаем false
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else // если искомый преподаватель ассистент или ст. препод.
                    {
                        if (el.Rank == (int)ProfesorRank.SeniorLecturer || el.Rank == (int)ProfesorRank.Assistent)
                        {
                            if (!el.Equals(p)) // если препод. не он же сам
                            {
                                if (p.Load > el.Load) // если есть препод. у которого меньше загруженность возвращаем false
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        // находит аудиторию для проведения пары у 2 потоков сразу
        private static Auditorium FindAudit(Flows flow1, Flows flow2, List<Auditorium> audit, int Department, int TypeOfAuditorium)
        {
            int people = flow1.PeopleOnFlow() + flow2.PeopleOnFlow(); // общее кол-во студентов на 2 потоках

            foreach (Auditorium a in audit)
            {
                // можно добавить загруженность
                if (a.Department == Department && a.TypeOfAuditorium == TypeOfAuditorium && people <= a.Сapacity) // если у аудитории нужная кафедра, тип, достаточная вместимость
                {
                    if (MinLoadAud(a, people, audit)) // если аудитория имеет самую низкую загруженность
                    {
                        return a; // возвращаем подходящую аудиторию
                    }
                }
            }

            return new Auditorium(); // если нет подходящей аудитоии возвращаем пустую
        }

        // находит аудиторию для проведения пары у 1 потокa
        private static Auditorium FindAudit(Flows flow, List<Auditorium> audit, int Department, int TypeOfAuditorium)
        {
            int people = flow.PeopleOnFlow(); // общее кол-во студентов потоке

            foreach (Auditorium a in audit)
            {
                // можно добавить загруженность
                if (a.Department == Department && a.TypeOfAuditorium == TypeOfAuditorium && people <= a.Сapacity) // если у аудитории нужная кафедра, тип, достаточная вместимость
                {
                    if (MinLoadAud(a, people, audit)) // если аудитория имеет самую низкую загруженность
                    {
                        return a; // возвращаем подходящую аудиторию
                    }
                }
            }

            return new Auditorium(); // если нет подходящей аудитоии возвращаем пустую
        }

        // находит аудиторию для проведения пары у 1 группы
        private static Auditorium FindAudit(Group group, List<Auditorium> audit, int Department, int TypeOfAuditorium)
        {
            int people = group.Population; // общее кол-во студентов потоке

            foreach (Auditorium a in audit)
            {
                // можно добавить загруженность
                if (a.Department == Department && a.TypeOfAuditorium == TypeOfAuditorium && people <= a.Сapacity) // если у аудитории нужная кафедра, тип, достаточная вместимость
                {
                    if (MinLoadAud(a, people, audit)) // если аудитория имеет самую низкую загруженность
                    {
                        return a; // возвращаем подходящую аудиторию
                    }
                }
            }

            return new Auditorium(); // если нет подходящей аудитоии возвращаем пустую
        }

        // находим преподавателя по факультету и типу занятия (леция или практика)
        private static Professor FindProf(List<Professor> prof, int Department, bool isLecture)
        {
            foreach (Professor pr in prof) // ищем с списке всех препод.
            {
                if (pr.Department == Department) // если у препод. нужная кафедра
                {
                    if (isLecture) // если ищем препод. для лекций
                    {
                        if (pr.Rank == (int)ProfesorRank.Profesor || pr.Rank == (int)ProfesorRank.Docent) // если препод. профессор или доцент
                        {
                            //                  true значит "высокий" ранг(проф. доц.)
                            if (MinLoadProf(pr, true, prof)) // если преп. имеет самую низкую загруженность
                            {
                                return pr;
                            }
                        }

                    }
                    else // если ищем препод. для практик
                    {
                        if (pr.Rank == (int)ProfesorRank.SeniorLecturer || pr.Rank == (int)ProfesorRank.Assistent) // если препод. ассистент или ст. преп.
                        {
                            //                  false значит "низкий" ранг
                            if (MinLoadProf(pr, false, prof)) // если преп. имеет самую низкую загруженность
                            {
                                return pr;
                            }
                        }
                    }
                }
            }

            return new Professor();
        }

        // определяет список пар, которые можно провести у 2 потоков вместе
        private static List<Lesson> ListOfSameLessonsForTwoFlows(Flows flow1, Flows flow2, List<Auditorium> audit, List<Professor> prof)
        {
            List<Lesson> same_lessons = new List<Lesson>(); // список одинаковых предметов

            // сравниваем учебные планы 2 потоков
            foreach (Curriculum cur1 in flow1.CurriculumDataTable)
            {
                foreach (Curriculum cur2 in flow2.CurriculumDataTable)
                {
                    if (cur2.NameOfSubject == cur1.NameOfSubject) // если одинаковый предмет
                    {
                        if (cur1.NumOfHourForLections != 0 && cur2.NumOfHourForLections != 0) // если есть лекции
                        {
                            if (!cur1.IsLectUsed && !cur2.IsLectUsed) // если у 2 потоков лекции по этому предмету ещё не использованы (нет в списке занятий)
                            {
                                if (cur1.NumOfHourForLections == cur2.NumOfHourForLections) // если одинаковое кол-во часов лекций
                                {
                                    Auditorium a = FindAudit(flow1, flow2, audit, cur1.Department, (int)AuditoriumType.Lecture); // ищем лекционную аудиторию на кафедре
                                    Professor p = FindProf(prof, cur1.Department, true);

                                    if (!a.isNull() && !p.isNull()) // если найдены аудитория и преподаватель
                                    {
                                        same_lessons.Add(new Lesson(cur1.NameOfSubject, cur1.NumOfHourForLections, p, a)); // добавляем в список одинаковых предметов

                                        a.Load++; // увеличиваем загруженность на 1
                                        p.Load++; // увеличиваем загруженность на 1
                                        cur1.IsLectUsed = cur2.IsLectUsed = true; // лекция по данному предмету есть в списке занятий
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cur1.NumOfHoursForPractice != 0 && cur2.NumOfHoursForPractice != 0) // если есть практики
                            {
                                if (!cur1.IsPractUsed && !cur2.IsPractUsed) // если у 2 потоков практики по этому предмету ещё не использованы (их нет в списке занятий)
                                {
                                    if (cur1.PractForTwoFlows && cur2.PractForTwoFlows) // если практики могут проводиться у 2 потоков вместе
                                    {
                                        if (cur1.NumOfHoursForPractice == cur2.NumOfHoursForPractice) // если одинаковое кол-во часов практик
                                        {
                                            Auditorium a = FindAudit(flow1, flow2, audit, cur1.Department, cur1.TypeOfAuditorium); // ищем пркт. аудиторию на кафедре
                                            Professor p = FindProf(prof, cur1.Department, false);

                                            if (!a.isNull() && !p.isNull()) // если найдены аудитория и преподаватель
                                            {
                                                same_lessons.Add(new Lesson(cur1.NameOfSubject, cur1.NumOfHoursForPractice, p, a)); // добавляем в список одинаковых предметов

                                                a.Load++; // увеличиваем загруженность на 1
                                                p.Load++; // увеличиваем загруженность на 1
                                                cur1.IsPractUsed = cur2.IsPractUsed = true; // практика по данному предмету есть в списке занятий
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return same_lessons;
        }

        // Step1
        // потоки должны быть отсортированы по кусру и по специальности
        public static List<LessonForFlows> FormListOfLessonsForFlows(List<Flows> flows, List<Auditorium> audit, List<Professor> prof) // формирует список пар для двух потоков
        {
            List<LessonForFlows> lessons_for_flows = new List<LessonForFlows>(); // конечный список

            List<List<Lesson>[,]> SameLessonsForTwoFlowsInOneCourse = new List<List<Lesson>[,]>(Program.NumOfCourses); // одинаковый предметы для 2 потоков на одном курсе на одинаковой кафедре

            //                          1 курс                                              2 курс                    ...

            // номера специальностей        121         122         123         719

            //                       121    0          l1, l2       l1          0

            //                       122                0           l3          0

            //                       123                            0           0

            //                       719                                        0

            // определяем размер матрицы: кол-во специальностей на курсе
            for (int j = 1; j <= Program.NumOfCourses; j++) // проходим все кусры
            {
                // квадартная матрица
                SameLessonsForTwoFlowsInOneCourse.Add(new List<Lesson>[Flows.NumOfSpecialitiesOnCourse(flows, j), Flows.NumOfSpecialitiesOnCourse(flows, j)]);
            }

            // инициализируем элементы массива пустыми списками
            foreach (List<Lesson>[,] el in SameLessonsForTwoFlowsInOneCourse)
            {
                for (int j = 0; j < el.GetLength(0); j++)
                {
                    for (int u = 0; u < el.GetLength(1); u++)
                    {
                        el[j, u] = new List<Lesson>();
                    }
                }
            }

            // используем отсортированный по кусрам и специальностям список потоков
            int PreviousFlowIndex = 0;
            // рассматриваем последовательно все курсы
            for (int j = 0; j < Program.NumOfCourses; j++)
            {
                int u = 0;
                // рассматриваем последовательно каждую специальность на курсе
                for (u = PreviousFlowIndex; u < PreviousFlowIndex + SameLessonsForTwoFlowsInOneCourse[j].GetLength(0); u++) // размер матрицы - кол-во специальностей на курсе
                {
                    // сравниваем с кажой группой чтобы найти количество одинаковых предметов
                    for (int k = u + 1; k < PreviousFlowIndex + SameLessonsForTwoFlowsInOneCourse[j].GetLength(1); k++)
                    {
                        // находим все пары, которые можно провести у 2 потоков
                        SameLessonsForTwoFlowsInOneCourse[j][u - PreviousFlowIndex, k - PreviousFlowIndex] = ListOfSameLessonsForTwoFlows(flows[u], flows[k], audit, prof);
                    }
                }

                PreviousFlowIndex = u;
            }

            foreach (List<Lesson>[,] el in SameLessonsForTwoFlowsInOneCourse)
            {
                for (int j = 0; j < el.GetLength(0); j++)
                {
                    string save = "";
                    for (int u = 0; u < el.GetLength(1); u++)
                    {
                        if (el[j, u].Count != 0)
                        {
                            foreach (Lesson str in el[j, u])
                            {
                                save += str.SubjectName.ToString() + " ";
                            }
                        }
                    }
                    Console.WriteLine(save);
                }
            }

            PreviousFlowIndex = 0; // обнуляем
            foreach (List<Lesson>[,] el in SameLessonsForTwoFlowsInOneCourse)
            {
                int j = 0;
                for (j = 0; j < el.GetLength(0); j++)
                {
                    for (int u = 0; u < el.GetLength(1); u++)
                    {
                        if (el[j, u].Count != 0)
                        {
                            foreach (Lesson ls in el[j, u])
                            {
                                lessons_for_flows.Add(new LessonForFlows(ls, flows[PreviousFlowIndex + j], flows[PreviousFlowIndex + u]));
                            }
                        }
                    }
                }
                PreviousFlowIndex = j;
            }

            return lessons_for_flows;
        }

        // Step2
        // потоки должны быть отсортированы по кусру и по специальности
        public static List<LessonForOneFlow> FormListOfLessonsForOneFlow(List<Flows> flows, List<Auditorium> audit, List<Professor> prof) // формирует список пар для одного потока
        {
            List<LessonForOneFlow> lessons_for_one_flow = new List<LessonForOneFlow>(); // конечный список

            foreach (Flows flow in flows) // обходим все потоки
            {
                foreach (Curriculum cur in flow.CurriculumDataTable) // проходим каждый предмет
                {
                    if (cur.NumOfHourForLections != 0) // если есть лекции
                    {
                        if (!cur.IsLectUsed) // если у потока лекция по этому предмету ещё не использована (нет в списке занятий)
                        {
                            Auditorium a = FindAudit(flow, audit, cur.Department, (int)AuditoriumType.Lecture); // ищем лекционную аудиторию на кафедре
                            Professor p = FindProf(prof, cur.Department, true); // ищем препод.

                            if (!a.isNull() && !p.isNull()) // если найдены аудитория и преподаватель
                            {
                                lessons_for_one_flow.Add(new LessonForOneFlow(cur.NameOfSubject, flow, cur.NumOfHourForLections, p, a)); // добавляем в список пар для потока

                                a.Load++; // увеличиваем загруженность на 1
                                p.Load++; // увеличиваем загруженность на 1
                                cur.IsLectUsed = true; // лекция по данному предмету есть в списке занятий
                            }
                        }
                    }
                    else // если нет лекций
                    {
                        if (cur.PractForTwoFlows) // если пара практики для 2 потоков не нашлась в шаге 1, то разбиваем эту пару для кажого потока отдеально (например англ)
                        {
                            if (cur.NumOfHoursForPractice != 0) // если есть практики
                            {
                                if (!cur.IsPractUsed) // если у потока практика по этому предмету ещё не использована (нет в списке занятий)
                                {
                                    Auditorium a = FindAudit(flow, audit, cur.Department, cur.TypeOfAuditorium); // ищем пркт. аудиторию на кафедре
                                    Professor p = FindProf(prof, cur.Department, false); // ищем препод.

                                    if (!a.isNull() && !p.isNull()) // если найдены аудитория и преподаватель
                                    {
                                        lessons_for_one_flow.Add(new LessonForOneFlow(cur.NameOfSubject, flow, cur.NumOfHoursForPractice, p, a)); // добавляем в список пар для потока

                                        a.Load++; // увеличиваем загруженность на 1
                                        p.Load++; // увеличиваем загруженность на 1
                                        cur.IsPractUsed = true; // практика по данному предмету есть в списке занятий
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return lessons_for_one_flow;
        }

        // Step2
        // потоки должны быть отсортированы по кусру и по специальности
        public static List<LessonForGroup> FormListOfLessonsForGroup(List<Flows> flows, List<Auditorium> audit, List<Professor> prof) // формирует список пар для одной группы
        {
            List<LessonForGroup> lessons_for_group = new List<LessonForGroup>();

            foreach (Flows flow in flows)
            {
                foreach (Curriculum cur in flow.CurriculumDataTable)
                {
                    if (cur.NumOfHoursForPractice != 0)
                    {
                        if (!cur.PractForTwoFlows)
                        {
                            if (!cur.IsPractUsed)
                            {
                                bool IsAllGroupsUsed = true; // все ли LessonForGroup получили аудиторию и препод.

                                foreach (Group group in flow.Groups)
                                {
                                    Auditorium a = FindAudit(group, audit, cur.Department, cur.TypeOfAuditorium); // ищем пркт. аудиторию на кафедре
                                    Professor p = FindProf(prof, cur.Department, false); // ищем препод.

                                    if (a.isNull()) // если не нашлось аудитории
                                    {
                                        if (cur.TypeOfAuditorium == (int)AuditoriumType.Laboratory) // если тип искомой аудитории лабор.
                                        {
                                            a = FindAudit(group, audit, cur.Department, (int)AuditoriumType.Lecture); // найдем аудиторию на той же кафедру но лекционную
                                        }
                                    }

                                    if (p.isNull()) // если не нашлось преподавателя
                                    {
                                        p = FindProf(prof, cur.Department, true); // ищем препод. среди профессоров и доцентов
                                    }

                                    Console.WriteLine("---------------------");
                                    Console.WriteLine(cur.NameOfSubject + " " + group.NumberName);
                                    a.WtiteInConsole();
                                    p.WtiteInConsole();

                                    if (!a.isNull() && !p.isNull()) // если найдены аудитория и преподаватель
                                    {
                                        lessons_for_group.Add(new LessonForGroup(cur.NameOfSubject, group, cur.NumOfHoursForPractice, p, a)); // добавляем в список пар для группы

                                        a.Load++; // увеличиваем загруженность на 1
                                        p.Load++; // увеличиваем загруженность на 1
                                    }
                                    else
                                    {
                                        IsAllGroupsUsed = false;
                                    }
                                }

                                if (IsAllGroupsUsed) cur.IsPractUsed = true; // если все для всех групп нашлись препод. и ауд. то практика по данному предмету есть в списке занятий
                            }
                        }
                    }
                }
            }

            return lessons_for_group;
        }

        private static void SetIn(LessonForFlows lesson_for_flows, int i, int j, bool IsNum)
        {
            foreach (Group gr in lesson_for_flows.flow1.Groups)
            {
                if (IsNum)
                {
                    gr.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_flows.SubjectName;
                    gr.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_flows.Hours;
                    gr.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_flows.auditorium;
                    gr.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_flows.professor;
                }
                else
                {
                    gr.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_flows.SubjectName;
                    gr.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_flows.Hours;
                    gr.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_flows.auditorium;
                    gr.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_flows.professor;
                }
            }

            foreach (Group gr in lesson_for_flows.flow2.Groups)
            {
                if (IsNum)
                {
                    gr.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_flows.SubjectName;
                    gr.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_flows.Hours;
                    gr.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_flows.auditorium;
                    gr.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_flows.professor;
                }
                else
                {
                    gr.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_flows.SubjectName;
                    gr.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_flows.Hours;
                    gr.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_flows.auditorium;
                    gr.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_flows.professor;
                }
            }
        }

        private static void SetIn(LessonForOneFlow lesson_for_one_flows, int i, int j, bool IsNum)
        {
            foreach (Group gr in lesson_for_one_flows.flow.Groups)
            {
                if (IsNum)
                {
                    gr.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_one_flows.SubjectName;
                    gr.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_one_flows.Hours;
                    gr.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_one_flows.auditorium;
                    gr.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_one_flows.professor;
                }
                else
                {
                    gr.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_one_flows.SubjectName;
                    gr.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_one_flows.Hours;
                    gr.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_one_flows.auditorium;
                    gr.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_one_flows.professor;
                }
            }
        }

        private static void SetIn(LessonForGroup lesson_for_group, int i, int j, bool IsNum, List<Flows> flows)
        {
            if (IsNum)
            {
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_group.SubjectName;
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_group.Hours;
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_group.auditorium;
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_group.professor;
            }
            else
            {
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_group.SubjectName;
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_group.Hours;
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_group.auditorium;
                Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_group.professor;
            }

            lesson_for_group.WriteInConsole();
        }

        public static void PasteInSchedule(List<Flows> flows, List<Auditorium> audit, List<Professor> prof, LessonForFlows lesson_for_flows)
        {
            bool IsNum = true;
            bool IsPasted = false;
            bool inter = false;

            int hours = Convert.ToInt32(2 * lesson_for_flows.Hours);


            for (int h = 0; h < hours; h++)
            {
                for (int i = 0; i < 5; i++) // days
                {
                    for (int j = 0; j < 5; j++) // paras
                    {
                        foreach (Group gr in lesson_for_flows.flow1.Groups)
                        {
                            if (IsNum)
                            {
                                if (gr.Week.Days[i].ScheduleTableNumenator[j].SubjectName != "")
                                {
                                    inter = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (gr.Week.Days[i].ScheduleTableDenominator[j].SubjectName != "")
                                {
                                    inter = true;
                                    break;
                                }
                            }
                        }
                        if (!inter)
                        {
                            foreach (Group gr in lesson_for_flows.flow2.Groups)
                            {
                                if (IsNum)
                                {
                                    if (gr.Week.Days[i].ScheduleTableNumenator[j].SubjectName != "")
                                    {
                                        inter = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (gr.Week.Days[i].ScheduleTableDenominator[j].SubjectName != "")
                                    {
                                        inter = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (inter)
                        {
                            IsPasted = false;
                            inter = false;
                        }
                        else
                        {
                            IsPasted = true;

                            SetIn(lesson_for_flows, i, j, IsNum);
                            Auditorium.SetInWeek(audit, lesson_for_flows, i, j, IsNum);
                            Professor.SetInWeek(prof, lesson_for_flows, i, j, IsNum);

                            break;
                        }
                    }

                    if (IsPasted) break;
                }

                IsNum = !IsNum;
            }
        }

        public static void PasteInSchedule(List<Flows> flows, List<Auditorium> audit, List<Professor> prof, LessonForOneFlow lesson_for_one_flows)
        {
            bool IsNum = true;
            bool IsPasted = false;
            bool inter = false;

            int hours = Convert.ToInt32(2 * lesson_for_one_flows.Hours);


            for (int h = 0; h < hours; h++)
            {
                for (int i = 0; i < 5; i++) // days
                {
                    for (int j = 0; j < 5; j++) // paras
                    {
                        foreach (Group gr in lesson_for_one_flows.flow.Groups)
                        {
                            if (IsNum)
                            {
                                if (gr.Week.Days[i].ScheduleTableNumenator[j].SubjectName != "")
                                {
                                    inter = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (gr.Week.Days[i].ScheduleTableDenominator[j].SubjectName != "")
                                {
                                    inter = true;
                                    break;
                                }
                            }
                        }
                        if (inter)
                        {
                            IsPasted = false;
                            inter = false;
                        }
                        else
                        {
                            IsPasted = true;

                            SetIn(lesson_for_one_flows, i, j, IsNum);
                            Auditorium.SetInWeek(audit, lesson_for_one_flows, i, j, IsNum);
                            Professor.SetInWeek(prof, lesson_for_one_flows, i, j, IsNum);

                            break;
                        }
                    }

                    if (IsPasted) break;
                }

                IsNum = !IsNum;
            }
        }

        public static void PasteInSchedule(List<Flows> flows, List<Auditorium> audit, List<Professor> prof, LessonForGroup lesson_for_group)
        {
            bool IsNum = true;
            bool IsPasted = false;
            bool inter = false;

            int hours = Convert.ToInt32(2 * lesson_for_group.Hours);


            for (int h = 0; h < hours; h++)
            {
                foreach (int day in Flows.GetFlowDueToGroup(flows, lesson_for_group.group).expectedSchedule.Importance.Keys) // days
                {
                    for (int j = 0; j <= Flows.GetFlowDueToGroup(flows, lesson_for_group.group).expectedSchedule.Importance[day]; j++) // paras
                    {
                        if (IsNum)
                        {
                            if (Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[day].ScheduleTableNumenator[j].SubjectName != "")
                            {
                                inter = true;
                            }
                        }
                        else
                        {
                            if (Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[day].ScheduleTableDenominator[j].SubjectName != "")
                            {
                                inter = true;
                            }
                        }

                        if (inter)
                        {
                            IsPasted = false;
                            inter = false;
                        }
                        else
                        {
                            IsPasted = true;

                            SetIn(lesson_for_group, day, j, IsNum, flows);
                            Auditorium.SetInWeek(audit, lesson_for_group, day, j, IsNum);
                            Professor.SetInWeek(prof, lesson_for_group, day, j, IsNum);

                            break;
                        }
                    }

                    if (IsPasted) break;
                }

                IsNum = !IsNum;
            }
        }

        public static void PasteInSchedule2(List<Flows> flows, List<Auditorium> audit, List<Professor> prof, LessonForFlows lesson_for_flows)
        {
            bool IsNum = true; // числитель или знаменатель
            bool IsPasted = false; // вставили ли урок в расписание
            bool inter = false; // указывает, можно ли вставить данный урок в определенный день и время
            bool IsAudProfOk = false;

            int hours = Convert.ToInt32(2 * lesson_for_flows.Hours); // для числит и знам

            // КРУГ 1

            for (int h = 0; h < hours; h++) // вставляем в расписание столько раз, сколько часов
            {
                for (int day = 0; day < 5; day++) // обходим дни не смотря на важность дней (пн вт ср чт птн)
                {
                    IsPasted = false;

                    // если в этот день у 2 потоков сразу нет пары по данной дисциплине (берем 0 группу из этих потоков для проверки)
                    if (!lesson_for_flows.flow1.Groups[0].IsSameLessonInThisDay(lesson_for_flows.SubjectName, day, IsNum) && !lesson_for_flows.flow2.Groups[0].IsSameLessonInThisDay(lesson_for_flows.SubjectName, day, IsNum))
                    {
                        for (int j = 0; j < 5; j++) // обходим все пары
                        {
                            IsAudProfOk = false; // audit + prof

                            if (IsNum)
                            {
                                if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_flows.auditorium).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "") // если у аудитории в это время нет пары
                                {
                                    if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_flows.professor).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "")  // если у преп. в это время нет пары
                                    {
                                        IsAudProfOk = true;
                                    }
                                }
                            }
                            else
                            {
                                if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_flows.auditorium).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "") // если у аудитории в это время нет пары
                                {
                                    if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_flows.professor).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "")  // если у преп. в это время нет пары
                                    {
                                        IsAudProfOk = true;
                                    }
                                }
                            }

                            if (IsAudProfOk) // если у аудитории и препод. в это время нет пары
                            {
                                foreach (Group gr in lesson_for_flows.flow1.Groups) // определяем, можно ли для потока 1 вcтавить пару в это время
                                {
                                    if (IsNum)
                                    {
                                        if (gr.Week.Days[day].ScheduleTableNumenator[j].SubjectName != "") // если в расписании на это время уже стоит пара
                                        {
                                            inter = true; // прерываем
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (gr.Week.Days[day].ScheduleTableDenominator[j].SubjectName != "")
                                        {
                                            inter = true;
                                            break;
                                        }
                                    }
                                }
                                if (!inter)
                                {
                                    foreach (Group gr in lesson_for_flows.flow2.Groups) // определяем, можно ли для потока 2 вcтавить пару в это время
                                    {
                                        if (IsNum)
                                        {
                                            if (gr.Week.Days[day].ScheduleTableNumenator[j].SubjectName != "")
                                            {
                                                inter = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (gr.Week.Days[day].ScheduleTableDenominator[j].SubjectName != "")
                                            {
                                                inter = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (inter)
                                {
                                    IsPasted = false;
                                    inter = false;
                                }
                                else
                                {
                                    IsPasted = true;

                                    SetIn(lesson_for_flows, day, j, IsNum);
                                    Auditorium.SetInWeek(audit, lesson_for_flows, day, j, IsNum);
                                    Professor.SetInWeek(prof, lesson_for_flows, day, j, IsNum);

                                    break;
                                }
                            }                            
                        }
                    }

                    if (IsPasted) break;
                }

                IsNum = !IsNum;
            }
        }

        public static void PasteInSchedule2(List<Flows> flows, List<Auditorium> audit, List<Professor> prof, LessonForOneFlow lesson_for_one_flows)
        {
            bool IsNum = true; // числитель или знаменатель
            bool IsPasted = false; // вставили ли урок в расписание
            bool inter = false; // указывает, можно ли вставить данный урок в определенный день и время
            bool IsAudProfOk = false;

            int hours = Convert.ToInt32(2 * lesson_for_one_flows.Hours); // для числит и знам

            // КРУГ 1

            for (int h = 0; h < hours; h++) // вставляем в расписание столько раз, сколько часов
            {
                for (int day = 0; day < 5; day++) // обходим дни не смотря на важность дней (пн вт ср чт птн)
                {
                    IsPasted = false;

                    // если в этот день у потокa нет пары по данной дисциплине
                    if (!lesson_for_one_flows.flow.Groups[0].IsSameLessonInThisDay(lesson_for_one_flows.SubjectName, day, IsNum))
                    {
                        for (int j = 0; j < 5; j++) // обходим все пары
                        {
                            IsAudProfOk = false; // audit + prof

                            if (IsNum)
                            {
                                if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_one_flows.auditorium).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "") // если у аудитории в это время нет пары
                                {
                                    if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_one_flows.professor).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "")  // если у преп. в это время нет пары
                                    {
                                        IsAudProfOk = true;
                                    }
                                }
                            }
                            else
                            {
                                if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_one_flows.auditorium).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "") // если у аудитории в это время нет пары
                                {
                                    if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_one_flows.professor).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "")  // если у преп. в это время нет пары
                                    {
                                        IsAudProfOk = true;
                                    }
                                }
                            }

                            if (IsAudProfOk) // если у аудитории и препод. в это время нет пары
                            {
                                foreach (Group gr in lesson_for_one_flows.flow.Groups) // определяем, можно ли для потока 1 вcтавить пару в это время
                                {
                                    if (IsNum)
                                    {
                                        if (gr.Week.Days[day].ScheduleTableNumenator[j].SubjectName != "") // если в расписании на это время уже стоит пара
                                        {
                                            inter = true; // прерываем
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (gr.Week.Days[day].ScheduleTableDenominator[j].SubjectName != "")
                                        {
                                            inter = true;
                                            break;
                                        }
                                    }
                                }

                                if (inter)
                                {
                                    IsPasted = false;
                                    inter = false;
                                }
                                else
                                {
                                    IsPasted = true;

                                    SetIn(lesson_for_one_flows, day, j, IsNum);
                                    Auditorium.SetInWeek(audit, lesson_for_one_flows, day, j, IsNum);
                                    Professor.SetInWeek(prof, lesson_for_one_flows, day, j, IsNum);

                                    break;
                                }
                            }
                        }
                    }

                    if (IsPasted) break;
                }

                IsNum = !IsNum;
            }
        }

        public static void PasteInSchedule2(List<Flows> flows, List<Auditorium> audit, List<Professor> prof, LessonForGroup lesson_for_group)
        {
            bool IsNum = true; // числитель или знаменатель
            bool IsPasted = false; // вставили ли урок в расписание
            bool inter = false; // указывает, можно ли вставить данный урок в определенный день и время

            bool [] FreeDays = new bool[5] { true, true, true, true, true }; // указывает, свободный ли день для данного урока (нужен для 2 круга)

            int hours = Convert.ToInt32(2 * lesson_for_group.Hours); // для числит и знам
            int pastedHours = 0;

            // КРУГ 1
            if (!Flows.GetFlowDueToGroup(flows, lesson_for_group.group).expectedSchedule.is_null()) // если пользователь задал желаемую загруженность
            {
                for (int h = 0; h < hours; h++) // вставляем в расписание столько раз, сколько часов
                {
                    foreach (int day in Flows.GetFlowDueToGroup(flows, lesson_for_group.group).expectedSchedule.Importance.Keys) // обходим дни согласно важности дней (например: ср вт чтв пн птн)
                    {
                        if (!Flows.GetGroupDueToGroup(flows, lesson_for_group.group).IsSameLessonInThisDay(lesson_for_group.SubjectName, day, IsNum)) // если в этот день нет пары по этой дисциплине
                        {
                            for (int j = 0; j < Flows.GetFlowDueToGroup(flows, lesson_for_group.group).expectedSchedule.Importance[day]; j++) // обходим все пары в этот день, начиная с 0 и до максимальной(её указывал пользователь)
                            {
                                if (IsNum) // если числитель
                                {
                                    if (Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "") // если у группы в это время нет пары
                                    {
                                        if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_group.auditorium).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "") // если у аудитории в это время нет пары
                                        {
                                            if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_group.professor).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "")  // если у преп. в это время нет пары
                                            {
                                                IsPasted = true;

                                                SetIn(lesson_for_group, day, j, IsNum, flows);
                                                Auditorium.SetInWeek(audit, lesson_for_group, day, j, IsNum);
                                                Professor.SetInWeek(prof, lesson_for_group, day, j, IsNum);
                                            }
                                        }
                                    }
                                }
                                else // если знаменатель
                                {
                                    if (Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "")
                                    {
                                        if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_group.auditorium).Week.Days[day].ScheduleTableDenominator[j].auditorium.isNull()) // если у аудитории в это время нет пары
                                        {
                                            if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_group.professor).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "")  // если у преп. в это время нет пары
                                            {
                                                IsPasted = true;

                                                SetIn(lesson_for_group, day, j, IsNum, flows);
                                                Auditorium.SetInWeek(audit, lesson_for_group, day, j, IsNum);
                                                Professor.SetInWeek(prof, lesson_for_group, day, j, IsNum);
                                            }
                                        }
                                    }
                                }

                                if (IsPasted) break; // если вставили пару в расписание - выходим
                            }
                        }
                        else // если в этот день есль пара по этой дисциплине
                        {
                            FreeDays[day] = false; // этот день больше не рассматриваем (на круге 2)
                        }

                        if (IsPasted) // если вставили пару в расписание - выходим
                        {
                            pastedHours++;
                            IsPasted = false;
                            break;
                        }
                    }

                    IsNum = !IsNum; // меняем числит. - знам.
                }
            }

            // КРУГ 2
            if (pastedHours != hours) // если не было найденно место в расписании с желаемой загруженностью или желаемая загруженность не была указана (is_null())
            {
                IsNum = true;
                IsPasted = false;

                for (int h = pastedHours; h < hours; h++) // вставляем в расписание столько раз, сколько часов
                {
                    for (int day = 0; day < 5; day++) // обходим дни 
                    {
                        if (!Flows.GetGroupDueToGroup(flows, lesson_for_group.group).IsSameLessonInThisDay(lesson_for_group.SubjectName, day, IsNum)) // если в этот день нет пары по этой дисциплине
                        {
                            for (int j = 0; j < 5; j++) // обходим все пары в этот день
                            {
                                if (IsNum) // если числитель
                                {
                                    if (Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "") // если у группы в это время нет пары
                                    {
                                        if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_group.auditorium).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "") // если у аудитории в это время нет пары
                                        {
                                            if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_group.professor).Week.Days[day].ScheduleTableNumenator[j].SubjectName == "")  // если у преп. в это время нет пары
                                            {
                                                IsPasted = true;

                                                SetIn(lesson_for_group, day, j, IsNum, flows);
                                                Auditorium.SetInWeek(audit, lesson_for_group, day, j, IsNum);
                                                Professor.SetInWeek(prof, lesson_for_group, day, j, IsNum);
                                            }
                                        }
                                    }
                                }
                                else // если знаменатель
                                {
                                    if (Flows.GetGroupDueToGroup(flows, lesson_for_group.group).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "")
                                    {
                                        if (Auditorium.GetAuditoriumDueToAuditName(audit, lesson_for_group.auditorium).Week.Days[day].ScheduleTableDenominator[j].auditorium.isNull()) // если у аудитории в это время нет пары
                                        {
                                            if (Professor.GetProfessorDueToProfessorName(prof, lesson_for_group.professor).Week.Days[day].ScheduleTableDenominator[j].SubjectName == "")  // если у преп. в это время нет пары
                                            {
                                                IsPasted = true;

                                                SetIn(lesson_for_group, day, j, IsNum, flows);
                                                Auditorium.SetInWeek(audit, lesson_for_group, day, j, IsNum);
                                                Professor.SetInWeek(prof, lesson_for_group, day, j, IsNum);
                                            }
                                        }
                                    }
                                }

                                if (IsPasted) break; // если вставили пару в расписание - выходим
                            }
                        }
                        else // если в этот день есль пара по этой дисциплине
                        {
                            FreeDays[day] = false; // этот день больше не рассматриваем (на круге 2)
                        }

                        if (IsPasted) // если вставили пару в расписание - выходим
                        {
                            IsPasted = false;
                            break;
                        }
                    }

                    IsNum = !IsNum; // меняем числит. - знам.
                }
            }

        }

    }
}
