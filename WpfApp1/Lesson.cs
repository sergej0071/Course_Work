//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Schedule
//{
//    class Lesson
//    {
//        public string SubjectName { set; get; }
//        public double Hours { set; get; }
//        public Professor professor { set; get; }
//        public Auditorium auditorium { set; get; }

//        public Lesson()
//        {
//            this.SubjectName = "";
//            this.Hours = 0;
//            this.professor = new Professor();
//            this.auditorium = new Auditorium();
//        }

//        public Lesson(string SubjectName, double Hours, Professor professor, Auditorium auditorium)
//        {
//            this.SubjectName = SubjectName;
//            this.Hours = Hours;
//            this.professor = professor;
//            this.auditorium = auditorium;
//        }
//    }
//}