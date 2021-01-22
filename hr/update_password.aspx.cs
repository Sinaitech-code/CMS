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
        SqlCommand cmd1;
        string strempid;
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
                        string username;
                        if (Request.QueryString["emp_id"]!= null)
                        {
                             cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                             cn.Open();
                             cmd = new SqlCommand("select user_id from mdx_users where emp_id='" + Request.QueryString["emp_id"].ToString() + "'", cn);
                             username = (String)cmd.ExecuteScalar(); 
                        }
                        else
                        {
                            username = Session["AUserName"].ToString();
                        }
                        //string strempid = Convert.ToBoolean(Request.QueryString["emp_id"]) ? Request.QueryString["emp_id"].ToString():"";
                       
                        // string strempid = empautonum();
                        // cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                        // cn.Open();
                        // cmd = new SqlCommand("select user_id from mdx_users where emp_id='" + strempid + "'", cn);
                        //string userid = (String)cmd.ExecuteScalar();
                        ////if (strempid!="")
                        ////{
                        ////    username = strempid;
                        ////}else
                        ////{
                        ////    username = Session["AUserName"].ToString(); 
                        ////}
                        txtuname.Text = username;
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
                //cn.Close();
                //cn.Dispose();

            }//end of finally
        }//end of page load
         //btnsave_Click to update the password

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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string empid;
                if (Request.QueryString["emp_id"] != "")
                {
                    empid = Request.QueryString["emp_id"].ToString();
                }
                else
                {
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("select emp_id from mdx_users where user_id='" + Session["AUserName"].ToString() + "'", cn);
                    empid = (String)cmd.ExecuteScalar();
                    cn.Close();
                }
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_mdx_update_resetpwd", cn);
                cmd.Parameters.AddWithValue("@emp_id", empid);
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