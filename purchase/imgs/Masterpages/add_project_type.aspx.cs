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
public partial class admin1_add_project_type : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_insert_mdx_project_type", cn);
         cmd.Parameters.AddWithValue("@type_name", txtprojtype.Text);
        cmd.Parameters.AddWithValue("@description", txtdescription.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtdescription.Text = "";
        
        txtprojtype.Text = "";

    }
}
