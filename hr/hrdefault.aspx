<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.HR.HR_hrdefault" Codebehind="hrdefault.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../includes/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div id="main_container">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo"></div>
        <!-- end #logo -->
        
        <!-- start #login_details -->
        <div id="login_details">
        	<span class="welcome">welcome:</span> <span class="loged_name">
                <asp:Label ID="lblemp" runat="server" Text=""></asp:Label></span>
            <br />
            <span class="date">date: 
                <asp:Label ID="lbldate1" runat="server" Text=""></asp:Label></span>
        </div>
        &nbsp;
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
             <asp:HyperLink ID="HyperLink1" runat="server" CssClass ="navi_head" NavigateUrl="../changepassword.aspx">change password</asp:HyperLink> 
                  <asp:HyperLink ID="HyperLink2" runat="server" CssClass ="navi_head" NavigateUrl="../HR/reset_ password.aspx">reset password</asp:HyperLink>

            </div>
           <div id="form">
           
           
          <uc1:AdminHeader ID="AdminHeader1" runat="server" />
         
            <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">HR</div>
            </div>
            
         
      </div>
         
          </div>
     
       
        </div>
         </div>
        <div id="footer">
    	
    </div>
    
</div>
    
    </form>
</body>
</html>
