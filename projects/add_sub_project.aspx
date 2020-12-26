<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.projects.Projects_add_sub_project" Codebehind="add_sub_project.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
<!--<title> - CMS</title>-->
<link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>

<body>
<form id="form5" runat ="server"  method ="post">
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
                <%--<a id="A17" href="../user_accs_permissions.aspx" class="side_navi">User Permissions</a>--%>
                <a href="view_purchase_requisition.aspx" class="side_navi"> view purchase requisition </a>
                <a href="view_rejected_orders.aspx" class="side_navi"> view rejected orders </a>
                <a href="view_pending_orders.aspx" class="side_navi"> view pending orders </a>
               </div>
         <uc1:AdminHeader ID="AdminHeader1" runat="server" />
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">add sub project</div>
            </div>
            
            <div id="form">
            
                <p>
                <label><asp:label id="Label7" runat="server"  Text="*"  ForeColor="red"></asp:label>select project:</label>
              
                <asp:DropDownList ID="ddlproj_id" runat="server" CssClass="dropdown" AutoPostBack="True" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select project name" ControlToValidate="ddlproj_id"></asp:RequiredFieldValidator>
              </p>
              
                <p>
              <label><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>enter sub project name:</label> 
                    <asp:TextBox ID="txtsub_projname" runat="server" CssClass="txt_box"></asp:TextBox>
                     <asp:Label ID="lblcheck" runat="server" Visible="False" CssClass ="errmsg" ></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter sub project name" ControlToValidate="txtsub_projname"></asp:RequiredFieldValidator>    
              </p>
                <p>
                  <label>project starting date:</label> <asp:TextBox ID="txtsdate" runat="server" CssClass="txt_box"></asp:TextBox>
                  <a href="javascript:;" onclick="window.open('../calnder.aspx?textbox=txtsdate','cal','width=210,height=190,left=220,top=180')">
      <img src="../imgs/icon_calendar.jpg" border="0"></a></p>
                <p>
                  <label>expecting to finish by:</label> <asp:TextBox ID="txtfinishingate" runat="server" CssClass="txt_box"></asp:TextBox>
                 <a href="javascript:;" onclick="window.open('../calnder.aspx?textbox=txtfinishingate','cal','width=210,height=190,left=220,top=180')">
      <img src="../imgs/icon_calendar.jpg" border="0"></a></p>
                <p><label>&nbsp;</label> 
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit"  CssClass="btn" OnClick="btnsubmit_Click"/>&nbsp;
                 <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg"></asp:Label>  
                </p>
                <p align ="center" ><asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg"></asp:Label></p>
             
          </div>
      </div>
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
   
    
</div>
<!-- end #main_container -->
</form> 
</body>
</html>
