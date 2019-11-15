using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Data;

namespace Schedule
{
    class Program
    {
        public static int NumOfCourses = 5;

        //static void Main(string[] args)
        //{
        //    Console.OutputEncoding = Encoding.Unicode; // для отображения украинских букв в консоле            

        //    List<Flows> flows = new List<Flows>(); // 4 потока

        //    flows.Add(new Flows(121, 1));
        //    flows.Add(new Flows(122, 1));
        //    flows.Add(new Flows(121, 2));
        //    flows.Add(new Flows(122, 2));

        //    foreach (Flows f in flows)
        //    {
        //        f.WriteUsedParam();
        //    }

        //    List<Auditorium> audit;
        //    Auditorium.SetAllAuditorium(out audit);
        //    foreach (Auditorium a in audit)
        //    {
        //        a.WtiteInConsole();
        //    }

        //    List<Professor> prof;
        //    Professor.SetAllProfessors(out prof);
        //    foreach (Professor p in prof)
        //    {
        //        p.WtiteInConsole();
        //    }

        //    MainAlgorithm.MakeSchedule(flows, audit, prof);
        //}
    }
}
