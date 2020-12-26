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
    public partial class admin1_edit_project_type : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {/////////security////////////////
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
                    {/////////security////////////////
                     //code to intialise the page
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            Display();
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AuUserName"]!=null)
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
         //code to display the projecttype
        private void Display()
        {
            try
            {
                string str = Request.QueryString["project_type_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_project_type", cn);
                cmd.Parameters.AddWithValue("@project_type_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    txtprojtype.Text = dr["type_name"].ToString();
                    txtdescription.Text = dr["description"].ToString();

                }//end of while
                dr.Close();
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
        }//end of pageload
         //code to update the project type details
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string str = Request.QueryString["project_type_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_project_type", cn);
                cmd.Parameters.AddWithValue("@project_type_id", str);
                cmd.Parameters.AddWithValue("@type_name", txtprojtype.Text);
                cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Project Type Updated SuccessFully..!";


            }//end of try
            catch (Exception ex)
            {
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