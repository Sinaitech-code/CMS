using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace CMS
{
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }//end of page load
         //function to check username 
        private bool CheckPassword()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("mdx_usp_check_user_login", cn);
            cmd.Parameters.AddWithValue("@user_id", txtuname.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();
            cn.Close();

            if (obj.ToString() == "0")

                return false;
            else
                return true;
        }//end of function

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            Session["AUserName"] = txtuname.Text.Trim();

            try
            {
                cmd1 = new SqlCommand("select(left(client_id,4)) from mdx_clients where user_id='" + Session["AUserName"] + "'", cn);
                string client_id = (String)cmd1.ExecuteScalar();
                if (client_id!= null && client_id.Trim() == "CLNT")
                {
                    Response.Redirect("clientdisplay.aspx");

                }else
                {

                    if (CheckPassword())
                    {
                        cmd = new SqlCommand("select status from mdx_employees where user_id='" + txtuname.Text + "'", cn);
                        object status = cmd.ExecuteScalar();
                        if (status.ToString().ToUpper() == "FALSE")
                        {
                            cmd2 = new SqlCommand("select dept_name from mdx_employees where user_id='" + txtuname.Text + "'", cn);
                            string dept_name = (String)(cmd2.ExecuteScalar());
                            if (dept_name.ToString().Trim().ToUpper() == "ADMIN")
                            {

                                Response.Redirect("admindefault.aspx?");
                            }//end of if


                            else
                            {

                                Session["AUserName"] = txtuname.Text.Trim();
                                Response.Redirect("Employees/employeedefault.aspx?");

                            }//end of else

                        }//end of if (status.ToString ().ToUpper () == "FALSE")


                    }//end of if (CheckPassword())
                    lblmsg.Visible = true;
                    lblmsg.Text = "Incorrect Password. Please try again.";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }//end of buttonclick
    }//end of class


}


         
         
        


         
        
