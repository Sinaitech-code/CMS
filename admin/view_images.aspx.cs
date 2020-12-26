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
    public partial class admin_view_images : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {/////////////security////////////////
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
                            binddata();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of elase


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
        }

        //code to bind images
        private void binddata()
        {
            try
            {

                string str = Request.QueryString["report_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select report_id,report_image_id,report_image_name1,report_image_name2,report_image_name3,report_image_name4,report_image_name5 from mdx_daily_report_images1 where report_id='" + str + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_daily_report_images1");
                if (ds.Tables["mdx_daily_report_images1"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }//end of if
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_daily_report_images1"];
                        GridView1.DataBind();
                    }//end of try
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_daily_report_images1"];
                        GridView1.DataBind();

                    }//end of catch


                }//end of else
            }//end of try

            catch (Exception ex1)
            {
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally


        }//end of binddata()
         //code to page index in grid view
        protected void gridview_pageindexchange(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_daily_report.aspx?");
        }
    }
}