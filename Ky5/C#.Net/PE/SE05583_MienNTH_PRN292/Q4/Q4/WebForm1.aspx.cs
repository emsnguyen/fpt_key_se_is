using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Q4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                projectList.SelectedIndex = 0;
            }
            if (projectList.SelectedValue == null || string.IsNullOrEmpty(projectList.SelectedValue))
            {
                return;
            }
            //load projects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT e.name Employee
                                  ,[position] Position
                                  ,[isFulltime]
                                  ,[date] Date
                              FROM [ProjectMember] pm, Employee e
                              WHERE pm.employeeID = e.id
                              AND pm.projectID = @pID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@pID", SqlDbType.Int).Value = int.Parse(projectList.SelectedValue);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvEmployee.DataSource = dt;
                    gvEmployee.DataBind();
                }
            }
        }
    }
}