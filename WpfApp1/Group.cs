using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Group
    {
        public int Departmant { set; get; }
        public int NumberName { set; get; }
        public int Population { set; get; }

        public SchoolWeek Week;

        public Group()
        {
            this.Departmant = 0;
            this.NumberName = 0;
            this.Population = 0;

            this.Week = new SchoolWeek();
        }

        public Group(int Departmant, int NumberName, int Population)
        {
            this.Departmant = Departmant;
            this.NumberName = NumberName;
            this.Population = Population;

            this.Week = new SchoolWeek();
        }

        public bool IsSameLessonInThisDay(string subj, int day, bool IsNum)
        {
            if (IsNum)
            {
                foreach (KeyValuePair<int, Lesson> l in Week.Days[day].ScheduleTableNumenator)
                {
                    if (l.Value.SubjectName == subj) return true;
                }
            }
            else
            {
                foreach (KeyValuePair<int, Lesson> l in Week.Days[day].ScheduleTableDenominator)
                {
                    if (l.Value.SubjectName == subj) return true;
                }
            }

            return false;
        }

        public void WriteInConsole()
        {
            Console.WriteLine(NumberName);
            Week.WriteInConsole();
        }
    }
}
