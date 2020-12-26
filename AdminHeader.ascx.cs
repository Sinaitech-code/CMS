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

namespace CMS
{
    public partial class AdminHeader : System.Web.UI.UserControl
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["AUserName"] != null)
            {

                try
                {
                    tdAccounts.Style["display"] = "none";
                    tdHR.Style["display"] = "none";
                    tdProject.Style["display"] = "none";
                    tdPurchase.Style["display"] = "none";
                    tdAdmin.Style["display"] = "none";
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    cmd = new SqlCommand("select dept_name from mdx_employees where user_id='" + Session["AUserName"] + "'", cn);

                    string deptname = (String)cmd.ExecuteScalar();
                    if (deptname.ToUpper().Trim() == "ADMIN")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select A.module_id,F.module_name from mdx_admin_module_assign A inner join mdx_form_modules F on A.module_id= F.module_id  where user_id='" + Session["AUserName"] + "' ", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            if (dr["module_name"].ToString().ToUpper() == "HR")
                            {
                                tdHR.Style["display"] = "table-cell";

                            }

                            else if (dr["module_name"].ToString().ToUpper() == "PROJECT")
                            {
                                tdProject.Style["display"] = "table-cell";

                            }

                            else if (dr["module_name"].ToString().ToUpper() == "PURCHASE")
                            {
                                tdPurchase.Style["display"] = "table-cell";
                            }


                            else if (dr["module_name"].ToString().ToUpper() == "ACCOUNT")
                            {
                                tdAccounts.Style["display"] = "table-cell";
                            }

                            else if (dr["module_name"].ToString().ToUpper() == "ADMIN")
                            {
                                tdAdmin.Style["display"] = "table-cell";

                            }
                        }//end of foreach
                    }//end of if (deptname.ToUpper().Trim() == "ADMIN")

                    else
                    {
                        Response.Redirect("noprivilise.aspx?");
                    }

                    cn.Close();
                }

                catch (Exception ex)
                {
                    Response.Redirect("Default.aspx?");
                }
                finally
                {

                }

            }//end of  if(Session ["AUserName"]!=null)
            else
            {
                Response.Redirect("Default.aspx?");
            }

        }//end of page load
    }//end of class
}