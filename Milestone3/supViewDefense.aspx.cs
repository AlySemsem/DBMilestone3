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
    public partial class supViewDefense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GUCian_Click(object sender, EventArgs e)
        {
            Session["errMsg"] = "";
            Response.Redirect("AddDefenseGucian.aspx");
        }

        protected void nonGucian_Click(object sender, EventArgs e)
        {
            Session["errMsg"] = "";
            Response.Redirect("AddDefenseNonGucian.aspx");
        }
    }
}