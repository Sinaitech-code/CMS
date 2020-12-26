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
using System.Text;

namespace CMS.projects
{
    public partial class Projects_add_sub_project : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////////security//////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    if (ck == true)
                    {//////////////security/////////////

                        if (!IsPostBack)
                        {
                            fun.fnfill(ddlproj_id, "select project_id,project_name from mdx_projects");
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                        }//end of postback
                    }//end of if(ck==true)

                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(session["AUserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }//end of try
            catch (Exception ex)
            {
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {


            }//end of finally
        }//end of pageload
         //fun to check whether the subproj is already exist or not
        private bool check_subproject()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from  mdx_sub_projects  where sub_project_name='" + txtsub_projname.Text + "'and project_id='" + ddlproj_id.SelectedValue + "' ", cn);
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
                lblcheck.Text = " Sub Project Already Exists....Please Try Another Sub Project";
                return false;
            }
        }//end of check_subproject()
         //code for insert subproj details
        private void insertsub_proj()
        {
            try
            {
                if (check_subproject())
                {
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("usp_insert_mdx_sub_projects", cn);
                    cmd.Parameters.AddWithValue("@project_id", ddlproj_id.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@sub_project_name ", txtsub_projname.Text);
                    cmd.Parameters.AddWithValue("@project_start_date", txtsdate.Text);
                    cmd.Parameters.AddWithValue("@project_end_date", txtfinishingate.Text);
                    cmd.Parameters.AddWithValue("@user_id", Session["AUserName"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    lblcheck.Visible = true;
                    lblcheck.Text = "";

                    lblmessage.Text = "Sub Project Inserted SuccessFully..!";
                    // Response.Write("<script language='javascript'>alert('Sub ProjectInserted SuccessFully..!' )</script>");
                }
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            } //end of finally

        }//end of insertsub_proj()
         //code to insert sub_proj details and clear all the fields
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            insertsub_proj();
            lblerr_msg.Text = "";
            lblmessage.Visible = true;
            txtfinishingate.Text = "";
            txtsub_projname.Text = "";
            txtsdate.Text = "";
            ddlproj_id.SelectedIndex = 0;

        }


    }
}