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
    public partial class admin1_manage_project_type : System.Web.UI.Page
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
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    if (ck == true)
                    {
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fillgrid();
                        }
                    }
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }
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
        }
        private void fillgrid()
        {

            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select project_type_id,type_name from mdx_project_type", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_project_type");
                if (ds.Tables["mdx_project_type"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {

                        GridView1.DataSource = ds.Tables["mdx_project_type"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {

                        GridView1.DataSource = ds.Tables["mdx_project_type"];
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


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fillgrid();
        }
    }
}