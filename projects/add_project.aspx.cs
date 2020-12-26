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
    public partial class admin1_add_project : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /////////security//////////
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
                    {///////////security///////////
                     //put user code to initialize the page
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlclient, "select client_id,client_name from mdx_clients");
                            fun.fnfill(ddlprojtype, " select project_type_id,type_name from mdx_project_type");
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
        }//end of pageload
         //fun to check project whether it is exists or not
        private bool ckeck_project()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from  mdx_projects where project_name='" + txtprojname.Text + "'", cn);
            object obj = cmd.ExecuteScalar();
            if (obj.ToString() == "0")
            {

                return true;
            }
            else

            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblcheck.Visible = true;
                lblcheck.Text = "Project Already Exists....Please Try Another Project";
                return false;
            }

        }//end of chech_project()
        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (ckeck_project())
                {
                    //to insert the project details
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("usp_insert_mdx_projects", cn);
                    cmd.Parameters.AddWithValue("@project_type_id", ddlprojtype.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@client_id ", ddlclient.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@project_name", txtprojname.Text);
                    cmd.Parameters.AddWithValue("@project_start_date", txtsdate.Text);
                    cmd.Parameters.AddWithValue("@project_end_date", txtfinishingate.Text);
                    cmd.Parameters.AddWithValue("@user_id", Session["AUserName"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    lblcheck.Visible = true;
                    lblcheck.Text = "";
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Project Inserted SuccessFully..!";
                } //end of check project

            }//end of try
            catch (Exception ex)
            {


                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();


            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally

            txtfinishingate.Text = "";
            txtprojname.Text = "";
            txtsdate.Text = "";
            ddlclient.SelectedIndex = 0;
            ddlprojtype.SelectedIndex = 0;
        }//end of btnsave

        protected void ddlclient_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

    }
}