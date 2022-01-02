using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class profileExaminer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = Int16.Parse(Session["userID"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand supTable = new SqlCommand("viewExaminerDefenses", conn);
            supTable.CommandType = System.Data.CommandType.StoredProcedure;
            supTable.Parameters.Add(new SqlParameter("@id", userID));


            SqlCommand examinerProfile = new SqlCommand("viewExaminerProfile", conn);
            examinerProfile.CommandType = CommandType.StoredProcedure;
            examinerProfile.Parameters.Add(new SqlParameter("@id", userID));

            conn.Open();
            SqlDataReader reader = supTable.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

            conn.Open();

            SqlDataReader reader2 = examinerProfile.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader2.Read())
            {
                String examinerName = reader2.GetString(reader2.GetOrdinal("name"));
                String examinerField = reader2.GetString(reader2.GetOrdinal("fieldOfWork"));
                String examinerEmail = reader2.GetString(reader2.GetOrdinal("email"));
                String examinerPassword = reader2.GetString(reader2.GetOrdinal("password"));

                Label3.Text = examinerName;
                Label4.Text = examinerField;
                Label6.Text = examinerEmail;
                Label8.Text = examinerPassword;

                Session["examinerName"] = examinerName;
                Session["examinerField"] = examinerField;
                Session["examinerEmail"] = examinerEmail;
                Session["examinerPassword"] = examinerPassword;
            }
            conn.Close();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("editExaminerProfile.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addCommentOrGrade.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int userID = Int16.Parse(Session["userID"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searchThesis = new SqlCommand("findThesis", conn);
            searchThesis.CommandType = System.Data.CommandType.StoredProcedure;
            searchThesis.Parameters.Add(new SqlParameter("@id", userID));
            searchThesis.Parameters.Add(new SqlParameter("@input", search.Text));

            conn.Open();
            SqlDataReader reader = searchThesis.ExecuteReader();
            GridView2.DataSource = reader;
            GridView2.DataBind();
            conn.Close();
        }
    }
}