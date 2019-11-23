using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Q2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadEmployee();
            }
            LoadSkill();
        }
        void LoadEmployee()
        {
            //load employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "Select * from Employee";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    listEmployee.DataTextField = "Name";
                    listEmployee.DataValueField = "EmployeeID";
                    listEmployee.DataSource = dt;
                    listEmployee.DataBind();
                }
            }

        }
        void LoadSkill()
        {
            //load skill
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT s.[SkillID] as ID
                                      , SkillName as Name
                                  FROM[EmployeeSkill] es, Skill s
                                  WHERE es.SkillID = s.SkillID
                                  AND EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string empID = listEmployee.SelectedValue.ToString();
                    command.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = empID;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvSkill.DataSource = dt;
                    gvSkill.DataBind();
                }
            }
        }
    }
}