using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace CMS.HR
{
    //Summary description for HR_create_employee
    public partial class HR_create_employee_ : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        functions fun = new functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////Security///////////////

                if (Session["AUserName"] != null)

                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ////////////////////Security///////////////
                    if (ck == true)
                    {

                        // Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            fun.fnfill(ddlemp_grade, "select distinct grade_id,grade_name from mdx_employee_grade");
                            fun.fnfill(ddlemp_type, "select distinct employee_type_id,employee_type from mdx_employee_type");
                            fun.fnfill(ddldept_name, "select  distinct dept_id,dept_name from mdx_departments where dept_name!='admin'");
                            //fun.fnfill(ddlrole, "select role_id,role_name from mdx_roles");
                            txtemp_id.Text = empautonum();


                        }//end of 	if(!IsPostBack)
                        lblemp.Text = Session["AUserName"].ToString();

                    }//end of  if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }

                }//end of if(Session["User_Id"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else if(Session["User_Id"]!=null)

            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");

            }//end of 	catch
            finally
            {


            } //end of 	finally

        }//end of pageload
         // function empautonum generates autogeneration code
        public string empautonum()
        {
            string empid;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_autonum_mdx_employees", cn);
            strm = cmd1.Parameters.Add("@emp_id", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            empid = (string)cmd1.Parameters["@emp_id"].Value;
            return (empid);
            cn.Close();
        }//end of 	empautonum() function

        //function insert to save employee information into database
        private void insert()
        {
            string status = "false";
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_mdx_users", cn);
            cmd1.Parameters.AddWithValue("@emp_id", txtemp_id.Text);
            //cmd1.Parameters.AddWithValue("@role_id", ddlrole.SelectedValue);
            cmd1.Parameters.AddWithValue("@user_id", txtuser_name.Text);
            cmd1.Parameters.AddWithValue("@password", txtpwd.Text);
            cmd1.Parameters.AddWithValue("@conform_password", txtcpwd.Text);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            cmd = new SqlCommand("usp_insert_mdx_employees", cn);
            cmd.Parameters.AddWithValue("@emp_id", txtemp_id.Text);
            cmd.Parameters.AddWithValue("@dept_name", ddldept_name.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@grade_id", ddlemp_grade.SelectedValue);
            cmd.Parameters.AddWithValue("@emp_type", ddlemp_type.SelectedValue);
            cmd.Parameters.AddWithValue("@first_name", txtempf_name.Text);
            cmd.Parameters.AddWithValue("@middle_name", txtempm_name.Text);
            cmd.Parameters.AddWithValue("@last_name", txtempl_name.Text);
            cmd.Parameters.AddWithValue("@emp_name", txtempf_name.Text + " " + txtempm_name.Text + " " + txtempl_name.Text);
            cmd.Parameters.AddWithValue("@gender ", rbtngender.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@dob", ddldate.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlyear.SelectedValue);
            cmd.Parameters.AddWithValue("@qualification", txtqualif.Text);
            cmd.Parameters.AddWithValue("@experience", txtexp.Text);
            cmd.Parameters.AddWithValue("@joining_date", txtjoin_date.Text);
            cmd.Parameters.AddWithValue("@address1", txtaddress1.Text);
            cmd.Parameters.AddWithValue("@address2", txtaddress2.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@phone1", txtphone1.Text);
            cmd.Parameters.AddWithValue("@phone2", txtphone2.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@user_id", txtuser_name.Text);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            lblerr_msg.Text = "";
            lblmessage.Visible = true;
            lblmessage.Text = " Employee Inserted SuccessFully..!";
            // Response.Write("<script language='javascript'>alert('Employee Inserted SuccessFully..!' )</script>");

            txtaddress1.Text = "";
            txtaddress2.Text = "";
            txtcity.Text = "";
            txtcpwd.Text = "";
            txtemail.Text = "";
            txtemp_id.Text = empautonum();
            txtempf_name.Text = "";
            txtempl_name.Text = "";
            txtempm_name.Text = "";
            txtexp.Text = "";
            txtjoin_date.Text = "";
            txtphone1.Text = "";
            txtphone2.Text = "";
            txtpwd.Text = "";
            txtqualif.Text = "";
            txtstate.Text = "";
            txtuser_name.Text = "";
            ddldate.SelectedIndex = 0;
            ddldept_name.SelectedIndex = 0;
            ddlemp_grade.SelectedIndex = 0;
            ddlemp_type.SelectedIndex = 0;
            ddlmonth.SelectedIndex = 0;
            ddlyear.SelectedIndex = 0;
            cn.Close();
        }//end of 	insert() function

        //inserts employee information into database
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                insert();
            }//end of 	try
            catch (Exception ex)
            {
                // display message if user_id exists        
                if (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
                {
                    //lblerr_msg.Text =("<script language='javascript'>alert('This UserId is already Exist,Choose Another ID')</script>");
                    lblerr_msg.Text = "This UserId is already Exist,Choose Another ID";
                }//end of if (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
                else
                {
                    lblerr_msg.Text = ex.Message.ToString();
                } //end of else if  (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of 	finally
        }//end of btnsave_Click

    }//end of class HR_create_employee 
}