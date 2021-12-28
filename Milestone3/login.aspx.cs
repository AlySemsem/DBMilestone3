using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUC_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            int id = Int16.Parse(ID.Text);
            String pass = password.Text;

            SqlCommand loginproc = new SqlCommand("userLogin", conn);
            loginproc.CommandType = System.Data.CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@id", id));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter success = loginproc.Parameters.Add("@success", System.Data.SqlDbType.Int);
            SqlParameter type = loginproc.Parameters.Add("@type", System.Data.SqlDbType.Int);

            success.Direction = System.Data.ParameterDirection.Output;
            type.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "1")
            {
                Response.Write("Hello");
                //Response.Redirect("registerGUCian.aspx");

            }
        }
    }
}