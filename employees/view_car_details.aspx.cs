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
    public partial class Employees_view_car_details : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        string proj_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AUserName"] != null)
                {
                    //        functions ULC = new functions();
                    //        bool ck;
                    //        string st1 = Request.PhysicalApplicationPath;
                    //        string st2 = Request.PhysicalPath;
                    //        string[] s = st2.Split(new char[] { '/', '\\' });
                    //        string st3 = s.GetValue(s.Length - 1).ToString();
                    //        ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    //        if (ck == true)
                    //        {
                    if (!IsPostBack)
                    {
                        display();
                        lbldate1.Text = DateTime.Now.ToShortDateString();
                        lblempname.Text = Session["AUserName"].ToString();
                        lblemp.Text = Session["AUserName"].ToString();
                    }//end of if(!ispostback)
                     //        }
                     //        else
                     //        {
                     //            Response.Redirect("../noprivilise.aspx");
                     //        }
                     //    }
                     //    else
                     //    {
                     //        Response.Redirect("../Default.aspx");

                }//end of if(Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }
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
         //function to display cars information

        private void display()
        {
            string str = Request.QueryString["car_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_display_mdx_cars", cn);
            cmd.Parameters.AddWithValue("@car_id", str);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblclientname.Text = dr["client_id"].ToString();
                proj_name = dr["project_id"].ToString();
                lbltoemp.Text = dr["to_emp_id"].ToString();
                lblattention.Text = dr["attention"].ToString();
                lblfromemp.Text = dr["user_id"].ToString();
                lbldate.Text = dr["car_send_date"].ToString();
                lbldescription.Text = dr["description"].ToString();

            }//end of while
            dr.Close();
            cmd = new SqlCommand("select project_name from mdx_projects where project_id = '" + proj_name + "'", cn);
            lblprojname.Text = (String)cmd.ExecuteScalar();
            cn.Close();
        }//end of function display()
         //function to update  cars reply from employees
        private void update()
        {
            try
            {
                string str = Request.QueryString["car_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_car_reply", cn);
                cmd.Parameters.AddWithValue("@car_id", str);
                cmd.Parameters.AddWithValue("@reply", txtreply.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessge.Visible = true;
                lblmessge.Text = "Car Reply Updated successFully..!";
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

        }//end of update()

        protected void Button1_Click(object sender, EventArgs e)
        {
            update();//call the function
        }
        protected void Btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_cars.aspx?");

        }
    }//end of class
}