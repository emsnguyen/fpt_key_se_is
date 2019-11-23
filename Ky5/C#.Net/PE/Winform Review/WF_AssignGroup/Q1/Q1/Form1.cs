using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            //load employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT  [UserID]
                                      ,[DisplayName]
                                  FROM [Account]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    listAccount.DisplayMember = "DisplayName";
                    listAccount.ValueMember = "UserID";
                    listAccount.DataSource = dt;
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
                    listGroups.DisplayMember = "GroupName";
                    listGroups.ValueMember = "GroupID";
                    listGroups.DataSource = dt;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userID = "";
            if (listAccount.SelectedValue != null)
            {
                userID = listAccount.SelectedValue.ToString();
                if (listGroups.SelectedIndices != null)
                {
                    var lst = listGroups.SelectedItems.Cast<DataRowView>();
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
                                command.Parameters.Add("@GroupID", SqlDbType.Int).Value = int.Parse(item.Row[0].ToString());
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("data is saved", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }

}
