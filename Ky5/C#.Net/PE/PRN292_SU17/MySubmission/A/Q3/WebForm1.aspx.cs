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
                string query = @"SELECT [master_id]
                                  ,[master_name]
                              FROM [DummyMaster]";
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
                string query = @"SELECT [detail_id]
                                      ,[detail_name]
                                      ,master_name
                                  FROM [DummyDetail] dd, DummyMaster dm
                                  WHERE dd.master_id = dm.master_id
                                  AND detail_name like @detailName
                                  AND dd.master_id = @masterID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@detailName", SqlDbType.VarChar).Value = "%" + txtName.Text + "%";
                    command.Parameters.Add("@masterID", SqlDbType.Int).Value = masterList.SelectedValue;
                    Debug.WriteLine("id:" + masterList.SelectedValue);
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