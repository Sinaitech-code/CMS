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

    public partial class Employees_daily_report_expencess : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    ////////////////////////////////////////////////////////////Security///////////////
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
                            bindgrid();
                        }//END OF IF(!ISPOSTBACK)
                        lbldate1.Text = DateTime.Now.ToShortDateString();
                        lblemp.Text = Session["AUserName"].ToString();
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    } //end of  else if(ck==true)
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
         //function to binding data from the database 
        private void bindgrid()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select r.report_title,r.report_date,r.report_id ,p.project_name from mdx_daily_report r,mdx_projects p where r.report_id!='" + 0 + "' and p.project_id=r.project_id", cn);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView2.DataSource = ds.Tables[0];
                        GridView2.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView2.DataSource = ds.Tables[0];
                        GridView2.DataBind();

                    }


                }//end of else if (ds.Tables[0].Rows.Count == 0)
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

        }//end of binddata()
         //gridview paging one paging to another page
        protected void grid_paginging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            bindgrid();

        }//end of gridview event
    }//end of class
}