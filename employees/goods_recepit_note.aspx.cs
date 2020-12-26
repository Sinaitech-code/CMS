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
    public partial class Employees_goods_recepit_note : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlDataAdapter da;
        DataSet ds;
        DataSet ds1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ///////// ////////////////////////////////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    //// Put user code to initialize the page here
                    if (ck == true)
                    {

                        if (!IsPostBack)
                        {
                            string orderid = Request.QueryString["order_id"].ToString();
                            display();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            lblformno.Text = orderid;
                            ViewState["recp_id"] = receptautogennumber();
                            lblreceiptid.Text = ViewState["recp_id"].ToString();

                            lbldate.Text = DateTime.Now.ToShortDateString();
                            lblorderdate.Text = DateTime.Now.ToShortDateString();
                            bindrbtn();
                        } ////END OF IF(!ISPOSTBACK)
                        lblemp.Text = Session["AUserName"].ToString();

                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of  if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else  if (Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }

        }//end of page_load
         //function to autogenerate number 
        public string receptautogennumber()
        {
            string recp_id;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_autonum_grn", cn);
            strm = cmd1.Parameters.Add("@receipt_id", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            recp_id = (string)cmd1.Parameters["@receipt_id"].Value;
            return (recp_id);
            cn.Close();
        }//end of function receptautogennumber()

        //function to binding the details 

        private void display()
        {
            try
            {
                string orderid = Request.QueryString["order_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select m.material_id,m.material_name,pr.quantity,po.description,po.accepted_quantity from mdx_purchase_order_details po,mdx_purchase_requisition_details pr,mdx_materials m where pr.requisition_detail_id=po.requisition_detail_id and m.material_id=pr.material_id and po.order_id='" + orderid + "'", cn);

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


                }//end of else
            }//end of try

            catch (Exception ex0)
            {
                lblerr_msg.Text = ex0.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }//end of display()
         //function to binding status details in radiobuttonlist


        private void bindrbtn()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_name,status_id  from mdx_purchase_order_status", cn);
            ds1 = new DataSet();
            da.Fill(ds1, "mdx_purchase_order_status");
            rbtnstatus.DataTextField = "status_name";
            rbtnstatus.DataValueField = "status_id";
            rbtnstatus.DataSource = ds1.Tables["mdx_purchase_order_status"];
            rbtnstatus.DataBind();
            cn.Close();

        }//end of function
         //function to insert  rejected quantity in the database

        private void insertdata()
        {
            try
            {
                string str = Request.QueryString["order_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_insert_mdx_goods_receipt_note", cn);
                cmd.Parameters.AddWithValue("@receipt_id", ViewState["recp_id"].ToString());
                cmd.Parameters.AddWithValue("@order_id", str);
                cmd.Parameters.AddWithValue("@status", rbtnstatus.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    string material_id = GridView1.DataKeys[row.RowIndex].Value.ToString();

                    string description = ((TextBox)row.FindControl("txtdesc")).Text;
                    string rejectedqty = ((TextBox)row.FindControl("txtrejected_qty")).Text;
                    string desc = ((TextBox)row.FindControl("txtdesc")).Text;
                    cmd2 = new SqlCommand("usp_insert_mdx_goods_receipt_note_details", cn);
                    cmd2.Parameters.AddWithValue("@receipt_id", ViewState["recp_id"].ToString());
                    cmd2.Parameters.AddWithValue("@material_id", material_id);
                    cmd2.Parameters.AddWithValue("@description", desc);
                    cmd2.Parameters.AddWithValue("@items_rejected", rejectedqty);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.ExecuteNonQuery();
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Record  Inserted SuccessFully..!";


                }//end of foreach (GridViewRow row in GridView1.Rows)



            }//end of try
            catch (Exception ex2)
            {
                // lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex2.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }//end of function insertdata()

        protected void btnsave_Click(object sender, EventArgs e)
        {
            insertdata();
        }//end of btnsave

    }//end of class
}