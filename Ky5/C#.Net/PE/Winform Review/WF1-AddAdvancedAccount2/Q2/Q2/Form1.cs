using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        Dictionary<int, string> select = new Dictionary<int, string>();
        Dictionary<int, string> selected = new Dictionary<int, string>();
        void LoadData()
        {
            //load employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [EmployeeID]
                                      ,[EmployeeName]
                                  FROM [Y17S3B1].[dbo].[Employees]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    employeeList.DisplayMember = "EmployeeName";
                    employeeList.ValueMember = "EmployeeID";
                    employeeList.DataSource = dt;
                }
            }
            //load group
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [GroupID]
                                      ,[GroupName]
                                  FROM [Y17S3B1].[dbo].[UserGroups]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string name = reader.GetValue(1) as string;
                        select.Add(id, name);
                    }
                    groupList.ValueMember = "Key";
                    groupList.DisplayMember = "Value";
                    groupList.DataSource = new BindingSource(select, null);
                }
            }
        }
        bool IsIDExisted(string userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT UserID
                                  FROM [Y17S3B1].[dbo].[Account] WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userID;
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
            string userID = txtUserID.Text;
            if (IsIDExisted(userID))
            {
                MessageBox.Show("User ID existed");
                return;
            }
            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("User ID cannot be empty");
                return;
            }
            string displayName = txtDisplayName.Text;
            if (String.IsNullOrEmpty(displayName))
            {
                MessageBox.Show("Display name cannot be empty");
                return;
            }
            int empID = int.Parse(employeeList.SelectedValue.ToString());
            //insert account
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO [dbo].[Account]
                                       ([UserID]
                                       ,[DisplayName]
                                       ,[JoinedDate]
                                       ,[Active]
                                       ,[EmployeeID])
                                 VALUES
                                       (@UserID
                                       ,@DisplayName
                                       ,@JoinedDate
                                       ,@Active
                                       ,@EmployeeID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userID;
                    command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = empID;
                    command.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = displayName;
                    command.Parameters.Add("@JoinedDate", SqlDbType.Date).Value = dateTimePicker1.Value;
                    command.Parameters.Add("@Active", SqlDbType.Bit).Value = cbYes.Checked;
                    command.ExecuteNonQuery();
                }
            }
            //insert user with group
            foreach (var item in selectedGroupList.Items)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO [dbo].[User_Group]
                                           ([GroupID]
                                           ,[UserID])
                                     VALUES
                                           (@GroupID
                                           ,@UserID)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userID;
                        command.Parameters.Add("@GroupID", SqlDbType.Int).Value = ((KeyValuePair<int, string>)item).Key;
                        command.ExecuteNonQuery();
                    }
                }

            }
            MessageBox.Show("data is saved", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (groupList.SelectedValue != null)
            {
                int selectedValue = (int)groupList.SelectedValue;
                //add to selected
                selected.Add(selectedValue, select[selectedValue]);
                //remove from select
                select.Remove(selectedValue);
                selectedGroupList.ValueMember = "Key";
                selectedGroupList.DisplayMember = "Value";
                selectedGroupList.DataSource = new BindingSource(selected, null);
                if (select.Count > 0)
                {
                    groupList.DataSource = new BindingSource(select, null);
                }

            }

        }
    }
}
