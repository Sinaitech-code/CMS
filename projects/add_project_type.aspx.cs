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
    public partial class admin1_add_project_type : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {/////////////security/////////////////
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
                    {
                        /////////security/////////////////

                        lblemp.Text = Session["AUserName"].ToString();
                        lbldate1.Text = DateTime.Now.ToShortDateString();
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
        //fun to check whether project type is exists or not 
        private bool checkproject_type()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from mdx_project_type where  type_name='" + txtprojtype.Text + "'", cn);
            object obj = cmd.ExecuteScalar();
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                lblerr_msg.Text = "";
                lblcheckavaliable.Visible = true;
                lblcheckavaliable.Text = "Project Type Already Exists";
                return false;
            }

        }//end of checkproj_type()
         //code for insert project_type
        private void insert_project_type()
        {

            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_insert_mdx_project_type", cn);
            cmd.Parameters.AddWithValue("@type_name", txtprojtype.Text);
            cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            txtdescription.Text = "";
            txtprojtype.Text = "";
            cn.Close();

        }//end of insert_project_type
         //code to insert_project_type details and clear all the fields
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (checkproject_type())
                {
                    insert_project_type();
                    lblcheckavaliable.Text = "";
                    lblcheckavaliable.Visible = true;
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Project Type Inserted SuccessFully..!";

                }

            }
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString(); ;

            }
            finally
            {
                cn.Close();
                cn.Dispose();

            }

        }

    }
}