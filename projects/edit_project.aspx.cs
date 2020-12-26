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
    public partial class admin1_edit_project : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {////////security////////////////
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
                    {/////////security/////////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlclient, "select client_id,client_name from mdx_clients");
                            fun.fnfill(ddlprojtype, " select project_type_id,type_name from mdx_project_type");
                            displayproject();
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AuserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else
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
         //code to display project
        private void displayproject()
        {
            try
            {

                string str = Request.QueryString["project_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_projects", cn);
                cmd.Parameters.AddWithValue("@project_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlclient.SelectedValue = dr["client_id"].ToString();
                    ddlprojtype.SelectedValue = dr["project_type_id"].ToString();
                    txtprojname.Text = dr["project_name"].ToString();
                    txtsdate.Text = dr["project_start_date"].ToString();
                    txtfinishingate.Text = dr["project_end_date"].ToString();

                }//end of while
                dr.Close();

            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally


        }//end of displayproject
         //code to edit the project details
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string str = Request.QueryString["project_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_projects", cn);
                cmd.Parameters.AddWithValue("@project_id", str);
                cmd.Parameters.AddWithValue("@client_id", ddlclient.SelectedValue);
                cmd.Parameters.AddWithValue("@project_type_id", ddlprojtype.SelectedValue);
                cmd.Parameters.AddWithValue("@project_name", txtprojname.Text);
                cmd.Parameters.AddWithValue("project_start_date", txtsdate.Text);
                cmd.Parameters.AddWithValue("project_end_date", txtfinishingate.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Project Updated SuccessFully..!";


            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();


            }//end of finally


        }//end of btnclick
    }
}