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

namespace CMS.projects
{
    public partial class projects_view_rejected_order_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlCommand cmd4;
        SqlCommand cmd5;
        SqlCommand cmd6;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////////security/////////////
                if (Session["AUserName"] != null)
                {
                    //code to initialise the page
                    if (!IsPostBack)
                    {
                        binddata();
                        bindrbtn();
                        lblemp.Text = Session["AUserName"].ToString();
                        lblformno.Text = Request.QueryString["requisition_id"].ToString();
                        lbldate.Text = DateTime.Now.ToShortDateString();
                    }//end of postback
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    da = new SqlDataAdapter("select p.project_name, pr.status_by_emp,pr.user_id,pr.requisition_gen_date from mdx_purchase_requisition pr,mdx_projects p where requisition_id='" + lblformno.Text + "' and p.project_id=pr.project_id", cn);
                    ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        lblprojectid.Text = dr["project_name"].ToString();
                        lblaccepted_by_emp.Text = dr["status_by_emp"].ToString();
                        lblempname.Text = dr["user_id"].ToString();
                        lblordergendate.Text = dr["requisition_gen_date"].ToString();

                    }//end of foreach

                    cmd3 = new SqlCommand("select top_user from mdx_emp_relations where user_id='" + lblaccepted_by_emp.Text + "'", cn);
                    lblacepted_by_topuser.Text = (String)cmd3.ExecuteScalar();

                }//end of if(session["AUserName"]!=null)
                else
                {
                    Response.Redirect("../noprivilise.aspx");
                }//end of else
            }//end of try


            catch (Exception ex)
            {
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
                //lblerr_msg.Text = ex.Message.ToString(); ;
                //lblerr_msg.Visible = true;
            }//end of catch
            finally
            {

            }//end of finally
        }

        protected void btnsubmit_Click1(object sender, EventArgs e)
        {
            try
            {
                string str = Request.QueryString["requisition_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_mdx_update_status_project_admin", cn);
                cmd.Parameters.AddWithValue("requisition_id", str);
                cmd.Parameters.AddWithValue("@projadmin", Session["AUserName"].ToString());
                cmd.Parameters.AddWithValue("@projadmin_status", rbtnlist.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Status Updated SuccessFully..!";
                //Response.Write("<script language='javascript'>alert('Status Updated SuccessFully..!' )</script>");

            }

            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }
        //code to fill grid
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["requisition_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select requisition_id,requisition_detail_id,material_id,description,quantity  from mdx_purchase_requisition_details  where requisition_id='" + str + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "mdx_purchase_requisition_details");
                if (ds.Tables["mdx_purchase_requisition_details"].Rows.Count == 0)
                {
                    lblerr_msg.Text = "No Records Found";
                    lblerr_msg.Visible = true;
                    btnsubmit.Visible = false;
                    rbtnlist.Visible = false;

                }//end of if
                else
                {
                    try
                    {

                        GridView1.DataSource = ds.Tables["mdx_purchase_requisition_details"];
                        GridView1.DataBind();


                    }//end of try
                    catch (Exception ex)
                    {
                        GridView1.DataSource = ds.Tables["mdx_purchase_requisition_details"];
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

        //code to bind radiobuttons
        private void bindrbtn()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_id,status_name from mdx_purchase_requisition_status", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_purchase_requisition_status");
            rbtnlist.DataTextField = "status_name";
            rbtnlist.DataValueField = "status_id";

            rbtnlist.DataSource = ds.Tables["mdx_purchase_requisition_status"];
            rbtnlist.DataBind();
            cn.Close();

        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_rejected_orders.aspx?");
        }
    }

}
