using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        Dictionary<int, string> departments = new Dictionary<int, string>();
        Dictionary<int, string> skillRequired = new Dictionary<int, string>();
        Dictionary<int, string> skillSet = new Dictionary<int, string>();
        void LoadData()
        {
            //load department list
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [DepartmentID]
                                  ,[DepartmentName]
                                    FROM[Department]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string name = (string)reader.GetValue(1);
                        departments.Add(id, name);
                    }
                }
                comboDepartment.DisplayMember = "Value";
                comboDepartment.ValueMember = "Key";
                comboDepartment.DataSource = departments.ToList();
            }
            //load skill list
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [SkillID]
                                  ,[SkillName]
                              FROM [PRN292_SPRING_2017].[dbo].[Skill]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string name = (string)reader.GetValue(1);
                        skillRequired.Add(id, name);
                    }
                    listSkillsRequired.DisplayMember = "Value";
                    listSkillsRequired.ValueMember = "Key";
                    listSkillsRequired.DataSource = skillRequired.ToList();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (listSkillsRequired.SelectedValue != null)
            {
                int skillID = (int)listSkillsRequired.SelectedValue;
                string skillName = ((KeyValuePair<int, string>)listSkillsRequired.SelectedItem).Value;
                skillSet.Add(skillID, skillName);
                skillRequired.Remove(skillID);
                listSkillSet.DisplayMember = "Value";
                listSkillSet.ValueMember = "Key";
                listSkillsRequired.DataSource = skillRequired.ToList();
                listSkillSet.DataSource = skillSet.ToList();
            }
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if (listSkillSet.SelectedValue != null)
            {
                int skillID = (int)listSkillSet.SelectedValue;
                string skillName = ((KeyValuePair<int, string>)listSkillSet.SelectedItem).Value;
                skillRequired.Add(skillID, skillName);
                skillSet.Remove(skillID);
                listSkillsRequired.DataSource = skillRequired.ToList();
                listSkillSet.DataSource = skillSet.ToList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sID = txtID.Text;
            if (string.IsNullOrEmpty(sID) || sID.Trim().Length > 10)
            {
                MessageBox.Show("ID must be between 1 and 10 characters", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = txtName.Text;
            if (string.IsNullOrEmpty(name) || name.Trim().Length == 0)
            {
                MessageBox.Show("Name must not be blank", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool gender;
            if (rdFemale.Checked)
            {
                gender = false;
            }
            else if (rdMale.Checked)
            {
                gender = true;
            }
            else
            {
                MessageBox.Show("Gender must be selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //add new employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [dbo].[Employee]
                                       ([EmployeeID]
                                       ,[Name]
                                       ,[Gender]
                                       ,[DOB]
                                       ,[DepartmentID])
                                 VALUES
                                       (@EmployeeID
                                       ,@Name
                                       ,@Gender
                                       ,@DOB
                                       ,@DepartmentID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = sID;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@Gender", SqlDbType.Bit).Value = gender;
                    command.Parameters.Add("@DOB", SqlDbType.Date).Value = dateTimePicker1.Value;
                    command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = int.Parse(comboDepartment.SelectedValue.ToString());
                    command.ExecuteNonQuery();
                }
            }
            //add new skills for employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [dbo].[EmployeeSkill]
                                       ([SkillID]
                                       ,[EmployeeID])
                                 VALUES
                                       (@SkillID
                                       ,@EmployeeID)";
                for (int i = 0; i < listSkillSet.Items.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = sID;
                        command.Parameters.Add("@SkillID", SqlDbType.Int).Value = ((KeyValuePair<int, string>)listSkillSet.Items[i]).Key;
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Data updated");
        }
    }
}
