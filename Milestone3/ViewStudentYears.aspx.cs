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
            SqlDataReader rdr = StudentsYears.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String studentFirstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                String studentLastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                String yearsSpent = rdr.GetString(rdr.GetOrdinal("years"));
                Label firstName = new Label();
                Label lastName = new Label();
                Label years = new Label();
                firstName.Text = studentFirstName;
                lastName.Text = studentLastName;
                years.Text = yearsSpent;
                form1.Controls.Add(firstName);
                form1.Controls.Add(lastName);
                form1.Controls.Add(years);
                conn.Close();
            }

            //StudentsYears.ExecuteNonQuery();     
            //SqlDataReader reader = StudentsYears.ExecuteReader();
            //  GridView.Datasource = reader;
            //GridView.DataBind();
            //GridView1.DataSource = ADONET_methods.DisplaySchemaTables();
            //GridView1.DataBind();
            //DisplaySchemaTables()
        }

    }
}