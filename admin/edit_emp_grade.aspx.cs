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
    public partial class Masterpages_edit_emp_grade : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    //////////////////////////////////Security///////////////
                    if (ck == true)
                    {//// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            displayempgrade();

                        }//end of if(!ispostback)

                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)


                }//end of if((Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else if(Session["AUserName"] != null)
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
         //function to display emp grade information
        private void displayempgrade()
        {
            string str = Request.QueryString["grade_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_display_mdx_employee_grade", cn);
            cmd.Parameters.AddWithValue("@grade_id", str);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txtempgrade.Text = dr["grade_name"].ToString();
                txtdescription.Text = dr["description"].ToString();


            }//end of while
            dr.Close();
            cn.Close();

        }//end of function 
         //function to edit the empgrade details 
        private void Editempgrade()
        {
            string str = Request.QueryString["grade_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_update_mdx_employee_grade", cn);
            cmd.Parameters.AddWithValue("@grade_id", str);
            cmd.Parameters.AddWithValue("@grade_name", txtempgrade.Text);
            cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();


        }//end of function Editempgrade()
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblerr_msg.Text = "";
                Editempgrade();
                lblmessage.Visible = true;
                lblmessage.Text = "Employee Grade Updated SuccessFully..!";


            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString(); ;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        }//end of button click
    }//end of class
}