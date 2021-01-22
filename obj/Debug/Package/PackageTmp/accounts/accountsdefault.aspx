<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.accounts.accounts_accountsdefault" Codebehind="accountsdefault.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Accounts home</title>
    <link type="text/css" rel="stylesheet" href="../includes/css/styles.css" />
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
                <asp:Label ID="lblemp" runat="server" Text=""></asp:Label></span>
            <br />
            <span class="date">date: 
                <asp:Label ID="lbldate1" runat="server" Text=""></asp:Label></span>
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
        		<a href="#" class="navi_head">Accounts</a>	
              <a href="view_purchase_orders.aspx" class="side_navi">view purchase order</a>
                <a href="view_expences_status.aspx" class="side_navi">view prettyexpences</a>
                <a href="view_accounts.aspx" class="side_navi">view accounts</a>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass ="navi_head" NavigateUrl="../changepassword.aspx">change password</asp:HyperLink>
             
            
            
        </div>
         <uc1:AdminHeader ID="AdminHeader1" runat="server" />
    
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">Accounts</div>
            </div>
            
           
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
