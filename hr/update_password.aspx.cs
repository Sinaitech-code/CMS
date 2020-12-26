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
    //Summary description for HR_update_password
    public partial class HR_update_password : System.Web.UI.Page
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
                    {
                        lblemp.Text = Session["AUserName"].ToString();
                        lbldate.Text = DateTime.Now.ToShortDateString();
                        string strempid = Request.QueryString["emp_id"].ToString();
                        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                        cn.Open();
                        cmd = new SqlCommand("select user_id from mdx_users where emp_id='" + strempid + "'", cn);
                        string userid = (String)cmd.ExecuteScalar();
                        txtuname.Text = userid;
                    } // end of if (ck == true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                } //end of  if(Session["User_Id"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                } //end of else if(Session["User_Id"]!=null)
            }
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
        }//end of page load
         //btnsave_Click to update the password
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
                lblmsg.Text = "password reset";
                lblmsg.Visible = true;
            } //end of try
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

            }//end of finally
        }// end of btnsave_Click
    }//end of class HR_update_password
}