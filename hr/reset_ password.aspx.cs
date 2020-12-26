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

namespace CMS.HR
{
    //Summary description for HR_reset__password
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
                ////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ////////////////////Security///////////////
                    if (ck == true)
                    {
                        // Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            binddata();
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                        }//end of if (!IsPostBack)
                    } // end of if (ck == true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of  if(Session["User_Id"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                } //end of  else if(Session["User_Id"]!=null)
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {


            }//end of finally
        }//end of pageload
         //function binddata  to get the data from database and display in GridView
        private void binddata()
        {
            try
            {
                lblerr_msg.Text = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select emp_id,user_id from mdx_users where role_id!=4", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_users");
                if (ds.Tables["mdx_users"].Rows.Count == 0)

                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }//end of if (ds.Tables["mdx_users"].Rows.Count == 0)
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_users"];
                        GridView1.DataBind();
                    } //end of  inner try
                    catch (Exception ex)
                    {

                        GridView1.DataSource = ds.Tables["mdx_users"];
                        GridView1.DataBind();

                    }//end of inner catch


                } //end of else if (ds.Tables["mdx_users"].Rows.Count == 0)
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


        }//end of function binddata

        //event gridview_pageindex to move to the  next page in GridView
        protected void gridview_pageindex(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        } //end of event gridview_pageindex
    } //end of class HR_reset__password
}