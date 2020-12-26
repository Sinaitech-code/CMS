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

public partial class Masterpages_edit_materials : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    functions fun = new functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fun.fnfill(ddlmat_cat, "select category_id,category_name from mdx_material_category");
            display();

        }
    }

    private void display()
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
        }
        dr.Close();
        cn.Close();
        }

    private void updatematerials()
    {  // string strdeleted="false";
        string str = Request.QueryString["material_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_materials",cn);
        cmd.Parameters.AddWithValue("@material_id", str);
        cmd.Parameters.AddWithValue("@category_id", ddlmat_cat.SelectedValue);
        cmd.Parameters.AddWithValue("@material_name", txtmaterialname.Text);
        cmd.Parameters.AddWithValue("@description", txtdesc.Text);
        //cmd.Parameters.AddWithValue("@is_deleted", strdeleted);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
  }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        updatematerials();
    }
}
