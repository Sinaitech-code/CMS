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

namespace CMS.admin
{
    public partial class admin_edit_client : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {//////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ///////////////////////////Security///////////////
                    if (ck == true)
                    {
                        //// Put user code to initialize the page here
                        if (!IsPostBack)
                        {
                            lblname.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            Display();
                        }//end of if(!ispostback)
                    }//end of if(ck==true)


                    else
                    {

                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)

                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else if(Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch
            finally
            {

            }//end of finally
        }//end of page load
         //function to display client information from the database
        private void Display()
        {

            try
            {
                string str = Request.QueryString["client_id"].ToString();
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_display_mdx_clients", cn);
                cmd.Parameters.AddWithValue("@client_id", str);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtclientid.Text = dr["client_id"].ToString();
                    txtclientname.Text = dr["client_name"].ToString();
                    txtaddress1.Text = dr["address1"].ToString();
                    txtaddress2.Text = dr["address2"].ToString();
                    txtcity.Text = dr["city"].ToString();
                    txtcperson.Text = dr["contact_Person"].ToString();
                    txtstate.Text = dr["state"].ToString();
                    txtwebsite.Text = dr["website"].ToString();
                    txtphone1.Text = dr["phone1"].ToString();
                    txtphone2.Text = dr["phone2"].ToString();
                    txtfax.Text = dr["fax"].ToString();
                    txtemail.Text = dr["email"].ToString();

                }//end of while statement
                dr.Close();
            }//end of try
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();
            }//end of finally

        }//end of function
         //function to update the client information from the database
        private void updateclient()
        {
            string str = Request.QueryString["client_id"].ToString();
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_update_mdx_clients", cn);
            cmd.Parameters.AddWithValue("@client_id", str);
            cmd.Parameters.AddWithValue("@client_name", txtclientname.Text);
            cmd.Parameters.AddWithValue("@address1", txtaddress1.Text);
            cmd.Parameters.AddWithValue("@address2", txtaddress2.Text);
            cmd.Parameters.AddWithValue("@contact_Person", txtcperson.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@phone1", txtphone1.Text);
            cmd.Parameters.AddWithValue("@phone2", txtphone2.Text);
            cmd.Parameters.AddWithValue("@fax", txtfax.Text);
            cmd.Parameters.AddWithValue("@website", txtwebsite.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

        }//end of function updateclient()
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblcheckavaliable.Text = "";
                //if (checkusername())
                //{

                updateclient();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Client Updated SuccessFully..!";

                // Response.Write("<script language='javascript'>alert('Client Updated SuccessFully..!' )</script>");

                //}

            }//end of try
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex.Message.ToString();

            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }//end of finally
        }//End of  btnsubmit_Click 
         //private bool checkusername()
         //{
         //    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
         //    cn.Open();
         //    cmd = new SqlCommand("select count(*)from mdx_clients where  client_name='" + txtclientname.Text + "'", cn);
         //    object obj = cmd.ExecuteScalar();
         //    if (obj.ToString() == "0")
         //    {
         //        return true;
         //    }
         //    else
         //    {
         //        lblcheckavaliable.Visible = true;
         //        lblcheckavaliable.Text = "Clientname Already Exists";
         //        return false;
         //    }

        //}


    }//end of class
}