using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class MainAlgorithm
    {
        public static void MakeSchedule(List<Flows> flows, List<Auditorium> audit, List<Professor> prof)
        {
            InsertionSort(flows);

            Dictionary<int, int> TestImportance = new Dictionary<int, int>(5);
            TestImportance.Add(0, 3); // mon
            TestImportance.Add(2, 3); // tu
            TestImportance.Add(1, 3); // we
            TestImportance.Add(4, 3); // th
            TestImportance.Add(3, 3); // fr

            foreach(Flows fl in flows)
            {
                fl.expectedSchedule.Set(fl.Course, fl.Speciality, TestImportance);
            }

            Flows.ChangePractiseStatusForSubjectForFlows(flows, "Фізвиховання"); // делаем возможность проведения практики по физкультуре у нескольких потоков
            List<LessonForFlows> lessons_for_flows = Steps.FormListOfLessonsForFlows(flows, audit, prof);

            List<LessonForOneFlow> lessons_for_one_flow = Steps.FormListOfLessonsForOneFlow(flows, audit, prof);

            List<LessonForGroup> lessons_for_group = Steps.FormListOfLessonsForGroup(flows, audit, prof);

            foreach (LessonForFlows lff in lessons_for_flows)
            {
                Steps.PasteInSchedule2(flows, audit, prof, lff);
            }

            //Steps.PasteInSchedule2(flows, audit, prof, lessons_for_flows[0]);
            //Steps.PasteInSchedule2(flows, audit, prof, lessons_for_flows[4]);

            foreach (LessonForOneFlow lfof in lessons_for_one_flow)
            {
                Steps.PasteInSchedule2(flows, audit, prof, lfof);
            }

            foreach (LessonForGroup lfg in lessons_for_group)
            {
                Steps.PasteInSchedule2(flows, audit, prof, lfg);
            }

            //flows[0].WriteScheduleInConsole();
            //flows[2].WriteScheduleInConsole();


            foreach (Auditorium a in audit)
            {
                if (a.NumOfAuditorium == 1000)
                {
                    a.Week.WriteInConsole();
                    break;
                }
            }

            foreach (Flows flow in flows)
            {
                flow.WriteScheduleInConsole();
            }

            //foreach (Flows flow in flows)
            //{
            //    flow.WriteUsedParam();
            //}
        }

        public static void InsertionSort(List<Flows> flows)
        {
            int i = 0;
            Flows key;

            //сортировка по курсу и специальности
            for (int j = 1; j < flows.Count; j++)
            {
                key = flows[j];
                i = j - 1;

                while (i >= 0 && flows[i].Course > key.Course) //сортировка по курсу
                {
                    flows[i + 1] = flows[i];
                    i -= 1;
                }
                flows[i + 1] = key;

                while (i >= 0 && flows[i].Speciality > key.Speciality && flows[i].Course == key.Course) // сортировка по номеру специальности
                {
                    flows[i + 1] = flows[i];
                    i -= 1;
                }
                flows[i + 1] = key;
            }

            foreach (Flows flow in flows)
            {
                flow.WtiteInConsole();
            }
        }
    }
}
