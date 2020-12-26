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
    public partial class admin_view_pending_task_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommand cmd1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {//////////security///////////
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
                    {////////security/////////////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
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

        }//end of pageload
         //code to display pending task details
        private void display()
        {
            try
            {

                string str1 = "";
                string str = Request.QueryString["task_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_pending_tasks", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@task_id", str);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbltasktitle.Text = dr["task_title"].ToString();

                    str1 = dr["project_id"].ToString();

                    lbldate.Text = dr["created_date"].ToString();
                    lblpriority.Text = dr["priority"].ToString();
                    lblassignto.Text = dr["assign_to"].ToString();
                    lblassignfrom.Text = dr["user_id"].ToString();
                    lbldesc.Text = dr["description"].ToString();


                }//end of while
                dr.Close();
                cmd1 = new SqlCommand("select project_name from mdx_projects where project_id='" + str1 + "'", cn);
                lblprojname.Text = (string)cmd1.ExecuteScalar();


            }//end of try
            catch (Exception ex1)
            {
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of  catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally

        }//end of display()
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_pending_tasks.aspx?");

        }
    }
}