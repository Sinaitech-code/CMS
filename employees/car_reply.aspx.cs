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
    public partial class Employees_car_reply : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        string proj_name;
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
                    /////////////////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {//// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblempname.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
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
            }
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;


            }
            finally
            {


            }

        }//end of page load
         //function to display car details 

        private void display()
        {
            try
            {
                string str = Request.QueryString["car_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_cars_reply", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@car_id", str);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lblclientname.Text = dr["client_id"].ToString();
                    proj_name = dr["project_id"].ToString();
                    lbltoemp.Text = dr["to_emp_id"].ToString();
                    lbldate.Text = dr["car_send_date"].ToString();
                    lblattention.Text = dr["attention"].ToString();
                    lbldescription.Text = dr["description"].ToString();
                    lblreply.Text = dr["reply"].ToString();
                    lblfromemp.Text = dr["user_id"].ToString();
                }//end of while
                dr.Close();
                cmd = new SqlCommand("select project_name from mdx_projects where project_id = '" + proj_name + "'", cn);
                lblprojname.Text = (String)cmd.ExecuteScalar();
                cn.Close();

            }
            catch (Exception ex1)
            {
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {
                cn.Open();
                cn.Dispose();
            }

        }//end of function display()


        protected void btnback_Click1(object sender, EventArgs e)
        {
            Response.Redirect("view_car_reply.aspx?");
        }//end of btnbackclick
    }//end of class
}