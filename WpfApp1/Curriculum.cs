using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Curriculum
    {
        public string NameOfSubject { get; set; }
        public int Department { get; set; }
        public double NumOfHourForLections { get; set; } // на неделю
        public double NumOfHoursForPractice { get; set; }
        public int TypeOfAuditorium { get; set; } // для практики

        public bool IsLectUsed { get; set; }
        public bool IsPractUsed { get; set; }

        public bool PractForTwoFlows { get; set; } // может ли практика быть не только у одной группы, а у 1 или 2 потоков

        public Curriculum(string NameOfSubject, int Department, double NumOfHourForLections, double NumOfHoursForPractice, int TypeOfAuditorium)
        {
            this.NameOfSubject = NameOfSubject;
            this.Department = Department;
            this.NumOfHourForLections = NumOfHourForLections;
            this.NumOfHoursForPractice = NumOfHoursForPractice;
            this.TypeOfAuditorium = TypeOfAuditorium;

            IsLectUsed = false;
            IsPractUsed = false;

            PractForTwoFlows = false;
        }

        public void WriteInConsole()
        {
            if (NameOfSubject.Length > 5)
            {
                Console.WriteLine(NameOfSubject.Substring(0, 5) + "\t" + Department.ToString() + "\t" + NumOfHourForLections.ToString() + "\t" + NumOfHoursForPractice.ToString() + "\t" + TypeOfAuditorium.ToString());

            }
            else
            {
                Console.WriteLine(NameOfSubject + "\t" + Department.ToString() + "\t" + NumOfHourForLections.ToString() + "\t" + NumOfHoursForPractice.ToString() + "\t" + TypeOfAuditorium.ToString());
            }
        }

        public void WriteUsedParam()
        {
            if (NameOfSubject.Length > 5)
            {
                Console.WriteLine(NameOfSubject.Substring(0, 5) + "\t" + IsLectUsed.ToString() + "\t" + IsPractUsed.ToString());

            }
            else
            {
                Console.WriteLine(NameOfSubject + "\t" + IsLectUsed.ToString() + "\t" + IsPractUsed.ToString());
            }
        }
    }
}
