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
    public partial class Employees_view_orders : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { ///////////////Security////////////
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
                    {//Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            binddata();
                            lblemp.Text = Session["AUserName"].ToString();
                            lblorderdate.Text = DateTime.Now.ToShortDateString();

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
         //function to binding purchase orders
        private void binddata()
        {
            try
            {

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select po.order_id,po.user_id,po.order_date from mdx_purchase_orders po,mdx_purchase_requisition pr where po.requisition_id=pr.requisition_id and pr.user_id='" + Session["AUserName"].ToString() + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_purchase_orders");
                if (ds.Tables["mdx_purchase_orders"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_purchase_orders"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_purchase_orders"];
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

        }//end of  function binddata()

        protected void grid_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }//end of gridview paging event
    }//end of class
}