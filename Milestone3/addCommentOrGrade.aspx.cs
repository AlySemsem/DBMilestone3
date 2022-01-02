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
    public partial class addCommentOrGrade : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            conn = new SqlConnection(connStr);

            conn.Open();
            viewTable();
            conn.Close();

            error.Text = Session["msg"].ToString();
            error2.Text = Session["msg"].ToString();
        }

        protected void viewTable()
        {
            int userID = Int16.Parse(Session["userID"].ToString());
            SqlCommand defenseData = new SqlCommand("viewDefense", conn);
            defenseData.CommandType = CommandType.StoredProcedure;
            defenseData.Parameters.Add(new SqlParameter("@id", userID));

            SqlDataReader reader = defenseData.ExecuteReader(CommandBehavior.CloseConnection);

            Control tableBodyAdd = FindControl("tableBody");
            while (reader.Read())
            {
                HtmlTableRow tableRow = new HtmlTableRow();

                HtmlTableCell idCell = new HtmlTableCell();
                idCell.InnerText = reader.GetInt32(reader.GetOrdinal("serialNumber")).ToString();
                tableRow.Cells.Add(idCell);

                HtmlTableCell dateCell = new HtmlTableCell();
                dateCell.InnerText = reader.GetSqlDateTime(reader.GetOrdinal("date")).ToString();
                tableRow.Cells.Add(dateCell);

                HtmlTableCell locationCell = new HtmlTableCell();
                try
                {
                    locationCell.InnerText = reader.GetString(reader.GetOrdinal("location"));
                }
                catch
                {
                    locationCell.InnerText = "Null";
                }
                tableRow.Cells.Add(locationCell);

                HtmlTableCell gradeCell = new HtmlTableCell();
                try
                {
                    gradeCell.InnerText = reader.GetDecimal(reader.GetOrdinal("grade")).ToString();
                }
                catch
                {
                    gradeCell.InnerText = "Null";
                }
                tableRow.Cells.Add(gradeCell);

                HtmlTableCell commentCell = new HtmlTableCell();
                commentCell.InnerText = reader.GetString(reader.GetOrdinal("comment"));
                tableRow.Cells.Add(commentCell);

                tableBodyAdd.Controls.Add(tableRow);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileExaminer.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Label1.Text == "" || Label2.Text == "" || Label3.Text == "") {
                    error.Text = "No fields should be empty.";
                }
                else {
                    SqlCommand addGrade = new SqlCommand("AddDefenseGrade", conn);
                    addGrade.CommandType = CommandType.StoredProcedure;
                    addGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", SD.Text));
                    addGrade.Parameters.Add(new SqlParameter("@DefenseDate", DT.Text));
                    addGrade.Parameters.Add(new SqlParameter("@grade", newGrade.Text));

                    conn.Open();
                    addGrade.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("addCommentOrGrade.aspx");
                }
            }
            catch
            {
                error.Text = "Invalid input.";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Label1.Text == "" || Label2.Text == "" || Label4.Text == "")
                {
                    error2.Text = "No fields should be empty.";
                }
                else
                {
                    SqlCommand addComment = new SqlCommand("AddCommentsGrade", conn);
                    addComment.CommandType = CommandType.StoredProcedure;
                    addComment.Parameters.Add(new SqlParameter("@ThesisSerialNo", SD.Text));
                    addComment.Parameters.Add(new SqlParameter("@DefenseDate", DT.Text));
                    addComment.Parameters.Add(new SqlParameter("@comments", newComment.Text));

                    conn.Open();
                    addComment.ExecuteNonQuery();
                    conn.Close();
                    Session["msg"] = "Operation done successfully";
                    Response.Redirect("addCommentOrGrade.aspx");
                }
            }
            catch
            {
                error2.Text = "Invalid input.";
            }
        }
    }
}