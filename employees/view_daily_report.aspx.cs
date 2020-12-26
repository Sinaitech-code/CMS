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
                    ///////////////Security////////////
                    if (ck == true)
                    {////Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            fun.fnfill(ddlempname, "select distinct e.emp_id,e.user_id from mdx_employees e,mdx_tasks t where t.user_id='" + Session["AUserName"].ToString() + "' and e.user_id in(select assign_to from mdx_tasks where  user_id='" + Session["AUserName"].ToString() + "') ");

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

            }
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }
        }//end of page load
         //function to searching particular emp daily report information 

        private void search()
        {
            try
            {
                StringBuilder querry = new StringBuilder();
                querry.Append("select r.report_id,r.report_title,r.report_date ,p.project_name from mdx_daily_report r,mdx_projects p where r.report_id!='" + 0 + "' and p.project_id=r.project_id ");
                if (ddlempname.SelectedValue.ToString() != "")
                {
                    querry.Append("and r.user_id='" + ddlempname.SelectedItem.Text + "' ");
                }

                if (ddlprojname.SelectedValue.ToString() != "")
                {
                    querry.Append("and  r.project_id='" + ddlprojname.SelectedValue + "'");
                }
                if (txttodate.Text != "" && txtfromdate.Text != "")
                {


                    querry.Append("and  report_date  between   Convert(DateTime,'" + txtfromdate.Text + "',101) and Convert(DateTime,'" + txttodate.Text + "',101)");
                }
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter(querry.ToString(), cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_daily_report");
                if (ds.Tables["mdx_daily_report"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;


                }
                else
                {
                    try
                    {
                        GridView2.DataSource = ds.Tables["mdx_daily_report"];
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        lblerr_msg.Text = "";

                    }
                    catch (Exception ex)
                    {
                        GridView2.DataSource = ds.Tables["mdx_daily_report"];
                        GridView2.DataBind();
                        GridView2.Visible = true;
                        lblerr_msg.Text = "";
                    }

                }
            }
            catch (Exception ex1)
            {

                lblerr_msg.Text = ex1.Message.ToString();

            }
            finally
            {
                cn.Close();
                cn.Dispose();

            }
        } //end of function search()
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            search();//call search function
            Session["toempname"] = ddlempname.SelectedItem.Text;
        }
        protected void ddlempname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //binding projects 
            fun.fnfill(ddlprojname, "select distinct p.project_id,p.project_name from mdx_projects p,mdx_emp_relations r where p.project_id in(select project_id from mdx_emp_relations where user_id='" + ddlempname.SelectedItem.Text + "')");
        }

        protected void grid_paginging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            search();
        }
    }//end of class
}
