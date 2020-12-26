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
    public partial class view_expences_status_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {///////////security////////////////
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
                    {//////////security/////////////////
                        if (!IsPostBack)
                        {
                            binddata();
                         
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            string str = Request.QueryString["sno"].ToString();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();
                            da = new SqlDataAdapter("select distinct sno,status,status_changed_by,user_id from mdx_daily_report_account_details where sno='" + str + "'", cn);
                            ds = new DataSet();
                            da.Fill(ds, "mdx_daily_report_account_details");
                            foreach (DataRow dr in ds.Tables["mdx_daily_report_account_details"].Rows)
                            {
                                lblstatus.Text = dr["status"].ToString();
                                lblstatus_changedby.Text = dr["status_changed_by"].ToString();
                                lbluserid.Text = dr["user_id"].ToString();

                            }//end of foreach
                            cn.Close();


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
                //    Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {

            }//finally

        }//end of page load
         //code to bind expences
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["sno"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select sno,expenses,description from mdx_daily_report_account_details where sno='" + str + "'", cn);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                 
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }//end of if
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }//end of try
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables[0];
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

        }
        //code to paging in gridview
        protected void grid_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }
}
