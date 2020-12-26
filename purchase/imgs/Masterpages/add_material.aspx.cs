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

public partial class Masterpages_add_material : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    functions fun = new functions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fun.fnfill(ddlmat_cat, "select category_id,category_name from mdx_material_category");
                
        }

    }

    private void insert()
    {
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
        cn.Close();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        insert();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {

    }
}
