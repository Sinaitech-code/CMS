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

namespace CMS
{
    public partial class calnder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string strscript = "<script>window.opener.document.forms[0]." + Request.QueryString["textbox"] + ".value = '";
                strscript += Calendar1.SelectedDate.ToString("MM/dd/yyyy");

                strscript += "';self.close()";
                strscript += "</" + "script>";
                RegisterClientScriptBlock("anything", strscript);
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>alert('Please Try Again..!' )</script>");
            }
            finally { }
        }
    }
}
