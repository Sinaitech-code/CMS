<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin1_manage_department" Codebehind="manage_department.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <title>Untitled Page</title>
<link href="includes/css/styles.css" type="text/css" rel="stylesheet" /></head>

<body>
<form id="form1" runat="server">
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
                <a href="../Employees/view_daily_report.aspx" class="side_navi">view daily progress report</a>                
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
                <div id="form_head_text_area">manage departments</div>
            </div>
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td>
           <asp:GridView ID="GridView1" runat="server"  width="100%" CssClass="grid_content_1" AutoGenerateColumns ="false" >
                <Columns >
                <asp:BoundField  HeaderStyle-CssClass ="grid_head" DataField ="dept_name" HeaderText ="Department Name"  />
               <asp:HyperLinkField  Text="Edit" DataNavigateUrlFields ="dept_id"  HeaderText="Manage" DataNavigateUrlFormatString ='edit_department.aspx?dept_id={0}'  >
                   <HeaderStyle CssClass="grid_head" />
               </asp:HyperLinkField>
              
               </Columns>
               
                </asp:GridView>
             </td>
          </tr>
          </table>
        
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

