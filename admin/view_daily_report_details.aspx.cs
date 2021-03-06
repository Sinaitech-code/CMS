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
    public partial class Employees_view_daily_report_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {//////////////security//////////////
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
                    {/////////security///////////////
                        if (!IsPostBack)
                        {
                            string str = Request.QueryString["report_id"].ToString();
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();
                            cmd = new SqlCommand("select user_id from mdx_daily_report where report_id='" + str + "'", cn);
                            string struserid = (String)cmd.ExecuteScalar();
                            lblname.Text = struserid;
                            cn.Close();
                            displaydailyreport();
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

                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch
            finally
            {

            }//end of finally
        }//end of pageload


        private void displaydailyreport()
        {
            try
            {

                string str = Request.QueryString["report_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_daily_report", cn);
                cmd.Parameters.AddWithValue("@report_id", str);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ViewState["projectid"] = dr["project_id"].ToString();
                    lbldate.Text = dr["report_date"].ToString();
                    lbltitle.Text = dr["report_title"].ToString();
                    lblnoofworkers.Text = dr["no_of_workers"].ToString();
                    lblremarks.Text = dr["remarks"].ToString();
                    lblresourcesused.Text = dr["resources_used"].ToString();
                    lblmoneypaid.Text = dr["Money_paid"].ToString();
                    lbldescription.Text = dr["description"].ToString();


                }//end of while
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("select project_name from mdx_projects where project_id='" + ViewState["projectid"] + "'", cn);
                lblproj_name.Text = (String)cmd2.ExecuteScalar();
                SqlCommand cmd1 = new SqlCommand("select client_name from mdx_clients where client_id in(select client_id from mdx_projects where project_id='" + ViewState["projectid"] + "')", cn);
                lblclientname.Text = (String)cmd1.ExecuteScalar();
                cn.Close();
                Session["clientname"] = lblclientname.Text;
                Session["projectname"] = lblproj_name.Text;
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

    }
}