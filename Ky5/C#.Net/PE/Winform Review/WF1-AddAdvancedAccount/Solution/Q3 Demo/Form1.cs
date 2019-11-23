using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Q3_Demo
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
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    groupList.DisplayMember = "GroupName";
                    groupList.ValueMember = "GroupID";
                    groupList.DataSource = dt;
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
            var lst = groupList.SelectedItems.Cast<DataRowView>();
            foreach (var item in lst)
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
                        command.Parameters.Add("@GroupID", SqlDbType.Int).Value = item.Row[0].ToString();
                        command.ExecuteNonQuery();
                    }
                }

            }
            MessageBox.Show("data is saved", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void employeeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbYes_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
