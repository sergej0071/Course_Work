using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class TestGroup
    {
        public int Course { set; get; }
        public int Departmant { set; get; } 
        public int Speciality { set; get; }
        public int NumberName { set; get; }
        public int Population { set; get; }

        public TestGroup()
        {
            this.Course = 0;
            this.Departmant = 0;
            this.Speciality = 0;
            this.NumberName = 0;
            this.Population = 0;
        }

        public TestGroup(int Course, int Departmant, int Speciality, int NumberName, int Population)
        {
            this.Course = Course;
            this.Departmant = Departmant;
            this.Speciality = Speciality;
            this.NumberName = NumberName;
            this.Population = Population;
        }
    }
}
