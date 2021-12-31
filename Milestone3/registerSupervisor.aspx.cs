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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

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

            conn.Open();
            SupervisorRegister.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("profileSupervisor.aspx");

        }
    }
}