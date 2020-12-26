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
    public partial class Employees_view_prettyexpences_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;




        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    //        functions ULC = new functions();
                    //        bool ck;
                    //        string st1 = Request.PhysicalApplicationPath;
                    //        string st2 = Request.PhysicalPath;
                    //        string[] s = st2.Split(new char[] { '/', '\\' });
                    //        string st3 = s.GetValue(s.Length - 1).ToString();
                    //        ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    //        if (ck == true)
                    //        {
                    if (!IsPostBack)
                    {
                        lblemp.Text = Session["AUserName"].ToString();
                        lbldate.Text = DateTime.Now.ToShortDateString();
                        binddata();
                        bindrbtnlist();
                        string str = Request.QueryString["sno"].ToString();
                        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                        cn.Open();
                        cmd = new SqlCommand("select user_id from mdx_daily_report_account_details where sno='" + str + "'", cn);
                        lbluserid.Text = (String)cmd.ExecuteScalar();

                    }//end of if(!ispostback)
                     //        }
                     //        else
                     //        {
                     //            Response.Redirect("../noprivilise.aspx");
                     //        }
                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }

            catch (Exception ex)
            {
                //    Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }

        }//end of page load
         //function to binding  report information
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["sno"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select expenses,description,date from mdx_daily_report_account_details where sno='" + str + "'", cn);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables[0];
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

        }//end of function binddata()
         //function to binding radiobutton list
        private void bindrbtnlist()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status from prettyexp_status", cn);
            ds = new DataSet();
            da.Fill(ds, "prettyexp_status");
            rbtnstatus.DataTextField = "status";
            rbtnstatus.DataValueField = "status";
            rbtnstatus.DataSource = ds.Tables["prettyexp_status"];
            rbtnstatus.DataBind();
            cn.Close();


        }//end of function 
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //update the expences status
                string str = Request.QueryString["sno"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_prettyexp_status", cn);
                cmd.Parameters.AddWithValue("@sno", str);
                cmd.Parameters.AddWithValue("@status", rbtnstatus.SelectedValue);
                cmd.Parameters.AddWithValue("@status_changed_by", lblemp.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblmessage.Visible = true;
                lblmessage.Text = "Update status successfully..!";
            }
            catch (Exception ex3)
            {
                lblerr_msg.Text = ex3.Message.ToString();
                lblerr_msg.Visible = true;

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }//end of button click
         //gridview paging
        protected void gridview_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }//end of pagin
    }//end of class
}