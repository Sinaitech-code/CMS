<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.projects.projects_projectdefault" Codebehind="projectdefault.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../includes/css/styles.css" type="text/css" rel="stylesheet" />
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
    	<a id="A1" href="../Default.aspx" class="logout" runat="server">logout</a>
    </div>
    <!-- end #header_bg -->
    
    <div id="content_holder">
    	<div id="left_navi_holder">
        	<div class="side_navi_gap">&nbsp;</div>
        	<a href="#" class="navi_head">Projects</a>
            	<a href="add_project_type.aspx" class="side_navi">add project type</a>
                <a href="manage_project_type.aspx" class="side_navi">manage project type</a>
                <a href="add_project.aspx" class="side_navi">add project</a>
                <a href="manage_project.aspx" class="side_navi">manage project</a>
                <a href="add_sub_project.aspx" class="side_navi">add sub project</a>
                <a href="manage_sub_project.aspx" class="side_navi">manage sub project</a>
                <a href="add_project_levels.aspx" class="side_navi">add project levels</a>
                <a href="manage_project_levels.aspx" class="side_navi">manage project levels</a>
                <a href="assign_project_to_employee.aspx" class="side_navi">assign employee to project</a>
                <a href="user_relations.aspx" class="side_navi"> employee relation </a>
                 <a href="view_purchase_requisition.aspx" class="side_navi"> view purchase requisition </a>
                <a href="view_rejected_orders.aspx" class="side_navi"> view rejected orders </a>
                 <a href="view_pending_orders.aspx" class="side_navi"> view pending orders </a>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass ="navi_head" NavigateUrl="../changepassword.aspx">change password</asp:HyperLink>
               </div>
        <uc1:AdminHeader ID="AdminHeader1" runat="server" />
    
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
               <div id="form_head_text_area">project</div>
            </div>
            
            <div id="Div1">
        	
      </div>
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
    
</div>
<!-- end #main_container -->
       
    </div>
    </div> 
    </form>
</body>
</html>
