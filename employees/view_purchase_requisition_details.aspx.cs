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
    public partial class Employees_view_purchase_requisition_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlCommand cmd4;
        SqlCommand cmd5;
        SqlCommand cmd6;
        SqlCommand cmd7;
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
                    ////Put user code to initialize the page here
                    if (!IsPostBack)
                    {
                        binddata();
                        bindrbtn();
                        display();

                        lbldate.Text = DateTime.Now.ToShortDateString();
                        lblformno.Text = Request.QueryString["requisition_id"].ToString();
                        lblemp.Text = Session["AUserName"].ToString();
                    }//end of if(!ispostback)


                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("select distinct p.project_name from mdx_projects p,mdx_emp_relations  r where p.project_id=r.project_id and  r.top_user='" + lblemp.Text + "'", cn);
                    lblprojectid.Text = (String)cmd.ExecuteScalar();
                    cmd6 = new SqlCommand("select requisition_gen_date from mdx_purchase_requisition where requisition_id='" + lblformno.Text + "'", cn);
                    lblcreatedate.Text = (String)cmd6.ExecuteScalar();
                    cmd7 = new SqlCommand("select distinct q.role_id from mdx_purchase_requisition p,mdx_emp_relations  q where p.requisition_id='" + lblformno.Text + "' and p.emp_status=1 and q.top_user='" + lblemp.Text + "'", cn);
                    object objroleid = cmd7.ExecuteScalar();

                    try
                    {
                        if (objroleid.ToString() == "1")
                        {
                            lblaccepted.Visible = true;
                            lblstatuschangedbyemp.Visible = true;
                            cmd5 = new SqlCommand("select distinct p.status_by_emp from mdx_purchase_requisition p,mdx_emp_relations  q where p.requisition_id='" + lblformno.Text + "' and p.emp_status=1 and q.top_user='" + lblemp.Text + "'", cn);
                            lblstatuschangedbyemp.Text = (String)cmd5.ExecuteScalar();


                        }//end of if(objroleid.ToString() == "1")
                    }
                    catch (Exception ex1)
                    {
                        lblaccepted.Visible = false;
                        lblstatuschangedbyemp.Visible = false;
                    }


                    cn.Close();
                }//end of if (Session["AUserName"] != null)
                 //        }
                 //        else
                 //        {
                 //            Response.Redirect("../noprivilise.aspx");
                 //        }
                 //    }

            }
            catch (Exception ex)
            {
                //Response.Redirect("../Default.aspx");
                Response.Write(ex.Message.ToString());
            }
            finally
            {

            }
        }//end of page load
         //function to  binding purchase requisition 
        private void binddata()
        {
            try
            {
                string str = Request.QueryString["requisition_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                da = new SqlDataAdapter("select a.requisition_id,a.requisition_detail_id,a.material_name,a.description,a.quantity  from mdx_purchase_requisition_details a inner join mdx_materials b on a.material_id=b.material_id  where requisition_id='" + str + "'", cn);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "No Records Found";

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
                }
            }

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

        }//end of function binddata()
         //function to binding  status of the purchase requisition 


        private void bindrbtn()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select status_id,status_name from mdx_purchase_requisition_status", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_purchase_requisition_status");
            rbtn.DataValueField = "status_id";
            rbtn.DataTextField = "status_name";
            rbtn.DataSource = ds.Tables["mdx_purchase_requisition_status"];
            rbtn.DataBind();
            cn.Close();

        }//end of function bindrbtn()
         //update the status of the  purchase requisition
        protected void btnsubmit_Click1(object sender, EventArgs e)
        {
            string str = Request.QueryString["requisition_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select p.role_id from mdx_emp_relations p, mdx_purchase_requisition q where p.top_user='" + lblemp.Text + "' and q.requisition_id='" + str + "'", cn);
            int roleid = Convert.ToInt32(cmd.ExecuteScalar());
            if (roleid == 1)
            {
                update_status_top_user();//call the function update status of the topuser
            }
            else if (roleid == 2)
            {
                update_status_by_emp();

            }

        }//end of button click
         //function to update  status of the employee
        private void update_status_by_emp()
        {
            string str = Request.QueryString["requisition_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_update_emp_status_purchase_requisition", cn);
            cmd.Parameters.AddWithValue("@requisition_id", str);
            cmd.Parameters.AddWithValue("@emp_status", rbtn.SelectedValue);
            cmd.Parameters.AddWithValue("@status_by_emp", lblemp.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            lblmessage.Visible = true;
            lblmessage.Text = " Employee Status SuccessFully..!";
            //Response.Write("<script language='javascript'>alert('Employee Status SuccessFully..!' )</script>");

            cn.Close();
        }//end of function update_status_by_emp()
         //function to update status of the top user
        private void update_status_top_user()
        {
            string str = Request.QueryString["requisition_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            string val = rbtn.SelectedItem.Text;
            string val1 = rbtn.SelectedValue;
            string val2 = rbtn.SelectedItem.Value;
            cmd = new SqlCommand("usp_update_purchase_requisition_status_by_topuser", cn);
            cmd.Parameters.AddWithValue("@requisition_id", str);
            cmd.Parameters.AddWithValue("@top_user_status", rbtn.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            lblmessage.Visible = true;
            lblmessage.Text = "Employee Status Updated SuccessFully..!";
            //Response.Write("<script language='javascript'>alert('Employee Status SuccessFully..!' )</script>");

            cn.Close();

        }//end of function update_status_top_user()
         //function to display the create purchase requisition date
        private void display()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select user_id,requisition_gen_date from mdx_purchase_requisition where requisition_id='" + Request.QueryString["requisition_id"].ToString() + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblempname.Text = dr["user_id"].ToString();
                lblcreatedate.Text = dr["requisition_gen_date"].ToString();
            }
            dr.Close();
            cn.Close();
        }//end of function display()

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view purchase_requisition.aspx");
        }
    }//end of class
}