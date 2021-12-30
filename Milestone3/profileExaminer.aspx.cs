using System;
using System.Collections.Generic;
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

            conn.Open();
            SqlDataReader reader = supTable.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("editExaminerProfile.aspx");
        }
    }
}