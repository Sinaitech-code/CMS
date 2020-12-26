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

namespace CMS.accounts
{
    public partial class accounts_view_purchase_order_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        functions fun = new functions();
        SqlCommand cmd1;
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
                    //Put user code to initialize the page here
                    if (!IsPostBack)
                    {
                        binddata();
                        //lblempname.Text = Session["AUserName"].ToString();
                        lbldate.Text = DateTime.Now.ToShortDateString();
                        lblemp.Text = Session["AUserName"].ToString();
                        lblformno.Text = Request.QueryString["order_id"].ToString();
                        lblorderdate.Text = DateTime.Now.ToShortDateString();
                        string str = Request.QueryString["order_id"].ToString();
                        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                        cn.Open();
                        cmd = new SqlCommand("select p.user_id from mdx_purchase_requisition p,mdx_purchase_orders q where q.order_id='" + str + "'", cn);
                        lblempname.Text = (String)cmd.ExecuteScalar();
                    }//end of if(!ispostback)



                }//end of if(Session["Ausername"])
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }

        }//end of page load

        //function to binding data from database in gridview
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["order_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select a.accepted_quantity,b.quantity,a.order_detial_id,b.material_name  from mdx_purchase_order_details a, mdx_purchase_requisition_details b ,mdx_materials c where a.requisition_detail_id=b.requisition_detail_id and  b.material_id=c.material_id and a.order_id='" + str + "' and a.amount is null", cn);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    //lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Text = "amount paid for this purchse requisition";
                    lblerr_msg.Visible = true;
                    btnsubmit.Visible = false;

                }
                else
                {
                    try
                    {
                        btnsubmit.Visible = true;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        btnsubmit.Visible = true;
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();

                    }
                }//end of else 
            }//end of try

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

        }//end of function 
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //call function
                updateamount();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Amount Inserted SuccessFully..!";

            }
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();

            }
            finally
            {
                cn.Dispose();

            }

        }//end of btnsubmit_Click

        //function to update the amount and insert the amount
        private void updateamount()
        {
            string str = Request.QueryString["order_id"].ToString();

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            //start the foreach statement 
            foreach (GridViewRow row in GridView1.Rows)
            {
                //string amt= ((TextBox)row.FindControl("txtamt")).Text;
                decimal amt = Convert.ToDecimal(((TextBox)row.FindControl("txtamt")).Text);//convert to decimal datatype
                string order_det_id = GridView1.DataKeys[row.RowIndex].Value.ToString();//get the order_detail_id 
                cmd = new SqlCommand("usp_update_purchase_amount", cn);
                cmd.Parameters.AddWithValue("@order_detial_id", order_det_id);
                cmd.Parameters.AddWithValue("@amount", amt);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }//end of foreach

            cn.Close();
        }//end of updateamount()
         //update the amount in the database
        protected void btnback_Click1(object sender, EventArgs e)
        {
            Response.Redirect("view_purchase_orders.aspx");
        }
        //end of btnback_Click1
    }
    //end of class accounts_view_purchase_order_details
}