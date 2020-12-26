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
using System.Drawing;

namespace CMS.admin
{
    public partial class admin_user_accs_permissions : System.Web.UI.Page
    {
        functions fun = new functions();
        //DataTable dt;
        DataSet ds;
        SqlConnection cn;
        SqlCommand cmd;
        SqlTransaction t;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        CheckBoxList ChkLst;
        SqlCommand cmd1;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ///Put user code to initialize the page here
                if (!IsPostBack)
                {
                    lbldate1.Text = DateTime.Now.ToShortDateString();
                    lblemp.Text = Session["AUserName"].ToString();
                    fun.fnfill(DrpUserID, "select emp_id,user_id from mdx_employees where status!=1 and user_id !='superadmin'");
                    //fun.fnfill(DrpUserID, "select user_id from mdx_employees where status!=1");
                }//end of if(!ispostback)
                 /////////////////////////////////////////////////////Security///////////////

                if (Session["AUserName"] != null)
                {
                    functions ULC = new functions();
                    bool ck;
                    string st1 = Request.PhysicalApplicationPath;
                    string st2 = Request.PhysicalPath;
                    string[] s = st2.Split(new char[] { '/', '\\' });
                    string st3 = s.GetValue(s.Length - 1).ToString();
                    ck = ULC.Check(st3, Session["AUserName"].ToString(), Session["AUserName"].ToString());
                    /////////////////////////////////////////////////////Security///////////////

                    if (ck == true)
                    {

                        cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                        cn.Open();
                        da = new SqlDataAdapter("select distinct module_id,module_name from mdx_form_modules", cn);
                        ds = new DataSet();
                        da.Fill(ds, "mdx_form_modules");
                        TblScrpPages.Width = 720;
                        if (ds.Tables["mdx_form_modules"].Rows.Count >= 0)
                        {
                            int Num = 1;
                            foreach (DataRow row in ds.Tables["mdx_form_modules"].Rows)
                            {
                                TableRow Trow = new TableRow();

                                Trow.BackColor = Color.Gray;
                                Trow.ForeColor = Color.White;
                                Trow.Font.Name = "Times New Roman";
                                Trow.Font.Size = 10;
                                Trow.Font.Bold = true;
                                Trow.Font.Underline = true;
                                TableCell cell = new TableCell();
                                cell.Text = row["module_name"].ToString();
                                cell.Text = cell.Text.ToUpper();
                                Trow.Cells.Add(cell);
                                TblScrpPages.Rows.Add(Trow);

                                da1 = new SqlDataAdapter("select f.form_id,f.page_name,m.module_name from mdx_form_names f, mdx_form_modules m where  f.module_id ='" + row["module_id"] + "' and f.module_id=m.module_id", cn);
                                ds = new DataSet();
                                da1.Fill(ds, "mdx_form_names");
                                if (ds.Tables["mdx_form_names"].Rows.Count >= 0)
                                {
                                    TableRow rw = new TableRow();
                                    TableCell Tcell = new TableCell();
                                    ChkLst = new CheckBoxList();
                                    ChkLst.ID = Num.ToString();
                                    ChkLst.Width = 720;
                                    ChkLst.RepeatDirection = RepeatDirection.Horizontal;
                                    ChkLst.RepeatColumns = 3;
                                    ChkLst.CellPadding = 1;
                                    ChkLst.CellSpacing = 1;
                                    ChkLst.BorderWidth = 1;
                                    ChkLst.CssClass = "chekBox";
                                    ChkLst.DataSource = ds.Tables["mdx_form_names"];
                                    ChkLst.DataTextField = "page_name";
                                    ChkLst.DataValueField = "form_id";
                                    ChkLst.DataBind();
                                    Tcell.Controls.Add(ChkLst);
                                    rw.Cells.Add(Tcell);
                                    TblScrpPages.Rows.Add(rw);
                                    Num += 1;
                                }//end of if (ds.Tables["mdx_form_names"].Rows.Count >= 0)
                                ds.Clear();
                            }//end of foreach statement

                        }//end of if (ds.Tables["mdx_form_modules"].Rows.Count >= 0)
                    }//end of if(ck==true)
                    else
                    {
                        Response.Redirect("../noprivilise.aspx");
                    }//end of else if(ck==true)
                }//end of if (Session["AUserName"] != null)
                else
                {
                    Response.Redirect("Default.aspx");
                }//end of else if (Session["AUserName"] != null)
            }//end of try
            catch (Exception ex)
            {
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();

                //Response.Write("<script language='javascript'>alert('" + oe.Message.ToString() + "' )</script>");
            }//end of catch
            finally
            {
                cn.Close();
                cn.Dispose();

            }

        }//end of page load
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                cn.Open();
                string ScrCode, str, UId = DrpUserID.SelectedItem.Text;
                cmd = new SqlCommand("delete from mdx_user_previligers where user_id='" + UId + "'", cn);
                cmd.ExecuteNonQuery();
                CheckBoxList ChkLst;
                int Num = 1;
                //display pages in chkboxlist 
                foreach (TableRow row in TblScrpPages.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {//display module in headers
                        ChkLst = new CheckBoxList();
                        // 				 ch.ID=Num.ToString();    
                        ChkLst = (CheckBoxList)cell.FindControl(Num.ToString());
                        if (ChkLst != null)
                        {
                            for (int i = 0; i < ChkLst.Items.Count; i++)
                            {
                                if (ChkLst.Items[i].Selected == true)
                                {
                                    ScrCode = ChkLst.Items[i].Value;
                                    //insert the ids in the another table 

                                    cmd = new SqlCommand("usp_insert_user_previligers ", cn);
                                    cmd.Connection = cn;
                                    cmd.Parameters.AddWithValue("@user_id", UId);
                                    cmd.Parameters.AddWithValue("@form_id", ScrCode.Trim());
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.ExecuteNonQuery();
                                    cmd.Cancel();
                                }//end of if(ChkLst.Items[i].Selected == true)
                            }//end of for statement
                            Num += 1;
                        }//end of if(ck==true)


                    }//end of foreach  foreach (TableCell cell in row.Cells)
                }//end of foreach statement foreach (TableRow row in TblScrpPages.Rows)

                lblerr_msg.Text = "";
                lblmessage.Visible = true;
                lblmessage.Text = "User Privileges Updated SuccessFully..!";
                unfillchecklist(true);
                DrpUserID.SelectedIndex = 0;
                chkall.Checked = false;
                checkhr.Checked = false;
                checkaccount.Checked = false;
                checkadmin.Checked = false;
                checkemp.Checked = false;
                checkproject.Checked = false;
                checkpurchase.Checked = false;
                unfillchecklist(true);
                //Response.Write("<script language='javascript'>alert('User Privileges Updated SuccessFully..!' )</script>");
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";

                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
            }//end of catch
            finally
            {

                cn.Close();
                cn.Dispose();
            }
        }//end of button click

        //function to binding modules and pages from the database

        private void fillchecklist(Boolean ischksel)
        {
            try
            {
                CheckBoxList ChkLst;

                int Num = 1;
                foreach (TableRow row in TblScrpPages.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        ChkLst = new CheckBoxList();
                        // 				 ch.ID=Num.ToString();    
                        ChkLst = (CheckBoxList)cell.FindControl(Num.ToString());
                        if (ChkLst != null)
                        {
                            for (int i = 0; i < ChkLst.Items.Count; i++)
                            {
                                if (ischksel == true)
                                    ChkLst.Items[i].Selected = true;
                                else
                                    ChkLst.Items[i].Selected = false;
                            }//end of for statement
                            Num += 1;
                        }//end of if(chklist!=null)
                    }//end of foreach foreach (TableCell cell in row.Cells)
                }//end of foreach foreach (TableRow row in TblScrpPages.Rows)
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
            }//end of catch
            finally
            {

            }

        }//end of function

        //function to display module wise pages
        private void fillchecklist_module(Boolean ischksel, int Num)
        {
            try
            {
                CheckBoxList ChkLst;

                foreach (TableRow row in TblScrpPages.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {


                        ChkLst = new CheckBoxList();
                        // 				 ch.ID=Num.ToString();    
                        ChkLst = (CheckBoxList)cell.FindControl(Num.ToString());
                        if (ChkLst != null)
                        {
                            for (int i = 0; i < ChkLst.Items.Count; i++)
                            {
                                if (ischksel == true)
                                    ChkLst.Items[i].Selected = true;
                                else
                                    ChkLst.Items[i].Selected = false;
                            }//end of for 

                        }//end of if(chklist!=null)
                    }//end of foreach  foreach (TableCell cell in row.Cells)
                }//end of foreach foreach (TableRow row in TblScrpPages.Rows)
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";

                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
            }//end of catch
            finally
            {

            }
        }//end of function
         //function to unselect to checkboxes

        private void unfillchecklist(Boolean ischksel)
        {
            try
            {
                CheckBoxList ChkLst;

                int Num = 1;
                foreach (TableRow row in TblScrpPages.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        ChkLst = new CheckBoxList();
                        // 				 ch.ID=Num.ToString();    
                        ChkLst = (CheckBoxList)cell.FindControl(Num.ToString());
                        if (ChkLst != null)
                        {
                            for (int i = 0; i < ChkLst.Items.Count; i++)
                            {
                                if (ischksel == true)
                                    ChkLst.Items[i].Selected = false;
                                else
                                    ChkLst.Items[i].Selected = false;
                            }//end of for statement
                            Num += 1;
                        }//end of if
                    }//end of foreach (TableCell cell in row.Cells)
                }//end of foreach  foreach (TableRow row in TblScrpPages.Rows)
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";
                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
            }
            finally
            {

            }

        }//end of function

        protected void btnshow_previous_Click(object sender, EventArgs e)
        {
            //this is show the previous permission of the empname from the database
            try
            {
                lblmessage.Visible = true;
                lblmessage.Text = "";
                fillchecklist(false);
                if (DrpUserID.SelectedIndex > 0)
                {
                    CheckBoxList chbox;
                    int Num;
                    cn = new SqlConnection(ConfigurationManager.AppSettings["CMS"]);
                    cn.Open();
                    ds = new DataSet();
                    da = new SqlDataAdapter();
                    cmd = new SqlCommand("Select form_id from mdx_user_previligers where user_id='" + DrpUserID.SelectedItem.Text + "'", cn);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "mdx_form_names");
                    if (ds.Tables["mdx_form_names"].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables["mdx_form_names"].Rows)
                        {
                            Num = 1;
                            foreach (TableRow Trow in TblScrpPages.Rows)
                            {
                                foreach (TableCell cell in Trow.Cells)
                                {
                                    chbox = new CheckBoxList();
                                    // 				 ch.ID=Num.ToString();    
                                    chbox = (CheckBoxList)cell.FindControl(Num.ToString());
                                    if (chbox != null)
                                    {
                                        for (int i = 0; i < chbox.Items.Count; i++)
                                        {
                                            if (chbox.Items[i].Value.ToString() == row["form_id"].ToString())
                                                chbox.Items[i].Selected = true;
                                        }
                                        Num += 1;
                                    }//end of if(chkbox!=null)
                                }//end of foreach (TableCell cell in Trow.Cells)
                            }//end of foreach (TableRow Trow in TblScrpPages.Rows)

                        }//end of  foreach (DataRow row in ds.Tables["mdx_form_names"].Rows)
                    }//end of if(ds.Tables["mdx_form_names"].Rows.Count > 0)
                }//end of if (DrpUserID.SelectedIndex) 
            }//end of try
            catch (Exception ex)
            {
                lblmessage.Text = "";

                lblerr_msg.Visible = true;
                lblerr_msg.Text = ex.Message.ToString();
                //Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "' )</script>");
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }//end of buttonclick


        protected void ch_all_checkedchanged(object sender, EventArgs e)
        {
            if (chkall.Checked == true)
                fillchecklist(true);
            else
                fillchecklist(false);
        }
        protected void ch_hr_chechedchanged(object sender, EventArgs e)
        {
            int Num = 1;
            if (checkhr.Checked == true)
                fillchecklist_module(true, Num);
            else
                fillchecklist_module(false, Num);
        }
        protected void ch_proj_chechedchanged(object sender, EventArgs e)
        {
            int Num = 2;
            if (checkproject.Checked == true)
                fillchecklist_module(true, Num);
            else
                fillchecklist_module(false, Num);
        }
        protected void ch_purchase_chechedchanged(object sender, EventArgs e)
        {
            int Num = 3;
            if (checkpurchase.Checked == true)
                fillchecklist_module(true, Num);
            else
                fillchecklist_module(false, Num);
        }
        protected void ch_admin_chechedchanged(object sender, EventArgs e)
        {
            int Num = 4;
            if (checkadmin.Checked == true)
                fillchecklist_module(true, Num);
            else
                fillchecklist_module(false, Num);
        }
        protected void ch_account_chechedchanged(object sender, EventArgs e)
        {
            int Num = 5;
            if (checkaccount.Checked == true)
                fillchecklist_module(true, Num);
            else
                fillchecklist_module(false, Num);
        }
        protected void ch_emp_chechedchanged(object sender, EventArgs e)
        {
            int Num = 6;
            if (checkemp.Checked == true)
                fillchecklist_module(true, Num);
            else
                fillchecklist_module(false, Num);
        }



    }//end of class
}