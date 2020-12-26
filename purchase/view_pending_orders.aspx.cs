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

namespace CMS.purchase
{
    public partial class purchases_view_pending_orders : System.Web.UI.Page
    {

        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////////security/////////////
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
                    {//////////security///////////
                        if (!IsPostBack)
                        {
                            binddata();
                        }//end of postback
                        lblemp.Text = Session["AUserName"].ToString();
                        lblorderdate.Text = DateTime.Now.ToShortDateString();
                        //lblpending_code .Text =pendingcode();
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
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
                // Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");

            }//end of catch
            finally
            {

            }//end of finally
        }//end of pageload
         //code to bind pending orders
        private void binddata()
        {
            try
            {

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select distinct p.requisition_id,p.user_id,p.requisition_gen_date,p.requisition_expected_date from  mdx_purchase_requisition  p,mdx_purchase_requisition_details q where p.requisition_id=q.requisition_id and q.status=2 ", cn);
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


        }//end of pageload
         //code to pending code
        private string pendingcode()
        {
            string NewId;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_auto_pendingcode_mdx_purchase_requisition", cn);
            //string  obj=(string)cmd1.ExecuteScalar();
            strm = cmd1.Parameters.Add("@pendingcode", SqlDbType.VarChar, 12);
            //cmd1.Parameters.Add("@requisition_id", lblreqid.Text);
            cmd1.Parameters.Add("@requisition_id", Request.QueryString["requisition_id"].ToString());

            strm.Direction = ParameterDirection.Input;
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            NewId = (string)cmd1.Parameters["@pendingcode"].Value;
            return (NewId);
            cn.Close();
        }//end of pendingcode()
         //code to paging in gridview
        protected void grid_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
    }
}