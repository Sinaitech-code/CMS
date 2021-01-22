<%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation="true" Inherits="CMS.HR.HR_user_access_permissions_hr" Codebehind="user_access_permissions_hr.aspx.cs" %>
<%--<%@ Page EnableEventValidation="true" %>
--%><%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>User Access permissions</title>
     <link type="text/css" rel="stylesheet" href="includes/css/styles.css" />
     <style>
        .chekBox{ text-align:left; color:Balck; display:table;}
     </style>
</head>
<body>
    <form id="form1" runat="server">
   
    <div>
     <!-- start #main_container -->
        
<div id="main_container">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo"></div>
        <!-- end #logo -->
        
        <!-- start #login_details -->
        <div id="login_details">
        	<span class="welcome">welcome:</span> <span class="loged_name">
                <asp:Label ID="lblemp" runat="server" Text="Label"></asp:Label></span>
            <br />
            <span class="date">date: 
                <asp:Label ID="lbldate1" runat="server" Text="Label"></asp:Label></span>
        </div>
        <!-- end #login_details -->
        
    </div>
    <!-- end #header -->
    
    <!-- start #header_bg -->
    <div id="header_bg">
    	<a href="../Default.aspx" class="logout">logout</a>
    </div>
    <!-- end #header_bg -->
    
    <div id="content_holder">
    	<div id="left_navi_holder">
        	<div class="side_navi_gap">&nbsp;</div>
        	<a href="#" class="navi_head">HR</a>
            <a href="create_employee .aspx" class="side_navi">add  employee</a>
            <a href="manage _employee.aspx" class="side_navi">manage employee</a>
            <a  id="A17" href="user_access_permissions_hr.aspx" class="side_navi">User Permissions</a>
           
            </div>
      <uc1:AdminHeader ID="AdminHeader1" runat="server" />
       
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
              <%--<div id="form_head_text_area">add project</div>--%>
                <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" CssClass="btn" />
                <asp:Label ID="lblerr_msg" runat="server" CssClass ="errmsg" Visible="False"></asp:Label>
                <asp:Label ID="lblmessage" runat="server" CssClass ="errmsg" Visible="False"></asp:Label>
                <asp:DropDownList ID="DrpUserID" runat="server" CssClass ="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Select Employee" ControlToValidate="DrpUserID"></asp:RequiredFieldValidator>
                <asp:Button ID="btnshow_previous" runat="server"  Text="Show Previous" OnClick="btnshow_previous_Click" CssClass="btn" />
                
            </div>
            <table>
            <tr><td><asp:CheckBox ID="chkall" runat="server"   Text ="Check All"  AutoPostBack="true" OnCheckedChanged="ch_all_checkedchanged" />
             </td></tr>
            
             <tr> <td>
               <asp:CheckBox ID="checkhr" runat="server" Text ="Check HR" AutoPostBack="true" OnCheckedChanged="ch_hr_chechedchanged" />
                 </td></tr>
                  <tr><td><asp:CheckBox ID="checkproject" runat="server" Text ="Check Project" AutoPostBack="true" OnCheckedChanged="ch_proj_chechedchanged"/>
                </td></tr>
                <tr> <td>
               <asp:CheckBox ID="checkpurchase" runat="server" Text ="Check Purchase" AutoPostBack="true" OnCheckedChanged="ch_purchase_chechedchanged" />
                 </td></tr>
                  <tr> <td>
               <asp:CheckBox ID="checkadmin" runat="server" Text ="Check Admin" AutoPostBack="true" OnCheckedChanged="ch_admin_chechedchanged" />
                 </td></tr>
                  <tr> <td>
               <asp:CheckBox ID="checkaccount" runat="server" Text ="Check Account" AutoPostBack="true" OnCheckedChanged="ch_account_chechedchanged" />
                 </td></tr>
                  <tr> <td>
               <asp:CheckBox ID="checkemp" runat="server" Text ="Check Employee" AutoPostBack="true" OnCheckedChanged="ch_emp_chechedchanged" />
                 </td></tr>
                </table>
           <%-- <div id="form">--%>
            
           <table width="100%" cellpadding="0" cellspacing="0" border="1" >
           <tr><td class="permission_table">
               <asp:Table ID="TblScrpPages" runat="server">
               </asp:Table> </td></tr>
            
           
           
            
           
            </table>
               
            
          <%--</div>--%>
      </div>
       
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
    
</div>
<!-- end #main_container -->
    
      
    </div>
    </form>
</body>
</html>
