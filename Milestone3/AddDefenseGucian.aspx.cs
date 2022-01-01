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
        int isNational;
        String err1= "No field can be left empty.";
        String err2 = "Thesis does not exist, please select a different one.";
        String err3= "Defense added successfully.";

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
                    errTB.Text = err1;
                }
                else {
                    int ThesisSerialNo = Int16.Parse(TSN.Text);
                    DateTime DefenseDate = DateTime.Parse(DefD.Text);
                    String DefenseLocation = DefLoc.Text;

                    String examinerName = ExamName.Text;
                    String password = passTB.Text;
                    String FieldOfWork = FoWork.Text;

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

                    SqlCommand isThesisReg = new SqlCommand("thesisExistGUC", conn);
                    isThesisReg.CommandType = CommandType.StoredProcedure;
                    isThesisReg.Parameters.Add(new SqlParameter("@thesisSN", ThesisSerialNo));

                    SqlParameter thesisP = isThesisReg.Parameters.Add("@thesisSuc", System.Data.SqlDbType.Int);
                    thesisP.Direction = System.Data.ParameterDirection.Output;

                    SqlCommand defE = new SqlCommand("defExists", conn);
                    defE.CommandType = CommandType.StoredProcedure;
                    defE.Parameters.Add(new SqlParameter("@defDate", DefenseDate));
                    defE.Parameters.Add(new SqlParameter("@TSN", ThesisSerialNo));

                    SqlParameter DefExistVal = defE.Parameters.Add("@defExist", System.Data.SqlDbType.Int);
                    DefExistVal.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    isThesisReg.ExecuteNonQuery();
                    defE.ExecuteNonQuery();
                    conn.Close();

                        if (thesisP.Value.ToString() == "0")
                        {
                            errTB.Text = err2;
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
                                defGUC.ExecuteNonQuery();
                                addExaminer.ExecuteNonQuery();
                                conn.Close();
                                Session["errMsg"] = err3;
                                Response.Redirect("AddDefenseGucian.aspx");
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