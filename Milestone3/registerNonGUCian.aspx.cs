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

        }

        protected void register_Click(object sender, EventArgs e)
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
            NonGucianRegister.Parameters.Add(new SqlParameter("@Gucian", 0));
            NonGucianRegister.Parameters.Add(new SqlParameter("@email", mail));
            NonGucianRegister.Parameters.Add(new SqlParameter("@address", add));

            conn.Open();
            NonGucianRegister.ExecuteNonQuery();
            conn.Close();

        }
    }
}