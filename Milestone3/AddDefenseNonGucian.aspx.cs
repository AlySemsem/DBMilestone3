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
    public partial class AddDefenseNonGucian : System.Web.UI.Page
    {
        int isNational;
        //String err1 = "ERROR: Field may be left empty";
        String err2 = "Thesis does not exist, please select a different one.";
        String err3 = "Defense added successfully.";
        String err4 = "Cannot add defense as the student did not score higher than 50% in all courses taken.";
        String err5 = "No field can be left empty";

        protected void Page_Load(object sender, EventArgs e)
        {
            errTB.Text = Session["errMsg"].ToString();
        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
           try
           {
                String connStr = WebConfigurationManager.ConnectionStrings["PostGradOffice"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
            if (TSN.Text == "" || DefD.Text == "" || DefLoc.Text == "" || ExamName.Text == "" || passTB.Text == "" || FoWork.Text == "" || (!RadioButton1.Checked && !RadioButton2.Checked))
            {
                errTB.Text = err5;
            }
            else {
                int ThesisSerialNo = Int16.Parse(TSN.Text);
                DateTime DefenseDate = DateTime.Parse(DD.Text);
                String DefenseLocation = DefLoc.Text;

                String examinerName = ExamName.Text;
                String password = passTB.Text;
                String FieldOfWork = FoWork.Text;

                SqlCommand defNonGUC = new SqlCommand("AddDefenseNonGucian", conn);
                defNonGUC.CommandType = CommandType.StoredProcedure;
                defNonGUC.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));
                defNonGUC.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDate));
                defNonGUC.Parameters.Add(new SqlParameter("@DefenseLocation", DefenseLocation));


                SqlCommand addExaminer = new SqlCommand("AddExaminer", conn);
                addExaminer.CommandType = CommandType.StoredProcedure;
                addExaminer.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));
                addExaminer.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDate));
                addExaminer.Parameters.Add(new SqlParameter("@ExaminerName", examinerName));
                addExaminer.Parameters.Add(new SqlParameter("@Password", password));
                addExaminer.Parameters.Add(new SqlParameter("@National", isNational));
                addExaminer.Parameters.Add(new SqlParameter("@fieldOfWork", FieldOfWork));

                SqlCommand isThesisReg = new SqlCommand("thesisExistNonGUC", conn);
                isThesisReg.CommandType = CommandType.StoredProcedure;
                isThesisReg.Parameters.Add(new SqlParameter("@thesisSN", ThesisSerialNo));

                SqlParameter thesisP = isThesisReg.Parameters.Add("@thesisSuc", System.Data.SqlDbType.Int);
                thesisP.Direction = System.Data.ParameterDirection.Output;

                SqlCommand courseG = new SqlCommand("gradesFifty", conn);
                courseG.CommandType = CommandType.StoredProcedure;
                courseG.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));

                SqlParameter coursEx = courseG.Parameters.Add("@gradeExist", System.Data.SqlDbType.Int);
                coursEx.Direction = System.Data.ParameterDirection.Output;

                SqlCommand defE = new SqlCommand("defExists", conn);
                defE.CommandType = CommandType.StoredProcedure;
                defE.Parameters.Add(new SqlParameter("@defDate", DefenseDate));
                defE.Parameters.Add(new SqlParameter("@TSN", ThesisSerialNo));

                SqlParameter DefExistVal = defE.Parameters.Add("@defExist", System.Data.SqlDbType.Int);
                DefExistVal.Direction = System.Data.ParameterDirection.Output;

                conn.Open();
                isThesisReg.ExecuteNonQuery();
                courseG.ExecuteNonQuery();
                defE.ExecuteNonQuery();
                conn.Close();
              
                    if (thesisP.Value.ToString() == "0")
                    {
                        errTB.Text = err2;
                    }
                    else
                    {
                        if (coursEx.Value.ToString() == "1")

                        {
                            errTB.Text = err4;
                        }
                        else
                        {
                        if (DefExistVal.Value.ToString() == "1")
                        {
                            errTB.Text = "Defense already exists";
                        }
                        else
                        {
                            conn.Open();
                            defNonGUC.ExecuteNonQuery();
                            addExaminer.ExecuteNonQuery();
                            conn.Close();
                            Session["errMsg"] = err3;
                            Response.Redirect("AddDefenseNonGucian.aspx");
                        }
                        }
                    }
            }
            }
           catch
            {
                errTB.Text = "Invalid input.";

            }

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