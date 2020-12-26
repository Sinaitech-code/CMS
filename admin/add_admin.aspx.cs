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

namespace CMS.admin
{
    public partial class admin_add_admin : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        SqlCommand cmd1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ////////////////////Security///////////////
            if (Session["AUserName"] != null)
            {
                try
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
                        {//  // Put user code to initialize the page here

                            fun.fnfill(ddlemp_grade, "select  distinct grade_id,grade_name from mdx_employee_grade");
                            fun.fnfill(ddlemp_type, "select distinct employee_type_id,employee_type from mdx_employee_type");
                            txtemp_id.Text = empautonum();//call the empautonum() in the textbox
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            lblempname.Text = Session["AUserName"].ToString();

                        }//end of if (!ispostback)
                    }//end of if (ck)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if (ck==true)

                }//end of try
                catch (Exception ex)
                {
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = ex.Message.ToString();

                }//end of catch


                finally
                {

                }//end of finally
            }//end of if(Session["AUserName"] != null)
            else
            {
                Response.Redirect("../Default.aspx");
            } //end of else if(Session["AUserName"] != null) 
        }//end of page load

        //function empautonum generates autogeneration code
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
        }//end of empautonum()
         //function insert to save Admin information into database
        private void insert()
        {
            ViewState["role_id"] = 4;
            ViewState["dept"] = "admin";

            string status = "false";
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();

            cmd1 = new SqlCommand("usp_insert_mdx_admin_login", cn);
            cmd1.Parameters.AddWithValue("@emp_id", txtemp_id.Text);
            cmd1.Parameters.AddWithValue("@role_id", ViewState["role_id"].ToString());
            cmd1.Parameters.AddWithValue("@user_id", txtuser_name.Text);
            cmd1.Parameters.AddWithValue("@password", txtpwd.Text);
            cmd1.Parameters.AddWithValue("@conform_password", txtcpwd.Text);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            cmd = new SqlCommand("usp_insert_admin_details", cn);
            cmd.Parameters.AddWithValue("@emp_id", txtemp_id.Text);
            cmd.Parameters.AddWithValue("@dept_name", ViewState["dept"].ToString());
            cmd.Parameters.AddWithValue("@grade_id", ddlemp_grade.SelectedValue);
            cmd.Parameters.AddWithValue("@emp_type", ddlemp_type.SelectedValue);
            cmd.Parameters.AddWithValue("@first_name", txtempf_name.Text);
            cmd.Parameters.AddWithValue("@middle_name", txtempm_name.Text);
            cmd.Parameters.AddWithValue("@last_name", txtempl_name.Text);
            cmd.Parameters.AddWithValue("@emp_name", txtempf_name.Text + " " + txtempm_name.Text + " " + txtempl_name.Text);
            cmd.Parameters.AddWithValue("@gender", rbtngender.SelectedItem.Value);
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
            cn.Close();
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
            ddlemp_grade.SelectedIndex = 0;
            ddlemp_type.SelectedIndex = 0;
            ddlmonth.SelectedIndex = 0;

            ddlyear.SelectedIndex = 0;
        }//end of insert()

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                insert();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = " Admin Inserted SuccessFully..!";
            }
            catch (Exception ex)
            {


                if (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "";
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "This UserId is already Exist,Choose Another ID";
                }
                else
                {
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = ex.Message.ToString();
                }
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally
        }//end of btnclick

    }//end of class
}