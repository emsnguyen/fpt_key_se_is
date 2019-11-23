using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration; //for reading connectionStrings
using System.Data.SqlClient; //connection, Command, DataReader,...

namespace ADOSample
{
    public partial class Form1 : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["EployeeDBConnectionStrings"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            //open DB Connection -> do transaction -> close DB Connection
            SqlConnection conn = null;
            try
            {
                string query = @"SELECT * FROM Project;select * from Employee";
                conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.ExecuteNonQuery(); ->update, delete, insert, drop
                SqlDataReader reader = cmd.ExecuteReader(); //select only 
                int i = 0;
                listView1.Items.Clear(); //clean all items
                do
                {
                    while (reader.Read()) 
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        listView1.Items.Add("" + id); //traverse through the rows, add to the first column
                        listView1.Items[i].SubItems.Add(name); //access the row, add to the second column
                        ++i;
                    }
                } while (reader.NextResult()); // read the next table 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Project", conn);
            int c = (int)cmd.ExecuteScalar();
            conn.Close();
            MessageBox.Show("# project(s): " + c);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string query = "insert into Project values (@arg1, @arg2)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@arg1", tbProjectID.Text);
            SqlParameter param = new SqlParameter("@arg2", SqlDbType.VarChar, 150);
            param.Value = tbProjectName.Text;
            cmd.Parameters.Add(param);
            if (cmd.ExecuteNonQuery() != 0) {
                MessageBox.Show("New project added");
            }
            conn.Close();
            buttonFill_Click(null, null); //reload projects
        }
    }
}
