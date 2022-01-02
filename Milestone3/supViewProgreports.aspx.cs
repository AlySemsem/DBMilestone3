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
        int eval;
        String msg1 = "Invalid input.";
        String msg2 = "Invalid input: Thesis or Progress Report does not exist";
        String msg3 = "No field can be left empty";

        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Text = Session["msg"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                if (TSN1.Text == "" || ProgNo2.Text == "" || (!RadioButton1.Checked && !RadioButton2.Checked && !RadioButton3.Checked && !RadioButton4.Checked))
                {
                    msg.Text = msg3;
                }
                else
                {
                    int thesisSerialNo = Int16.Parse(TSN1.Text);
                    int proprogressReportNo = Int16.Parse(ProgNo2.Text);

                    SqlCommand evalProRep = new SqlCommand("EvaluateProgressReport", conn);
                    evalProRep.CommandType = CommandType.StoredProcedure;
                    evalProRep.Parameters.Add(new SqlParameter("@supervisorID", Session["userID"]));
                    evalProRep.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisSerialNo));
                    evalProRep.Parameters.Add(new SqlParameter("@progressReportNo", proprogressReportNo));
                    evalProRep.Parameters.Add(new SqlParameter("@evaluation", eval));

                    SqlCommand isThesisRegGUC = new SqlCommand("thesisExistGUC", conn);
                    isThesisRegGUC.CommandType = CommandType.StoredProcedure;
                    isThesisRegGUC.Parameters.Add(new SqlParameter("@thesisSN", thesisSerialNo));

                    SqlParameter thesisPGUC = isThesisRegGUC.Parameters.Add("@thesisSuc", System.Data.SqlDbType.Int);
                    thesisPGUC.Direction = System.Data.ParameterDirection.Output;

                    SqlCommand isThesisRegNonGuc = new SqlCommand("thesisExistNonGUC", conn);
                    isThesisRegNonGuc.CommandType = CommandType.StoredProcedure;
                    isThesisRegNonGuc.Parameters.Add(new SqlParameter("@thesisSN", thesisSerialNo));

                    SqlParameter thesisPNonGUC = isThesisRegNonGuc.Parameters.Add("@thesisSuc", System.Data.SqlDbType.Int);
                    thesisPNonGUC.Direction = System.Data.ParameterDirection.Output;

                    SqlCommand PRE = new SqlCommand("PRExists", conn);
                    PRE.CommandType = CommandType.StoredProcedure;
                    PRE.Parameters.Add(new SqlParameter("@prNo", proprogressReportNo));

                    SqlParameter isPRE = PRE.Parameters.Add("@PRSuc", System.Data.SqlDbType.Int);
                    isPRE.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    evalProRep.ExecuteNonQuery();
                    isThesisRegGUC.ExecuteNonQuery();
                    isThesisRegNonGuc.ExecuteNonQuery();
                    PRE.ExecuteNonQuery();
                    conn.Close();

                    if (thesisPGUC.Value.ToString() == "0" && thesisPNonGUC.Value.ToString() == "0" && isPRE.Value.ToString() == "0")
                    {
                        msg.Text = msg2;
                    }
                    else
                    {
                        conn.Open();
                        evalProRep.ExecuteNonQuery();
                        conn.Close();
                        Session["msg"] = "Evaluation added successfully";
                        Response.Redirect("supViewProgreports.aspx");
                    }
                }
            }
            catch
            {
                msg.Text = msg1;
            }
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