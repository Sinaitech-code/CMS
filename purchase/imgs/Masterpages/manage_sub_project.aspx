<%@ Page Language="C#" AutoEventWireup="true" Inherits="Projects_manage_sub_project" Codebehind="manage_sub_project.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
<!--<title> - CMS</title>-->
<link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>

<body>
<form id="form14" runat ="server" >
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
                <div id="form_head_text_area">manage sub projects</div>
            </div>
            
          <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              
              <tr>
              <td style="height: 311px">
               
              <asp:GridView ID="GridView1" runat="server" width="100%"  AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridview_pageindex"  >
              <Columns>
              
               <asp:BoundField  HeaderText=" Sub Project Name" DataField="sub_project_name" HeaderStyle-CssClass="grid_head">
                  
                  
              </asp:BoundField>
               
             <%-- <asp:BoundField  HeaderText="Project ID" DataField="project_id" HeaderStyle-CssClass="grid_head">
                  <ControlStyle CssClass="grid_head" />
                  <HeaderStyle CssClass="grid_head" />
              </asp:BoundField>--%>
              
             <asp:HyperLinkField  Text="Edit" DataNavigateUrlFields ="sub_project_id"  HeaderText="Manage" DataNavigateUrlFormatString ='edit_sub_project.aspx?sub_project_id={0}'  >
                 <HeaderStyle CssClass="grid_head" />
             </asp:HyperLinkField>
              </Columns>
                 <AlternatingRowStyle CssClass="grid_content_1" />
             </asp:GridView>
            
              </td>
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
