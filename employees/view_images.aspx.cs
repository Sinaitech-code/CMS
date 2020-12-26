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
                        binddata();
                        lbldate.Text = DateTime.Now.ToShortDateString();
                        lblemp.Text = Session["AUserName"].ToString();

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
            }
            catch (Exception ex)
            {
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {

            }
        }//end of pageload
         //function to binding images
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
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_daily_report_images1"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_daily_report_images1"];
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


        }//end of function binddata()
        protected void gridview_pageindexchange(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }//end of class
}