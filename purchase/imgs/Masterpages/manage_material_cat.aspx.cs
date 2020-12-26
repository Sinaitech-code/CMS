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
public partial class Masterpages_manage_material_cat : System.Web.UI.Page
{
    SqlConnection cn;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    private void binddata()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        da = new SqlDataAdapter("select category_name,category_id from mdx_material_category", cn);
        ds = new DataSet();
        da.Fill(ds, "mdx_material_category");
        GridView1.DataSource = ds.Tables["mdx_material_category"];
        GridView1.DataBind();
        cn.Close();
    }
}
