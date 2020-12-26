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
using System.Text;
public partial class Projects_add_sub_project : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
   functions fun = new functions();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           fun.fnfill(ddlproj_id, "select project_id,project_name from mdx_projects");
        }
    }
    private void display()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();

    
    }
    private void insertsub_proj()
    {
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_insert_mdx_sub_projects", cn);
        //cmd.Parameters.AddWithValue("@Proj_Type", ddlprojtype.SelectedItem.Value);
        //cmd.Parameters.AddWithValue("@Client_Name ", ddlclient.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@project_id", ddlproj_id.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@sub_project_name ", txtsub_projname.Text);
        cmd.Parameters.AddWithValue("@project_start_date", txtsdate.Text);
        cmd.Parameters.AddWithValue("@project_end_date", txtfinishingate.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();
        
    
    }
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        insertsub_proj();

    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtfinishingate.Text = "";
        txtsub_projname.Text = "";
        txtsdate.Text = "";
    }
}
