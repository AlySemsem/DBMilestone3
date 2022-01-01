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
        String err1 = "Incorrect student ID, please choose a different one";
        String err2 = "Student ID cannot be empty, please enter a value";

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorBox.Text = Session["errMsg"].ToString();
        }

        protected void view_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                if (studentID_TB.Text == "")
                {
                    Session["errMsg"] = err2;
                    Response.Redirect("supViewPublications.aspx");
                }
                else
                {

                    int studentID = Int16.Parse(studentID_TB.Text);
                    Session["StudenID"] = studentID;

                    SqlCommand viewPub = new SqlCommand("ViewAStudentPublications", conn);
                    viewPub.CommandType = CommandType.StoredProcedure;
                    viewPub.Parameters.Add(new SqlParameter("@StudentID", studentID));

                    SqlCommand correctStudent = new SqlCommand("isCorrectStudent", conn);
                    correctStudent.CommandType = CommandType.StoredProcedure;
                    correctStudent.Parameters.Add(new SqlParameter("@supID", Session["userID"]));
                    correctStudent.Parameters.Add(new SqlParameter("@StudentID", studentID));

                    SqlParameter successP = correctStudent.Parameters.Add("@success", System.Data.SqlDbType.Int);
                    successP.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    correctStudent.ExecuteNonQuery();
                    conn.Close();

                    if (successP.Value.ToString() == "0")
                    {
                        Session["errMsg"] = err1;
                        Response.Redirect("supViewPublications.aspx");
                    }
                    else
                    {
                        conn.Open();
                        SqlDataReader reader = viewPub.ExecuteReader();
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                        conn.Close();
                        ErrorBox.Visible = false;
                    }
                }
            }

            catch
            {
                ErrorBox.Text = "Invalid input";
            }
        }      
    }
}