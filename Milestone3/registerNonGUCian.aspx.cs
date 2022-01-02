using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class registerNonGUCian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorBox.Text = Session["errMsg"].ToString();
        }

        protected void register_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstNameN.Text == "" || lastNameN.Text == "" || passwordN.Text == "" || facultyN.Text == "" || emailN.Text == "" || addressN.Text == "")
                {
                    ErrorBox.Text = "invalid input";
                }
                else
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    String first = firstNameN.Text;
                    String last = lastNameN.Text;
                    String pass = passwordN.Text;
                    String fac = facultyN.Text;
                    String mail = emailN.Text;
                    String add = addressN.Text;

                    SqlCommand NonGucianRegister = new SqlCommand("studentRegister", conn);
                    NonGucianRegister.CommandType = System.Data.CommandType.StoredProcedure;
                    NonGucianRegister.Parameters.Add(new SqlParameter("@first_name", first));
                    NonGucianRegister.Parameters.Add(new SqlParameter("@last_name", last));
                    NonGucianRegister.Parameters.Add(new SqlParameter("@password", pass));
                    NonGucianRegister.Parameters.Add(new SqlParameter("@faculty", fac));
                    NonGucianRegister.Parameters.Add(new SqlParameter("@Gucian", false));
                    NonGucianRegister.Parameters.Add(new SqlParameter("@email", mail));
                    NonGucianRegister.Parameters.Add(new SqlParameter("@address", add));

                    SqlCommand isemailUsed = new SqlCommand("isEmailUsed", conn);
                    isemailUsed.CommandType = System.Data.CommandType.StoredProcedure;
                    isemailUsed.Parameters.Add(new SqlParameter("@email", mail));

                    SqlParameter isExist = isemailUsed.Parameters.Add("@isExist", System.Data.SqlDbType.Int);
                    isExist.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    isemailUsed.ExecuteNonQuery();
                    conn.Close();

                    if (isExist.Value.ToString() == "1")
                    {
                        ErrorBox.Text = "email already in use";
                    }
                    else
                    {
                        conn.Open();
                        NonGucianRegister.ExecuteNonQuery();
                        conn.Close();
                        Session["email"] = mail;
                        Session["errMsg"] = "";
                        Response.Redirect("addMobileNumber.aspx");
                    }
                }
            }
            catch
            {
                ErrorBox.Text = "invalid input";
            }

        }
    }
}