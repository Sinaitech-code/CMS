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
    public partial class admin1_edit_department : System.Web.UI.Page
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
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            display();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)



                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else

                }//end of if(Session["AUserName"] != null)
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
         //function to display dept information

        private void display()
        {
            string str = Request.QueryString["dept_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_display_mdx_departments", cn);
            cmd.Parameters.AddWithValue("@dept_id", str);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txtdeptname.Text = dr["dept_name"].ToString();
                txtdescription.Text = dr["description"].ToString();
            }//end of while 
            dr.Close();
            cn.Close();
        }//end of function display()
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblerr_msg.Text = "";
                EditDepartment();
                lblmessage.Visible = true;
                lblmessage.Text = "Department Updated SuccessFully..!";


            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                //lblerr_msg.Text = "Already Exists... Please Try Again";

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally

        }//end of button click
         //function to update dept details

        private void EditDepartment()
        {
            string str = Request.QueryString["dept_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_update_mdx_departments", cn);
            cmd.Parameters.AddWithValue("@dept_id", str);
            cmd.Parameters.AddWithValue("@dept_name", txtdeptname.Text);
            cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

        }//end of function
    }//end of class
}