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

public partial class Projects_manage_sub_project : System.Web.UI.Page
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
        da = new SqlDataAdapter("select sub_project_id,sub_project_name from mdx_sub_projects", cn);
        ds = new DataSet();
        da.Fill(ds, "mdx_sub_projects");
        GridView1.DataSource = ds.Tables["mdx_sub_projects"];
        GridView1.DataBind();
        cn.Close();


    }
    protected void gridview_pageindex(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
