using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Q3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"select * from DummyMaster";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    masterList.DataTextField = "master_name";
                    masterList.DataValueField = "master_id";
                    masterList.DataSource = reader;
                    masterList.DataBind();
                }
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [detail_id] as ID
                                          ,[detail_name] as Name
                                          ,[master_name] as Master
                                      FROM [DummyDetail] dd, DummyMaster dm
                                      where dd.master_id = dm.master_id
                                      AND dd.master_id = @master_id
                                      And detail_name like @detail_name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@master_id", SqlDbType.Int).Value = masterList.SelectedValue;
                    command.Parameters.Add("@detail_name", SqlDbType.VarChar).Value = "%" + txtName.Text + "%";
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
}