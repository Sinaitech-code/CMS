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
    public partial class admin_send_car : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        functions fn = new functions();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /////////////////////////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////////////////////////////Security///////////////
                    if (ck == true)
                    { //// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            txtdate.Value = DateTime.Now.ToShortDateString();
                            txtfrom_empname.Value = Session["AUserName"].ToString();
                            lblclient_name.Text = Session["clientname"].ToString();
                            lblproj_name.Text = Session["projectname"].ToString();
                            txtto_empname.Value = Session["toempname"].ToString();

                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)
                }//end of  if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else  if (Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();


            }//end of catch
            finally
            {

            }

        }//end of page load
         //function  to insert the data in the database

        private void insert_car()
        {
            try
            {

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_insert_mdx_car", cn);
                cmd.Parameters.AddWithValue("@client_id", lblclient_name.Text);
                cmd1 = new SqlCommand("select project_id from mdx_projects where project_name ='" + lblproj_name.Text + "'", cn);
                int projectid = Convert.ToInt32(cmd1.ExecuteScalar());
                cmd.Parameters.AddWithValue("@project_id", projectid);
                cmd.Parameters.AddWithValue("@to_emp_id", txtto_empname.Value);
                cmd.Parameters.AddWithValue("@attention", txtattent.Value);
                cmd.Parameters.AddWithValue("@car_send_date", txtdate.Value);
                cmd.Parameters.AddWithValue("@description", textarea1.Value);
                cmd.Parameters.AddWithValue("@user_id", Session["AUserName"].ToString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Car Sent SuccessFully..!";
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

        }//end of function insert_car()

        protected void button_ServerClick(object sender, EventArgs e)
        {
            insert_car();
        }//end of button click

    }//end of class
}