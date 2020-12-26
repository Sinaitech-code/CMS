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
using System.IO;

namespace CMS.Employees
{
    public partial class Employees_create_daily_report : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        functions fun = new functions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ///////// ////////////////////////////////////////////////////////////Security///////////////
                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    ///////// ////////////////////////////////////////////////////////////Security///////////////
                    if (ck == true)
                    {
                        // Put user code to initialize the page here
                        if (!IsPostBack)
                        {

                            lbldate1.Text = DateTime.Now.ToShortDateString();
                            lblemp.Text = Session["AUserName"].ToString();
                            lbldate.Text = DateTime.Now.ToShortDateString();
                            ViewState["rpt_id"] = rptautonum();
                            string rptid = ViewState["rpt_id"].ToString();
                            string rpt = rptautonum();
                            fun.fnfill(ddlclient1, "select client_id, client_name from mdx_clients where client_id in(select client_id from mdx_projects where project_id in(select project_id from mdx_tasks where assign_to='" + Session["AUserName"] + "'))");

                        }//end of if(!ispostback)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }
                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("../Default.aspx");

                }//end of else if (Session["AUserName"] != null)
            }
            catch (Exception ex)
            {

                lblerr_msg.Text = ex.Message.ToString();
                lblerr_msg.Visible = true;
            }
            finally
            {


            }
        }//end  of page load
         //function to autogenerate number 

        public string rptautonum()
        {
            string rpt_id;
            SqlParameter strm;
            cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
            cn.Open();
            cmd1 = new SqlCommand("usp_insert_autonum_mdx_daily_report", cn);
            strm = cmd1.Parameters.Add("@report_id", SqlDbType.VarChar, 12);
            strm.Direction = ParameterDirection.Output;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            rpt_id = (string)cmd1.Parameters["@report_id"].Value;
            return (rpt_id);
            cn.Close();
        }//end of rptautonum()
         //function to insert to daily report
        private void insert_dialy_report()
        {
            try
            {

                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                cmd = new SqlCommand("usp_insert_mdx_dialy_report", cn);
                cmd.Parameters.AddWithValue("@report_id", ViewState["rpt_id"].ToString());
                cmd.Parameters.AddWithValue("project_id", ddlprojectname.SelectedValue);
                cmd.Parameters.AddWithValue("@report_title", txttitle.Value);
                cmd.Parameters.AddWithValue("@report_date", lbldate.Text);
                cmd.Parameters.AddWithValue("@description", txtdesc.Value);
                cmd.Parameters.AddWithValue("@resources_used", txtres_used.Value);
                cmd.Parameters.AddWithValue("@no_of_workers", txtno_workers.Value);
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Value);
                cmd.Parameters.AddWithValue("@money_paid", txtmoneypaid.Value);
                cmd.Parameters.AddWithValue("@user_id", Session["AUserName"]);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                //HttpPostedFile attFile = FileUpload1.PostedFile;

                //strFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath(@"./attachments/" + "p1" + strFileName));

                string image_name1 = "";
                string s = Server.MapPath("./imagefile/");

                if (fileupload1.HasFile)
                {
                    FileInfo flinfo1 = new FileInfo(fileupload1.PostedFile.FileName);
                    string extention1 = flinfo1.Extension;
                    string img1 = flinfo1.Name;

                    //fileupload1.PostedFile.SaveAs(Server.MapPath(s +  ViewState["rpt_id"] + "p1" + extention1));
                    //fileupload1.PostedFile.SaveAs(Server.MapPath("http://www.sinaitech.com/httpdocs/projects/construction/Employees/imagefile/" + ViewState["rpt_id"] + "p1" + extention1));
                    //fileupload1.PostedFile.SaveAs(Server.MapPath(@"http://www.sinaitech.com/httpdocs/projects/construction/Employees/imagefile/" + ViewState["rpt_id"] + "p1" + extention1));
                    //fileupload1.PostedFile.SaveAs(Server.MapPath(ViewState["rpt_id"] + "p1" + extention1));
                    ////fileupload1.PostedFile.SaveAs(Server.MapPath( @"http://www.sinaitech.com/httpdocs/projects/construction/Employees/imagefile/"  + ViewState["rpt_id"] + "p1" + extention1));
                    fileupload1.PostedFile.SaveAs(Server.MapPath("./imagefile/" + ViewState["rpt_id"] + "p1" + img1));
                    image_name1 = ViewState["rpt_id"] + "p1" + img1;
                    //Response.Write(filePath);
                }//end of if(fileupload1.HasFile)

                string image_name2 = "";
                if (fileupload2.HasFile)
                {
                    FileInfo flinfo2 = new FileInfo(fileupload2.PostedFile.FileName);
                    string extention2 = flinfo2.Extension;
                    string img2 = flinfo2.Name;
                    fileupload2.PostedFile.SaveAs(Server.MapPath("./imagefile/" + ViewState["rpt_id"] + "p2" + img2));
                    image_name2 = ViewState["rpt_id"] + "p2" + img2;
                    //fileupload2.PostedFile.SaveAs(Server.MapPath("imagefile/" + ViewState["rpt_id"] + "p2" + extention2));

                }//end of if(fileupload2.HasFile)

                string image_name3 = "";
                if (fileupload3.HasFile)
                {
                    FileInfo flinfo3 = new FileInfo(fileupload3.PostedFile.FileName);
                    string extention3 = flinfo3.Extension;
                    string img3 = flinfo3.Name;
                    fileupload3.PostedFile.SaveAs(Server.MapPath("./imagefile/" + ViewState["rpt_id"] + "p3" + img3));
                    image_name3 = ViewState["rpt_id"] + "p3" + img3;
                }//end of if (fileupload3.HasFile)

                string image_name4 = "";
                if (fileupload4.HasFile)
                {
                    FileInfo flinfo4 = new FileInfo(fileupload4.PostedFile.FileName);
                    string extention4 = flinfo4.Extension;
                    string img4 = flinfo4.Name;
                    fileupload4.PostedFile.SaveAs(Server.MapPath("./imagefile/" + ViewState["rpt_id"] + "p4" + img4));
                    image_name4 = ViewState["rpt_id"] + "p4" + img4;
                }//end of if (fileupload4.HasFile)
                string image_name5 = "";
                if (fileupload5.HasFile)
                {
                    FileInfo flinfo5 = new FileInfo(fileupload5.PostedFile.FileName);
                    string extention5 = flinfo5.Extension;
                    string img5 = flinfo5.Name;
                    fileupload5.PostedFile.SaveAs(Server.MapPath("./imagefile/" + ViewState["rpt_id"] + "p5" + img5));
                    image_name5 = ViewState["rpt_id"] + "p5" + img5;
                }//end of if (fileupload5.HasFile)


                //string visible1 = "";
                //if (rbtnvisible1.SelectedValue.Trim() == "yes")
                //{
                //    visible1 = "true";
                //}
                //else
                //{
                //    visible1 = "false";
                //}

                //}
                //string visible2 = "";
                //if (rbtnvisible2.SelectedValue.Trim() == "yes")
                //{
                //    visible2 = "true";
                //}
                //else
                //{
                //    visible2 = "false";
                //}
                //string visible3 = "";
                //if (rbtnvisible3.SelectedValue.Trim() == "yes")
                //{
                //    visible3 = "true";
                //}
                //else
                //{
                //    visible3 = "false";
                //}
                //string visible4 = "";
                //if (rbtnvisible4.SelectedValue.Trim() == "yes")
                //{
                //    visible4 = "true";
                //}
                //else
                //{
                //    visible4 = "false";
                //}

                string visible5 = "";
                if (rbtnvisible5.SelectedValue.Trim() == "yes")
                {
                    visible5 = "true";
                }
                else
                {
                    visible5 = "false";
                }
                cmd2 = new SqlCommand("usp_insert_mdx_daily_report_images1", cn);
                cmd2.Parameters.AddWithValue("@report_id", ViewState["rpt_id"].ToString());
                cmd2.Parameters.AddWithValue("@report_image_name1", image_name1);
                // cmd2.Parameters.AddWithValue("@visble_to_client1", visible1);
                cmd2.Parameters.AddWithValue("@report_image_name2", image_name2);
                // cmd2.Parameters.AddWithValue("@visble_to_client2", visible2);
                cmd2.Parameters.AddWithValue("@report_image_name3", image_name3);
                // cmd2.Parameters.AddWithValue("@visble_to_client3", visible3);
                cmd2.Parameters.AddWithValue("@report_image_name4", image_name4);
                // cmd2.Parameters.AddWithValue("@visble_to_client4", visible4);
                cmd2.Parameters.AddWithValue("@report_image_name5", image_name5);
                cmd2.Parameters.AddWithValue("@visble_to_client1", visible5);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.ExecuteNonQuery();
                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "Daily Report Inserted SuccessFully..!";
                ddlprojectname.SelectedIndex = 0;
                txttitle.Value = "";
                lbldate.Text = "";
                txtdesc.Value = "";
                txtres_used.Value = "";
                txtno_workers.Value = "";
                txtremarks.Value = "";
                txtmoneypaid.Value = "";
                ddlclient1.SelectedIndex = 0;
                //fileupload1.Attributes.Clear();
                rbtnvisible5.SelectedIndex = 0;


                // Response.Write("<script language='javascript'>alert('Daily Report Inserted SuccessFully..!' )</script>");

            }//end of try
            catch (Exception ex1)
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                lblerr_msg.Text = ex1.Message.ToString();
                lblerr_msg.Visible = true;

            }
            finally
            {

                cn.Dispose();
            }

        }//end of function insert_dialy_report()

        protected void Button1_Click(object sender, EventArgs e)
        {
            insert_dialy_report();

        }//end of button click
        protected void ddlclient1_selectedchanged(object sender, EventArgs e)
        {
            if (ddlclient1.SelectedIndex > 0)
            {
                fun.fnfill(ddlprojectname, "select distinct p.project_id,p.project_name  from mdx_projects p,mdx_tasks t where client_id='" + ddlclient1.SelectedValue + "' and t.project_id =p.project_id ");
            }
        }
    }//end of class
}