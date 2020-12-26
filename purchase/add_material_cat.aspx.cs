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
    //Summary description for Masterpages_add_material_cat 
    public partial class Masterpages_add_material_cat : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {     ////////////////////Security///////////////
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
                        } //end of if (!IsPostBack)
                    }//end of (ck == true)

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

            }//end of catch
            finally
            {

            }//end of finally
        }//end of page load

        private bool checkavaliable()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from  mdx_material_category where category_name='" + txtcatname.Text + "'", cn);
            object obj = cmd.ExecuteScalar();
            if (obj.ToString() == "0")
            {

                return true;
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblcheck.Visible = true;
                lblcheck.Text = "Catagory Already Exists....Please Try Another Catagory";
                return false;
            }
        }
        private void insert()
        {

            try
            {
                if (checkavaliable())
                {
                    lblcheck.Text = "";
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("usp_insert_mdx_material_category", cn);
                    cmd.Parameters.AddWithValue("@category_name", txtcatname.Text);
                    cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    txtdesc.Text = "";
                    txtcatname.Text = "";
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Material Catagory Inserted SuccessFully..!";

                }

            }
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();

            }
            finally
            {
                cn.Close();
                cn.Dispose();

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            insert();

        }

    }
}