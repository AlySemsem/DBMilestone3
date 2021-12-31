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
    public partial class GUCianEditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userID = Int16.Parse(Session["userID"].ToString()); 
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String first = firstNameBox.Text;
            String last = lastNameBox.Text;
            String pass = passBox.Text;
            String mail = emailBox.Text;
            String add = addressBox.Text;
            String type = typeBox.Text;

            SqlCommand GucianRegister = new SqlCommand("editMyProfile", conn);
            GucianRegister.CommandType = System.Data.CommandType.StoredProcedure;
            GucianRegister.Parameters.Add(new SqlParameter("@studentID", userID));
            GucianRegister.Parameters.Add(new SqlParameter("@firstName", first));
            GucianRegister.Parameters.Add(new SqlParameter("@lastName", last));
            GucianRegister.Parameters.Add(new SqlParameter("@password", pass));
            GucianRegister.Parameters.Add(new SqlParameter("@email", mail));
            GucianRegister.Parameters.Add(new SqlParameter("@address", add));
            GucianRegister.Parameters.Add(new SqlParameter("@type", type));

            conn.Open();
            GucianRegister.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("profileGUCian.aspx");
        }
    }
}