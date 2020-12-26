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
public partial class Masterpages_edit_emp_grade : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayempgrade();

        }

    }
    private void displayempgrade()
    {
        string str = Request.QueryString["grade_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_display_mdx_employee_grade", cn);
        cmd.Parameters.AddWithValue("@grade_id", str);
        cmd.CommandType = CommandType.StoredProcedure;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            txtempgrade.Text = dr["grade_name"].ToString();
            txtdescription.Text = dr["description"].ToString();


        }
        dr.Close();
        cn.Close();

    }
    private void Editempgrade()
    {
        string str = Request.QueryString["grade_id"].ToString();
        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
        cn.Open();
        cmd = new SqlCommand("usp_update_mdx_employee_grade", cn);
        cmd.Parameters.AddWithValue("@grade_id", str);
        cmd.Parameters.AddWithValue("@grade_name", txtempgrade.Text);
        cmd.Parameters.AddWithValue("@description", txtdescription.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cn.Close();

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Editempgrade();
    }
}
