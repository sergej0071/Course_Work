using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Data;

namespace Schedule
{
    class Auditorium : LoadFiles
    {
        public int Department { get; set; }
        public int NumOfAuditorium { get; set; }
        public string LetterOfAuditorium { get; set; }
        public int Сapacity { get; set; }
        public int TypeOfAuditorium { get; set; }

        public SchoolWeek Week; // расписание для аудиторий

        public int Load { get; set; }

        public Auditorium()
        {
            Department = 0;
            NumOfAuditorium = -1;
            LetterOfAuditorium = "";
            Сapacity = 0;
            TypeOfAuditorium = 0;
            Load = 0;
        }

        public Auditorium(int num_of_aud, string letter, int capacity, int type, int department)
        {
            Department = department;
            NumOfAuditorium = num_of_aud;
            LetterOfAuditorium = letter;
            Сapacity = capacity;
            TypeOfAuditorium = type;
            Load = 0;

            Week = new SchoolWeek();
        }

        public bool isNull()
        {
            if (NumOfAuditorium == -1) return true;
            else return false;
        }

        public void AddAuditoriumIntoTable()
        {
            if (Department != 0 && NumOfAuditorium != -1 && TypeOfAuditorium != 0) // NumOfAuditorium != null
            {
                int dep = Department;
                int type = TypeOfAuditorium;

                this.LoadDB();
                SQLiteCommand cmd = DB.CreateCommand();
                if (LetterOfAuditorium == "")
                {
                    cmd.CommandText = @"SELECT COUNT(*) FROM Auditorium WHERE [Num of Auditorium] = @num AND [Letter of Auditorium] IS NULL ;";
                }
                else
                {
                    cmd.CommandText = @"SELECT COUNT(*) FROM Auditorium WHERE [Num of Auditorium] = @num AND [Letter of Auditorium] = @letter ;";
                }

                cmd.Parameters.AddWithValue("@num", NumOfAuditorium);
                cmd.Parameters.AddWithValue("@letter", LetterOfAuditorium);
                var firstColumn = cmd.ExecuteScalar();
                string res = firstColumn.ToString();

                if (int.Parse(res) != 0)
                {
                    throw new Exception("Аудиторія з заданими параметрами вже існує !");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@capacity", Сapacity);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@department", dep);

                    cmd.CommandText = @"INSERT INTO Auditorium([Num of Auditorium], [Letter of Auditorium],[Сapacity], [Type of Auditorium], [Department])" +
                                      @"VALUES(@num, @letter, @capacity, @type, @department);";

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //MessageBox.Show(ex.Message);
                    }
                }

                this.CloseDB();
            }
        }

        public static void SetAllAuditorium(out List<Auditorium> temp)
        {
            DataTable dataTable = loadTable("Auditorium");

            temp = new List<Auditorium>(dataTable.Rows.Count);

            for (int i = 0; i < temp.Count; ++i)
            {
                temp[i] = new Auditorium();
            }

            string a = dataTable.Rows[0][0].ToString();

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
            {
                Auditorium buf = new Auditorium();

                buf.NumOfAuditorium = int.Parse(dataTable.Rows[rowCounter][0].ToString());
                buf.LetterOfAuditorium = dataTable.Rows[rowCounter][1].ToString();
                buf.Сapacity = int.Parse(dataTable.Rows[rowCounter][2].ToString());
                buf.TypeOfAuditorium = int.Parse(dataTable.Rows[rowCounter][3].ToString());
                buf.Department = int.Parse(dataTable.Rows[rowCounter][4].ToString());
                buf.Load = 0;

                buf.Week = new SchoolWeek();

                temp.Add(buf);
            }
        }

        public static void SetInWeek(List<Auditorium> audit, LessonForFlows lesson_for_flows, int i, int j, bool IsNum)
        {
            foreach (Auditorium a in audit)
            {
                if (a.NumOfAuditorium == lesson_for_flows.auditorium.NumOfAuditorium)
                {
                    if (IsNum)
                    {
                        a.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_flows.auditorium;
                        a.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_flows.Hours;
                        a.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_flows.professor;
                        a.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_flows.SubjectName;

                        break;
                    }
                    else
                    {
                        a.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_flows.auditorium;
                        a.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_flows.Hours;
                        a.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_flows.professor;
                        a.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_flows.SubjectName;

                        break;
                    }
                }
            }
        }

        public static void SetInWeek(List<Auditorium> audit, LessonForOneFlow lesson_for_one_flow, int i, int j, bool IsNum)
        {
            foreach (Auditorium a in audit)
            {
                if (a.Equals(lesson_for_one_flow.auditorium))
                {
                    if (IsNum)
                    {
                        a.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_one_flow.auditorium;
                        a.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_one_flow.Hours;
                        a.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_one_flow.professor;
                        a.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_one_flow.SubjectName;
                    }
                    else
                    {
                        a.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_one_flow.auditorium;
                        a.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_one_flow.Hours;
                        a.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_one_flow.professor;
                        a.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_one_flow.SubjectName;
                    }
                }
            }
        }

        public static void SetInWeek(List<Auditorium> audit, LessonForGroup lesson_for_group, int i, int j, bool IsNum)
        {
            foreach (Auditorium a in audit)
            {
                if (a.Equals(lesson_for_group.auditorium))
                {
                    if (IsNum)
                    {
                        a.Week.Days[i].ScheduleTableNumenator[j].auditorium = lesson_for_group.auditorium;
                        a.Week.Days[i].ScheduleTableNumenator[j].Hours = lesson_for_group.Hours;
                        a.Week.Days[i].ScheduleTableNumenator[j].professor = lesson_for_group.professor;
                        a.Week.Days[i].ScheduleTableNumenator[j].SubjectName = lesson_for_group.SubjectName;
                    }

                    else
                    {
                        a.Week.Days[i].ScheduleTableDenominator[j].auditorium = lesson_for_group.auditorium;
                        a.Week.Days[i].ScheduleTableDenominator[j].Hours = lesson_for_group.Hours;
                        a.Week.Days[i].ScheduleTableDenominator[j].professor = lesson_for_group.professor;
                        a.Week.Days[i].ScheduleTableDenominator[j].SubjectName = lesson_for_group.SubjectName;
                    }
                }
            }
        }

        public static Auditorium GetAuditoriumDueToAuditName(List<Auditorium> audit, Auditorium a)
        {
            foreach(Auditorium el in audit)
            {
                if (el.Equals(a))
                {
                    return el;
                }
            }

            return new Auditorium();
        }

        public void WtiteInConsole() // функция вывода в консоль
        {
            string strout = Department.ToString() + "\t" + NumOfAuditorium.ToString() + "\t" +
                LetterOfAuditorium.ToString() + "\t" + Сapacity.ToString() + "\t" + TypeOfAuditorium.ToString() + "\t" + Load.ToString() + "\n";
            Console.WriteLine(strout);
        }

        public static void WtiteAllInConsole(List<Auditorium> temp) // функция вывода в консоль
        {
            foreach (Auditorium el in temp) // вывод CurriculumDataTable
            {
                el.WtiteInConsole();
            }
        }
    }
}

