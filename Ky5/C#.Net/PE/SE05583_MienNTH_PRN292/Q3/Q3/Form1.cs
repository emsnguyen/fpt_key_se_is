using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            //load employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [id]
                                      ,[name]
                                  FROM [Employee]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    listEmployee.DisplayMember = "name";
                    listEmployee.ValueMember = "id";
                    listEmployee.DataSource = dt;
                }
            }
            //load project
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [id]
                                      ,[name]
                                  FROM [Project]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    listProject.DisplayMember = "name";
                    listProject.ValueMember = "id";
                    listProject.DataSource = dt;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listEmployee.SelectedValue == null || listProject.SelectedValue == null)
            {
                return;
            }
            string position = txtPosition.Text;
            if (String.IsNullOrEmpty(position) || position.Trim().Length == 0)
            {
                MessageBox.Show("Position cannot be blank",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int pID = (int)listProject.SelectedValue;
            int empID = (int)listEmployee.SelectedValue;
            if (IsIDExisted(pID, empID))
            {
                MessageBox.Show("This employee has been added to the project.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [dbo].[ProjectMember]
                                   ([employeeID]
                                   ,[projectID]
                                   ,[position]
                                   ,[isFulltime]
                                   ,[date])
                             VALUES
                                   (@employeeID
                                   ,@projectID
                                   ,@position
                                   ,@isFulltime
                                   ,@date)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@employeeID", SqlDbType.Int).Value = empID;
                    command.Parameters.Add("@projectID", SqlDbType.Int).Value = pID;
                    command.Parameters.Add("@position", SqlDbType.VarChar).Value = position;
                    command.Parameters.Add("@isFullTime", SqlDbType.Bit).Value = cbFullTime.Checked;
                    command.Parameters.Add("@date", SqlDbType.Date).Value = dateTimePicker1.Value;
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Data is saved",
                    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //check if employee has been assigned to the project
        bool IsIDExisted(int pID, int empID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT *
                        FROM [ProjectMember] 
                        where employeeID = @empID AND projectID = @pID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@empID", SqlDbType.Int).Value = empID;
                    command.Parameters.Add("@pID", SqlDbType.Int).Value = pID;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
