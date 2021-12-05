using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace laba2
{
    public class LINQtoXML : IStrategy
    {
        private List<Student> resList = null;
        XDocument currentDoc = new XDocument();
        public List<Student> Search(Student student, string path)
        {
            currentDoc = XDocument.Load(@path);
            resList = new List<Student>();
            List <XElement> matches = (from value in currentDoc.Descendants("StudentSuccess")
                                      where ((student.Name == String.Empty || student.Name == value.Attribute("Name").Value) &&
                                      (student.Faculty == String.Empty || student.Faculty == value.Attribute("Faculty").Value) &&
                                      (student.Department == String.Empty || student.Department == value.Attribute("Department").Value) &&
                                      (student.AcademicDisciplines == String.Empty || student.AcademicDisciplines == value.Attribute("AcademicDisciplines").Value) &&
                                      (student.StudentPerformance == String.Empty || student.StudentPerformance == value.Attribute("StudentPerformance").Value))
                                      select value).ToList();
            foreach (XElement match in matches)
            {
                Student stud = new Student();
                stud.Name = match.Attribute("Name").Value;
                stud.Faculty = match.Attribute("Faculty").Value;
                stud.AcademicDisciplines = match.Attribute("AcademicDisciplines").Value;
                stud.Department = match.Attribute("Department").Value;
                stud.StudentPerformance = match.Attribute("StudentPerformance").Value;
                resList.Add(stud);
            }
            return resList;
        }
    }
}
