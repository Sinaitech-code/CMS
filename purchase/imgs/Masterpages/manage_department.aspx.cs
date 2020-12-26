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

public partial class admin1_manage_department : System.Web.UI.Page
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
        da = new SqlDataAdapter("select dept_name,dept_id from mdx_departments", cn);
        ds = new DataSet();
        da.Fill(ds, "mdx_departments");
        GridView1.DataSource = ds.Tables["mdx_departments"];
        GridView1.DataBind();
        cn.Close();


    }
    protected void Gridview_pageindex(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
