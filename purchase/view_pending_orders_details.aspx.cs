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
    public partial class purchase_view_pending_orders_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlDataAdapter da;
        DataSet ds;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {//////////security///////////
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
                            bindradiobtnlist();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            string str = Request.QueryString["requisition_id"].ToString();
                            binddata();
                            lblpuchaseorder_id.Text = autoordernumber();
                            lblrequisition_id.Text = str;
                            lblemp.Text = Session["AUserName"].ToString();
                            //lblempname.Text = Session["AUserName"].ToString();
                            lblorderdate.Text = DateTime.Now.ToShortDateString();
                            //lblpending_code.Text = pendingcode();
                        }//end of postback
                    }//end of if(ck==true)

                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of elase
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


            }//end of finally
        }//end of pageload
         //code to pending order details
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["requisition_id"].ToString();
                string mat_id = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select p.requisition_detail_id,p.material_id,p.description,p.quantity,q.user_id from mdx_purchase_requisition_details p,mdx_purchase_requisition q where p.requisition_id=q.requisition_id and p.status=2 and p.requisition_id='" + str + "'", cn);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                    btnsubmit.Visible = false;


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
        }//end of pending code
         //end of autoordernumber
        private string autoordernumber()
        {
            string Neworder;
            SqlParameter strm;
            SqlParameter strm1;
            string req_id = Request.QueryString["requisition_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_purchase_order_autocode", cn);
            //string  obj=(string)cmd1.ExecuteScalar();
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
         //code to bind radiobuttons list in gridview
        public DataSet bindradiobtnlist()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_id,status_name from mdx_purchase_requisition_status", cn);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = Request.QueryString["requisition_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    string rbtnlist;
                    rbtnlist = ((RadioButtonList)row.FindControl("rbtnlist")).SelectedValue;
                    string req_detail_id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    cmd = new SqlCommand("usp_update_purchase_requisition_status", cn);
                    cmd.Parameters.AddWithValue("@requisition_detail_id", req_detail_id);
                    cmd.Parameters.AddWithValue("@status", rbtnlist);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Purchase Requisition Status Updated SuccessFully..!";
                    //Response.Write("<script language='javascript'>alert('Purchase Requisition Status Updated SuccessFully..!' )</script>");

                }//end of foreach
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally

        }//end of btn click
    }
}