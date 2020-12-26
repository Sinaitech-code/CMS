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

namespace CMS
{
    public partial class clientdisplay : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblemp.Text = Session["AUserName"].ToString();
            lbldate1.Text = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                binddata();
            }

        }
        private void binddata()
        {
            try
            {

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter(" select distinct img.report_id,img.report_image_id,img.report_image_name1,img.report_image_name2,img.report_image_name3,img.report_image_name4,img.report_image_name5 from mdx_daily_report_images1 img,mdx_emp_project_assign ass,mdx_clients c where   ass.project_id in(select project_id from mdx_emp_project_assign where client_id=(select client_id from mdx_clients where user_id='" + Session["AUserName"].ToString() + "')  )and img.visble_to_client1='1'  ", cn);
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

        }

        protected void gridview_pageindexchange(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }

}