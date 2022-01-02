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
    public partial class registerSupervisor : System.Web.UI.Page
    {
        String err1 = "ERROR: No field can be left empty";
        String err2 = "ERROR: Email already in use, please enter a different one";

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorBox.Text = Session["errMsg"].ToString();
        }

        protected void register_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            //try
            //{
                if (firstNameS.Text == "" || lastNameS.Text == "" || passwordS.Text == "" || facultyS.Text == "" || emailS.Text == "")
                {
                    ErrorBox.Text = err1;
                }

                else
                {
                    String first = firstNameS.Text;
                    String last = lastNameS.Text;
                    String pass = passwordS.Text;
                    String fac = facultyS.Text;
                    String mail = emailS.Text;

                    SqlCommand SupervisorRegister = new SqlCommand("supervisorRegister", conn);
                    SupervisorRegister.CommandType = System.Data.CommandType.StoredProcedure;
                    SupervisorRegister.Parameters.Add(new SqlParameter("@first_name", first));
                    SupervisorRegister.Parameters.Add(new SqlParameter("@last_name", last));
                    SupervisorRegister.Parameters.Add(new SqlParameter("@password", pass));
                    SupervisorRegister.Parameters.Add(new SqlParameter("@faculty", fac));
                    SupervisorRegister.Parameters.Add(new SqlParameter("@email", mail));

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
                        ErrorBox.Text = err2;
                    }
                    else
                    {
                        conn.Open();
                        SupervisorRegister.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("login.aspx");
                    }
                }
            //}
            //catch
            //{
                //.Text = "invalid input";
            //}
        }
    }
}