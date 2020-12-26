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
public partial class Masterpages_add_material_cat : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void insert()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_insert_mdx_material_category", cn);
        cmd.Parameters.AddWithValue("@category_name", txtcatname.Text);
        cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        insert();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtdesc.Text = "";
        txtcatname.Text = "";
    }
}
