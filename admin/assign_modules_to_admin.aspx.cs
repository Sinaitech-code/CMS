
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
    public partial class admin_assign_modules_to_admin : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { ////////////////////Security///////////////
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
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fill(ddladmins, "select user_id from mdx_employees where dept_name='admin' and user_id!='superadmin' and status !=1");
                            fun.fnfilllistbox(listmodules, "select module_id,module_name from mdx_form_modules where module_id !=6");

                        }//end of if(!ispostback)
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

            }//end of finally
        }//end  of page load
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblerr_msg.Text = "";
                string str = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("delete from  mdx_admin_module_assign where user_id='" + ddladmins.SelectedValue + "'", cn);
                cmd.ExecuteNonQuery();
                for (int i = 0; i < listmodules.Items.Count; i++)
                {
                    cmd = new SqlCommand("usp_insert_mdx_admin_module_assign", cn);
                    cmd.Parameters.AddWithValue("@user_id", ddladmins.SelectedValue);
                    if (listmodules.Items[i].Selected == true)
                    {
                        str = listmodules.Items[i].Value;
                        cmd.Parameters.AddWithValue("@module_id", str);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        listmodules.Items[i].Selected = false;
                        lblerr_msg.Text = "";
                        lblmessage.Visible = true;
                        lblmessage.Text = "Modules Assigned SuccessFully..!";

                    }//end of if statement

                }//end of for
                ddladmins.SelectedIndex = 0;
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