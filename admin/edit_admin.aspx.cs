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
    public partial class admin_edit_admin : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////////////////////////Security///////////////
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
                        //// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlemp_grade, "select grade_id,grade_name from mdx_employee_grade");
                            fun.fnfill(ddlemp_type, "select employee_type_id,employee_type from mdx_employee_type");
                            display();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)
                }//end of if
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else if (Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch
            finally
            {


            }//end of finally
        }//end of page load
         //function to display all the data 


        private void display()
        {
            string str = Request.QueryString["emp_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_display_mdx_admin_details", cn);
            cmd.Parameters.AddWithValue("@emp_id", str);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtemp_id.Text = dr["emp_id"].ToString();
                ddlemp_grade.SelectedValue = dr["grade_id"].ToString();
                ddlemp_type.SelectedValue = dr["emp_type"].ToString();
                txtempf_name.Text = dr["first_name"].ToString();
                txtempm_name.Text = dr["middle_name"].ToString();
                txtempl_name.Text = dr["last_name"].ToString();
                rbtngender.SelectedValue = dr["gender"].ToString();
                txtcity.Text = dr["city"].ToString();
                txtstate.Text = dr["state"].ToString();
                txtjoin_date.Text = dr["joining_date"].ToString();
                txtqualif.Text = dr["qualification"].ToString();
                txtexp.Text = dr["experience"].ToString();
                txtaddress1.Text = dr["address1"].ToString();
                txtaddress2.Text = dr["address2"].ToString();
                txtphone1.Text = dr["phone1"].ToString();
                txtphone2.Text = dr["phone2"].ToString();
                txtemail.Text = dr["email"].ToString();

            }//end of while
            dr.Close();


        }//end of function

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                lblerr_msg.Text = "";

                string str = Request.QueryString["emp_id"].ToString();
                string status = "false";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_admin_details", cn);
                cmd.Parameters.AddWithValue("@emp_id", str);
                cmd.Parameters.AddWithValue("@emp_type", ddlemp_type.SelectedValue);
                cmd.Parameters.AddWithValue("@grade_id", ddlemp_grade.SelectedValue);
                cmd.Parameters.AddWithValue("@first_name", txtempf_name.Text);
                cmd.Parameters.AddWithValue("@middle_name", txtempm_name.Text);
                cmd.Parameters.AddWithValue("@last_name", txtempl_name.Text);
                cmd.Parameters.AddWithValue("@gender", rbtngender.SelectedValue);
                cmd.Parameters.AddWithValue("@joining_date", txtjoin_date.Text);
                cmd.Parameters.AddWithValue("@qualification", txtqualif.Text);
                cmd.Parameters.AddWithValue("@experience", txtexp.Text);
                cmd.Parameters.AddWithValue("@address1", txtaddress1.Text);
                cmd.Parameters.AddWithValue("@address2", txtaddress2.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@state", txtstate.Text);
                cmd.Parameters.AddWithValue("@phone1", txtphone1.Text);
                cmd.Parameters.AddWithValue("@phone2", txtphone2.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@emp_name", txtempf_name.Text + " " + txtempm_name.Text + " " + txtempl_name.Text);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = " Admin Updated SuccessFully..!";

            }//end of try

            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        }//end of btnsave_Click



    }//end of class

}