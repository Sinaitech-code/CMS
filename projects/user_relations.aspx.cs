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

namespace CMS.projects
{
    public partial class projects_user_relations : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {///////security///////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    if (ck == true)
                    {///////security////////////
                        if (!IsPostBack)
                        {
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            fun.fnfill(ddlroles, "select distinct  role_id,role_name from mdx_roles");
                            fun.fnfill(ddlemprole, "select role_id,role_name from mdx_roles where role_id !=1");
                            fun.fnfill(ddlproject, "select distinct project_id,project_name from mdx_projects");
                        }//end of postback
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else
                }//end of if(session["AUserName"]!=null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {

            }//end of finally
        }//end of pageload
         //code to insert emp relations
        private void insertdata()
        {
            try
            {

                string str = "";
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();

                for (int i = 0; i < listboxemp2.Items.Count; i++)
                {
                    cmd = new SqlCommand("usp_insert_mdx_emp_relations", cn);
                    cmd.Parameters.AddWithValue("@project_id", ddlproject.SelectedValue);
                    cmd.Parameters.AddWithValue("@top_user", ddltopuser.SelectedValue);
                    cmd.Parameters.AddWithValue("@role_id", ddlroles.SelectedValue);
                    cmd.Parameters.AddWithValue("@emp_role_id", ddlemprole.SelectedValue);
                    if (listboxemp2.Items[i].Selected == true)
                    {
                        str = listboxemp2.Items[i].Value;
                        cmd.Parameters.AddWithValue("@user_id", str);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        lblerr_msg.Text = "";
                        lblmessage.Visible = true;
                        lblmessage.Text = "User Relations Given SuccessFully..!";


                    }//end of if


                }//end of for
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        }//end of inserdata()


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            insertdata();
            listboxemp2.Items.Clear();
            //listboxemp1.Items.Clear();

        }
        //this event is to load userid when ddlroles seleted index chenged 
        protected void ddlroles_SelectedIndexChanged1(object sender, EventArgs e)
        {
            fun.fill(ddltopuser, "select distinct user_id from mdx_emp_project_assign where role_id='" + ddlroles.SelectedValue + "'  and project_id='" + ddlproject.SelectedValue + "' ");
        }

        protected void ddlemprole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlemprole.SelectedIndex > 0)
            {

                if (ddlemprole.SelectedValue == "2")
                {
                    fun.filllistbox(listboxemp1, "select distinct user_id from mdx_emp_project_assign where role_id='" + ddlemprole.SelectedValue + "' and project_id='" + ddlproject.SelectedValue + "' ");

                }//end of if
                else if (ddlemprole.SelectedValue == "3")
                {
                    fun.filllistbox(listboxemp1, "select distinct user_id from mdx_emp_project_assign where role_id='" + ddlemprole.SelectedValue + "' and project_id='" + ddlproject.SelectedValue + "' ");

                }//end of ifelse
            }

            //fun.filllistbox(listboxemp1, "select distinct user_id from mdx_emp_project_assign where role_id='" + ddlemprole.SelectedValue + "'");
        }
        //code to add items from one list box to another listbox 
        protected void btnadd_Click1(object sender, EventArgs e)
        {
            try
            {
                string stritem;
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                for (int i = 0; i < listboxemp1.Items.Count; i++)
                {
                    if (listboxemp1.Items[i].Selected == true)
                    {
                        stritem = listboxemp1.Items[i].Value;
                        listboxemp2.Items.Add(stritem);
                    }//end of if

                }//end of for


            }//end of try
            catch (Exception ex1)
            {
                lblmessage.Text = "";
                lblerr_msg.Text = ex1.Message.ToString();

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally

        }
    }
}