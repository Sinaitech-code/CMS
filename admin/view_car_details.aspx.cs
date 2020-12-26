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
    public partial class admin_view_car_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommand cmd2;
        SqlCommand cmd1;
        SqlCommand cmd3;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    /////////////////////////////////////////////////////Security///////////////
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {

                        if (!IsPostBack)
                        {
                            //// Put user code to initialize the page here

                            lblemp.Text = Session["AUserName"].ToString();

                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            string str = Request.QueryString["car_id"].ToString();
                            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                            cn.Open();
                            cmd1 = new SqlCommand("select  to_emp_id from mdx_cars where car_id='" + str + "'", cn);
                            string stremp = (String)cmd1.ExecuteScalar();
                            lblempname.Text = stremp.ToString();
                            display();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)

                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else if (Session["AUserName"] != null)
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
         //function to display send car details 

        private void display()
        {
            try
            {
                lblerr_msg.Text = "";
                string str = Request.QueryString["car_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd2 = new SqlCommand("select project_id from mdX_cars where car_id='" + str + "'", cn);
                int strprojectid = Convert.ToInt32(cmd2.ExecuteScalar());
                cmd3 = new SqlCommand("select project_name from mdx_projects where project_id='" + strprojectid.ToString() + "'", cn);
                string projname = (String)cmd3.ExecuteScalar();
                lblprojname.Text = projname.ToString();
                cmd = new SqlCommand("usp_display_admin_view_car_details", cn);
                cmd.Parameters.AddWithValue("@car_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lblclientname.Text = dr["client_id"].ToString();
                    lblprojname.Text = projname.ToString(); ;
                    lblfromemp.Text = dr["user_id"].ToString();
                    lbltoemp.Text = dr["to_emp_id"].ToString();
                    lbldate.Text = dr["car_send_date"].ToString();
                    lblattention.Text = dr["attention"].ToString();
                    lbldescription.Text = dr["description"].ToString();
                    lblreply.Text = dr["reply"].ToString();

                }//end of while
                dr.Close();

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

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_cars.aspx?");
        }//end of button click
    }//end of class
}