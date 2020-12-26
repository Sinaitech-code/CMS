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
    public partial class Employees_task_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;
        functions fn = new functions();
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
                    if (!IsPostBack)
                    {
                        lbldate1.Text = DateTime.Now.ToShortDateString();
                        lblemp.Text = Session["AUserName"].ToString();
                        display();
                        bindrbtn();
                    }//end of if(!ispostback)
                     //        }
                     //        else
                     //        {
                     //            Response.Redirect("../noprivilise.aspx");
                     //        }
                }//end of if(Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }//end of try

            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }

            finally
            {

            }
        }//end of page load
         //function to binding radiobuttons 

        private void bindrbtn()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_id,status_name from mdx_task_status", cn);
            ds = new DataSet();
            rbtnprogress.DataTextField = "status_name";
            rbtnprogress.DataValueField = "status_id";
            da.Fill(ds, "mdx_task_status");
            rbtnprogress.DataSource = ds.Tables["mdx_task_status"];
            rbtnprogress.DataBind();
            cn.Close();


        }//end of bindrbtn()
         //function to display tasks details
        private void display()
        {
            try
            {
                string str = Request.QueryString["task_id"].ToString();

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_tasks", cn);

                cmd.Parameters.AddWithValue("@task_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbltasktitle.Text = dr["task_title"].ToString();
                    lblproj_client_name.Text = dr["project_id"].ToString();
                    lbldate.Text = dr["created_date"].ToString();
                    lblemp_name.Text = dr["user_id"].ToString();
                    lbldesc.Text = dr["description"].ToString();
                    string priority = dr["priority"].ToString();

                }//end of while
                dr.Close();
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
        }//end of function
         //function to update the status of the tasks
        private void update()
        {
            try
            {
                string str = Request.QueryString["task_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_tasks", cn);
                cmd.Parameters.AddWithValue("@task_id", str);
                cmd.Parameters.AddWithValue("@task_status", rbtnprogress.SelectedItem.Value);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Task Status Updated SuccessFully..!";

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
        }//end of function update the status of the tasks

        protected void btnsubmit_ServerClick(object sender, EventArgs e)
        {
            update();//call the function
        }
        protected void btnback_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("view_task.aspx?");
        }
    }//end of class
}