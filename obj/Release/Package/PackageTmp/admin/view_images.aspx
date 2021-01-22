<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.admin.admin_view_images" Codebehind="view_images.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View Images</title>
    <link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    
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
                <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></span>
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
      <a href="view_expences_status.aspx" class="side_navi">view expenses status</a>
       <a href="view_daily_report.aspx" class="side_navi">view emp daily report</a>
      <a href="#" class="navi_head">Projects</a>
       <a href="view_underprocess_project_status.aspx" class="side_navi">view under process projects</a>
       <a href="view_pending_projects.aspx" class="side_navi">view pending projects</a>
        <a href="view_completed_projects.aspx" class="side_navi">view completed projects</a>
        
                    
     </div>
        <uc1:AdminHeader ID="AdminHeader1" runat="server" />
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view images</div>
            </div>
             <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
               <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td>
         
              <asp:GridView ID="GridView1" runat="server" width="100%" AutoGenerateColumns="False"  CssClass="grid_content_1" AllowPaging="True" OnPageIndexChanging="gridview_pageindexchange" PageSize="5" >
              <Columns>
               <asp:BoundField  HeaderText="report id" DataField="report_id">
                   <HeaderStyle CssClass="grid_head" />
                  
              </asp:BoundField>
              <asp:BoundField  HeaderText="image id" DataField="report_image_id">
                   <HeaderStyle CssClass="grid_head" />
                  
              </asp:BoundField>
              <asp:TemplateField HeaderText="image1">
              
              <ItemTemplate>
            
             <a href ="javascript:;"onclick="window.open('image.aspx?report_id=<%#Eval("report_image_name1") %>','cal','width=400,height=200,left=650,top=450')">     <asp:Image ID="Image1" runat="server" Height="50" Width="50" ImageUrl='<%#"../Employees/imagefile/"+Eval("report_image_name1")%>'/></a>
              </ItemTemplate>
                  <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image2">
              
              <ItemTemplate>
             <asp:Image ID="img2" runat="server"  Height="50" Width="50" ImageUrl='<%#"../Employees/imagefile/"+Eval("report_image_name2")%>' />
             
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image3">
              
              <ItemTemplate>
              <asp:Image ID="img3" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"../Employees/imagefile/"+Eval("report_image_name3")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image4">
              
              <ItemTemplate>
              <asp:Image ID="img4" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"../Employees/imagefile/"+Eval("report_image_name4")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image5">
              
              <ItemTemplate>
              <asp:Image ID="img5" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"../Employees/imagefile/"+Eval("report_image_name5")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
       
              </Columns>
                  <AlternatingRowStyle CssClass="grid_content_2" />
              
              </asp:GridView>
             </td>
          </tr>
          <tr>
          <td align="center">
              <asp:Button ID="btnback" runat="server" Text="back" CssClass="btn" OnClick="btnback_Click" />
          </td>
          </tr>
          
          </table>
          
    
</div>
  </div>     
    </div>
    </form>
</body>
</html>
