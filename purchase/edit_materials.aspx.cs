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
    public partial class Masterpages_edit_materials : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////////security////////////
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
                    {///////////security/////////////

                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();

                            fun.fnfill(ddlmat_cat, "select category_id,category_name from mdx_material_category");
                            display();

                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AUserName"]!=null)
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

        //code to display the materials 
        private void display()
        {
            try
            {
                string str = Request.QueryString["material_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_materials", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@material_id", str);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlmat_cat.SelectedValue = dr["category_id"].ToString();
                    txtmaterialname.Text = dr["material_name"].ToString();
                    txtdesc.Text = dr["description"].ToString();
                }//end of while
                dr.Close();
            }//end of catch
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
        }//end of display()
         //code to update material details
        private void updatematerials()
        {
            try
            {

                string str = Request.QueryString["material_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_update_mdx_materials", cn);
                cmd.Parameters.AddWithValue("@material_id", str);
                cmd.Parameters.AddWithValue("@category_id", ddlmat_cat.SelectedValue);
                cmd.Parameters.AddWithValue("@material_name", txtmaterialname.Text);
                cmd.Parameters.AddWithValue("@description", txtdesc.Text);
                //cmd.Parameters.AddWithValue("@is_deleted", strdeleted);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Materials Updated SuccessFully..!";


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

        }//end of updatematerials()
        protected void btnsave_Click(object sender, EventArgs e)
        {
            updatematerials();

        }
    }
}