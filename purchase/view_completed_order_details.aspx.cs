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
    public partial class purchase_view_completed_order_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {/////////////security//////////////
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
                    {////////////security//////////
                        if (!IsPostBack)
                        {
                            binddata();
                            lblrequisition_id.Text = Request.QueryString["requisition_id"].ToString();
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            lblpuchaseorder_id.Text = autoordernumber();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();
                            cmd = new SqlCommand("select user_id from mdx_purchase_requisition where requisition_id='" + lblrequisition_id.Text + "'", cn);
                            string struserid = (String)cmd.ExecuteScalar();
                            lblempname.Text = struserid;


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
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {


            }//end of finally

        }//end of pageload
         //code to autogenerate order number
        private string autoordernumber()
        {
            string Neworder;
            SqlParameter strm;
            SqlParameter strm1;
            string req_id = Request.QueryString["requisition_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_purchase_order_autocode", cn);
            strm1 = cmd1.Parameters.Add("@requisition_id", req_id);
            strm1.Direction = ParameterDirection.Input;
            strm = cmd1.Parameters.Add("@order_id", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            Neworder = (string)cmd1.Parameters["@order_id"].Value;
            return (Neworder);
            cn.Close();
        }//end of autoordernumber

        //code to  bind completed order details
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["requisition_id"].ToString();
                string mat_id = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select p.material_name,p.description,p.quantity  from mdx_purchase_requisition_details p,mdx_purchase_requisition q where p.requisition_id=q.requisition_id  and p.requisition_id='" + str + "' and p.status=1", cn);
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
        //code to paging in grid
        protected void grid_pagin(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }

        protected void btnback_Click1(object sender, EventArgs e)
        {
            Response.Redirect("view_completed_orders.aspx?");
        }
    }
}