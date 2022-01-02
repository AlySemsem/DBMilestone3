using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Milestone3
{
    public partial class profileSupervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Students(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudentYears.aspx");
        }

        protected void Publications(object sender, EventArgs e)
        {
            Session["errMsg"] = "";
            Response.Redirect("supViewPublications.aspx");
        }

        protected void Defense(object sender, EventArgs e)
        {
            Session["msg"] = "";
            Response.Redirect("supViewDefense.aspx");
        }

        protected void PR(object sender, EventArgs e)
        {
            Session["msg"] = "";
            Response.Redirect("supViewProgreports.aspx");
        }

        protected void Thesis(object sender, EventArgs e)
        {
            Session["errMsg"] = "";
            Response.Redirect("supCancelThesis.aspx");
        }
    }
}