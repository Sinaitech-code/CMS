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
using System.Text;

namespace CMS.Employees
{
    public partial class Employees_pretty_expencess : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        DataSet ds;
        functions fun = new functions();
        DataTable dt;
        DataRow dr;
        DataRow drow;
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
                    ///////// ////////////////////////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();

                            ViewState["sno"] = pretty_sno();
                            string str = ViewState["sno"].ToString();
                            bindgrid();
                            labeldate.Text = DateTime.Now.ToShortDateString();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();

                            int count = 5;

                            if (ViewState["dt"] != null)
                            {
                                DataTable dt = (DataTable)ViewState["dt"];

                                bindgrid(count);

                            }
                            else
                            {

                                bindgrid(count);
                            }
                        }//end of if(!ispostback)


                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if (Session["AUserName"] != null)
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

        }//end of pageload
         //function to binding rows in gridview 
        private void bindgrid(int rowcount)
        {
            try
            {
                DataTable dt = new DataTable();
                if (ViewState["dt"] != null)
                {
                    for (int i = 1; i <= rowcount - 1; i++)
                    {
                        dt = (DataTable)ViewState["dt"];
                        drow = dt.NewRow();
                        dt.Rows.Add(drow);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                    }//end of for

                }//end of if(ViewState["dt"] != null)
            }//end of try
            catch (Exception ex1)
            {
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {

            }
        }//end of function 
         //function to grnerate number

        public string pretty_sno()
        {
            string sno;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_autonum_mdx_daily_report_prettyexpenses_account_details", cn);
            strm = cmd1.Parameters.Add("@sno", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            sno = (string)cmd1.Parameters["@sno"].Value;
            return (sno);
            cn.Close();
        }//end of pretty_sno()
         //function to insert expencess in the database

        private void insert_expencess()
        {
            try
            {


                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    string desc;
                    string expences;
                    decimal exp = 0;

                    desc = ((TextBox)row.FindControl("txtdesc")).Text;
                    expences = ((TextBox)row.FindControl("txtexpences")).Text;

                    if (expences.Trim() != "")
                    {
                        exp = Convert.ToDecimal(expences.ToString());
                        cmd = new SqlCommand("usp_insert_mdx_daily_report_prettyexpenses_account_details", cn);
                        cmd.Parameters.AddWithValue("@user_id", Session["AUserName"].ToString());
                        cmd.Parameters.AddWithValue("@sno", ViewState["sno"]);
                        cmd.Parameters.AddWithValue("@expenses", exp);
                        cmd.Parameters.AddWithValue("@description", desc);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();


                    }//end of if((expences.Trim() != "")

                }//end of foreach
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Pretty expenses Inserted SuccessFully..!";
            }//end of try
            catch (Exception ex2)
            {
                lblerr_msg.Text = ex2.Message.ToString();
                lblerr_msg.Visible = true;

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }//end of insert_expencess()

        protected void btnsave_Click(object sender, EventArgs e)
        {
            insert_expencess();
        }//end of btnsave_Click
         //function to binding data
        private void bindgrid()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select description,expenses from mdx_daily_report_account_details where expenses =000000 ", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_daily_report_account_details");
                ViewState["dt"] = ds.Tables["mdx_daily_report_account_details"];
                dt = (DataTable)ViewState["dt"];
                drow = dt.NewRow();
                dt.Rows.Add(drow);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }//end of try
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
        }//end of function bindgrid
    }//end of class
}