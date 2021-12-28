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

        }

        protected void register_Click(object sender, EventArgs e)
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

            conn.Open();
            GucianRegister.ExecuteNonQuery();
            conn.Close();

        }
    }
}