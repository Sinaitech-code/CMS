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

namespace CMS.Employees
{
    public partial class projects_projects_levels_status : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd1;
        functions fun = new functions();
        SqlDataAdapter da1;
        DataSet ds1;
        DataSet ds2;
        SqlDataAdapter da2;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ///////////////Security////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ///////////Security////////////
                    if (ck == true)
                    {//Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            fun.fnfill(ddlprojectname, "select distinct p.project_id,p.project_name from mdx_projects p,mdx_emp_relations r where r.user_id='" + Session["AUserName"] + "' and r.project_id=p.project_id");

                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();

                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of  if (Session["AUserName"] != null)
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
         //function to binding status in the gridview

        private void show_status()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    string level_id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    cmd = new SqlCommand("select status_id from mdx_project_levels where sub_project_id='" + ddlsubproject.SelectedValue + "' and level_id='" + level_id + "'", cn);
                    object status_id = cmd.ExecuteScalar();
                    ((RadioButtonList)row.FindControl("rblist1")).SelectedValue = status_id.ToString();

                }
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
        }//end of function
         //function to display  projectname
        private void display()
        {
            try
            {
                lblsubprojectname.Text = ddlsubproject.SelectedItem.Text;
                lblprojectname.Text = ddlprojectname.SelectedItem.Text;
                string clientid;
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("select  distinct client_id from mdx_projects where project_id='" + ddlprojectname.SelectedValue + "'", cn);
                clientid = (String)cmd.ExecuteScalar();
                cmd1 = new SqlCommand("select  distinct client_name from mdx_clients where client_id='" + clientid.ToString() + "'", cn);
                lblclient.Text = (String)cmd1.ExecuteScalar();

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
        }//end of display()

        protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects where project_id='" + ddlprojectname.SelectedValue + "' ");

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //update the level status coding
            try
            {
                string str = Session["AUserName"].ToString();

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    string rb1 = ((RadioButtonList)row.FindControl("rblist1")).SelectedValue;
                    string strlvlId = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    cmd = new SqlCommand("update mdx_project_levels set  status_id='" + rb1 + "',client_name='" + lblclient.Text + "',status_changed_by='" + str + "' where  level_id ='" + strlvlId + "'", cn);
                    cmd.ExecuteNonQuery();
                }//end of foreach
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Level Status Update Success Fully..!";

                updatestatus();
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
        }//end of btnsubmit_Click
         //function to binding the radio buttons


        public DataSet rblistbind()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_id, status_name  from mdx_project_status", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_project_status");
            return ds;
        }//end of function rblistbind()




        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            search();//call the function search()
            display();

        }
        //function to searching the data
        private void search()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                StringBuilder querry = new StringBuilder();
                querry.Append("select p.sub_project_name,s.level_name,s.level_id from mdx_sub_projects p inner join mdx_project_levels s on p.project_id=s.project_id where s.sub_project_id!='" + 0 + "'and s.sub_project_id=p.sub_project_id ");
                if (ddlprojectname.SelectedValue.ToString() != "")
                {
                    querry.Append(" and p.project_id='" + ddlprojectname.SelectedValue + "'");
                }
                if (ddlsubproject.SelectedValue.ToString() != "")
                {
                    querry.Append(" and s.sub_project_id='" + ddlsubproject.SelectedValue + "'");
                }
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter(querry.ToString(), cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_project_levels");
                if (ds.Tables["mdx_project_levels"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_project_levels"];
                        GridView1.DataBind();
                        show_status();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_project_levels"];
                        GridView1.DataBind();
                        show_status();

                    }


                }//end of else
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



        }//end of search()
         //function to update the status 


        private void updatestatus()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                lblstatuschanged.Text = Session["AUserName"].ToString();
                cmd = new SqlCommand("select count(*) from mdx_project_levels where project_id='" + ddlprojectname.SelectedValue + "'and status_id='2' ", cn);
                object str = (Object)cmd.ExecuteScalar();
                cmd1 = new SqlCommand("select count(*) from mdx_project_levels  where  project_id='" + ddlprojectname.SelectedValue + "'", cn);
                object count1 = (Object)cmd1.ExecuteScalar();
                cmd1 = new SqlCommand("select status_id from  mdx_project_levels  where  project_id='" + ddlprojectname.SelectedValue + "'", cn);
                object statusid = (Object)cmd1.ExecuteScalar();

                if (count1.ToString() != "")
                {
                    if (str.ToString() == count1.ToString())
                    {

                        cmd = new SqlCommand("update mdx_sub_projects set status_id='2',status_changed_by='" + lblstatuschanged.Text + "' where project_id='" + ddlprojectname.SelectedValue + "'and sub_project_id='" + ddlsubproject.SelectedValue + "'", cn);
                        cmd.ExecuteNonQuery();
                    }


                    else if (statusid.ToString() == "1")
                    {
                        cmd = new SqlCommand("update mdx_sub_projects set status_id='1',status_changed_by='" + lblstatuschanged.Text + "' where project_id='" + ddlprojectname.SelectedValue + "'and sub_project_id='" + ddlsubproject.SelectedValue + "'", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                        if (statusid.ToString() == "3")
                    {
                        cmd = new SqlCommand("update mdx_sub_projects set status_id='3',status_changed_by='" + lblstatuschanged.Text + "' where project_id='" + ddlprojectname.SelectedValue + "'and sub_project_id='" + ddlsubproject.SelectedValue + "'", cn);
                        cmd.ExecuteNonQuery();
                    }

                }//end of if

                cmd = new SqlCommand("select count(*) from mdx_sub_projects where project_id='" + ddlprojectname.SelectedValue + "'and status_id='2'", cn);
                object subcount = (Object)cmd.ExecuteScalar();
                cmd1 = new SqlCommand("select count(*) from mdx_sub_projects where project_id='" + ddlprojectname.SelectedValue + "'", cn);
                object total = (Object)cmd1.ExecuteScalar();
                cmd = new SqlCommand("select  status_id  from mdx_sub_projects where project_id='" + ddlprojectname.SelectedValue + "'", cn);
                object stid = (Object)cmd.ExecuteScalar();
                if (total.ToString() != "")
                {
                    if (subcount.ToString() == total.ToString())
                    {
                        cmd = new SqlCommand("update mdx_projects set status_id='2',status_changed_by='" + lblstatuschanged.Text + "' where project_id='" + ddlprojectname.SelectedValue + "'", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                        if (stid.ToString() == "1")
                    {
                        cmd = new SqlCommand("update mdx_projects set status_id='1',status_changed_by='" + lblstatuschanged.Text + "' where project_id='" + ddlprojectname.SelectedValue + "'", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                            if (stid.ToString() == "3")
                    {
                        cmd = new SqlCommand("update mdx_projects set status_id='3',status_changed_by='" + lblstatuschanged.Text + "' where project_id='" + ddlprojectname.SelectedValue + "'", cn);
                        cmd.ExecuteNonQuery();
                    }
                }//end of if(total.ToString() != "")





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





    }//end of class
}