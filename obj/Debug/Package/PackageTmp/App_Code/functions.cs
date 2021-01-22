using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for functions
/// </summary>
public class functions
{
    SqlConnection cn;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable tblRecords;
    SqlCommand Cmd;
    SqlDataAdapter Adp;
    DataTable TblData;
	public functions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void DbConnect()
    {
        // open the database connection
        cn = new SqlConnection(ConfigurationManager.AppSettings["maddox"]);
        if (cn.State == ConnectionState.Closed)
            cn.Open();

    }
    public void DbDisConnect()
    {
        // close the database connection
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
            cn.Dispose();
        }
    }
    public DataTable GetRecords(string Strcmd)
    {
        DbConnect();
        cmd = new SqlCommand(Strcmd, cn);
        da = new SqlDataAdapter(cmd);
        tblRecords = new DataTable();
        da.Fill(tblRecords);
        DbDisConnect();
        return tblRecords;

    }
    
    public void fill(DropDownList control, string strCmd)
    {
        DbConnect();
        tblRecords = GetRecords(strCmd);
        //tblRecords =get
        DbDisConnect();
        control.Items.Clear();
        if (tblRecords.Rows.Count > 0)
        {
            control.DataSource = tblRecords;
            control.DataTextField = tblRecords.Columns[0].ToString();
            control.DataValueField = tblRecords.Columns[0].ToString();
            control.DataBind();
        }

        control.Items.Insert(0, new ListItem("Select", ""));
    }
    public void fnfill(DropDownList control, string strCmd)
    {
        DbConnect();
        tblRecords = GetRecords(strCmd);
        //tblRecords =get
        DbDisConnect();
        control.Items.Clear();
        if (tblRecords.Rows.Count > 0)
        {
            control.DataSource = tblRecords;
            control.DataTextField = tblRecords.Columns[1].ToString();
            control.DataValueField = tblRecords.Columns[0].ToString();
            control.DataBind();
        }

        control.Items.Insert(0, new ListItem("Select", ""));
    
    
    
    }
    public void filllistbox(ListBox control, string strCmd)
    {
        DbConnect();
        tblRecords = GetRecords(strCmd);
        //tblRecords =get
        DbDisConnect();
        control.Items.Clear();
        if (tblRecords.Rows.Count > 0)
        {
            control.DataSource = tblRecords;
            control.DataTextField = tblRecords.Columns[0].ToString();
            control.DataValueField = tblRecords.Columns[0].ToString();
            control.DataBind();
        }

        control.Items.Insert(0, new ListItem("Select", ""));
    
    
    
    }

    public void fnfilllistbox(CheckBoxList control, string strCmd)
    {

        DbConnect();
        tblRecords = GetRecords(strCmd);
        //tblRecords =get
        DbDisConnect();
        control.Items.Clear();
        if (tblRecords.Rows.Count > 0)
        {
            control.DataSource = tblRecords;
            control.DataTextField = tblRecords.Columns[1].ToString();
            control.DataValueField = tblRecords.Columns[0].ToString();
            control.DataBind();
        }
    }


    
      

    public bool Check(string st3, string id, string admin)
    {   //If Page Is Valid or not

       
        SqlConnection con;
        SqlDataAdapter da2;
        DataSet ds;

        bool sts = false;

        if (admin != "superadmin")
        {
            cn = new SqlConnection(ConfigurationManager.AppSettings["maddox"]);
            cn.Open();
            da2 = new SqlDataAdapter("select form_name from mdx_form_names f ,mdx_user_previligers u where f.form_id=u.form_id  and u.user_id='" + id + "'", cn);
            ds = new DataSet();
            da2.Fill(ds, "mdx_users");
            cn.Close();
            if (ds.Tables["mdx_users"].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables["mdx_users"].Rows)
                {
                    if (dr["form_name"].ToString().ToUpper() == st3.ToString().ToUpper())
                    {
                        sts = true;
                        return (sts);

                    }

                }//end of foreach
                if (sts != true)
                {
                    return (sts);
                }
            }//end of if(ds.Tables["mdx_users"].Rows.Count>0)
            else
            {
                sts = false;
                return (sts);
            }
        }//end if if(admin!="superadmin)
        else
        {
            sts = true;
        }//end of else if(admin!="superadmin)
        return (sts);
    }//end of check function


   
}
