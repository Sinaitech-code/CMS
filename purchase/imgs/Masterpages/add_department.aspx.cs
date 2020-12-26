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

public partial class admin1_add_department : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    private void insertdept()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_insert_mdx_departments", cn);
        cmd.Parameters.AddWithValue("@dept_name", txtdept.Text);
        cmd.Parameters.AddWithValue("@Description",txtdescription.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        insertdept();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtdept.Text = "";
        txtdescription.Text = "";

    }
}
