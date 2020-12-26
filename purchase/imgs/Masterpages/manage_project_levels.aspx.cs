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
public partial class Masterpages_manage_project_levels : System.Web.UI.Page
{

    SqlConnection cn;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillgrid();
        }

    }
    private void fillgrid()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        da = new SqlDataAdapter("select  level_id,level_name from mdx_project_levels", cn);
        ds = new DataSet();
        da.Fill(ds, "mdx_project_levels");
        GridView1.DataSource = ds.Tables["mdx_project_levels"];
        GridView1.DataBind();
        cn.Close();


    }
    protected void gridview_pageindexchangeig(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
