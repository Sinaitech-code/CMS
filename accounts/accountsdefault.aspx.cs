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


namespace CMS.accounts
{
    public partial class accounts_accountsdefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblemp.Text = Session["AUserName"].ToString();
                lbldate1.Text = DateTime.Now.ToShortDateString();
            }//end of if(!ispostback)
        }//end of pageload
    }//end of class
}