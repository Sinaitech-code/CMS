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

namespace CMS.projects
{
    public partial class Masterpages_add_project_levels : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {////////////security////////////
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
                    {////////security////////////////
                     //put the user code to initialize the page
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlprojects, "select project_id,project_name from mdx_projects");
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(session["AuserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//End of catch
            finally
            {

            }//end of finally
        }//end of pageload
         //fun to check project levels
        private bool check_proj_levels()

        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*) from  mdx_project_levels where level_name='" + txtprojectlevel.Text + "' and sub_project_id='" + ddlsubproject.SelectedValue + "' ", cn);
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
                lblcheck.Text = "Level Already Exists....Please Try Another Level";
                return false;
            }

        }//end of check function
         //fun to insert the projectlevel details
        private void insertdata()
        {
            try
            {
                if (check_proj_levels())
                {
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("usp_insert_mdx_project_levels", cn);
                    cmd.Parameters.AddWithValue("@project_id", ddlprojects.SelectedValue);
                    cmd.Parameters.AddWithValue("@sub_project_id", ddlsubproject.SelectedValue);
                    cmd.Parameters.AddWithValue("@level_name", txtprojectlevel.Text);
                    cmd.Parameters.AddWithValue("@project_start_date", txtstartingdate.Text);
                    cmd.Parameters.AddWithValue("@project_end_date", txtfinishingdate.Text);
                    cmd.Parameters.AddWithValue("@user_id", Session["AUserName"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    lblcheck.Visible = true;
                    lblcheck.Text = "";
                    lblerr_msg.Text = "";
                    lblerr_msg.Visible = true;
                    lblmessage.Visible = true;
                    lblmessage.Text = "Project Levels Inserted SuccessFully..!";

                }//end of check_proj_levels()

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


        }
        //event ddlproj_selectedindexchenged to load the subprojects when ddlprojects selected index chenged
        protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects where project_id='" + ddlprojects.SelectedValue + "'");
        }
        //to save the project level details and to clear all the fields
        protected void btnsave_Click(object sender, EventArgs e)
        {

            insertdata();
            lblerr_msg.Visible = true;
            lblerr_msg.Text = "";
            txtfinishingdate.Text = "";
            txtprojectlevel.Text = "";
            txtstartingdate.Text = "";
            ddlprojects.SelectedIndex = 0;
            ddlsubproject.SelectedIndex = 0;

        }

    }
}