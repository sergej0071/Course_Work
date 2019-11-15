using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Lesson
    {
        public string SubjectName { set; get; }
        public double Hours { set; get; }
        public Professor professor { set; get; }
        public Auditorium auditorium { set; get; }

        public Lesson()
        {
            SubjectName = "";
            Hours = 0;
            professor = new Professor();
            auditorium = new Auditorium();
        }

        public Lesson(string Subject_Name, double Hours_, Professor professor_, Auditorium auditorium_)
        {
            SubjectName = Subject_Name;
            Hours = Hours_;
            professor = professor_;
            auditorium = auditorium_;
        }

        public Lesson(Lesson lesson)
        {
            SubjectName = lesson.SubjectName;
            Hours = lesson.Hours;
            professor = lesson.professor;
            auditorium = lesson.auditorium;
        }

        public void WriteLessonInConsole()
        {
            Console.WriteLine(SubjectName.ToString() + " " + Hours.ToString() + " " + professor.FIO.ToString() + " " + auditorium.NumOfAuditorium.ToString() + "\n");
        }
    }

    class LessonForGroup : Lesson
    {
        public Group group { set; get; }

        public LessonForGroup() : base()
        {
            group = new Group();
        }

        public LessonForGroup(string Subject_Name, Group group_, double Hours_, Professor professor_, Auditorium auditorium_)
               : base(Subject_Name, Hours_, professor_, auditorium_)
        {
            group = group_;
        }

        public void WriteInConsole()
        {
            Console.WriteLine(group.NumberName.ToString());
            WriteLessonInConsole();
        }
    }

    class LessonForOneFlow : Lesson
    {
        public Flows flow { set; get; }

        public LessonForOneFlow(string Subject_Name, Flows flow_, double Hours_, Professor professor_, Auditorium auditorium_) : base(Subject_Name, Hours_, professor_, auditorium_)
        {
            flow = flow_;
        }

        public LessonForOneFlow(Lesson lesson, Flows flow)
               : base(lesson)
        {
            this.flow = flow;
        }

        public void WriteInConsole()
        {
            Console.WriteLine(flow.Course.ToString() + " " + flow.Speciality.ToString());
            WriteLessonInConsole();
        }
    }

    class LessonForFlows : Lesson
    {
        public Flows flow1 { set; get; }
        public Flows flow2 { set; get; }

        public LessonForFlows(string Subject_Name, Flows flow1_, Flows flow2_, double Hours_, Professor professor_, Auditorium auditorium_)
               : base(Subject_Name, Hours_, professor_, auditorium_)
        {
            flow1 = flow1_;
            flow2 = flow2_;
        }

        public LessonForFlows(Lesson lesson, Flows flow1, Flows flow2)
               : base(lesson)
        {
            this.flow1 = flow1;
            this.flow2 = flow2;
        }

        public void WriteInConsole()
        {
            Console.WriteLine(flow1.Course.ToString() + " " + flow1.Speciality.ToString() + " " + flow2.Speciality.ToString());
            WriteLessonInConsole();
        }
    }
}
