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
    //Summary description for Masterpages_add_material 
    public partial class Masterpages_add_material : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();

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
                            fun.fnfill(ddlmat_cat, "select category_id,category_name from mdx_material_category");
                        }//end of if (!IsPostBack)
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
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");

            }//end of catch
            finally
            {

            }//end of finally
        }//end of page load

        //function checkavaliable to check the availability of the material in database
        private bool checkavaliable()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from  mdx_materials where material_name='" + txtmaterialname.Text + "'", cn);
            object obj = cmd.ExecuteScalar();
            if (obj.ToString() == "0")
            {

                return true;
            }//end of if (obj.ToString() == "0")
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblcheck.Visible = true;
                lblcheck.Text = "Material Already Exists....Please Try Another Material";
                return false;

            } //end of else if (obj.ToString() == "0")

        }//end of function checkavaliable

        //function insert to insert material if material not exists 
        private void insert()
        {
            try
            {
                if (checkavaliable())
                {
                    lblcheck.Text = "";
                    string str = "false";
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("usp_insert_mdx_materials", cn);
                    cmd.Parameters.AddWithValue("@category_id", ddlmat_cat.SelectedValue);
                    cmd.Parameters.AddWithValue("@material_name", txtmaterialname.Text);
                    cmd.Parameters.AddWithValue("@description", txtdesc.Text);
                    cmd.Parameters.AddWithValue("@is_deleted", str);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Material  Inserted SuccessFully..!";
                    // Response.Write("<script language='javascript'>alert('Material  Inserted SuccessFully..!' )</script>");
                }//end of if (checkavaliable())
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch

            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally

        }//end of function insert
        protected void btnsave_Click(object sender, EventArgs e)
        {

            insert();
            lblcheck.Visible = true;
            ddlmat_cat.SelectedIndex = 0;
            txtdesc.Text = "";
            txtmaterialname.Text = "";
        }

    }//end of class Masterpages_add_material
}