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
    public partial class HR_update_password : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    /////////////////////////////////////////////////////Security///////////////
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {
                        //// Put user code to initialize the page here
                        lblemp.Text = Session["AUserName"].ToString();
                        lbldate.Text = DateTime.Now.ToShortDateString();
                        string strempid = Request.QueryString["emp_id"].ToString();
                        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                        cn.Open();
                        cmd = new SqlCommand("select user_id from mdx_users where emp_id='" + strempid + "'", cn);
                        string userid = (String)cmd.ExecuteScalar();
                        txtuname.Text = userid;
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else  if(ck==true)
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
                cn.Close();
                cn.Dispose();
            }//end of finally
        }//end of page load
        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                string str = Request.QueryString["emp_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_mdx_update_resetpwd", cn);
                cmd.Parameters.AddWithValue("@emp_id", str);
                cmd.Parameters.AddWithValue("@password", txtnewpwd.Text);
                cmd.Parameters.AddWithValue("@conform_password", txtcpwd.Text);
                cmd.Parameters.AddWithValue("@password_reset_by", Session["AUserName"].ToString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblmsg.Text = "password was reset";
                lblmsg.Visible = true;
            }//end of try
            catch (Exception ex)
            {

                //Response.Write("<script language='javascript'>alert('" + oe.Message.ToString() + "' )</script>");
                lblmsg.Text = ex.Message.ToString();
                lblmsg.Visible = true;
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end  of finally

        }//end of button click
    }//end of class
}