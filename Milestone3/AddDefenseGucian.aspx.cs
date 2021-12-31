using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class AddDefenseGucian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            int ThesisSerialNo= Int16.Parse(ThesisSerialNoTB.Text);
            DateTime DefenseDate = DefenseDateC.Text;
            String DefenseLocation = DefenseLocationTB.Text;

            String examinerName = eName.Text;
            String password = pass.Text;
            int isNational;
            String FieldOfWork = fow.Text;

            SqlCommand defGUC = new SqlCommand("AddDefenseGucian", conn);
            defGUC.CommandType = CommandType.StoredProcedure;
            defGUC.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));
            defGUC.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDate));
            defGUC.Parameters.Add(new SqlParameter("@DefenseLocation", DefenseLocation));

            SqlCommand addExaminer = new SqlCommand("AddExaminer", conn);
            addExaminer.CommandType = CommandType.StoredProcedure;
            addExaminer.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));
            addExaminer.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDate));
            addExaminer.Parameters.Add(new SqlParameter("@ExaminerName", examinerName));
            addExaminer.Parameters.Add(new SqlParameter("@Password", password));
            addExaminer.Parameters.Add(new SqlParameter("@National", isNational));
            addExaminer.Parameters.Add(new SqlParameter("@fieldOfWork", FieldOfWork));

            conn.Open();
            defGUC.ExecuteNonQuery();
            addExaminer.ExecuteNonQuery();
            conn.Close();
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isNational = 1;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isNational = 0;
        }
    }
}