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
    public partial class Employees_create_task_ : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        string assign_emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////////////////////////////Security///////////////
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
                    {
                        //// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            fun.filllistbox(listemp, "select distinct user_id  from mdx_emp_relations where top_user='" + Session["AUserName"].ToString() + "'");
                            fun.fnfill(ddlproject, "select distinct p.project_id,p.project_name from mdx_projects p,mdx_emp_relations r where p.project_id in(select project_id from mdx_emp_relations  where top_user='" + Session["AUserName"].ToString() + "')");
                            txtdate.Text = DateTime.Now.ToShortDateString();
                        }//END OF IF(!ISPOSTBACK)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of  if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else if (Session["AUserName"] != null)

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
         //function to create tasks and insert taske in the database
        private void createtasks()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("select role_id from mdx_users where user_id='" + Session["AUserName"] + "'", cn);
                int roleid = Convert.ToInt32(cmd1.ExecuteScalar());
                for (int i = 1; i < listemp.Items.Count; i++)
                {
                    cmd = new SqlCommand("usp_insert_mdx_tasks", cn);
                    cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedValue);
                    cmd.Parameters.AddWithValue("@created_date", txtdate.Text);
                    cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                    cmd.Parameters.AddWithValue("@priority", rbtnpriority.SelectedValue);
                    cmd.Parameters.AddWithValue("@task_title", txttasktitle.Text);
                    cmd.Parameters.AddWithValue("@user_id", Session["AUserName"]);
                    cmd.Parameters.AddWithValue("@role_id", roleid);

                    if (listemp.Items[i].Selected == true)
                    {

                        assign_emp = listemp.Items[i].Text;
                        cmd.Parameters.AddWithValue("@assign_to", assign_emp);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        lblerr_msg.Text = "";
                        lblmessage.Visible = true;
                        lblmessage.Text = "Task Inserted SuccessFully..!";
                        //Response.Write("<script language='javascript'>alert('Task Inserted SuccessFully..!' )</script>");


                    }//end of  if (listemp.Items[i].Selected == true)

                }//end of for

            }//end of try
            catch (Exception ex1)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }//end of createtasks()
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            createtasks();
        }//end of btnsubmit_click
    }//end of class
}