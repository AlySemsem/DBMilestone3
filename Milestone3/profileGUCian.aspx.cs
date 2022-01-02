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
    public partial class profileGUCian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["GUCian"] = "1";

            int userID = Int16.Parse(Session["userID"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand userInfo = new SqlCommand("viewMyProfile", conn);
            userInfo.CommandType = CommandType.StoredProcedure;
            userInfo.Parameters.Add(new SqlParameter("@studentId", userID));

            SqlDataReader reader = userInfo.ExecuteReader();

            while (reader.Read())
            {
                String name = reader.GetString(reader.GetOrdinal("firstName")) + " " + reader.GetString(reader.GetOrdinal("lastName"));
                Name.Text = "Name: " + name;

                if (reader.IsDBNull(reader.GetOrdinal("type")))
                    Type.Text = "Degree: null";
                else
                {
                    String degreet = reader.GetString(reader.GetOrdinal("type"));
                    Type.Text = "Degree: " + degreet;
                }

                String Facultyt = reader.GetString(reader.GetOrdinal("faculty"));
                Faculty.Text = "Faculty: " + Facultyt;

                if (reader.IsDBNull(reader.GetOrdinal("GPA")))
                    GPA.Text = "GPA: null";
                else
                {
                    String GPAt = reader.GetDecimal(reader.GetOrdinal("GPA")).ToString();
                    GPA.Text = "GPA: " + GPAt;
                }

            }
            reader.Close();
            DisplayThesis(conn, userID);
            conn.Close();

            errorProgress.Text = Session["msg"].ToString();
            errorFill.Text = Session["msg"].ToString();
            errorPublication.Text = Session["msg"].ToString();
            errorLink.Text = Session["msg"].ToString();
        }

        

        private void DisplayThesis(SqlConnection conn, int userID)
        {
            SqlCommand thesisInfo = new SqlCommand("getStudentThesis", conn);
            thesisInfo.CommandType = CommandType.StoredProcedure;
            thesisInfo.Parameters.Add(new SqlParameter("@studentID", userID));

            SqlDataReader reader = thesisInfo.ExecuteReader(CommandBehavior.CloseConnection);

            Control ThesisBody = FindControl("ThesisBody");

            while (reader.Read())
            {
                HtmlTableRow userRow = new HtmlTableRow();

                HtmlTableCell serialNoCell = new HtmlTableCell();
                serialNoCell.InnerText = reader.GetInt32(reader.GetOrdinal("serialNumber")).ToString();
                userRow.Cells.Add(serialNoCell);

                HtmlTableCell fieldCell = new HtmlTableCell();
                fieldCell.InnerText = reader.GetString(reader.GetOrdinal("field"));
                userRow.Cells.Add(fieldCell);

                HtmlTableCell typeCell = new HtmlTableCell();
                typeCell.InnerText = reader.GetString(reader.GetOrdinal("type"));
                userRow.Cells.Add(typeCell);

                HtmlTableCell titleCell = new HtmlTableCell();
                titleCell.InnerText = reader.GetString(reader.GetOrdinal("title"));
                userRow.Cells.Add(titleCell);

                HtmlTableCell startDateCell = new HtmlTableCell();
                startDateCell.InnerText = reader.GetDateTime(reader.GetOrdinal("startDate")).ToString();
                userRow.Cells.Add(startDateCell);

                HtmlTableCell endDateCell = new HtmlTableCell();
                endDateCell.InnerText = reader.GetDateTime(reader.GetOrdinal("endDate")).ToString();
                userRow.Cells.Add(endDateCell);

                HtmlTableCell defenseDateCell = new HtmlTableCell();
                if (reader.IsDBNull(reader.GetOrdinal("defenseDate")))
                    defenseDateCell.InnerText = "Null";
                else
                {
                    defenseDateCell.InnerText = reader.GetDateTime(reader.GetOrdinal("defenseDate")).ToString();
                    userRow.Cells.Add(defenseDateCell);
                }

                HtmlTableCell yearsCell = new HtmlTableCell();
                yearsCell.InnerText = reader.GetInt32(reader.GetOrdinal("years")).ToString();
                userRow.Cells.Add(yearsCell);
                
                HtmlTableCell gradeCell = new HtmlTableCell();
                if (reader.IsDBNull(reader.GetOrdinal("grade")))
                    gradeCell.InnerText = "Null";
                else
                {
                    gradeCell.InnerText = reader.GetDecimal(reader.GetOrdinal("grade")).ToString();
                    userRow.Cells.Add(gradeCell);
                }
                
                HtmlTableCell payment_idCell = new HtmlTableCell();
                payment_idCell.InnerText = reader.GetInt32(reader.GetOrdinal("payment_id")).ToString();
                userRow.Cells.Add(payment_idCell);

                HtmlTableCell extensionsCell = new HtmlTableCell();
                extensionsCell.InnerText = reader.GetInt32(reader.GetOrdinal("noOfExtensions")).ToString();
                userRow.Cells.Add(extensionsCell);

                ThesisBody.Controls.Add(userRow);
            }

        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUCianEditProfile.aspx");
        }

        protected void addProgressReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (thesisSerialBox.Text == "" || reportDateBox.Text == "")
                {
                    errorProgress.Text = "No fields should be empty.";
                }
                else
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    SqlCommand addReport = new SqlCommand("AddProgressReport", conn);
                    addReport.CommandType = CommandType.StoredProcedure;
                    int serialNo = Int16.Parse(thesisSerialBox.Text);
                    addReport.Parameters.Add(new SqlParameter("@thesisSerialNo", serialNo));
                    DateTime reportDate = Convert.ToDateTime(reportDateBox.Text);
                    addReport.Parameters.Add(new SqlParameter("@progressReportDate", reportDate));
                    int userID = Int16.Parse(Session["userID"].ToString());
                    addReport.Parameters.Add(new SqlParameter("@studentID", userID));
                    String reportNum = reportNumBox.Text;
                    addReport.Parameters.Add(new SqlParameter("@progressReportNo", reportNum));

                    conn.Open();
                    addReport.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("profileGUCian.aspx");

                }
            }
            catch
            {
                errorProgress.Text = "Invalid Input";
            }
        }

        protected void fillProgressReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (thesisSerialBox2.Text == "" || progressReportNumberBox.Text == "" || stateBox.Text == "" || descriptionBox.Text == "") 
                { 
                    errorFill.Text = "No fields should be empty.";
                } 
                else {

                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    SqlCommand fillReport = new SqlCommand("FillProgressReport", conn);
                    fillReport.CommandType = CommandType.StoredProcedure;
                    int serialNo = Int16.Parse(thesisSerialBox2.Text);
                    fillReport.Parameters.Add(new SqlParameter("@thesisSerialNo", serialNo));
                    int progressReportNo = Int16.Parse(progressReportNumberBox.Text);
                    fillReport.Parameters.Add(new SqlParameter("@progressReportNo", progressReportNo));
                    int state = Int16.Parse(stateBox.Text);
                    fillReport.Parameters.Add(new SqlParameter("@state", state));
                    String description = descriptionBox.Text;
                    fillReport.Parameters.Add(new SqlParameter("@description", description));
                    int userID = Int16.Parse(Session["userID"].ToString());
                    fillReport.Parameters.Add(new SqlParameter("@studentID", userID));

                conn.Open();
                    fillReport.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("profileGUCian.aspx");
                }
            }
            catch
            {
                errorProgress.Text = "Invalid Input";
            }
        }

        protected void pubAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (titleBox.Text == "" || pubDateBox.Text == "" || hostBox.Text == "" || placeBox.Text == "")
                {
                    errorPublication.Text = "No fields should be empty.";
                }
                else {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    SqlCommand addPub = new SqlCommand("addPublication", conn);
                    addPub.CommandType = CommandType.StoredProcedure;
                    String title = titleBox.Text;
                    addPub.Parameters.Add(new SqlParameter("@title", title));
                    DateTime pubDate = Convert.ToDateTime(pubDateBox.Text);
                    addPub.Parameters.Add(new SqlParameter("@pubDate", pubDate));
                    String host = hostBox.Text;
                    addPub.Parameters.Add(new SqlParameter("@host", host));
                    String place = placeBox.Text;
                    addPub.Parameters.Add(new SqlParameter("@place", place));
                    int accepted = Int16.Parse(acceptedList.SelectedValue);
                    addPub.Parameters.Add(new SqlParameter("@accepted", accepted));

                    conn.Open();
                    addPub.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("profileGUCian.aspx");
                }
            }
            catch
            {
                errorPublication.Text = "Invalid Input";
            }

        }

        protected void pubLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (pubIDBox.Text == "" || thesisSerialNoBox.Text == "")
                {
                    errorLink.Text = "No fields should be empty.";
                }
                else {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    SqlCommand linkPub = new SqlCommand("linkPubThesis", conn);
                    linkPub.CommandType = CommandType.StoredProcedure;
                    int PubID = Int16.Parse(pubIDBox.Text);
                    linkPub.Parameters.Add(new SqlParameter("@PubID", PubID));
                    int thesisSerialNo = Int16.Parse(thesisSerialNoBox.Text);
                    linkPub.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisSerialNo));

                    conn.Open();
                    linkPub.ExecuteNonQuery();
                    conn.Close();

                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("profileGUCian.aspx");
                }
            }
            catch
            {
                errorLink.Text = "Invalid Input";
            }
        }
    }

}