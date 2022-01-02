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
    public partial class ViewStudentYears : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand StudentsYears = new SqlCommand("ViewSupStudentsYears",conn);
            StudentsYears.CommandType = CommandType.StoredProcedure;
            StudentsYears.Parameters.Add(new SqlParameter("@supervisorID", Session["userID"]));

            conn.Open();

            SqlDataReader reader = StudentsYears.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
        }


    }
}