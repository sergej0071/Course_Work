using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class SchoolWeek
    {
        public List<Day> Days { set; get; }

        public SchoolWeek()
        {
            Days = new List<Day>(5);
            for (int i = 1; i <= 5; i++)
            {
                Days.Add(new Day(i));
            }
        }

        public void WriteInConsole()
        {
            Console.WriteLine("Numenator:\n");
            foreach (Day day in Days)
            {
                day.WriteNumInConsole();
            }

            Console.WriteLine("\nDenominator:\n");
            foreach (Day day in Days)
            {
                day.WriteDemInConsole();
            }
        }
    }
}
