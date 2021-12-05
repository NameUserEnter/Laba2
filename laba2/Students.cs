using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace laba2
{
    public partial class Students : Form
    {
        string path = "E:\\laba2\\laba2\\StudentSuccess.xml";
        public Student student = null;
        public Students()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            resBox.Clear();
            student = new Student();
            IStrategy chosenStrategy;
            if (stNameBox.Checked)
            {
                student.Name = nameComboBox.Text;
            }
            if (facultyBox.Checked)
            {
                student.Faculty = facultyComboBox.Text;
            }
            if (departmentBox.Checked)
            {
                student.Department = departmentComboBox.Text;
            }
            if (academicDisciplinesBox.Checked)
            {
                student.AcademicDisciplines = academicDisciplinesComboBox.Text;
            }
            if (studentPerformanceBox.Checked)
            {
                student.StudentPerformance = studentPerformanceComboBox.Text;
            }
            if (domBtn.Checked)
            {
                chosenStrategy = new DOM();
                List<Student> resList = chosenStrategy.Search(student, path);
                ShowResults(resList);
            }
            if (saxBtn.Checked)
            {
                chosenStrategy = new SAX();
                List<Student> resList = chosenStrategy.Search(student, path);
                ShowResults(resList);
            }
            if (linqToXmlBtn.Checked)
            {
                chosenStrategy = new LINQtoXML();
                List<Student> resList = chosenStrategy.Search(student, path);
                ShowResults(resList);
            }

        }

        public void ShowResults(List<Student> stList)
        {
            for (int i = 0; i < stList.Count; i++)
            {
                resBox.AppendText(i + 1 + ".\n");
                resBox.AppendText("Name: " + stList[i].Name + "\n");
                resBox.AppendText("Faculty: " + stList[i].Faculty + "\n");
                resBox.AppendText("AcademicDisciplines: " + stList[i].AcademicDisciplines + "\n");
                resBox.AppendText("Department: " + stList[i].Department + "\n");
                resBox.AppendText("StudentPerformance: " + stList[i].StudentPerformance + "\n");
                resBox.AppendText("------------------------------------------\n");
            }
        }

        private void FillAll(object sender, EventArgs e)
        {
            XmlDocument currentDoc = new XmlDocument();
            currentDoc.Load(path);
            XmlElement node = currentDoc.DocumentElement;
            XmlNodeList childNodes = node.SelectNodes("StudentSuccess");

            foreach (XmlNode childNode in childNodes)
            {
                if (!nameComboBox.Items.Contains(childNode.SelectSingleNode("@Name").Value))
                {
                    nameComboBox.Items.Add(childNode.SelectSingleNode("@Name").Value);
                }
                if (!facultyComboBox.Items.Contains(childNode.SelectSingleNode("@Faculty").Value))
                {
                    facultyComboBox.Items.Add(childNode.SelectSingleNode("@Faculty").Value);
                }
                if (!departmentComboBox.Items.Contains(childNode.SelectSingleNode("@Department").Value))
                {
                    departmentComboBox.Items.Add(childNode.SelectSingleNode("@Department").Value);
                }
                if (!academicDisciplinesComboBox.Items.Contains(childNode.SelectSingleNode("@AcademicDisciplines").Value))
                {
                    academicDisciplinesComboBox.Items.Add(childNode.SelectSingleNode("@AcademicDisciplines").Value);
                }
                if (!studentPerformanceComboBox.Items.Contains(childNode.SelectSingleNode("@StudentPerformance").Value))
                {
                    studentPerformanceComboBox.Items.Add(childNode.SelectSingleNode("@StudentPerformance").Value);
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            resBox.Clear();
            stNameBox.Checked = false;
            nameComboBox.Text = null;

            facultyBox.Checked = false;
            facultyComboBox.Text = null;

            departmentBox.Checked = false;
            departmentComboBox.Text = null;

            academicDisciplinesBox.Checked = false;
            studentPerformanceComboBox.Text = null;

            studentPerformanceBox.Checked = false;
            academicDisciplinesComboBox.Text = null;

            domBtn.Checked = false;
            saxBtn.Checked = false;
            linqToXmlBtn.Checked = false;
        }

        private void TransformBtn_Click(object sender, EventArgs e)
        {
            Transform();
        }

        private void Transform()
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load("E:\\laba2\\laba2\\StudentSuccess.xsl");
            string fXml = "E:/laba2/laba2/StudentSuccess.xml";
            string fHtml = "E:/laba2/laba2/bin/Debug/StudentSuccess.html";
            xct.Transform(fXml, fHtml);
            MessageBox.Show("Done!");
        }
    }
}

