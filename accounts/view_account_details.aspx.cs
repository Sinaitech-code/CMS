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
    public partial class accounts_view_account_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {//start page_load
            if (!IsPostBack)
            {
                binddata();
                lblorderdate.Text = DateTime.Now.ToShortDateString();
                lblemp.Text = Session["AUserName"].ToString();


            } //end of if(!ispostback)

        }
        //end of page load

        //function to binding accounts information  from database
        private void binddata()
        {
            string str = Request.QueryString["order_id"].ToString();
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select distinct order_id,accepted_quantity,description,amount from mdx_purchase_order_details where order_id='" + str + "'and amount is not null", cn);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //staring if statement

                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "No Records Found";

                }//end if 
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

                    }//end of inner catch
                }//end of else
            }//end of try

            catch (Exception ex1)
            {

                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex1.Message.ToString();


            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }//end of function

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_accounts.aspx?");

        }//end of button click
    }
    //end of class accounts_view_account_details

}

