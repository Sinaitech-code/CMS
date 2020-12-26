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
    //Summary description for HR_edit_employee
    public partial class HR_edit_employee : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        functions fun = new functions();
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
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
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlemp_grade, "select grade_id,grade_name from mdx_employee_grade");
                            fun.fnfill(ddlemp_type, "select employee_type_id,employee_type from mdx_employee_type");
                            fun.fnfill(ddldept_name, "select dept_id,dept_name from mdx_departments");
                            bindgender();
                            display();

                        }//end of if(!IsPostBack)
                    } //end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of  if(Session["User_Id"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else if(Session["User_Id"]!=null)
            }//end of try
            catch (Exception ex)
            {
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {


            }//end of finally
        }//end of page load
         //function  display  to get the data from database and display for edit
        private void display()
        {

            try
            {
                string str = Request.QueryString["emp_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_employees", cn);
                cmd.Parameters.AddWithValue("@emp_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtempid.Text = dr["emp_id"].ToString();
                    ddldept_name.SelectedItem.Text = dr["dept_name"].ToString();
                    ddlemp_grade.SelectedValue = dr["grade_id"].ToString();
                    ddlemp_type.SelectedValue = dr["emp_type"].ToString();
                    txtempf_name.Text = dr["first_name"].ToString();
                    txtempm_name.Text = dr["middle_name"].ToString();
                    txtempl_name.Text = dr["last_name"].ToString();
                    rbtngender.SelectedValue = dr["gender"].ToString();
                    //ViewState ["date"] = dr["dob"].ToString();
                    //ViewState["month"] = ViewState["date"];
                    //ViewState["year"] = ViewState["date"];
                    txtjoin_date.Text = dr["joining_date"].ToString();
                    txtqualif.Text = dr["qualification"].ToString();
                    txtexp.Text = dr["experience"].ToString();
                    txtaddress1.Text = dr["address1"].ToString();
                    txtaddress2.Text = dr["address2"].ToString();
                    txtcity.Text = dr["city"].ToString();
                    txtstate.Text = dr["state"].ToString();
                    txtphone1.Text = dr["phone1"].ToString();
                    txtphone2.Text = dr["phone2"].ToString();
                    txtemail.Text = dr["email"].ToString();

                }//end of while loop
                dr.Close();
            } //end of try
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally

        }//end of function display

        // function  bindgender to bind gender to dropdown 
        private void bindgender()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select gender from gender", cn);
            ds = new DataSet();
            da.Fill(ds, "gender");
            rbtngender.DataTextField = "gender";
            rbtngender.DataValueField = "gender";
            rbtngender.DataSource = ds.Tables["gender"];
            rbtngender.DataBind();
            cn.Close();

        }//end of function bindgender

        //function updateempdetails to update the employee details
        private void updateempdetails()
        {
            try
            {

                string str = Request.QueryString["emp_id"].ToString();
                string status = "false";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_employees", cn);
                cmd.Parameters.AddWithValue("@emp_id", str);
                cmd.Parameters.AddWithValue("@dept_name", ddldept_name.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@grade_id", ddlemp_grade.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_type", ddlemp_type.SelectedValue);
                cmd.Parameters.AddWithValue("@first_name", txtempf_name.Text);
                cmd.Parameters.AddWithValue("@middle_name", txtempm_name.Text);
                cmd.Parameters.AddWithValue("@last_name", txtempl_name.Text);
                cmd.Parameters.AddWithValue("@emp_name", txtempf_name.Text + " " + txtempm_name.Text + " " + txtempl_name.Text);
                cmd.Parameters.AddWithValue("@gender ", rbtngender.SelectedValue);
                //cmd.Parameters.AddWithValue("@dob", ddldate.SelectedValue + "/" + ddlmonth.SelectedValue + "/" + ddlyear.SelectedValue);
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
                // cmd.Parameters.AddWithValue("@user_id", );
                cmd.Parameters.AddWithValue("@status", status);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Employee Updated SuccessFully..!";
                //Response.Write("<script language='javascript'>alert('Employee Updated SuccessFully..!' )</script>");

            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        }
        // btnsave_Click  updates employee details
        protected void btnsave_Click(object sender, EventArgs e)
        {
            updateempdetails();
        }// end of btnsave_Click
    }//end of class HR_edit_employee
}