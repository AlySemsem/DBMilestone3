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
    public partial class registerExaminer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int isnational;
            String name = ExaminerName.Text;
            int serialno = Int16.Parse(ThesisSerialNo.Text);
            String pass = password.Text;
            String field = fieldOfWork.Text;
            DateTime date = DateTime.Parse(defdate.Text);
            if (RadioButton1.Checked)
            {
                isnational = 1;
            }
            else
            {
                isnational = 0;
            }
            SqlCommand ExaminerRegister = new SqlCommand("registerExaminer", conn);
            ExaminerRegister.CommandType = System.Data.CommandType.StoredProcedure;
            ExaminerRegister.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialno));
            ExaminerRegister.Parameters.Add(new SqlParameter("@DefenseDate", date));
            ExaminerRegister.Parameters.Add(new SqlParameter("@Password", pass));
            ExaminerRegister.Parameters.Add(new SqlParameter("@ExaminerName", name));
            ExaminerRegister.Parameters.Add(new SqlParameter("@National", isnational));
            ExaminerRegister.Parameters.Add(new SqlParameter("@fieldOfWork", field));

            conn.Open();
            ExaminerRegister.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("profileExaminer.aspx");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Text = "Yes";
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Text = "No";
        }
    }
}