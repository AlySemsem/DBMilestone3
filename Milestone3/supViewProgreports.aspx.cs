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
    public partial class supViewProgreports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            int thesisSerialNo = Int16.Parse(TSN.Text);
            int proprogressReportNo = Int16.Parse(ProgNo.Text);
            int eval;


            SqlCommand evalProRep = new SqlCommand("AddDefenseGucian", conn);
            evalProRep.CommandType = CommandType.StoredProcedure;
            evalProRep.Parameters.Add(new SqlParameter("@supervisorID", Session["userID"]));
            evalProRep.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisSerialNo));
            evalProRep.Parameters.Add(new SqlParameter("@progressReportNo", proprogressReportNo));
            evalProRep.Parameters.Add(new SqlParameter("@evaluation", eval));

            conn.Open();
            evalProRep.ExecuteNonQuery();
            conn.Close();
        }

        protected void RadioButton0_CheckedChanged(object sender, EventArgs e)
        {
            eval = 0;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            eval = 1;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            eval = 2;
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            eval = 3;
        }
    }
}