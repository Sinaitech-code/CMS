<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.admin.admin_send_car"  Debug="true" Codebehind="send_car.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Send car</title>
         <link href="../HR/includes/css/styles.css" rel="stylesheet" type="text/css" />

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
                <asp:Label ID="lblemp" runat="server" Text="Label"></asp:Label></span>
            <br />
            <span class="date">Date:
                <asp:Label ID="lbldate1" runat="server" ></asp:Label></span>
        </div>
        <!-- end #login_details -->
        
    </div>
    <!-- end #header -->
    
    <!-- start #header_bg -->
    <div id="header_bg">
    	<a id="A1" href="../Default.aspx" class="logout" runat ="server">logout</a>
    </div>
    <!-- end #header_bg -->
    
    <div id="content_holder">
    	<div id="left_navi_holder">
       <div class="side_navi_gap">&nbsp;</div>
      <a href="#" class="navi_head">Admin</a>
      <a href="add_client.aspx" class="side_navi">add client</a>
      <a href="add_admin.aspx" class="side_navi">add admin</a>
      <a href="add_department.aspx" class="side_navi">add department</a>
      <a href="add_emp_grade.aspx" class="side_navi">add employee grade</a>
       <a href="assign_modules_to_admin.aspx" class="side_navi">assign modules to admin</a>
      <a href="manage_client.aspx" class="side_navi">manage clients</a>
      <a href="manage_department.aspx" class="side_navi">manage department</a>
      <a href="manage_admin.aspx" class="side_navi">manage admin</a>
      <a href="manage_emp_grade.aspx" class="side_navi">manage employee grade</a>
       <a href="user_accs_permissions.aspx" class="side_navi">user permissions</a>
      <a href="#" class="navi_head">Employee</a>
      <a href="view_pending_tasks.aspx" class="side_navi">view pending tasks</a>
      <a href="virew_underprocess_tasks.aspx" class="side_navi">view underprocess tasks</a>
      <a href="view_completed_tasks1.aspx" class="side_navi">view completed tasks</a>
      <a href="view_cars.aspx" class="side_navi">view cars</a>
     <a href="view_expences_status.aspx" class="side_navi">view expenses status</a>
     <a href="view_daily_report.aspx" class="side_navi">view emp daily report</a>
     <a href="#" class="navi_head">Projects</a>
     <a href="view_underprocess_project_status.aspx" class="side_navi">view under process projects</a>
     <a href="view_pending_projects.aspx" class="side_navi">view pending projects</a>
     <a href="view_completed_projects.aspx" class="side_navi">view completed projects</a> </div>
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">send CAR</div>
            </div>
            
          <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="184" class="grid_content_2">client name:</td>
                <td width="574" class="grid_content_2">
                <asp:Label ID="lblclient_name" runat="server" Text="" ></asp:Label></td>
              </tr>
              <tr>
                <td class="grid_content_indent_1">project name:</td>
                <td class="grid_content_indent_1">
                <asp:Label ID="lblproj_name" runat="server" Text="" ></asp:Label></td>
              </tr>
              <tr>
                <td class="grid_content_indent_2">to:</td>
                <td class="grid_content_indent_2">
                  <input name="textfield24" type="text" class="txt_box_other" id="txtto_empname"   runat ="server"/>                </td>
              </tr>
              <tr>
                <td class="grid_content_indent_1">attention:</td>
                <td class="grid_content_indent_1">
                <input name="textfield23" type="text" class="txt_box_other" id="txtattent"  runat ="server"/></td>
              </tr>
              <tr>
                <td class="grid_content_indent_2">From:</td>
                <td class="grid_content_indent_2">
                  <input name="textfield25" type="text" class="txt_box_other" id="txtfrom_empname"  runat ="server"/>                </td>
              </tr>
              <tr>
                <td class="grid_content_indent_1">
                    date:</td>
                <td class="grid_content_indent_1"><input name="textfield26" type="text" class="txt_box_other" id="txtdate" runat ="server" />
                </td>
              </tr>
              
              <tr>
                <td class="grid_content_indent_2">description:</td>
                <td class="grid_content_indent_2">
                <textarea name="textarea" cols="45" rows="5" class="text_area_indent" id="textarea1" runat ="server"></textarea></td>
              </tr>
              <tr>
                <td class="grid_content_indent_1">&nbsp;</td>
                <td class="grid_content_indent_1">
                <input name="button" type="submit" class="btn" id="button" value="Submit" runat ="server" onserverclick="button_ServerClick"  />
                <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
                <p align ="center" ><asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label></p></td>
              </tr>
            </table>
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
