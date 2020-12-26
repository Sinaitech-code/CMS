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

namespace CMS
{

    public partial class changepassword : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;


        protected void Page_Load(object sender, EventArgs e)
        {
            txtuname.Text = Session["AUserName"].ToString();
            lblemp.Text = Session["AUserName"].ToString();
            lbldate.Text = DateTime.Now.ToShortDateString();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd1 = new SqlCommand("select(left(client_id,4)) from mdx_clients where user_id='" + Session["AUserName"] + "'", cn);
                string client_id = (String)cmd1.ExecuteScalar();
                if (client_id.Trim() == "CLNT")
                {
                    change_client_pwd();

                }
                else
                {

                    lblmsg.Text = "Please Try Again";
                    lblmsg.Visible = true;
                }
            }

            catch (Exception ex)
            {

                change_emp_pwd();

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        private void change_client_pwd()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("select password from mdx_clients where user_id='" + Session["AUserName"] + "'", cn);
                string pwd = (String)cmd.ExecuteScalar();
                if (txtoldpwd.Text.Trim() == pwd)
                {
                    cmd1 = new SqlCommand("update mdx_clients set password='" + txtnewpwd.Text + "',conformpassword='" + txtcpwd.Text + "'where user_id='" + Session["AUserName"] + "'", cn);
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                    lblmsg.Visible = true;
                    lblmsg.Text = "Your password is changed SuccessFully";
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "You have entered wrong password";

                }
            }
            catch (Exception ex)
            {
                lblmsg.Visible = true;
                lblmsg.Text = ex.Message.ToString();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }

        private void change_emp_pwd()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("select password from mdx_users where user_id='" + Session["AUserName"] + "'", cn);
                string pwd = (String)cmd.ExecuteScalar();
                if (txtoldpwd.Text == pwd)
                {
                    cmd1 = new SqlCommand("update mdx_users set password='" + txtnewpwd.Text + "',conform_password='" + txtcpwd.Text + "' where user_id='" + Session["AUserName"] + "'", cn);
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                    lblmsg.Visible = true;
                    lblmsg.Text = "password changed SuccessFully";
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "entered wrong password";

                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message.ToString();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }

    }

}