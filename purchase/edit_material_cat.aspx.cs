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

namespace CMS.purchase
{
    //Summary description for Masterpages_edit_material_cat
    public partial class Masterpages_edit_material_cat : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;
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
                    {
                        // Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            display();
                        }// end of  if (!IsPostBack)
                    }
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if(Session["User_Id"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else if(Session["User_Id"]!=null)
            }// end of page load
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;

            }//end of catch
            finally
            {


            }//end of finally

        }//end of page load

        // function display material category in GridView
        private void display()
        {
            try
            {

                string str = Request.QueryString["category_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd1 = new SqlCommand("usp_display_mdx_material_category", cn);
                cmd1.Parameters.AddWithValue("@category_id", str);

                cmd1.CommandType = CommandType.StoredProcedure;
                dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    txtcatname.Text = dr["category_name"].ToString();
                    txtdesc.Text = dr["description"].ToString();
                } //end of while loop
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


        }//end of funtion display

        //function update to edit material category details
        private void update()
        {
            try
            {

                string str = Request.QueryString["category_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_material_category ", cn);
                cmd.Parameters.AddWithValue("@category_id", str);
                cmd.Parameters.AddWithValue("@category_name", txtcatname.Text);
                cmd.Parameters.AddWithValue("@description", txtdesc.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Material Catagory Updated SuccessFully..!";

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

        }//end of function update

        //btnsave_Click to update  material category details
        protected void btnsave_Click(object sender, EventArgs e)
        {
            update();
        }//end of btnsave_Click
    }//end of class Masterpages_edit_material_cat
}