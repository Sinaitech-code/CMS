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
    public partial class projects_assign_project_to_employee : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        functions fun = new functions();
        string user_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {/////////security//////////
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
                    {//////////security////////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlclients, "select distinct client_id,client_name from mdx_clients");
                            fun.fnfill(ddlempgrade, "select grade_id,grade_name from  mdx_employee_grade");
                            bindrbtn();
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(session["AUserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {


            }//end of finally
        }
        //code to bind radiobuttons
        private void bindrbtn()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            da = new SqlDataAdapter("select role_id,role_name from mdx_roles", cn);
            ds = new DataSet();
            da.Fill(ds, "mdx_roles");
            rbtn.DataTextField = "role_name";
            rbtn.DataValueField = "role_id";
            rbtn.DataSource = ds.Tables["mdx_roles"];
            rbtn.DataBind();
            cn.Close();

        }//end of bindbtn()
         //code to insertdata
        private void insertdata()
        {
            try
            {

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                for (int i = 1; i < listboxemp.Items.Count; i++)
                {
                    cmd = new SqlCommand("usp_insert_mdx_emp_project_assign", cn);
                    cmd.Parameters.AddWithValue("@client_id", ddlclients.SelectedValue);
                    cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedValue);
                    cmd.Parameters.AddWithValue("@emp_grade", ddlempgrade.SelectedValue);
                    cmd.Parameters.AddWithValue("@role_id", rbtn.SelectedValue);
                    if (listboxemp.Items[i].Selected == true)
                    {
                        user_id = listboxemp.Items[i].Value;

                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }//end of if
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Project Assigned To Employee SuccessFully..!";
                }//end of for
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }   //end of finally

        }//end of insertdata()
         //code to update user rollid
        private void updateusers()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_update_roleid_mdx_users", cn);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@role_id", rbtn.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cn.Close();


        }//end of updateusers

        protected void btnasign_Click(object sender, EventArgs e)
        {
            lblrole.Text = "";
            insertdata();
            updateusers();
        }
        //event ddlclients_selectedindexchanged to load the projects when ddlclients selected index is changed
        protected void ddlclients_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblrole.Text = "";
            fun.fnfill(ddlproject, "select  distinct project_id,project_name from mdx_projects  where client_id='" + ddlclients.SelectedValue + "'");


        }//end of event
         //event ddlempgrade_slectedindexchanged1 to load userid when ddlempgrade selected index is changed
        protected void ddlempgrade_SelectedIndexChanged1(object sender, EventArgs e)
        {
            lblrole.Text = "";
            fun.filllistbox(listboxemp, "select user_id  from mdx_employees where grade_id='" + ddlempgrade.SelectedValue + "'and status!='1' and dept_name!='admin'");

        }// end of event
         //event listboxemp_selectedindexchanged to check the emp role for the selected project 
        protected void listboxemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblrole.Text = "";

                if (listboxemp.SelectedItem.Text != "Select")
                {
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();

                    for (int i = 0; i < listboxemp.Items.Count; i++)
                    {
                        string str = listboxemp.SelectedValue.ToString();
                        try
                        {

                            cmd = new SqlCommand("select role_id  from mdx_emp_project_assign where user_id='" + str + "' and project_id='" + ddlproject.SelectedValue + "' ", cn);
                            object emprole = cmd.ExecuteScalar();
                            if (emprole.ToString() != "0")
                            {
                                cmd = new SqlCommand("select role_name from mdx_roles where role_id=" + emprole + "", cn);
                                string strrolename = (String)cmd.ExecuteScalar();
                                lblrole.Visible = true;
                                lblrole.Text = "employee is already selected as  " + strrolename + " for this project";
                                lblmessage.Text = "";
                            }//end of emp
                        }//end of try
                        catch (Exception ex2)
                        {

                        }//end of catch


                    }//end of for
                    cn.Close();
                }//end of if
            }//end of try
            catch (Exception ex1)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex1.Message.ToString();

            }//end of catch

        }
    }
}