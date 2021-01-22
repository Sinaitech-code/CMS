<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.projects.projects_user_relations" Codebehind="user_relations.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>User relations</title>
    <link href="../HR/includes/css/styles.css" type="text/css" rel="stylesheet" />
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
               </div>
        <uc1:AdminHeader ID="AdminHeader1" runat="server" />
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">user relations</div>
            </div>
             <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible ="false"></asp:Label> 
            <div id="form">
            	<p>
                  <label><asp:label id="Label3" runat="server"  Text="*"  ForeColor="red"></asp:label>select project:</label>
                  <asp:DropDownList ID="ddlproject" runat="server" CssClass="dropdown" AutoPostBack="True" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select project" ControlToValidate="ddlproject"></asp:RequiredFieldValidator>   
             </p>
               <p>
                  <label><asp:label id="Label2" runat="server"  Text="*"  ForeColor="red"></asp:label>select role:</label>
                  <asp:DropDownList ID="ddlroles" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlroles_SelectedIndexChanged1">
                    </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select employee role" ControlToValidate="ddlroles"></asp:RequiredFieldValidator>
             </p>
                <p>
                  <label><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>select topuser:</label>
                    <asp:DropDownList ID="ddltopuser" runat="server" CssClass="dropdown" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="select topuser" ControlToValidate="ddltopuser"></asp:RequiredFieldValidator>
              </p>
              
                <p>
                <label><asp:label id="Label7" runat="server"  Text="*"  ForeColor="red"></asp:label>select employee emprole:</label>
               <asp:DropDownList ID="ddlemprole" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlemprole_SelectedIndexChanged" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="select employee role" ControlToValidate="ddlemprole"></asp:RequiredFieldValidator>
              </p>
              <p>
                <label>select employee(s):</label>
                  <asp:ListBox ID="listboxemp1" runat="server" SelectionMode="Multiple" CssClass="listbox"> </asp:ListBox>
                  <asp:Button ID="btnadd" runat="server" Text="add" CssClass="btn" OnClick="btnadd_Click1"  />
                  <asp:ListBox ID="listboxemp2" runat="server" SelectionMode="Multiple" CssClass="listbox"></asp:ListBox>
                
              </p>
              
              <p><label>&nbsp;</label> 
                  <asp:Button ID="btnsubmit" runat="server" Text="submit" CssClass="btn" OnClick="btnsubmit_Click"  />
                  <asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible ="false" ></asp:Label>
                </p>              
          </div>
      </div>
    </div>
    
    
    <div id="footer">
    	&nbsp;
    &nbsp;
    </div>
    
</div>
<!-- end #main_container -->
    </div>
    </form>
</body>
</html>
