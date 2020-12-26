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
    public partial class Masterpages_edit_project_levels : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {/////////security/////////////
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
                    {/////////security/////////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlprojects, "select project_id,project_name from mdx_projects");
                            fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects");
                            display();
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AUserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {


            }//end of finally
        }
        //code to display project levels
        private void display()
        {
            try
            {

                string str = Request.QueryString["level_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_project_levels", cn);
                cmd.Parameters.AddWithValue("@level_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlprojects.SelectedValue = dr["project_id"].ToString();
                    ddlsubproject.SelectedValue = dr["sub_project_id"].ToString();
                    txtprojectlevel.Text = dr["level_name"].ToString();
                    txtstartingdate.Text = dr["project_start_date"].ToString();
                    txtfinishingdate.Text = dr["project_end_date"].ToString();
                }
                dr.Close();

            }//end of try
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
        }//end of display
         //code to edit projectlevels
        private void update()
        {

            try
            {
                string str = Request.QueryString["level_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_project_levels", cn);
                cmd.Parameters.AddWithValue("@level_id", str);
                cmd.Parameters.AddWithValue("@project_id", ddlprojects.SelectedValue);
                cmd.Parameters.AddWithValue("@sub_project_id", ddlsubproject.SelectedValue);
                cmd.Parameters.AddWithValue("@level_name", txtprojectlevel.Text);
                cmd.Parameters.AddWithValue("@project_start_date", txtstartingdate.Text);
                cmd.Parameters.AddWithValue("@project_end_date", txtfinishingdate.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Project Levels Updated SuccessFully..!";


            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {

                cn.Close();
                cn.Dispose();
            }//end of finally

        }//end of update

        protected void btnsave_Click(object sender, EventArgs e)
        {

            update();
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtfinishingdate.Text = "";
            txtprojectlevel.Text = "";
            txtstartingdate.Text = "";
        }
        //this event is to load subprojects when ddlprojects selected index is changed
        protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects");
        }
    }
}