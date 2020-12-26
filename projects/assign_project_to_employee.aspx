<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.projects.projects_assign_project_to_employee" Codebehind="assign_project_to_employee.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
<title> - CMS</title>
<link href="../HR/includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">
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
              <a href="view_rejected_orders.aspx" class="side_navi"> view rejected orders </a>
                <a href="view_pending_orders.aspx" class="side_navi"> view pending orders </a>
               </div>
        <uc1:AdminHeader ID="AdminHeader1" runat="server" />
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">assign employee(s) to project</div>
            </div>
            
            <div id="form">
            	
               <p>
                  <label><asp:label id="Label7" runat="server"  Text="*"  ForeColor="red"></asp:label>select client:</label>
                  <asp:DropDownList ID="ddlclients" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlclients_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select client name" ControlToValidate="ddlclients"></asp:RequiredFieldValidator>
             </p>
                <p>
                  <label><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>select project:</label>
                    <asp:DropDownList ID="ddlproject" runat="server" CssClass="dropdown" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select project" ControlToValidate="ddlproject"></asp:RequiredFieldValidator>
              </p>
           
                <p>
                <label><asp:label id="Label2" runat="server"  Text="*"  ForeColor="red"></asp:label>select employee grade:</label>
               <asp:DropDownList ID="ddlempgrade" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlempgrade_SelectedIndexChanged1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="select employee grade" ControlToValidate="ddlempgrade"></asp:RequiredFieldValidator>
              </p>
              <p>
                <label><asp:label id="Label3" runat="server"  Text="*"  ForeColor="red"></asp:label>select employee(s):</label>
                  <asp:ListBox ID="listboxemp" runat="server" SelectionMode="Multiple" CssClass="listbox" AutoPostBack="True" OnSelectedIndexChanged="listboxemp_SelectedIndexChanged"></asp:ListBox>
                  <asp:HyperLink ID="lnk" runat="server" Visible="false">HyperLink</asp:HyperLink>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="select employee(s)" ControlToValidate="listboxemp"></asp:RequiredFieldValidator>
                  <asp:Label ID="lblrole" runat="server" Text="" CssClass="errmsg" Visible="false"></asp:Label>
              </p>
                <p>
                  <label><asp:label id="Label4" runat="server"  Text="*"  ForeColor="red"></asp:label>select role:</label>
                    <asp:RadioButtonList ID="rbtn" runat="server">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="select role" ControlToValidate="rbtn"></asp:RequiredFieldValidator>
                    </p>
                <p>&nbsp;</p>
              <p><label>&nbsp;</label> 
                  <asp:Button ID="btnasign" runat="server" Text="assign" CssClass="btn" OnClick="btnasign_Click" />
                 <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg"></asp:Label>  
                </p> 
                <p align ="center" ><asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible ="false" ></asp:Label></p>             
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
