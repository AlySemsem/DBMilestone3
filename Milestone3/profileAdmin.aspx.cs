using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class profileAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            conn = new SqlConnection(connStr);
            conn.Open();
            DisplaySupervisors();

            conn.Close();



        }

        protected void DisplaySupervisors()
        {
            SqlCommand supervisorList = new SqlCommand("AdminListSup", conn);
            supervisorList.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = supervisorList.ExecuteReader(CommandBehavior.CloseConnection);

            Control supervisorBody = FindControl("supervisorBody");

            while (reader.Read())
            {
                HtmlTableRow supervisorRow = new HtmlTableRow();

                HtmlTableCell idCell = new HtmlTableCell();
                idCell.InnerText = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                supervisorRow.Cells.Add(idCell);

                HtmlTableCell nameCell = new HtmlTableCell();
                nameCell.InnerText = reader.GetString(reader.GetOrdinal("name"));
                supervisorRow.Cells.Add(nameCell);

                HtmlTableCell mailCell = new HtmlTableCell();
                mailCell.InnerText = reader.GetString(reader.GetOrdinal("email"));
                supervisorRow.Cells.Add(mailCell);

                HtmlTableCell passCell = new HtmlTableCell();
                passCell.InnerText = reader.GetString(reader.GetOrdinal("password"));
                supervisorRow.Cells.Add(passCell);

                HtmlTableCell facultyCell = new HtmlTableCell();
                facultyCell.InnerText = reader.GetString(reader.GetOrdinal("faculty"));
                supervisorRow.Cells.Add(facultyCell);

                supervisorBody.Controls.Add(supervisorRow);
            }

        }

        protected void DisplayThesis()
    }
}