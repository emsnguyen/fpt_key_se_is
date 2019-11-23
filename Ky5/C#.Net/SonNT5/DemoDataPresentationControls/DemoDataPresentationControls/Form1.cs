using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoDataPresentationControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
            // this.cbxStudents.SelectedIndexChanged += new System.EventHandler(this.cbxStudents_SelectedIndexChanged);
           
        }

        private void loadData()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { ID = 1, Name = "A",isGender=true });
            students.Add(new Student() { ID = 2, Name = "B", isGender = false });
            students.Add(new Student() { ID = 3, Name = "C", isGender = true });

            cbxStudents.DisplayMember = "Name";
            cbxStudents.DataSource = students;
            lstStudents.DisplayMember = "Name";
            lstStudents.DataSource = students;

            grdStudents.AutoGenerateColumns = false;
            grdStudents.DataSource = students;
            
        }

        private void cbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student s = (Student)cbxStudents.SelectedItem;
            MessageBox.Show("Name:" + s.Name + ", ID:" + s.ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lstStudents.SelectedIndex != -1 )
              foreach(Student s in lstStudents.SelectedItems)
                {
                    MessageBox.Show(s.Name);
                }


        }
    }

    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isGender { get; set; }
    }

}
