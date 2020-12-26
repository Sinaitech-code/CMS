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
    public partial class Projects_edit_sub_project : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        functions fun = new functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {////////security///////////
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
                    {////////security/////////////
                     //code to initialise the page
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlproject, "select project_id,project_name from mdx_projects");
                            Display();
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
        //code to display the sub proj details 
        private void Display()

        {
            try
            {
                string str = Request.QueryString["sub_project_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_sub_projects", cn);
                cmd.Parameters.AddWithValue("@sub_project_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlproject.SelectedValue = dr["project_id"].ToString();
                    txtsubprojectname.Text = dr["sub_project_name"].ToString();
                    txtstartingdate.Text = dr["project_start_date"].ToString();
                    txtendingdate.Text = dr["project_end_date"].ToString();
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            updatedata();

        }
        //code to update subproject details
        private void updatedata()
        {
            try
            {

                string str = Request.QueryString["sub_project_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_sub_projects", cn);
                cmd.Parameters.AddWithValue("@sub_project_id", str);
                cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sub_project_name", txtsubprojectname.Text);
                cmd.Parameters.AddWithValue("@project_start_date", txtstartingdate.Text);
                cmd.Parameters.AddWithValue("@project_end_date", txtendingdate.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Sub Project Updated SuccessFully..!";


            }//end try
            catch (Exception ex)
            {
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();

            }//end catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end finally

        }//end update()
    }
}