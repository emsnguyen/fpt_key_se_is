using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Q3_A : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ShipConnectionString"].ConnectionString;
        string selectedShip = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadShipNameList();
            GridView1.Visible = false;
        }
        void LoadShipNameList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select ship from Outcomes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = (string)reader.GetValue(0);
                        listShipName.Items.Add(name);
                    }
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!cbSelectShip.Checked)
            {
                OutcomeDataSource.SelectCommand = "select * from Outcomes";
                lblNoOfRows.Text = CountBattles().ToString();
                GridView1.DataBind();
            }
            else
            {
                //a ship is selected
                OutcomeDataSource.SelectCommand = $"select * from Outcomes where ship = '{selectedShip}'";
                lblNoOfRows.Text = CountBattles(selectedShip).ToString();
                GridView1.DataBind();
            }
            GridView1.Visible = true;
        }
        int CountBattles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"select count(*) from Outcomes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object reader = command.ExecuteScalar();
                    return (int)reader;
                }
            }
        }
        int CountBattles(string ship)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"select count(*) from Outcomes where ship = '{selectedShip}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object reader = command.ExecuteScalar();
                    return (int)reader;
                }
            }
        }
        protected void listShipName_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShip = listShipName.SelectedItem.ToString();
        }
    }
}