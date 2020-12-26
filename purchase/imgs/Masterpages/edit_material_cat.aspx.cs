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

public partial class Masterpages_edit_material_cat : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlCommand cmd1;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            display();
        }
    }
    private void display()
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
        }
        dr.Close();
        cn.Close();
    }
    private void update()
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
        cn.Close();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        update();
    }
}
