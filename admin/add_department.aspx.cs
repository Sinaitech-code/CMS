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

namespace CMS.admin
{
    public partial class admin1_add_department : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ////////////////////Security///////////////
                    if (ck == true)
                    {// Put user code to initialize the page here
                        if (!IsPostBack)
                        {  // Put user code to initialize the page here
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                        }//end of if(!ispostback)


                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)

                }//end of if((Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else if((Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {

            }//end of finally

        }//end of pageload
         //function to insert dept information in the database
        private void insertdept()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_insert_mdx_departments", cn);
            cmd.Parameters.AddWithValue("@dept_name", txtdept.Text);
            cmd.Parameters.AddWithValue("@Description", txtdescription.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cn.Close();
            txtdept.Text = "";
            txtdescription.Text = "";
        }//end of function

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                insertdept();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = " Department Inserted SuccessFully..!";

            }//end of try
            catch (Exception ex)
            {

                if (((System.Data.SqlClient.SqlException)((ex.GetBaseException()))).Number == 2627)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "";
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = "Department already Exist,Choose Another";


                }//end of if
                else
                {
                    lblerr_msg.Visible = true;
                    lblerr_msg.Text = ex.Message.ToString();
                }//end of else

            }//end of catch
            finally
            {


            }//end of finally

        }//end of button click

    }//end of class
}