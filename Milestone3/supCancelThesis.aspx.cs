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
        String msg1 = "Thesis successfully cancelled";
        String msg2 = "Cannot cancel thesis as student's last progress report evaluation was not 0";
        String msg3 = "Thesis serial number cannot be empty";

        protected void Page_Load(object sender, EventArgs e)
        {
            messageBox.Text = Session["errMsg"].ToString();
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (TSN1.Text == "")
                {
                    messageBox.Text = msg3;
                }
                else
                {
                    String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    //create a new connection
                    SqlConnection conn = new SqlConnection(connStr);

                    int thesisSerialNo = Int16.Parse(TSN1.Text);

                    SqlCommand cancelThesis = new SqlCommand("CancelThesis", conn);
                    cancelThesis.CommandType = CommandType.StoredProcedure;
                    cancelThesis.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNo));

                    SqlCommand ProgE = new SqlCommand("ProgRepEval", conn);
                    ProgE.CommandType = CommandType.StoredProcedure;
                    ProgE.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNo));

                    SqlParameter EvalVal = ProgE.Parameters.Add("@eval", System.Data.SqlDbType.Int);
                    EvalVal.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    ProgE.ExecuteNonQuery();
                    conn.Close();

                    if (EvalVal.Value.ToString() != "0")
                    {
                        // messageBox.Text = msg2;
                        Session["errMsg"] = msg2;
                        Response.Redirect("supCancelThesis.aspx");
                    }
                    else
                    {
                        conn.Open();
                        cancelThesis.ExecuteNonQuery();
                        conn.Close();
                        Session["errMsg"] = msg1;
                        Response.Redirect("supCancelThesis.aspx");
                    }
                }
            }
            catch
            {
                messageBox.Text = "Invalid input";
            }
        }
    }
}