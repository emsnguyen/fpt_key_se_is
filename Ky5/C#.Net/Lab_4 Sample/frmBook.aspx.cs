using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Chapter23
{
    public partial class frmBook : System.Web.UI.Page
    {
        string connStr = "Server= HaPN\\HAPN_SERVER; database = Lab_3; integrated security = true;";
        string selectedBook = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = null;
            GetSelectedRecord();
            if (Request.QueryString["ID"] != null)
            {
                id = Request.QueryString["ID"].ToString();
                load_detaildata(id);
            }
            else
            { 
                load_data();
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddNoew_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("insert into tbl_Book values('"
               + txtTitle.Text + "','" + txtAuthor.Text + "', '"
                + txtPublisher.Text + "', '" + txtNumber.Text + "')", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            load_data();
        }
        private void load_data()

        {
            SqlConnection con = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_book", con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            gridBookList.DataSource = tb;
            gridBookList.DataBind();

            SqlDataAdapter da_2 = new SqlDataAdapter("select * from tbl_copy", con);
            DataTable tb_2 = new DataTable();
            da_2.Fill(tb_2);
            gridCopyBookList.DataSource = tb_2;
            gridCopyBookList.DataBind();
            // display datagrid empty
            // normally executes at all postbacks
            if (gridCopyBookList.Rows.Count == 1 &&
                gridCopyBookList.DataSource == null)
            {
                bool bIsGridEmpty = true;

                // check first row that all cells empty
                for (int i = 0; i < gridCopyBookList.Rows[0].Cells.Count; i++)
                {
                    if (gridCopyBookList.Rows[0].Cells[i].Text != string.Empty)
                    {
                        bIsGridEmpty = false;
                    }
                }
                // hide row
                if (bIsGridEmpty)
                {
                    gridCopyBookList.Rows[0].Visible = false;
                    gridCopyBookList.Rows[0].Controls.Clear();
                }
            }
        }

        private void load_detaildata(string ID)

        {
            // Bin data in textbox
            String query = "select * from tbl_book where bookcode = " + int.Parse(ID);
            SqlConnection con = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            gridBookList.DataSource = tb;
            gridBookList.DataBind();


            // Response.Redirect("http://bcdonline.net");
        }

        protected void gridBookList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gridBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string bookcode = e.Values[0].ToString();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM tbl_Book WHERE BookCode = @BookCode"))
                {
                    command.Parameters.AddWithValue("@BookCode", int.Parse(bookcode));
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            load_data();
        }
        protected void gridCopyBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string copycode = e.Values[0].ToString();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM tbl_Copy WHERE CopyCode = @CopyCode"))
                {
                    command.Parameters.AddWithValue("@BookCode", int.Parse(copycode));
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            load_data();
        }
        
        protected void gridBookList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridBookList.Rows[e.RowIndex];
            int customerId = Convert.ToInt32(gridBookList.DataKeys[e.RowIndex].Values[0]);

            string bookcode = gridBookList.Rows[e.RowIndex].Cells[0].Text;
            string title = (gridBookList.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text;
            string author = (gridBookList.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text;
            string publisher = (gridBookList.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox).Text;
            string booknumber = (gridBookList.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox).Text;

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("update tbl_Book set title='" + title
                + "', author='" + author + "', publisher ='" + publisher
                + "', bookNumber='" + int.Parse(booknumber) + "' where bookCode='" + bookcode + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            gridBookList.EditIndex = -1;
            load_data();
        }

        protected void gridBookList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridBookList.EditIndex = e.NewEditIndex;
            load_data();
        }

        protected void gridBookList_RowCancelingEdit(object sender, EventArgs e)
        {
            gridBookList.EditIndex = -1;
            this.load_data();
        }

       
        protected void btnAddCopy_Click(object sender, EventArgs e)
        {
            txtCopyBookCode.Text = selectedBook;
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("insert into tbl_Copy values('"
               + int.Parse(selectedBook) + "','" + int.Parse(txtCopyNumber.Text) + "','" + int.Parse(txtSequenceNumber.Text) + "', '"
                + txtType.Text + "', '" + int.Parse(txtPrice.Text) + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            load_data();
        }

        private void GetSelectedRecord()

        {

            for (int i = 0; i < gridBookList.Rows.Count; i++)

            {

                RadioButton rb = (RadioButton)gridBookList.Rows[i].Cells[0].FindControl("RadioButton1");

                if (rb != null)

                {

                    if (rb.Checked)

                    {
                        HiddenField hf = (HiddenField)gridBookList.Rows[i].Cells[0].FindControl("HiddenField1");

                        if (hf != null)

                        {

                            ViewState["SelectedContact"] = hf.Value;
                            selectedBook = hf.Value;

                        }

                        

                        break;

                    }

                }

            }

        }
    }
}