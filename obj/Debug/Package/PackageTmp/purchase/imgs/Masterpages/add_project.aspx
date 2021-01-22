<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin1_add_project" Codebehind="add_project.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
 <title>Untitled Page</title>
<link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>

<body>
<form id="form9" runat="server">
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
        	<a href="#" class="navi_head">Admin</a>
            	<a href="add_admin.aspx" class="side_navi">add admin</a>
                <a href="manage_admins.aspx" class="side_navi">manage admins</a>
                <a href="assign_modules_to_admin.aspx" class="side_navi">assign modules to admin</a>
                <a href="manage_modules_with_admin.aspx" class="side_navi">manage modules with admin</a>
                <a href="add_department.aspx" class="side_navi">add department</a>
                <a href="manage_department.aspx" class="side_navi">manage departments</a>
            <a href="#" class="navi_head">Employees</a>
            	<a href="compleated_tasks.aspx" class="side_navi">view compleated tasks</a>
                <a href="pending_tasks.aspx" class="side_navi">view Pending tasks</a>
                <a href="under_process_tasks.aspx" class="side_navi">view under process tasks</a>
                <a href="view_daily_report.aspx" class="side_navi">view daily progress report</a>                
                <a href="#" class="side_navi">view pending CARs</a>
                <a href="#" class="side_navi">view closed CARs</a>
            <a href="#" class="navi_head">Project</a>
            	<a href="view_underprocess_projec.aspx" class="side_navi">under-process projects</a>
                <a href="view_pending_project.aspx" class="side_navi">pending projects</a>
                <a href="view_compleated_project.aspx" class="side_navi">compleated projects</a>
                <a href="#" class="side_navi">view pending CARs</a>
                <a href="#" class="side_navi">view closed CARs</a>
            <a href="#" class="navi_head">Client</a>
            	<a href="#" class="side_navi">view client comments</a>
                <a href="#" class="side_navi">view response to client</a>
            <a href="#" class="navi_head">Material</a>
            	<a href="manage_materials.aspx" class="side_navi">view material list</a>
                <a href="#" class="side_navi">view pending CARs</a>
                <a href="#" class="side_navi">view closed CARs</a>
            <a href="#" class="navi_head">Purchase Department</a>
            	<a href="purchase_order.aspx" class="side_navi">view purchase requistion</a>
                <a href="purchase_order.aspx" class="side_navi">view purchase order</a>
                <a href="#" class="side_navi">view delivery challan</a>
                <a href="#" class="side_navi">view goods receipt note</a>
                <a href="#" class="side_navi">view pending CARs</a>
                <a href="#" class="side_navi">view closed CARs</a>
            
        </div>
        
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">add project</div>
            </div>
            
            <div id="form">
            	
                <p>
                  <label>select client:</label>
                  <%--<select name="select" class="dropdown" id="select" runat="server">
                  </select>--%>
                    <asp:DropDownList ID="ddlclient" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlclient_SelectedIndexChanged">
                   
                    
                    </asp:DropDownList>
              </p>
              <p>
                <label>select project type:</label>
               <%-- <select name="select2" class="dropdown" id="select2" runat="server">
                </select>--%>
                <asp:DropDownList ID="ddlprojtype" runat="server" CssClass="dropdown" AutoPostBack="True">
                    <asp:ListItem>construction</asp:ListItem>
                    </asp:DropDownList>
              </p>
                <p>
              <label>enter project name:</label> <%--<input name="textfield" type="text" class="txt_box" id="txtprojname" runat="server" />--%>
                    <asp:TextBox ID="txtprojname" runat="server" CssClass="txt_box"></asp:TextBox>
              </p>
                <p>
                  <label>project starting date:</label> <asp:TextBox ID="txtsdate" runat="server" CssClass="txt_box"></asp:TextBox>
                  <a href="#"><img src="../employees/imgs/icon_calendar.jpg" alt="" width="20" height="20" border="0"  runat="server"/></a></p>
                <p>
                  <label>expecting to finish by:</label> <asp:TextBox ID="txtfinishingate" runat="server" CssClass="txt_box"></asp:TextBox>
                  <a href="#"><img src="../employees/imgs/icon_calendar.jpg" alt="" width="20" height="20" border="0"  runat="server"/></a></p>
                
                <p><label>&nbsp;</label>
                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn" OnClick="btnsave_Click" />
                    <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn" OnClick="btnclear_Click" />
                 <%--<input name="button" type="submit" class="btn" id="button" value="Submit" runat="server" onserverclick="button_ServerClick" />--%>
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

