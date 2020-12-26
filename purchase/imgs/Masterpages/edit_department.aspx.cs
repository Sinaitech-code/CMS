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

public partial class admin1_edit_department : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
        }
    }

    private void display()
    {
        string str = Request.QueryString["dept_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_display_mdx_departments", cn);
        cmd.Parameters.AddWithValue("@dept_id", str);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            txtdeptname.Text = dr["dept_name"].ToString();
            txtdescription.Text = dr["description"].ToString();
        
        }
        dr.Close();
        cn.Close();

        
    
    
    }
   
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        EditDepartment();
    }

    private void EditDepartment()
    {
        string str = Request.QueryString["dept_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_departments", cn);
        cmd.Parameters.AddWithValue("@dept_id", str); 
        cmd.Parameters.AddWithValue("@dept_name", txtdeptname.Text);
        cmd.Parameters.AddWithValue("@description", txtdescription.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();

    
    
    }
}
