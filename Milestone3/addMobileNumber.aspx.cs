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
    public partial class addMobileNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgTB.Text = Session["errMsg"].ToString();
        }
    protected void AddBtn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

                if (mobNoTB.Text == "")
                {
                    msgTB.Text = "Please enter a mobile number";
                }
                else
                {
                    SqlCommand gettingUserID = new SqlCommand("getUserID", conn);
                    gettingUserID.CommandType = System.Data.CommandType.StoredProcedure;
                    gettingUserID.Parameters.Add(new SqlParameter("@email", Session["email"].ToString()));

                    SqlParameter userID = gettingUserID.Parameters.Add("@userID", System.Data.SqlDbType.Int);
                    userID.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    gettingUserID.ExecuteNonQuery();
                    conn.Close();

                    int id = Int16.Parse(userID.Value.ToString());
                    int mobNo = Int32.Parse(mobNoTB.Text);

                    SqlCommand addMob = new SqlCommand("addMobile", conn);
                    addMob.CommandType = System.Data.CommandType.StoredProcedure;
                    addMob.Parameters.Add(new SqlParameter("@ID", id));
                    addMob.Parameters.Add(new SqlParameter("@mobile_number", mobNo));

                    conn.Open();
                    addMob.ExecuteNonQuery();
                    conn.Close();

                    Session["errMsg"] = "Mobile number added successfully";
                    Response.Redirect("addMobileNumber.aspx");
                }

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}