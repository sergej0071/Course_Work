using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Day
    {
        private int name { set; get; }

        public Dictionary<int, Lesson> ScheduleTableNumenator { set; get; }
        public Dictionary<int, Lesson> ScheduleTableDenominator { set; get; }

        public Day()
        {
            name = 0;

            ScheduleTableNumenator = new Dictionary<int, Lesson>();
            for (int i = 0; i < 5; i++)
            {
                ScheduleTableNumenator.Add(i, new Lesson());
            }

            ScheduleTableDenominator = new Dictionary<int, Lesson>();
            for (int i = 0; i < 5; i++)
            {
                ScheduleTableDenominator.Add(i, new Lesson());
            }
        }

        public Day(int i)
        {
            name = i;

            ScheduleTableNumenator = new Dictionary<int, Lesson>();
            for (int j = 0; j < 5; j++)
            {
                ScheduleTableNumenator.Add(j, new Lesson());
            }

            ScheduleTableDenominator = new Dictionary<int, Lesson>();
            for (int j = 0; j < 5; j++)
            {
                ScheduleTableDenominator.Add(j, new Lesson());
            }
        }

        public void WriteNumInConsole()
        {
            Console.WriteLine(name.ToString() + "\n");
            foreach (KeyValuePair<int, Lesson> keyValue in ScheduleTableNumenator)
            {
                Console.WriteLine(keyValue.Key.ToString() + ":\t" + keyValue.Value.SubjectName.ToString() + " " + keyValue.Value.Hours.ToString() + " " + keyValue.Value.professor.FIO + " " + keyValue.Value.auditorium.NumOfAuditorium.ToString());
            }
        }

        public void WriteDemInConsole()
        {
            Console.WriteLine(name.ToString() + "\n");
            foreach (KeyValuePair<int, Lesson> keyValue in ScheduleTableDenominator)
            {
                Console.WriteLine(keyValue.Key.ToString() + ":\t" + keyValue.Value.SubjectName.ToString() + " " + keyValue.Value.Hours.ToString() + " " + keyValue.Value.professor.FIO + " " + keyValue.Value.auditorium.NumOfAuditorium.ToString());
            }
        }
    }
}
