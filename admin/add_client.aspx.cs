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
    public partial class admin_add_client : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ////////////////////Security///////////////
                    if (ck == true)
                    {
                        // Put user code to initialize the page here
                        if (!IsPostBack)
                        {//  // Put user code to initialize the page here
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            txtclientid.Text = clintautonumber();
                        }//end of if (!ispostback)
                    }//end of if (ck)

                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if (ck == true)

                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");
                }//end of else if (Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {


                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }//end of catch
            finally
            {



            }//end of finally


        }//end of page load
         //function to autogenerate  number code
        private string clintautonumber()
        {
            string clientid;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_autonum_mdx_clients", cn);
            strm = cmd1.Parameters.Add("@client_id", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            clientid = (string)cmd1.Parameters["@client_id"].Value;
            return (clientid);
            cn.Close();

        }//end of function 
         //function to insert to client information in the database
        private void insertclient()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("usp_insert_mdx_clients", cn);
            cmd.Parameters.AddWithValue("@client_id", txtclientid.Text);
            cmd.Parameters.AddWithValue("@client_name", txtclientname.Text);
            cmd.Parameters.AddWithValue("@address1", txtaddress1.Text);
            cmd.Parameters.AddWithValue("@address2", txtaddress2.Text);
            cmd.Parameters.AddWithValue("@contact_person", txtcperson.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@phone1", txtphone1.Text);
            cmd.Parameters.AddWithValue("@phone2", txtphone2.Text);
            cmd.Parameters.AddWithValue("@fax", txtfax.Text);
            cmd.Parameters.AddWithValue("@website", txtwebsite.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@user_id", txtuser_name.Text);
            cmd.Parameters.AddWithValue("@password", txtpwd.Text);
            cmd.Parameters.AddWithValue("@conformpassword", txtcpwd.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cn.Close();
            txtaddress1.Text = "";
            txtaddress2.Text = "";
            txtcity.Text = "";
            txtclientid.Text = clintautonumber();
            txtclientname.Text = "";
            txtcperson.Text = "";
            txtemail.Text = "";
            txtfax.Text = "";
            txtphone1.Text = "";
            txtphone2.Text = "";
            txtstate.Text = "";
            txtwebsite.Text = "";
            txtuser_name.Text = "";
            txtpwd.Text = "";
            txtcpwd.Text = "";

        }//end of insert function

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {//call check data in the database 
                if (checkusername())
                {
                    lblcheckavaliable.Text = "";
                    insertclient();
                    lblerr_msg.Text = "";
                    lblmessage.Visible = true;
                    lblmessage.Text = "Client Inserted SuccessFully..!";


                }//end of if((checkusername())
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

        }//end of button click
         //function to check the  data in the database
        private bool checkusername()
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd = new SqlCommand("select count(*)from mdx_clients where  user_id='" + txtuser_name.Text + "'", cn);
            object obj = cmd.ExecuteScalar();
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblcheckavaliable.Visible = true;
                lblcheckavaliable.Text = "This User Id is already Exist,Choose Another user_id";
                return false;
            }


        }//end of function


    }//end of class
}