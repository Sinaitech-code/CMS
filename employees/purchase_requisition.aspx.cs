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
    public partial class purchage_requistion : System.Web.UI.Page
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
                    ///////////Security////////////
                    if (ck == true)
                    {
                        //Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            fun.fnfill(ddlproject, "select project_id,project_name from mdx_projects where project_id in(select project_id from mdx_emp_project_assign where user_id='" + Session["AUserName"] + "')");

                            lblemp.Text = Session["AUserName"].ToString();
                            lblformno.Text = formautonumber();
                            bindgrid();
                            labeldate.Text = DateTime.Now.ToShortDateString();
                            lblformdate.Text = DateTime.Now.ToShortDateString();
                            int count = 10;
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
         //function to binding adding rows in gridview
        private void bindgrid(int rowcount)
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

            }//end of if
        }//end of bindgrid(int rowcount)
         //function to autogenerate number

        private string formautonumber()
        {

            string NewId;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_autonum_mdx_requisition", cn);
            strm = cmd1.Parameters.Add("@requisition_id", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            NewId = (string)cmd1.Parameters["@requisition_id"].Value;
            return (NewId);
            cn.Close();
        }//end of function
         //function to create purchase of top user

        private void insert_purchase_requisition_topuser()
        {
            try
            {
                string strstatus = "1";
                string strname = Session["AUserName"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_insert_mdx_purchase_requisition_topuer", cn);
                cmd.Parameters.AddWithValue("@requisition_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@requisition_id ", lblformno.Text);
                cmd.Parameters.AddWithValue("@user_id", lblemp.Text);
                cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedValue);
                cmd.Parameters.AddWithValue("@requisition_gen_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@requisition_expected_date", txtexpdate.Text);
                cmd.Parameters.AddWithValue("@top_user_status", strstatus);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

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
         //function to inserting purchase requisition 

        private void insert_purchase_requisition()
        {
            try
            {
                string strname = Session["AUserName"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_insert_mdx_purchase_requisition", cn);
                cmd.Parameters.AddWithValue("@requisition_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@requisition_id ", lblformno.Text);
                cmd.Parameters.AddWithValue("@user_id", lblemp.Text);
                cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedValue);
                cmd.Parameters.AddWithValue("@requisition_gen_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("requisition_expected_date", txtexpdate.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

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
         //function to insert purchase requistion detailsin the database


        private void insert_purchase_requisition_details()
        {
            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList ddl;
                    string txt;
                    string quant;
                    string expdate;
                    expdate = txtexpdate.Text;
                    ddl = (DropDownList)row.FindControl("ddlitems");
                    if (ddl.SelectedItem.Text != "select")
                    {
                        txt = ((TextBox)row.FindControl("txtdesc")).Text;
                        quant = ((TextBox)row.FindControl("txtquantity")).Text;
                        cmd = new SqlCommand("usp_mdx_purchase_requisition_details", cn);
                        cmd.Parameters.AddWithValue("@quantity", quant);
                        cmd.Parameters.AddWithValue("@requisition_id ", lblformno.Text);
                        if (ddl.SelectedItem.Text.Trim().ToUpper() == "OTHER")
                        {
                            ((TextBox)row.FindControl("txtother")).Visible = true;
                            string stitem = ((TextBox)row.FindControl("txtother")).Text;
                            cmd.Parameters.AddWithValue("@material_id", ddl.SelectedValue);
                            cmd.Parameters.AddWithValue("@material_name", stitem);
                        }//end of if (ddl.SelectedItem.Text.Trim().ToUpper() == "OTHER")
                        else
                        {
                            ((TextBox)row.FindControl("txtother")).Visible = false;
                            cmd.Parameters.AddWithValue("@material_id", ddl.SelectedValue);
                            cmd.Parameters.AddWithValue("@material_name", ddl.SelectedItem.Text);
                        }
                        cmd.Parameters.AddWithValue("@excepted_date", expdate);
                        cmd.Parameters.AddWithValue("@description", txt);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }//end of if (ddl.SelectedItem.Text != "select")
                }//end of foreach
                lblmessage.Text = "Purchase Requisition Inserted SuccessFully..!";
                lblmessage.Visible = true;

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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select role_id from mdx_emp_project_assign where project_id='" + ddlproject.SelectedValue + "' and user_id='" + Session["AUserName"] + "'", cn);
            int roleid = Convert.ToInt32(cmd.ExecuteScalar());
            if (roleid == 1)
            {
                insert_purchase_requisition_topuser();//call the function create purchase of top user
                insert_purchase_requisition_details();
            }
            else
            {
                insert_purchase_requisition();
                insert_purchase_requisition_details();
                lblerr_msg.Text = "";
                lblmessage.Text = "Purchase Requisition Inserted SuccessFully..!";
                lblmessage.Visible = true;

            }//end of else if(roleid==1)


        }//end of button click
         //function to binding data 
        private void bindgrid()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select material_id,description,quantity from mdx_purchase_requisition_details where description='cxaxpxs'", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_purchase_requisition_details");
            ViewState["dt"] = ds.Tables["mdx_purchase_requisition_details"];
            dt = (DataTable)ViewState["dt"];
            drow = dt.NewRow();
            dt.Rows.Add(drow);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();
        }//end of function
         //function to bind the material in the dataset

        public DataSet ddlbind()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select material_id,material_name from mdx_materials", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_materials");
            return ds;

        }//end of ddlbind()
         //if other selected in the dropdownlist and display the textbox

        protected void ddl_selected(object sender, EventArgs e)
        {
            DropDownList ddlitem;
            TextBox txtitem;
            foreach (GridViewRow row in GridView1.Rows)
            {
                ddlitem = (DropDownList)row.FindControl("ddlitems");
                txtitem = (TextBox)row.FindControl("txtother");
                if (ddlitem.SelectedItem.Text == "other")
                {
                    txtitem.Visible = true;
                }
                else
                {
                    txtitem.Visible = false;
                }
            }


        }//end of event
         //function to binding no of rows in the gridview
        private void BindGrid(int rowcount)
        {
            try
            {

                DataTable dt = new DataTable();

                if (ViewState["dt1"] != null)
                {
                    for (int i = 1; i < rowcount + 1; i++)
                    {
                        dt = (DataTable)ViewState["dt1"];
                        if (dt.Rows.Count > 0)
                        {
                            dr = dt.NewRow();
                            dt.Rows.Add(dr);

                        }//end of  if (dt.Rows.Count > 0)
                        else
                        {
                            dr = dt.NewRow();
                            dt.Rows.Add(dr);//adding row
                        }//end of else 
                    }//end of for

                }//end of if(ViewState["dt1"] != null)
                else
                {
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);//adding row
                }//end of else if(ViewState["dt1"] != null)

                if (ViewState["dt1"] != null)
                {
                    GridView1.DataSource = (DataTable)ViewState["dt1"];
                    GridView1.DataBind();
                }//end of if
                else
                {

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }//end of else
                ViewState["dt1"] = dt;
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


        }//end function  
    }//end of class

}





    
   
