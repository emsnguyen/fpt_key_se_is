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
        void LoadData()
        {
            //load department
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [DepartmentID]
                                  ,[DepartmentName]
                                    FROM[Department]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboDepartment.DisplayMember = "DepartmentName";
                    comboDepartment.ValueMember = "DepartmentID";
                    comboDepartment.DataSource = dt;
                }
            }
            //load certification
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [CertificateID]
                                      ,[CertificateName]
                                  FROM [PRN292_SPRING_2017].[dbo].[Certificate]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string name = (string)reader.GetValue(1);
                        DataGridViewRow row = (DataGridViewRow)gvCertificate.Rows[0].Clone();
                        row.Cells[0].Value = id;
                        row.Cells[1].Value = name;
                        row.Cells[2].Value = false;
                        gvCertificate.Rows.Add(row);
                    }
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool IsIDExisted(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT *
                                  FROM Employee 
                        WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = id;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (String.IsNullOrEmpty(id) || id.Trim().Length == 0 || id.Trim().Length > 10)
            {
                MessageBox.Show("Id must contain 1 to 10 characters",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check that ID does not exist
            if (IsIDExisted(id))
            {
                MessageBox.Show("Id existed",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = txtName.Text;
            if (String.IsNullOrEmpty(name) || name.Trim().Length == 0)
            {
                MessageBox.Show("Name must not be blank",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Must choose a gender",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //insert new employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [Employee]
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
                    command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = id;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@Gender", SqlDbType.Bit).Value = gender;
                    command.Parameters.Add("@DOB", SqlDbType.Date).Value = dateTimePicker1.Value;
                    command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = int.Parse(comboDepartment.SelectedValue.ToString());
                    command.ExecuteNonQuery();
                }
            }

            //insert employee with certificates
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [dbo].[EmployeeCertificate]
                                       ([CertificateID]
                                       ,[EmployeeID])
                                 VALUES
                                       (@CertificateID
                                       ,@EmployeeID)";
                for (int i = 0; i < gvCertificate.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell row = gvCertificate.Rows[i].Cells[2] as DataGridViewCheckBoxCell;
                    bool hasIt = Convert.ToBoolean(row.Value);
                    if (hasIt)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = id;
                            command.Parameters.Add("@CertificateID", SqlDbType.Int).Value = (int)gvCertificate.Rows[i].Cells[0].Value;
                            command.ExecuteNonQuery();
                        }
                    }

                }
            }
            MessageBox.Show("Data is saved",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
