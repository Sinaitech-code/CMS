<%@ Page Language="C#" AutoEventWireup="true" Inherits="Projects_edit_sub_project" Codebehind="edit_sub_project.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<!--<title> - CMS</title>-->
<link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>

<body>
<form id="form10" runat ="server" >
<!-- start #main_container -->
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
                <div id="form_head_text_area">edit project</div>
            </div>
            
            <div id="form">
            	
                <%--<p>
                  <label>change client:</label>
                  <select name="select" class="dropdown" id="select" runat ="server" >
                    <option>alredy selected client name</option>
                  </select>
              </p>--%>
            <%--  <p>
                <label>change project type:</label>
                <select name="select2" class="dropdown" id="select2" runat ="server">
                  <option>alredy selected porject type</option>
                </select>
              </p>--%>
              <p>
                <label>change project:</label>
                  <asp:DropDownList ID="ddlproject" runat="server" DataTextField="project_id" DataValueField="project_id" CssClass="dropdown" >
                  </asp:DropDownList>
                <%--<select name="select2" class="dropdown" id="select1" runat ="server">
                  <option>alredy selected porject</option>
                </select>--%>
              </p>
                <p>
                  <label>edit sub project name:</label>
                  <asp:TextBox ID="txtsubprojectname" runat="server" CssClass="txt_box"></asp:TextBox>
              <%-- <input name="textfield" type="text" class="txt_box" id="textfield" value="project 1" runat ="server"/>--%>
              </p>
              <p>
                  <label>edit  scheduled starting date:</label> 
                  <asp:TextBox ID="txtstartingdate" runat="server" CssClass="txt_box"></asp:TextBox>
                  <%--<input name="textfield" type="text" class="txt_box" id="text1" value="13/08/2008" runat ="server"/>--%>
              <a href="#"><img src="../employees/imgs/icon_calendar.jpg" alt="" width="20" height="20" border="0" /></a></p>
                <p>
                  <label>edit expecting to finish by:</label>
                   <asp:TextBox ID="txtendingdate" runat="server" CssClass="txt_box"></asp:TextBox>
                  
                   <%--<input name="textfield" type="text" class="txt_box" id="text2" value="13/08/2009" runat ="server"/>--%>
                  <a href="#"><img src="../employees/imgs/icon_calendar.jpg" alt="" width="20" height="20" border="0" /></a></p>
                
                <p><label>&nbsp;</label><asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnsubmit_Click" />
                 <%--<input name="button" type="submit" class="btn" id="button" value="Submit" runat ="server"/>--%>
                </p>
              <!--
                <table width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td width="140">&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>First Name:</td>
                    <td><input name="textfield" type="text" class="txt_box" id="textfield" /></td>
                  </tr>
                  <tr>
                    <td>Middle Name:</td>
                    <td><input name="textfield2" type="text" class="txt_box" id="textfield2" /></td>
                  </tr>
                  <tr>
                    <td>Last Name:</td>
                    <td><input name="textfield3" type="text" class="txt_box" id="textfield3" /></td>
                  </tr>
                  <tr>
                    <td>Fathers Name:</td>
                    <td><input name="textfield4" type="text" class="txt_box" id="textfield4" /></td>
                  </tr>
                  <tr>
                    <td>Date of Birth:</td>
                    <td><input name="textfield5" type="text" class="txt_box" id="textfield5" /></td>
                  </tr>
                  <tr>
                    <td>Qualification:</td>
                    <td><input name="textfield6" type="text" class="txt_box" id="textfield6" /></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td><input name="button" type="submit" class="btn" id="button" value="Submit" /></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                </table>
                -->
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
