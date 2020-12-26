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
    public partial class admin_view_completed_tasks1 : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {////////security///////////////
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
                    {/////////security///////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();

                            binddata();
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AUserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();


            }//end of catch
            finally
            {


            }//end of finally
        }//end of pageload
         //code to bind completedtasks
        private void binddata()
        {
            try
            {
                lblerr_msg.Text = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select task_title,project_id,assign_to,user_id,task_id from mdx_tasks where task_status='" + 2 + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_tasks");
                if (ds.Tables["mdx_tasks"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }//end of if
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_tasks"];
                        GridView1.DataBind();
                    }//end of try
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_tasks"];
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
         //code to paging in gridview
        protected void gridview_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }
}