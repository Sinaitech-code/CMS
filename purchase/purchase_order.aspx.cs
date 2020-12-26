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
    public partial class purchase_purchase_order : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlCommand cmd4;
        SqlCommand cmd5;
        SqlCommand cmd6;
        SqlDataAdapter da;
        DataSet ds;
        functions fun = new functions();
        SqlCommand cmd7;
        SqlCommand cmd8;

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
                    {////////security/////////////
                        if (!IsPostBack)
                        {
                            //lbldate.Text = DateTime.Now.ToShortDateString();
                            string str = Request.QueryString["requisition_id"].ToString();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();
                            cmd8 = new SqlCommand("select requisition_gen_date from mdx_purchase_requisition where requisition_id='" + str + "'", cn);
                            string date = (String)cmd8.ExecuteScalar();
                            lbldate.Text = date;
                            cmd7 = new SqlCommand("select user_id from mdx_purchase_requisition where requisition_id='" + str + "'", cn);
                            string userid = (String)cmd7.ExecuteScalar();
                            lblempname.Text = userid;
                            cmd4 = new SqlCommand("select count(*) from mdx_purchase_requisition_details where requisition_id='" + str + "' and status=1", cn);
                            int strcount = Convert.ToInt32(cmd4.ExecuteScalar());
                            cmd4 = new SqlCommand("select count(*) from mdx_purchase_requisition_details where requisition_id='" + str + "' and status=3", cn);
                            int str_rejected = Convert.ToInt32(cmd4.ExecuteScalar());
                            int num = strcount + str_rejected;
                            cmd5 = new SqlCommand("select count(*) from mdx_purchase_requisition_details where requisition_id='" + str + "'", cn);
                            int strcount1 = Convert.ToInt32(cmd5.ExecuteScalar());
                            if (num == strcount1)
                            {
                                cmd6 = new SqlCommand("update mdx_purchase_requisition set status='completed' where requisition_id='" + str + "'", cn);
                                cmd6.ExecuteNonQuery();

                            }//end of if(num==strcount1)
                            cn.Close();
                            binddata();
                            lblpuchaseorder_id.Text = autoordernumber();
                            lblrequisition_id.Text = str;
                            lblemp.Text = Session["AUserName"].ToString();
                            //lblempname.Text = Session["AUserName"].ToString();
                            lblorderdate.Text = DateTime.Now.ToShortDateString();
                        }//end of postback

                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AUserName"]!=true)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else
            }//end if try
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
         //code to bind purchase order details
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["requisition_id"].ToString();
                string mat_id = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select distinct p.requisition_detail_id,p.material_name,p.description,p.quantity,q.user_id from mdx_purchase_requisition_details p,mdx_purchase_requisition q ,mdx_materials m where p.requisition_id=q.requisition_id and p.status=1 and p.requisition_id='" + str + "' and   m.material_id=p.material_id and p.requisition_detail_id not in(select requisition_detail_id from mdx_purchase_order_details) ", cn);

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

        }//end of binddata()
         //code to ordernumber
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
        }
        //code to purchase orders
        private void insert_purchase_orders()
        {
            try
            {
                string str1 = Request.QueryString["requisition_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();

                cmd1 = new SqlCommand("usp_insert_mdx_purchase_orders", cn);
                cmd1.Parameters.AddWithValue("@order_id", lblpuchaseorder_id.Text);
                cmd1.Parameters.AddWithValue("@requisition_id", str1);
                cmd1.Parameters.AddWithValue("@user_id", Session["AUserName"].ToString());
                cmd1.Parameters.AddWithValue("@order_date", DateTime.Now.ToShortDateString());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.ExecuteNonQuery();
            }//end of try
            catch (Exception ex2)
            {
                lblmessage.Visible = true;
                lblmessage.Text = ex2.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally

        }//end of insert_purchase_orders()


        //code to bind orders
        private void bind_order()
        {

            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    string requisition_detail_id = GridView1.DataKeys[row.RowIndex].Value.ToString();


                    cmd3 = new SqlCommand("select order_id from mdx_purchase_orders where requisition_id in(select requisition_id from mdx_purchase_requisition_details where requisition_detail_id='" + requisition_detail_id + "')", cn);

                    string order_id = (string)cmd3.ExecuteScalar();
                    string quantity = ((TextBox)row.FindControl("txtquant")).Text;
                    string desc = ((TextBox)row.FindControl("txtdesc")).Text;
                    cmd2 = new SqlCommand("usp_insert_mdx_purchase_order_details", cn);
                    cmd2.Parameters.AddWithValue("@order_id", order_id);
                    cmd2.Parameters.AddWithValue("@requisition_detail_id", requisition_detail_id);
                    cmd2.Parameters.AddWithValue("@accepted_quantity", quantity);
                    cmd2.Parameters.AddWithValue("@description", desc);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.ExecuteNonQuery();
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Purchase Order Inserted SuccessFully..!";

                }//end of foreach
            }//end of try
            catch (Exception ex3)
            {

                lblmessage.Visible = true;
                lblmessage.Text = ex3.Message.ToString();

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally


        }//end of bind_order()

        private void insert()

        {
            try
            {
                insert_purchase_orders();
                bind_order();
            }//end of try
            catch (Exception ex)
            {
                if (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
                {
                    bind_order();

                }//end of if
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = ex.Message.ToString();

                }//end of else
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//en dof finally

        }//end of insert



        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                insert_purchase_orders();
                bind_order();
            }//end of try
            catch (Exception ex)
            {
                if (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
                {
                    bind_order();

                }//end of if
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = ex.Message.ToString();

                }//end of else
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally
        }//end of btn click
         //code to paging in gridview
        protected void grid_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();

        }


        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_accepted_orders.aspx?");
        }
    }
}





