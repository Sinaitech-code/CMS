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

namespace CMS.admin
{
    public partial class Employees_view_daily_report : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        DataSet ds1;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////////security//////////////
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
                    {////////security//////////////
                        if (!IsPostBack)
                        {
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            //fun.fnfill(ddlempname, "select emp_id,user_id from mdx_employees where user_id!='superadmin'");
                            fun.fnfill(ddlempname, "select emp_id,user_id from mdx_employees where dept_name!='admin'");

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



                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();


            }//end of catch
            finally
            {


            }//end of finally
        }//end of pageload
         //code for search
        private void search()
        {
            try
            {
                StringBuilder querry = new StringBuilder();
                querry.Append("select r.report_id,r.report_title,r.report_date ,p.project_name from mdx_daily_report r,mdx_projects p where r.report_id!='" + 0 + "' and p.project_id=r.project_id ");
                if (ddlempname.SelectedValue.ToString() != "")
                {
                    querry.Append("and r.user_id='" + ddlempname.SelectedItem.Text + "' ");
                }//end of if

                if (ddlprojname.SelectedValue.ToString() != "")
                {
                    querry.Append("and  r.project_id='" + ddlprojname.SelectedValue + "'");
                }//end of if
                if (txttodate.Text != "" && txtfromdate.Text != "")
                {


                    querry.Append("and  report_date  between   Convert(DateTime,'" + txtfromdate.Text + "',101) and Convert(DateTime,'" + txttodate.Text + "',101)");
                }//end of if
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter(querry.ToString(), cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_daily_report");
                if (ds.Tables["mdx_daily_report"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;


                }//end of if
                else
                {
                    try
                    {
                        GridView2.DataSource = ds.Tables["mdx_daily_report"];
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        lblerr_msg.Text = "";

                    }//end of try
                    catch (Exception ex)
                    {
                        GridView2.DataSource = ds.Tables["mdx_daily_report"];
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        lblerr_msg.Text = "";
                    }//end of catch

                }//end of else
            }//end of try
            catch (Exception ex1)
            {

                lblerr_msg.Text = ex1.Message.ToString();

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        } //end of pageload


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            search();
            Session["toempname"] = ddlempname.SelectedItem.Text;
        }
        //this event is to load project name when ddlemp selected index changed
        protected void ddlempname_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun.fnfill(ddlprojname, "select distinct p.project_id,p.project_name from mdx_projects p,mdx_emp_relations r where p.project_id in(select project_id from mdx_emp_relations where user_id='" + ddlempname.SelectedItem.Text + "')");
        }
        //code to paging in gridview
        protected void grid_paginging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            search();
        }
    }
}