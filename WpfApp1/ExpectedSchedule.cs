using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class ExpectedSchedule
    {
        public int Course;
        public int Speciality;

        public Dictionary<int, int> Importance;

        public ExpectedSchedule()
        {
            Course = 0;
            Speciality = 0;

            Importance = new Dictionary<int, int>(5);
        }

        public ExpectedSchedule(int Course, int Speciality)
        {
            this.Course = Course;
            this.Speciality = Speciality;

            Importance = new Dictionary<int, int>(5);

            for(int i = 1; i <= 5; i++) // по умолчанию важность дней - это последовательность от пнд до птн, в кажом дне по 5 пар (0 - 4)
            {
                Importance.Add(i, 4);
            }
        }

        public bool is_null()
        {
            if (Course == 0 && Speciality == 0) return true;
            else return false;
        }

        public void Set(int Course, int Speciality, Dictionary<int, int> es)
        {
            this.Course = Course;
            this.Speciality = Speciality;
            Importance.Clear();

            foreach(KeyValuePair<int, int> el in es)
            {
                if (el.Key >= 0 && el.Key <= 4)
                {
                    if (el.Value >= 0 && el.Value <= 4)
                    {
                        Importance.Add(el.Key, el.Value);
                    }
                    else
                    {
                        Console.WriteLine("ExpectedSchedule Error");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("ExpectedSchedule Error");
                    break;
                }
            }
        }

        public void WriteInConsole()
        {
            Console.WriteLine(Course + " " + Speciality);

            foreach (KeyValuePair<int, int> el in Importance)
            {
                switch(el.Key)
                {
                    case 1:
                        Console.WriteLine("пнд - " + el.Value.ToString() + " пары");
                        break;
                    case 2:
                        Console.WriteLine("вт - " + el.Value.ToString() + " пары");
                        break;
                    case 3:
                        Console.WriteLine("ср - " + el.Value.ToString() + " пары");
                        break;
                    case 4:
                        Console.WriteLine("чтв - " + el.Value.ToString() + " пары");
                        break;
                    case 5:
                        Console.WriteLine("птн - " + el.Value.ToString() + " пары");
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
            }
        }
    }
}
