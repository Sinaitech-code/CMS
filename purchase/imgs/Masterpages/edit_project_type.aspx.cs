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

public partial class admin1_edit_project_type : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Display();
        }
    }
    private void Display()
    {
        string str = Request.QueryString["project_type_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_display_mdx_project_type", cn);
        cmd.Parameters.AddWithValue("@project_type_id", str);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            
            txtprojtype.Text = dr["type_name"].ToString();
            txtdescription.Text = dr["description"].ToString();

        }
        dr.Close();
        cn.Close();



    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string str = Request.QueryString["project_type_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_project_type", cn);
        cmd.Parameters.AddWithValue("@project_type_id", str);
        cmd.Parameters.AddWithValue("@type_name", txtprojtype.Text);
        cmd.Parameters.AddWithValue("@description", txtdescription.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}
