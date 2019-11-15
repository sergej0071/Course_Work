using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Schedule 
{
    class Professor : LoadFiles
    {
        public int Department { get; set; }
        public string FIO{ get; set; }
        public int Rank { get; set; }

        public SchoolWeek Week; // расписание для преподавателей 

        public int Load { get; set; }

        public Professor()
        {
            Department = 0;
            FIO = "";
            Rank = 0;
            Load = 0;
        }

        public Professor(int department, string fio, int rank_of_professor)
        {
            Department = department;
            FIO = fio;
            Rank = rank_of_professor;
            Load = 0;

            Week = new SchoolWeek();
        }

        public bool isNull()
        {
            if (Department == 0) return true;
            else return false;
        }

        public static void SetAllProfessors(out List<Professor> temp)
        {
            DataTable dataTable = loadTable("Professors");

            temp = new List<Professor>(dataTable.Rows.Count);

            for (int i = 0; i < temp.Count; ++i)
            {
                temp[i] = new Professor();
            }

            string a = dataTable.Rows[0][0].ToString();

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
            {
                Professor buf = new Professor();

                buf.Department = int.Parse(dataTable.Rows[rowCounter][0].ToString());
                buf.FIO = dataTable.Rows[rowCounter][1].ToString();
                buf.Rank = int.Parse(dataTable.Rows[rowCounter][2].ToString());

                buf.Week = new SchoolWeek(); // инициализвация расписания для преподавателей

                temp.Add(buf);
            }
        }

        public static void SetInWeek(List<Professor> prof, LessonForFlows lesson_for_flows, int i, int j, bool IsNum)
        {
            foreach(Professor p in prof)
            {
                if (p.FIO == lesson_for_flows.professor.FIO)
                {
                    if (IsNum)
                    {
                        p.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_flows.auditorium;
                        p.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_flows.Hours;
                        p.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_flows.professor;
                        p.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_flows.SubjectName;

                        break;
                    }
                    else
                    {
                        p.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_flows.auditorium;
                        p.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_flows.Hours;
                        p.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_flows.professor;
                        p.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_flows.SubjectName;

                        break;
                    }
                }
            }
        } // добавить препод. в расписание

        public static void SetInWeek(List<Professor> prof, LessonForOneFlow lesson_for_one_flow, int i, int j, bool IsNum)
        {
            foreach (Professor p in prof)
            {
                if (p.Equals(lesson_for_one_flow.professor))
                {
                    if (IsNum)
                    {
                        p.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_one_flow.auditorium;
                        p.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_one_flow.Hours;
                        p.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_one_flow.professor;
                        p.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_one_flow.SubjectName;
                    }
                    else
                    {
                        p.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_one_flow.auditorium;
                        p.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_one_flow.Hours;
                        p.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_one_flow.professor;
                        p.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_one_flow.SubjectName;
                    }
                }
            }
        } // добавить препод. в расписание

        public static void SetInWeek(List<Professor> prof, LessonForGroup lesson_for_group, int i, int j, bool IsNum)
        {
            foreach (Professor p in prof)
            {
                if (p.Equals(lesson_for_group.professor))
                {
                    if (IsNum)
                    {
                        p.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_group.auditorium;
                        p.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_group.Hours;
                        p.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_group.professor;
                        p.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_group.SubjectName;
                    }
                    else
                    {
                        p.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_group.auditorium;
                        p.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_group.Hours;
                        p.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_group.professor;
                        p.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_group.SubjectName;
                    }
                }
            }
        } // добавить препод. в расписание

        public static Professor GetProfessorDueToProfessorName(List<Professor> prof, Professor p)
        {
            foreach (Professor el in prof)
            {
                if (el.Equals(p))
                {
                    return el;
                }
            }

            return new Professor();
        }

        public void WtiteInConsole() // функция вывода в консоль
        {
            string strout = Department.ToString() + "\t" + FIO.ToString() + "\t" +
                Rank.ToString() + "\n";
            Console.WriteLine(strout);
        }

        public static void WtiteAllInConsole(List<Professor> temp) // функция вывода в консоль
        {
            foreach (Professor el in temp)
            {
                el.WtiteInConsole();
            }
        }
    }
}
