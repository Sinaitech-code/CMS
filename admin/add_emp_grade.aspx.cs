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
    public partial class Masterpages_add_emp_grade : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
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
                    {// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                        }//end of if(!ispostback)

                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else

                }//end of if (Session["AUserName"] != null)
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


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkavaliable())
                {
                    lblcheck.Text = "";
                    insertgrade();
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Employee Grade Inserted SuccessFully..!";

                }//end of if

            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString(); ;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        }//end  of button click
         //function to check grade information in the database
        private bool checkavaliable()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from  mdx_employee_grade where  grade_name='" + txtempgrade.Text + "'", cn);
            object obj = cmd.ExecuteScalar();
            if (obj.ToString() == "0")
            {

                return true;
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblcheck.Visible = true;
                lblcheck.Text = "Gradename Already Exists....Please Try Another Gradename";
                return false;
            }
        }//end of function
         //function to insert grade information in the database
        private void insertgrade()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_insert_mdx_employee_grade", cn);
            cmd.Parameters.AddWithValue("@grade_name", txtempgrade.Text);
            cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cn.Close();
            txtempgrade.Text = "";
            txtdescription.Text = "";
            lblmessage.Text = "";
        }//end of function


    }//end of class
}