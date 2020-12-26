<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.HR.HR_reset__password" Codebehind="reset_ password.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main_container">
	<!-- start #header -->
	<div id="header">
    <!-- start #logo -->
    <div id="logo"></div>
    <!-- end #logo -->
    <!-- start #login_details -->
    <div id="login_details">
    <span class="welcome">welcome:</span> <span class="loged_name">
    <asp:Label ID="lblemp" runat="server" ></asp:Label></span>
    <br />
    <span class="date">date: 
    <asp:Label ID="lbldate1" runat="server" ></asp:Label></span>
    </div>
    <!-- end #login_details -->
    </div>
    <!-- end #header -->
    <!-- start #header_bg -->
    <div id="header_bg">
    <a id="A1" href="../Default.aspx" class="logout" runat="server">logout</a>
    </div>
    <!-- end #header_bg -->
    <div id="content_holder">
     
    <div id="left_navi_holder">
    <div class="side_navi_gap">&nbsp;</div>
    <a href="#" class="navi_head">HR</a>
    <a href="create_employee .aspx" class="side_navi">add  employee</a>
    <a href="manage _employee.aspx" class="side_navi">manage employee</a> 
    <a id="A17" href="user_access_permissions_hr.aspx" class="side_navi">User Permissions</a>
     </div>
    <uc1:AdminHeader ID="AdminHeader1" runat="server" />
    <div id="form_area">
    <div id="form_head">
    <div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">manage employees</div>
            </div>
            
         <div id="form">
         <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible ="false"></asp:Label>  
             <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td style="height: 134px">
             <asp:GridView ID="GridView1"   CssClass="grid_content_1" runat="server" width="100%" DataKeyNames="emp_id" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridview_pageindex"  >
              <Columns>
               
             <asp:BoundField  HeaderText="Employee id" DataField="emp_id">
             <HeaderStyle CssClass="grid_head" />
             </asp:BoundField>
             <asp:BoundField  HeaderText="Employee Name" DataField="user_id">
             <ControlStyle CssClass="grid_head" />
             <HeaderStyle CssClass="grid_head" />
             </asp:BoundField>
            <asp:HyperLinkField  Text="reset password" DataNavigateUrlFields ="emp_id"  HeaderText="Manage" DataNavigateUrlFormatString ='update_password.aspx?emp_id={0}'  >
                 <HeaderStyle CssClass="grid_head" />
             </asp:HyperLinkField>
             </Columns>
             <AlternatingRowStyle CssClass="grid_content_2" />
             <HeaderStyle CssClass="grid_head" />
             </asp:GridView>
             </td>
          </tr>
          </table>
          </div>
        </div>
       
        
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
    
</div>
    </form>
</body>
</html>


