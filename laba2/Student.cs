using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public class Student
    {
        public string Name { get; set; } = String.Empty;
        public string Faculty { get; set; } = String.Empty;
        public string Department { get; set; } = String.Empty;
        public string AcademicDisciplines { get; set; } = String.Empty;
        public string StudentPerformance { get; set; } = String.Empty;

        public bool Compare(Student temp)
        {
            if (this.Name == temp.Name && this.Faculty == temp.Faculty && this.Department == temp.Department &&
                this.AcademicDisciplines == temp.AcademicDisciplines && this.StudentPerformance == temp.StudentPerformance )
            {
                return true;
            }
            return false;
        }
    }
}
