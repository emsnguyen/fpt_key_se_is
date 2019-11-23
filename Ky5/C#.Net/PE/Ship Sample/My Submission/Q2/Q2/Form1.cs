using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComboBox();
        }
        string connectionString = "Data Source=localhost;Initial Catalog=Ship;Integrated Security=True";
        void LoadComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select class from Classes order by class asc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string className = (string)reader.GetValue(0);
                        comboClass.Items.Add(className);
                    }
                }
                comboClass.SelectedIndex = 0;
            }

        }
        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //get ship info
            string name = txtName.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GetShipInfo(name);

            btnSave.Enabled = true;
            btnSearch.Enabled = false;
        }

        private void GetShipInfo(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select name, class, launched from Ships where name = @name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string className = (string)reader.GetValue(1);
                        int launched = (int)reader.GetValue(2);
                        comboClass.SelectedItem = className;
                        txtLaunched.Text = launched.ToString();
                    }
                    else
                    {
                        MessageBox.Show("This ship does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateShip();
            MessageBox.Show("This ship is saved!", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void UpdateShip()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "update Ships set " +
                    "class = @class, launched = @launched where name = @name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = txtName.Text;
                    command.Parameters.AddWithValue("@launched", SqlDbType.Int).Value = int.Parse(txtLaunched.Text);
                    command.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = comboClass.SelectedItem.ToString();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

