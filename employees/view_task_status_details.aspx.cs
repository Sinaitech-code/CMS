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
    public partial class Employees_view_task_status_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;
        functions fn = new functions();
        string status;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    //        functions ULC = new functions();
                    //        bool ck;
                    //        string st1 = Request.PhysicalApplicationPath;
                    //        string st2 = Request.PhysicalPath;
                    //        string[] s = st2.Split(new char[] { '/', '\\' });
                    //        string st3 = s.GetValue(s.Length - 1).ToString();
                    //        ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    //        if (ck == true)
                    //        {
                    ////Put user code to initialize the page here
                    if (!IsPostBack)
                    {

                        lbldate1.Text = DateTime.Now.ToShortDateString();
                        lblemp.Text = Session["AUserName"].ToString();
                        display();

                    }//end of if(!ispostback)
                }//end of  if (Session["AUserName"] != null)
                 //        else
                 //        {
                 //            Response.Redirect("../noprivilise.aspx");
                 //        }

                else
                {
                    Response.Redirect("../Default.aspx");

                }

            }
            catch (Exception ex)
            {
                //    Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }

        }//end of page load
         //function to display the tasks status
        private void display()
        {
            try
            {
                string status = null;
                string project;
                string str = Request.QueryString["task_id"].ToString();

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_tasks_status", cn);

                cmd.Parameters.AddWithValue("@task_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbltasktitle.Text = dr["task_title"].ToString();
                    lblproj_client_name.Text = dr["project_name"].ToString();
                    //lbldate.Text = dr["created_date"].ToString();
                    DateTime createdate = Convert.ToDateTime(dr["created_date"].ToString());
                    lbldate.Text = createdate.ToString("MM/dd/yyyy");

                    lblemp_name.Text = dr["user_id"].ToString();
                    lbldesc.Text = dr["description"].ToString();
                    status = dr["task_status"].ToString();
                }//end of while
                dr.Close();
                //status = lblstatus.Text;
                project = lblproj_client_name.Text;
                cmd = new SqlCommand("select status_name  from mdx_task_status where status_id='" + status + "'", cn);
                lblstatus.Text = Convert.ToString(cmd.ExecuteScalar());

                cmd = new SqlCommand("select project_name  from mdx_projects where project_id='" + project + "'", cn);
                lblproj_client_name.Text = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
            }//end of try
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


        }//end of function display()

        protected void btnback_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("view_task_status.aspx?");
        }//end of button click()
    }//end of class
}