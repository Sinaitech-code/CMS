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
    public partial class admindefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblemp.Text = Session["AUserName"].ToString();
                lbldate.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
