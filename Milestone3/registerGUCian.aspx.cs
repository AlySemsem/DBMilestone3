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
    public partial class registerGUCian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorBox.Text = Session["errMsg"].ToString();
        }

        protected void register_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstName.Text == "" || lastName.Text == "" || password.Text == "" || faculty.Text == "" || email.Text == "" || address.Text == "")
                {
                    ErrorBox.Text = "invalid input";
                }
                else
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);

                    String first = firstName.Text;
                    String last = lastName.Text;
                    String pass = password.Text;
                    String fac = faculty.Text;
                    String mail = email.Text;
                    String add = address.Text;

                    SqlCommand GucianRegister = new SqlCommand("studentRegister", conn);
                    GucianRegister.CommandType = System.Data.CommandType.StoredProcedure;
                    GucianRegister.Parameters.Add(new SqlParameter("@first_name", first));
                    GucianRegister.Parameters.Add(new SqlParameter("@last_name", last));
                    GucianRegister.Parameters.Add(new SqlParameter("@password", pass));
                    GucianRegister.Parameters.Add(new SqlParameter("@faculty", fac));
                    GucianRegister.Parameters.Add(new SqlParameter("@Gucian", 1));
                    GucianRegister.Parameters.Add(new SqlParameter("@email", mail));
                    GucianRegister.Parameters.Add(new SqlParameter("@address", add));

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
                        Session["email"] = mail;
                        Session["errMsg"] = "";
                        conn.Open();
                        GucianRegister.ExecuteNonQuery();
                        conn.Close();
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