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

public partial class Masterpages_edit_project_levels : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    functions fun = new functions();
    SqlDataReader dr;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fun.fnfill(ddlclient, "select client_id,client_name from mdx_clients");
            //fun.fnfill(ddlprojtype, "select project_type_id,type_name from mdx_project_type");
            fun.fnfill(ddlprojects, "select project_id,project_name from mdx_projects");
            fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects");
            display();
        }

    }
    private void display()
    {
        string str = Request.QueryString["level_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_display_mdx_project_levels", cn);
        cmd.Parameters.AddWithValue("@level_id", str);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlprojects.SelectedValue = dr["project_id"].ToString();
            ddlsubproject.SelectedValue = dr["sub_project_id"].ToString();
            txtprojectlevel.Text = dr["level_name"].ToString();
            txtstartingdate.Text = dr["project_start_date"].ToString();
            txtfinishingdate.Text = dr["project_end_date"].ToString();
        }
        dr.Close();
        cn.Close();

    
    
    
    
    }
    private void update()
    {
        string str = Request.QueryString["level_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_project_levels", cn);
        cmd.Parameters.AddWithValue("@level_id", str);
        cmd.Parameters.AddWithValue("@project_id", ddlprojects.SelectedValue);
        cmd.Parameters.AddWithValue("@sub_project_id", ddlsubproject.SelectedValue);
        cmd.Parameters.AddWithValue("@level_name", txtprojectlevel.Text);
        cmd.Parameters.AddWithValue("@project_start_date", txtstartingdate.Text);
        cmd.Parameters.AddWithValue("@project_end_date", txtfinishingdate.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();



    }






    protected void btnsave_Click(object sender, EventArgs e)
    {

        update();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtfinishingdate.Text = "";
        txtprojectlevel.Text = "";
        txtstartingdate.Text = "";
    }

    //protected void ddlprojtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fun.fnfill(ddlprojects, "select project_id,project_name from mdx_projects");
    //}
    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.fnfill(ddlsubproject, "select sub_project_id,sub_project_name from mdx_sub_projects");
    }
}
