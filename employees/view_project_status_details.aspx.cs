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

namespace CMS.Employees
{
    public partial class Employees_view_project_status_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    //functions ULC = new functions();
                    //bool ck;
                    //string st1 = Request.PhysicalApplicationPath;
                    //string st2 = Request.PhysicalPath;
                    //string[] s = st2.Split(new char[] { '/', '\\' });
                    //string st3 = s.GetValue(s.Length - 1).ToString();
                    //ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    //if (ck == true)
                    //{
                    //Put user code to initialize the page here
                    if (!IsPostBack)
                    {
                        lblemp.Text = Session["AUserName"].ToString();
                        lbldate1.Text = DateTime.Now.ToShortDateString();
                        display();
                    }//end of if(!ispostback)
                }//end of if (Session["AUserName"] != null)
                 //    else
                 //    {
                 //        Response.Redirect("../noprivilise.aspx");
                 //    }
                 //}
                 //else
                 //{
                 //    Response.Redirect("../Default.aspx");

                //}
            }
            catch (Exception ex)
            {
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }
        }//end of page load
         //function to display the project status details
        private void display()
        {
            try
            {

                string str1 = "";
                string str2 = "";
                string status = "";
                string str = Request.QueryString["level_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_project_level_details", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@level_id", str);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lblclientname.Text = dr["client_name"].ToString();
                    str1 = dr["project_id"].ToString();
                    // lblsubproj.Text = dr["sub_project_id"].ToString();
                    str2 = dr["sub_project_id"].ToString();
                    lblstartdate.Text = dr["project_start_date"].ToString();
                    lblenddate.Text = dr["project_end_date"].ToString();
                    status = dr["status_id"].ToString();
                    lblstatuschangedby.Text = dr["status_changed_by"].ToString();
                    lbllvlname.Text = dr["level_name"].ToString();
                }//end of while
                dr.Close();
                cmd1 = new SqlCommand("select project_name from mdx_projects where project_id='" + str1 + "'", cn);
                lblproj_name.Text = (string)cmd1.ExecuteScalar();
                cmd2 = new SqlCommand("select sub_project_name from  mdx_sub_projects where project_id='" + str2 + "'", cn);
                lblsubproj.Text = (string)cmd2.ExecuteScalar();
                cmd3 = new SqlCommand("select status_name from mdx_project_status where status_id='" + status + "'", cn);
                lblstatus.Text = (string)cmd3.ExecuteScalar();
            }

            catch (Exception ex1)
            {
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }//end of display()



    }//end of class

}
