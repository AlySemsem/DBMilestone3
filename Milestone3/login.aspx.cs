using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace GUC_System
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void login(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                String email = emailTB.Text;
                String pass = password.Text;

                SqlCommand gettingUserID = new SqlCommand("getUserID", conn);
                gettingUserID.CommandType = System.Data.CommandType.StoredProcedure;
                gettingUserID.Parameters.Add(new SqlParameter("@email", email));

                SqlParameter userID = gettingUserID.Parameters.Add("@userID", System.Data.SqlDbType.Int);
                userID.Direction = System.Data.ParameterDirection.Output;

                conn.Open();
                gettingUserID.ExecuteNonQuery();
                conn.Close();

                int id = Int16.Parse(userID.Value.ToString());

                SqlCommand loginproc = new SqlCommand("userLogin", conn);
                loginproc.CommandType = System.Data.CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@id", id));
                loginproc.Parameters.Add(new SqlParameter("@password", pass));

                SqlParameter success = loginproc.Parameters.Add("@success", System.Data.SqlDbType.Int);
                SqlParameter type = loginproc.Parameters.Add("@type", System.Data.SqlDbType.Int);

                success.Direction = System.Data.ParameterDirection.Output;
                type.Direction = System.Data.ParameterDirection.Output;

                SqlCommand loginwho = new SqlCommand("loginwhere", conn);
                loginwho.CommandType = System.Data.CommandType.StoredProcedure;
                loginwho.Parameters.Add(new SqlParameter("@id", id));

                SqlParameter outType = loginwho.Parameters.Add("@out", System.Data.SqlDbType.Int);
                outType.Direction = System.Data.ParameterDirection.Output;

                conn.Open();
                loginwho.ExecuteNonQuery();
                loginproc.ExecuteNonQuery();
                conn.Close();
                Session["msg"] = "";
                if (success.Value.ToString() == "1")
                {
                    Session["userID"] = id;
                    if (outType.Value.ToString() == "0")
                    {
                        Response.Redirect("profileGUCian.aspx");
                    }
                    else if (outType.Value.ToString() == "1")
                    {
                        Response.Redirect("profileNonGUCian.aspx");
                    }
                    else if (outType.Value.ToString() == "2")
                    {
                        Response.Redirect("profileSupervisor.aspx");
                    }
                    else if (outType.Value.ToString() == "3")
                    {
                        Response.Redirect("profileExaminer.aspx");
                    }
                    else if (outType.Value.ToString() == "4")
                    {
                        Response.Redirect("profileAdmin.aspx");
                    }

                }
            }
            catch
            {
                loginError.Text = "Invalid Email or Password.";
            }
        }

        protected void registerPage(object sender, EventArgs e)
        {
            Response.Redirect("registerPage.aspx");

        }
    }
}