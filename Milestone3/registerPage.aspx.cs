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
    public partial class registerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerGUCianF(object sender, EventArgs e)
        {
            Response.Redirect("registerGUCian.aspx");
        }

        protected void registerNonGUCianF(object sender, EventArgs e)
        {
            Response.Redirect("registerNonGUCian.aspx");

        }

        protected void registerSupervisorF(object sender, EventArgs e)
        {
            Session["errMsg"] = "";
            Response.Redirect("registerSupervisor.aspx");
        }

        protected void registerExaminerF(object sender, EventArgs e)
        {
            Response.Redirect("registerExaminer.aspx");
        }
    }
}