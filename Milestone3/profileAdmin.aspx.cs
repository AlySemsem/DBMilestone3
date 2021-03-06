using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class profileAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            conn = new SqlConnection(connStr);

            conn.Open();
            DisplaySupervisors();
            conn.Close();

            conn.Open();
            DisplayThesis();
            conn.Close();

            conn.Open();
            OngoingThesisCount();
            conn.Close();

            errorIssueThesis.Text = Session["msg"].ToString();
            errorIssueInstallments.Text = Session["msg"].ToString();
            errorIncreaseExtensions.Text = Session["msg"].ToString();

        }

        protected void DisplaySupervisors()
        {
            SqlCommand supervisorList = new SqlCommand("AdminListSup", conn);
            supervisorList.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = supervisorList.ExecuteReader(CommandBehavior.CloseConnection);


            Control supervisorBody = FindControl("supervisorBody");

            while (reader.Read())
            {
                HtmlTableRow supervisorRow = new HtmlTableRow();

                HtmlTableCell idCell = new HtmlTableCell();
                idCell.InnerText = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                supervisorRow.Cells.Add(idCell);

                HtmlTableCell nameCell = new HtmlTableCell();
                nameCell.InnerText = reader.GetString(reader.GetOrdinal("name"));
                supervisorRow.Cells.Add(nameCell);

                HtmlTableCell mailCell = new HtmlTableCell();
                mailCell.InnerText = reader.GetString(reader.GetOrdinal("email"));
                supervisorRow.Cells.Add(mailCell);

                HtmlTableCell passCell = new HtmlTableCell();
                passCell.InnerText = reader.GetString(reader.GetOrdinal("password"));
                supervisorRow.Cells.Add(passCell);

                HtmlTableCell facultyCell = new HtmlTableCell();
                facultyCell.InnerText = reader.GetString(reader.GetOrdinal("faculty"));
                supervisorRow.Cells.Add(facultyCell);

                supervisorBody.Controls.Add(supervisorRow);
            }
        }

        protected void DisplayThesis()
        {
            SqlCommand thesisList = new SqlCommand("AdminViewAllTheses", conn);
            thesisList.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = thesisList.ExecuteReader(CommandBehavior.CloseConnection);

            Control thesisBody = FindControl("thesisBody");

            while (reader.Read())
            {
                HtmlTableRow thesisRow = new HtmlTableRow();

                HtmlTableCell serialNumberCell = new HtmlTableCell();
                serialNumberCell.InnerText = reader.GetInt32(reader.GetOrdinal("serialNumber")).ToString();
                thesisRow.Cells.Add(serialNumberCell);

                HtmlTableCell fieldCell = new HtmlTableCell();
                try
                {
                    fieldCell.InnerText = reader.GetString(reader.GetOrdinal("field"));
                }
                catch
                {
                    fieldCell.InnerText = "NULL";
                }
                thesisRow.Cells.Add(fieldCell);

                HtmlTableCell typeCell = new HtmlTableCell();
                typeCell.InnerText = reader.GetString(reader.GetOrdinal("type"));
                thesisRow.Cells.Add(typeCell);

                HtmlTableCell titleCell = new HtmlTableCell();
                titleCell.InnerText = reader.GetString(reader.GetOrdinal("title"));
                thesisRow.Cells.Add(titleCell);

                HtmlTableCell SdateCell = new HtmlTableCell();
                SdateCell.InnerText = reader.GetDateTime(reader.GetOrdinal("startDate")).ToString("MM/dd/yyyy");
                thesisRow.Cells.Add(SdateCell);
                //shortdatestring

                HtmlTableCell EdateCell = new HtmlTableCell();
                EdateCell.InnerText = reader.GetDateTime(reader.GetOrdinal("endDate")).ToString("MM/dd/yyyy");
                thesisRow.Cells.Add(EdateCell);

                HtmlTableCell defencedateCell = new HtmlTableCell();
                try
                {
                    defencedateCell.InnerText = reader.GetDateTime(reader.GetOrdinal("defenseDate")).ToString("MM/dd/yyyy");
                }
                catch
                {
                    defencedateCell.InnerText = "NULL";
                }
                thesisRow.Cells.Add(defencedateCell);

                HtmlTableCell yearsCell = new HtmlTableCell();
                yearsCell.InnerText = reader.GetInt32(reader.GetOrdinal("years")).ToString();
                thesisRow.Cells.Add(yearsCell);

                HtmlTableCell gradeCell = new HtmlTableCell();
                try
                {
                    gradeCell.InnerText = reader.GetDecimal(reader.GetOrdinal("grade")).ToString();
                }
                catch
                {
                    gradeCell.InnerText = "NULL";
                }
                thesisRow.Cells.Add(gradeCell);

                HtmlTableCell paymentidCell = new HtmlTableCell();
                try
                {
                    paymentidCell.InnerText = reader.GetInt32(reader.GetOrdinal("payment_id")).ToString();
                }
                catch
                {
                    paymentidCell.InnerText = "NULL";
                }
                thesisRow.Cells.Add(paymentidCell);

                HtmlTableCell extensionsCell = new HtmlTableCell();
                try
                {
                    extensionsCell.InnerText = reader.GetInt32(reader.GetOrdinal("noOfExtensions")).ToString();
                }
                catch
                {
                    extensionsCell.InnerText = "NULL";
                }
                thesisRow.Cells.Add(extensionsCell);

                thesisBody.Controls.Add(thesisRow);
            }
        }
        protected void OngoingThesisCount()
        {
            SqlCommand ongoingCount = new SqlCommand("AdminViewOnGoingTheses", conn);
            ongoingCount.CommandType = CommandType.StoredProcedure;

            SqlParameter thesisCount = new SqlParameter("@thesesCount", SqlDbType.Int);
            thesisCount.Direction = ParameterDirection.Output;
            ongoingCount.Parameters.Add(thesisCount);

            SqlDataReader reader = ongoingCount.ExecuteReader(CommandBehavior.CloseConnection);

            count.Text = thesisCount.Value.ToString();


        }

        protected void Issue_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThesisID.Text == "" || amountT.Text == "" || NoIns.Text == "" || fundperc.Text == "") {
                    errorIssueThesis.Text = "No fields should be empty.";
                } 
                else {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    int thesis = Int32.Parse(ThesisID.Text);
                    int amount = Int32.Parse(amountT.Text);
                    int installments = Int32.Parse(NoIns.Text);
                    decimal fundpercentage = decimal.Parse(fundperc.Text);

                    SqlCommand ThesisPayment = new SqlCommand("AdminIssueThesisPayment", conn);
                    ThesisPayment.CommandType = System.Data.CommandType.StoredProcedure;
                    ThesisPayment.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesis));
                    ThesisPayment.Parameters.Add(new SqlParameter("@amount", amount));
                    ThesisPayment.Parameters.Add(new SqlParameter("@noOfInstallments", installments));
                    ThesisPayment.Parameters.Add(new SqlParameter("@fundPercentage", fundpercentage));

                    conn.Open();
                    ThesisPayment.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("profileAdmin.aspx");
                }
            } 
            catch
            {
                errorIssueThesis.Text = "Invalid Input";
            }
        }

        protected void increase_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThesisID2.Text == "")
                {
                    errorIncreaseExtensions.Text = "No fields should be empty.";
                }
                else {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    int thesis = Int32.Parse(ThesisID2.Text);

                    SqlCommand extensionInc = new SqlCommand("AdminUpdateExtension", conn);
                    extensionInc.CommandType = System.Data.CommandType.StoredProcedure;
                    extensionInc.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesis));

                    conn.Open();
                    extensionInc.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("profileAdmin.aspx");
                }
            } catch
            {
                errorIncreaseExtensions.Text = "Invalid Input";
            }
        }

        protected void IssueIns_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentId.Text == "" || defencedate.Text == "")
                {
                    errorIssueInstallments.Text = "No fields should be empty.";
                }
                else
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    int payid = Int32.Parse(paymentId.Text);
                    DateTime defdate = DateTime.Parse(defencedate.Text);

                    SqlCommand installmenstIssue = new SqlCommand("AdminIssueInstallPayment2", conn);
                    installmenstIssue.CommandType = System.Data.CommandType.StoredProcedure;
                    installmenstIssue.Parameters.Add(new SqlParameter("@paymentID", payid));
                    installmenstIssue.Parameters.Add(new SqlParameter("@InstallStartDate", defdate));

                    conn.Open();
                    installmenstIssue.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("profileAdmin.aspx");
                }
            }
            catch
            {
                errorIssueInstallments.Text = "Invalid Input";
            }
        }
    }
}