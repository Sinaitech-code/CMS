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

    //Summary description for HR_manage__employee
    public partial class HR_manage__employee : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
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

                            // Put user code to initialize the page here
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            binddata();
                        }//end of if(!IsPostBack)
                    } //end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of  if(Session["User_Id"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                } //end of else if(Session["User_Id"]!=null)
            }
            catch (Exception ex)
            {
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            } //end of catch
            finally
            {

            } //end of finally
        }//end of page load
         //function binddata  to get the data from database and display in GridView
        private void binddata()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select emp_id,first_name from mdx_employees where user_id!='superadmin' and status=0 and dept_name!='admin'", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_employees");

                if (ds.Tables["mdx_employees"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                } // end of if (ds.Tables["mdx_employees"].Rows.Count == 0)
                else
                {
                    try
                    {

                        GridView1.DataSource = ds.Tables["mdx_employees"];
                        GridView1.DataBind();


                    } //end of  inner try
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_employees"];
                        GridView1.DataBind();

                    }//end of  inner catch

                } //end of else if (ds.Tables["mdx_employees"].Rows.Count == 0)
            }//end of try

            catch (Exception ex1)
            {
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            } //end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            } //end of finally

        } //end of function binddata
          //event gridview_pageindex to move to the  next page in GridView
        protected void gridview_pageindex(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }//end of event  gridview_pageindex

        //event gridview_deleting to delete the employees in GridView
        protected void gridview_deleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string str = GridView1.DataKeys[e.RowIndex].Value.ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("update mdx_employees set status=1 where emp_id='" + str + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            binddata();
            lblerr_msg.Text = "employee deleted successfully !....";
            lblerr_msg.Visible = true;

        } //end of event gridview_deleting
    } //end of class HR_manage__employee
}