using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNETCONTROL
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }

            TextBox1.Text = "123";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "ABC";
        }

        private void loadData()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { ID = 1, Name = "A" });
            students.Add(new Student() { ID = 2, Name = "B" });
            students.Add(new Student() { ID = 3, Name = "C" });
            cbxStudents.DataSource = students;
            cbxStudents.DataTextField = "Name";
            cbxStudents.DataValueField = "ID";
            cbxStudents.DataBind();
        }

        protected void cbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cbxStudents.SelectedValue;
            TextBox1.Text = value;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx?param=1");
        }
    }



    public class Student
    {
        public int ID { get; set; }
        public String Name { get; set; }
    }
}