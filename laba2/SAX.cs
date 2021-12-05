using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace laba2
{
    public class SAX : IStrategy
    {
        private List<Student> lastRes = null;
        public List<Student> Search(Student student, string path)
        {
            List<Student> resList = new List<Student>();
            XmlReader reader = XmlReader.Create(path);

            Student found = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "StudentSuccess")
                        {
                            found = new Student();
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "Name")
                                {
                                    found.Name = reader.Value;
                                }
                                if (reader.Name == "Faculty")
                                {
                                    found.Faculty = reader.Value;
                                }
                                if (reader.Name == "AcademicDisciplines")
                                {
                                    found.AcademicDisciplines = reader.Value;
                                }
                                if (reader.Name == "Department")
                                {
                                    found.Department = reader.Value;
                                }
                                if (reader.Name == "StudentPerformance")
                                {
                                    found.StudentPerformance = reader.Value;
                                }
                            }
                            resList.Add(found);
                        }
                        break;
                }
            }
            lastRes = Filter(resList, student);
            return lastRes;
        }

        private List<Student> Filter(List<Student> resList, Student temp)
        {
            List<Student> newRes = new List<Student>();
            if (resList != null)
            {
                foreach (Student stud in resList)
                {
                    if ((temp.Name == stud.Name || temp.Name == String.Empty) &&
                       (temp.Faculty == stud.Faculty || temp.Faculty == String.Empty) &&
                       (temp.AcademicDisciplines == stud.AcademicDisciplines || temp.AcademicDisciplines == String.Empty) &&
                       (temp.Department == stud.Department || temp.Department == String.Empty) &&
                       (temp.StudentPerformance == stud.StudentPerformance || temp.StudentPerformance == String.Empty))
                    {
                        newRes.Add(stud);
                    }
                }
            }
            return newRes;
        }
    }
}

