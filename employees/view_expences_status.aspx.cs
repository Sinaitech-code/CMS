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
    public partial class Employees_view_expences_status : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
                /////////////////Security////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////Security////////////
                    if (ck == true)
                    {
                        ////Put user code to initialize the page here
                        if (!IsPostBack)
                        {

                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            binddata();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(Session["AUserName"] != null)
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
         //function to binding  report details
        private void binddata()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select distinct sno,user_id,status_changed_by from mdx_daily_report_account_details", cn);
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
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();

                    }
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
        }//end of binddata()
        protected void grid_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }//end of class
}