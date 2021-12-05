using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace laba2
{
    public class DOM : IStrategy
    {
        public List<Student> Search(Student student, string path)
        {
            XmlDocument currentDoc = new XmlDocument();
            currentDoc.Load(path);
            List<List<Student>> resList = new List<List<Student>>();
            if (student.Name == String.Empty && student.Faculty == String.Empty && student.AcademicDisciplines == String.Empty
                && student.Department == String.Empty && student.StudentPerformance == String.Empty )
            {
                return CatchError(currentDoc);
            }

            if (student.Name != String.Empty) resList.Add(SearchByAttribute("StudentSuccess", "Name", student.Name, currentDoc));
            if (student.Faculty != String.Empty) resList.Add(SearchByAttribute("StudentSuccess", "Faculty", student.Faculty, currentDoc));
            if (student.AcademicDisciplines != String.Empty) resList.Add(SearchByAttribute("StudentSuccess", "AcademicDisciplines", student.AcademicDisciplines, currentDoc));
            if (student.Department != String.Empty) resList.Add(SearchByAttribute("StudentSuccess", "Department", student.Department, currentDoc));
            if (student.StudentPerformance != String.Empty) resList.Add(SearchByAttribute("StudentSuccess", "StudentPerformance", student.StudentPerformance, currentDoc));  

            return FindCrossings(resList, student);
        }

        public List<Student> SearchByAttribute(string nodeName, string attribute, string template, XmlDocument doc)
        {
            List<Student> resList = new List<Student>();

            if (template != String.Empty)
            {
                XmlNodeList list = doc.SelectNodes("//" + nodeName + "[@" + attribute + "=\"" + template + "\"]");
                foreach (XmlNode node in list)
                {
                    resList.Add(GetInfo(node));
                }
            }
            return resList;
        }

        public List<Student> CatchError(XmlDocument doc)
        {
            List<Student> result = new List<Student>();
            XmlNodeList list = doc.SelectNodes("//" + "StudentSuccess");
            foreach (XmlNode node in list)
            {
                result.Add(GetInfo(node));
            }
            return result;
        }

        public Student GetInfo(XmlNode node)
        {
            Student st = new Student();
            st.Name = node.Attributes.GetNamedItem("Name").Value;
            st.Faculty = node.Attributes.GetNamedItem("Faculty").Value;
            st.AcademicDisciplines = node.Attributes.GetNamedItem("AcademicDisciplines").Value;
            st.Department = node.Attributes.GetNamedItem("Department").Value;
            st.StudentPerformance = node.Attributes.GetNamedItem("StudentPerformance").Value;

            return st;
        }

        public List<Student> FindCrossings(List<List<Student>> studs, Student obj)
        {
            List<Student> resList = new List<Student>();
            List<Student> cleared = CheckNodes(studs, obj);
            foreach (Student temp in cleared)
            {
                bool isIn = false;
                foreach (Student st in resList)
                {
                    if (st.Compare(temp))
                    {
                        isIn = true;
                    }
                }
                if (!isIn)
                {
                    resList.Add(temp);
                }

            }
            return resList;
        }

        public List<Student> CheckNodes(List<List<Student>> studs, Student obj)
        {
            List<Student> newRes = new List<Student>();
            foreach (List<Student> List in studs)
            {
                foreach (Student stud in List)
                {
                    if ((obj.Name == stud.Name || obj.Name == String.Empty) &&
                        (obj.Faculty == stud.Faculty || obj.Faculty == String.Empty) &&
                        (obj.AcademicDisciplines == stud.AcademicDisciplines || obj.AcademicDisciplines == String.Empty) &&
                        (obj.Department == stud.Department || obj.Department == String.Empty) &&
                        (obj.StudentPerformance == stud.StudentPerformance || obj.StudentPerformance == String.Empty))
                    {
                        newRes.Add(stud);
                    }
                }
            }
            return newRes;
        }
    }
}
