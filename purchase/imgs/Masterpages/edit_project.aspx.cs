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

public partial class admin1_edit_project : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    functions fun = new functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fun.fnfill(ddlclient, "select client_id,client_name from mdx_clients");
            fun.fnfill(ddlprojtype, " select project_type_id,type_name from mdx_project_type");
            displayproject();
        }
    }

    private void displayproject()
    {
        string str = Request.QueryString["project_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_display_mdx_projects", cn);
        cmd.Parameters.AddWithValue("@project_id", str);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlclient.SelectedValue = dr["client_id"].ToString();
            ddlprojtype.SelectedValue = dr["project_type_id"].ToString();
            txtprojname.Text = dr["project_name"].ToString();
            txtsdate.Text = dr["project_start_date"].ToString();
            txtfinishingate.Text = dr["project_end_date"].ToString();
        
        }
        dr.Close();
        cn.Close();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string str = Request.QueryString["project_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_projects", cn);
        cmd.Parameters.AddWithValue("@project_id", str);
        cmd.Parameters.AddWithValue("@client_id", ddlclient.SelectedValue);
        cmd.Parameters.AddWithValue("@project_type_id", ddlprojtype.SelectedValue);

        cmd.Parameters.AddWithValue("@project_name", txtprojname.Text);
        cmd.Parameters.AddWithValue("project_start_date", txtsdate.Text);
        cmd.Parameters.AddWithValue("project_end_date", txtfinishingate.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();

    }
}
