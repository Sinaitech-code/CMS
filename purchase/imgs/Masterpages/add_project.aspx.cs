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

public partial class admin1_add_project : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    functions fun = new functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fun.fnfill(ddlclient, "select client_id,client_name from mdx_clients");
           fun.fnfill(ddlprojtype, " select project_type_id,type_name from mdx_project_type");
        }
    }
   
    protected void btnsave_Click(object sender, EventArgs e)
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_insert_mdx_projects", cn);
        cmd.Parameters.AddWithValue("@project_type_id", ddlprojtype.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@client_id ", ddlclient.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@project_name", txtprojname.Text);
        cmd.Parameters.AddWithValue("@project_start_date", txtsdate.Text);
        cmd.Parameters.AddWithValue("@project_end_date", txtfinishingate.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtfinishingate.Text = "";
        txtprojname.Text = "";
        txtsdate.Text="";


    }
    protected void ddlclient_SelectedIndexChanged(object sender, EventArgs e)
   {
    //    fun.ddlfill(ddlprojtype, " select project_type_id from mdx_project_type where  client_id='" + ddlclient.SelectedItem.Value + "'");


    }
}