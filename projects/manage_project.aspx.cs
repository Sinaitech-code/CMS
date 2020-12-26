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

namespace CMS.projects
{
    public partial class admin1_manage_project : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {//////////security//////////
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
                    {/////////security////////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fillgrid();
                        }//end of postbach
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AuserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else
            }
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end catch
            finally
            {


            }//end of finally
        }//end of pageload
         //code to fill the gridview
        private void fillgrid()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select  project_name,project_id from mdx_projects", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_projects");
                if (ds.Tables["mdx_projects"].Rows.Count == 0)
                {

                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }//end of if
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_projects"];
                        GridView1.DataBind();

                    }//end of try
                    catch (Exception ex)
                    {

                        GridView1.DataSource = ds.Tables["mdx_projects"];
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
        }//end of pageload
         //code to gridview pageindex
        protected void gridview_pageindex(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fillgrid();
        }
    }
}