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
    public partial class supViewPublications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void studentIDbtn_Click(object sender, EventArgs e)
        {
            int studentID = Int16.Parse(studentID_TB.Text);

            //Session["studentID"] = studentID;
            //Response.Redirect("supViewPublications2.aspx");
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewPub = new SqlCommand("ViewAStudentPublications", conn);
            viewPub.CommandType = CommandType.StoredProcedure;
            viewPub.Parameters.Add(new SqlParameter("@StudentID", studentID));

            //conn.Open();
            //SqlDataReader rdr = viewPub.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //conn.Close();

            conn.Open();
            SqlDataReader rdr = viewPub.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())

            {
                String pubID = rdr.GetString(rdr.GetOrdinal("id"));
                String pubTitle = rdr.GetString(rdr.GetOrdinal("title"));
                String pubDate = rdr.GetString(rdr.GetOrdinal("dateOfPublication"));
                String pubPlace = rdr.GetString(rdr.GetOrdinal("place"));
                String pubIsAccepted = rdr.GetString(rdr.GetOrdinal("accepted"));
                String pubHost = rdr.GetString(rdr.GetOrdinal("host"));

                if (pubIsAccepted == "0")
                    pubIsAccepted = "No";
                else pubIsAccepted = "Yes";

                Label id = new Label();
                Label title = new Label();
                Label dateOfPublication = new Label();
                Label place = new Label();
                Label accepted = new Label();
                Label host = new Label();

                id.Text = pubID;
                title.Text = pubTitle;
                dateOfPublication.Text = pubDate;
                place.Text = pubPlace;
                accepted.Text = pubIsAccepted;
                host.Text = pubHost;

                form1.Controls.Add(id);
                form1.Controls.Add(title);
                form1.Controls.Add(dateOfPublication);
                form1.Controls.Add(place);
                form1.Controls.Add(accepted);
                form1.Controls.Add(host);

                conn.Close();
            }
           // Response.Redirect("profileExaminer.aspx");
        }
    }
}