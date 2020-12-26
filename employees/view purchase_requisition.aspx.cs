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
    public partial class Employees_view_purchase_requisition : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter da1;
        DataSet ds1;
        GridViewRow row;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ///////////////Security////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ///////////////Security////////////
                    if (ck == true)
                    {//Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lblorderdate.Text = DateTime.Now.ToShortDateString();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();
                            cmd = new SqlCommand("select role_id from mdx_emp_relations where top_user='" + lblemp.Text + "' ", cn);
                            int roleid = Convert.ToInt32(cmd.ExecuteScalar());
                            if (roleid == 1)
                            {
                                bindtopuser();//call the function to binding of the topuser details
                            }
                            else if (roleid == 2)
                            {
                                binddata();

                            }

                            cn.Close();

                        }//end of if(!ispostback)
                    }//end of if(ck==true) 
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }

        }//end of page load
         //function to binding data 
        private void binddata()
        {

            try
            {
                string str = Session["AUserName"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select distinct  p.requisition_id ,p.user_id,p.requisition_gen_date,p.requisition_expected_date from mdx_emp_relations q,mdx_purchase_requisition p where p.user_id=q.user_id and q.top_user='" + str + "' ", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_emp_relations");
                if (ds.Tables["mdx_emp_relations"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds.Tables["mdx_emp_relations"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_emp_relations"];
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
        }//end of function 
         //function to binding data of the topuser 

        private void bindtopuser()
        {
            try
            {
                string str = Session["AUserName"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da1 = new SqlDataAdapter("select distinct  p.requisition_id ,p.user_id,p.requisition_gen_date,p.requisition_expected_date from mdx_emp_relations q,mdx_purchase_requisition p where p.user_id=q.user_id and q.top_user='" + str + "' ", cn);
                ds1 = new DataSet();
                da1.Fill(ds1, "mdx_emp_relations");
                if (ds1.Tables["mdx_emp_relations"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                }
                else
                {
                    try
                    {
                        GridView1.DataSource = ds1.Tables["mdx_emp_relations"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds1.Tables["mdx_emp_relations"];
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
        }//end of function  to binding data of the topuser 

        protected void grid_paging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }//end of gridview pagin
    }//end of class
}