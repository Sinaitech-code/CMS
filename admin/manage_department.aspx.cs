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

namespace CMS.admin
{
    public partial class admin1_manage_department : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /////////////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ////////////////////////////////////Security///////////////
                    if (ck == true)
                    {
                        //// Put user code to initialize the page here

                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fillgrid();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else

                }//end of  if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else  if (Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();


            }//end of catch
            finally
            {


            }//end of finally
        }//end of page load
         //function to binding data from the database
        private void fillgrid()
        {
            try
            {
                lblerr_msg.Text = "";

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select dept_name,dept_id from mdx_departments", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_departments");
                if (ds.Tables["mdx_departments"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {

                        GridView1.DataSource = ds.Tables["mdx_departments"];
                        GridView1.DataBind();


                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_departments"];
                        GridView1.DataBind();

                    }
                }
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
            }

        }//end of function  binddata()
         //gridview paging event
        protected void gridview_pageindex(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fillgrid();
        }
    }//end of class
}