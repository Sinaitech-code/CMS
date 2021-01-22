<%@ Page Language="C#" AutoEventWireup="true" Inherits="Masterpages_add_project_levels" Codebehind="add_project_levels.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div>
    <div id="main_container">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo"><img src="imgs/logo.jpg" width="220" height="73" border="0" alt="" /></div>
        <!-- end #logo -->
        
        <!-- start #login_details -->
        <div id="login_details">
        	<span class="welcome">welcome:</span> <span class="loged_name">admin</span>
            <br />
            <span class="date">date: 13/08/2008</span>
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
            	<a href="../admin/add_client.aspx" class="side_navi">add client</a>
                <a href="../admin/manage_client.aspx" class="side_navi">manage client</a>
                <a href="add_project_type.aspx" class="side_navi">add project type</a>
                <a href="manage_project_type.aspx" class="side_navi">manage project type</a>
                <a href="add_project.aspx" class="side_navi">add project</a>
                <a href="manage_project.aspx" class="side_navi">manage project</a>
                <a href="add_sub_project.aspx" class="side_navi">add sub project</a>
                <a href="manage_sub_project.aspx" class="side_navi">manage sub project</a>
                <a href="add_project_levels.aspx" class="side_navi">add project levels</a>
                <a href="manage_project_levels.aspx" class="side_navi">manage project levels</a>
                <a href="assign_project_to_employee.aspx" class="side_navi">assign employee to project</a>
                <a href="manage_assigned_employees.aspx" class="side_navi">manage assigned employees</a>
        </div>
        
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">edit project level</div>
            </div>
            
            <div id="form">
            	
               
              <p>
                <label>select project:</label>
                  <asp:DropDownList ID="ddlprojects" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlprojects_SelectedIndexChanged">
                    </asp:DropDownList>
              </p>
              <p>
                <label>select sub project:</label>
                 <asp:DropDownList ID="ddlsubproject" runat="server" CssClass="dropdown" AutoPostBack="True">
                    </asp:DropDownList>
              </p>
                <p>
              <label>enter project level name:</label> 
                    <asp:TextBox ID="txtprojectlevel" runat="server" CssClass="txt_box"></asp:TextBox></p>
                <p>
                  <label>project level starting date:</label><asp:TextBox ID="txtstartingdate" runat="server" CssClass="txt_box"></asp:TextBox>
                  <a href="#"><img src="../employees/imgs/icon_calendar.jpg" alt="" width="20" height="20" border="0" /></a></p>
                <p>
                  <label>expecting to finish by:</label> <asp:TextBox ID="txtfinishingdate" runat="server" CssClass="txt_box"></asp:TextBox>
                  <a href="#"><img src="../employees/imgs/icon_calendar.jpg" alt="" width="20" height="20" border="0" /></a></p>
                
                <p><label>&nbsp;</label> 
                    <asp:Button ID="btnsave" runat="server" Text="save" CssClass="btn" OnClick="btnsave_Click"/>
                    <asp:Button ID="btnclear" runat="server" Text="clear" CssClass="btn" OnClick="btnclear_Click"/>
                </p>
             
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
