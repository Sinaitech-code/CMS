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
public partial class Projects_edit_sub_project : System.Web.UI.Page
{
    SqlConnection cn;
    SqlDataAdapter da;
    SqlDataReader dr;
    SqlCommand cmd;
    functions fun = new functions();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fun.fnfill(ddlproject, "select project_id,project_name from mdx_projects");
            Display();
        }

    }
    private void Display()
    {
        string str = Request.QueryString["sub_project_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_display_mdx_sub_projects", cn);
        cmd.Parameters.AddWithValue("@sub_project_id", str);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlproject.SelectedValue=dr["project_id"].ToString();
            txtsubprojectname.Text=dr["sub_project_name"].ToString();
            txtstartingdate.Text=dr["project_start_date"].ToString();
            txtendingdate.Text=dr["project_end_date"].ToString();
         }
        dr.Close();
        cn.Close();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        updatedata();

    }
    private void updatedata()
    {
        string str = Request.QueryString["sub_project_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_sub_projects", cn);
        cmd.Parameters.AddWithValue("@sub_project_id", str);
        cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@sub_project_name", txtsubprojectname.Text);
        cmd.Parameters.AddWithValue("@project_start_date", txtstartingdate.Text);
        cmd.Parameters.AddWithValue("@project_end_date", txtendingdate.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    }
