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
    public partial class accounts_view_accounts : System.Web.UI.Page
    //public partial class accounts_view_account_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // ////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    // starting if (Session["AUserName"])

                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    if (ck == true)
                    {
                        ////////////////////Security///////////////
                        // Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            //  start if statement
                            binddata();
                            lblorderdate.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();


                        }
                        //end of if
                    }//end of if(ck)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(session["Ausername"])
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }
            //end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();

            }

            finally
            {


            }

        }// end of page load

        //function to  retriveing data from database
        private void binddata()
        {

            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select distinct order_id from mdx_purchase_order_details", cn);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //start if statement
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "No Records Found";

                }//end of if
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
                }//end of else (if(ds.tables[0].rows.count))
            }//end of try

            catch (Exception ex1)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex1.Message.ToString();


            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }//end of function binddata

    }
    //end of class accounts_view_account_details
}