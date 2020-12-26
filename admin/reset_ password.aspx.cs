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
    public partial class HR_reset__password : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //////////////////////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {
                        //// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            binddata();

                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)
                }//end of if(Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else if(Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();


            }//end of catch
            finally
            {

            }

        }//end of page load
         //function to binding data
        private void binddata()
        {
            try

            {
                lblerr_msg.Text = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select emp_id,user_id from mdx_users where  user_id!='superadmin'", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_users");
                if (ds.Tables["mdx_users"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_users"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_users"];
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
            }//end of finally

        }//end of function binddata()
        protected void gridview_pageindex(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }//end of class
}