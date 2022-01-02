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
    public partial class editExaminerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
    {
        String examinerName = Session["examinerName"].ToString();
        firstName.Text = examinerName;
        String examinerField = Session["examinerField"].ToString();
        fieldofwork.Text = examinerField;
        String examinerEmail = Session["examinerEmail"].ToString();
        email.Text = examinerEmail;
        String examinerPassword = Session["examinerPassword"].ToString();
        password.Text = examinerPassword;

            errorEdit.Text = Session["msg"].ToString();
        }

    protected void Button1_Click(object sender, EventArgs e)
    {
            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int userID = Int16.Parse(Session["userID"].ToString());
                String name = firstName.Text;
                String field = fieldofwork.Text;
                String mail = email.Text;
                String pass = password.Text;


                SqlCommand editProfile = new SqlCommand("editExaminer", conn);
                editProfile.CommandType = System.Data.CommandType.StoredProcedure;
                editProfile.Parameters.Add(new SqlParameter("@id", userID));
                editProfile.Parameters.Add(new SqlParameter("@name", name));
                editProfile.Parameters.Add(new SqlParameter("@field", field));
                editProfile.Parameters.Add(new SqlParameter("@email", mail));
                editProfile.Parameters.Add(new SqlParameter("@password", pass));

                conn.Open();
                editProfile.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("profileExaminer.aspx");
            }
            catch
            {
                errorEdit.Text = "Invalid Operation";
            }
    }
}
}