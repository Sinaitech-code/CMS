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

namespace CMS.projects
{
    public partial class projects_projectdefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblemp.Text = Session["AUserName"].ToString();
                lbldate1.Text = DateTime.Now.ToShortDateString();
            }//end of try
            catch (Exception ex)
            {
                Response.Redirect("../Default.aspx");
            }//end of catch
        }//end of page load
    }//end of class

}
