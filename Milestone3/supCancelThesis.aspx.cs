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
    public partial class supCancelThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            int thesisSerialNo = Int16.Parse(TSN.Text);

            SqlCommand cancelThesis = new SqlCommand("CancelThesis", conn);
            cancelThesis.CommandType = CommandType.StoredProcedure;
            cancelThesis.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNo));
         
            conn.Open();
            cancelThesis.ExecuteNonQuery();
            conn.Close();
        }
    }
}