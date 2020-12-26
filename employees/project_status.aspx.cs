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
    public partial class project_status : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd1;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {
                        if (!IsPostBack)
                        {//// Put user code to initialize the page here
                            fun.fnfill(ddlprojectname, "select project_id,project_name from mdx_projects");
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }//end of try
            catch (Exception ex)
            {

                //lblerr_msg.Text = ex.Message.ToString();
                //lblerr_msg.Visible = true;
            }
            finally
            {


            }

        }//end of page load
         //function to display 

        private void display()
        {
            string clientid;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select client_id from mdx_projects where project_id='" + ddlprojectname.SelectedValue + "'", cn);
            clientid = (String)cmd.ExecuteScalar();
            cmd1 = new SqlCommand("select client_name from mdx_clients where client_id='" + clientid.ToString() + "'", cn);
            lblclient.Text = (String)cmd1.ExecuteScalar();
            cn.Close();
        }//end of display()
         //function to binding data
        private void bindgrid()
        {
            int subproj;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select sub_project_id from mdx_sub_projects where project_id='" + ddlprojectname.SelectedValue + "'", cn);
            subproj = (int)cmd.ExecuteScalar();
            da = new SqlDataAdapter("select level_id,level_name from mdx_project_levels where project_id ='" + ddlprojectname.SelectedValue + "'and sub_project_id='" + subproj.ToString() + "' ", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_project_levels");
            GridView1.DataSource = ds.Tables["mdx_project_levels"];
            GridView1.DataBind();
            cn.Close();
        }//end of bindgrid()
        protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects where project_id='" + ddlprojectname.SelectedValue + "' ");

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string str = Session["AUserName"].ToString();

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            foreach (GridViewRow row in GridView1.Rows)
            {
                string rb1 = ((RadioButtonList)row.FindControl("rblist1")).SelectedValue;
                string strlvlId = GridView1.DataKeys[row.RowIndex].Value.ToString();
                cmd = new SqlCommand("select top_user from mdx_emp_relations where user_id='" + str + "'", cn);
                string stname = (String)cmd.ExecuteScalar();
                cmd = new SqlCommand("update mdx_project_levels set user_id='" + stname.ToString() + "', status_id='" + rb1 + "',client_name='" + lblclient.Text + "',status_changed_by='" + str + "' where  level_id ='" + strlvlId + "'", cn);
                cmd.ExecuteNonQuery();
            }//end of foreach statement
            cn.Close();
        }//end of button click
         //function to binding status

        public DataSet rblistbind()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_name,status_id  from mdx_project_status", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_project_status");
            return ds;
        }//end of function rblistbind()
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid();
            display();
        }
        //end of btnsearch_Click
    }
    //end of class
}