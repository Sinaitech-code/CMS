<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.admin_view_images" Codebehind="view_images.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
            <span class="date">
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
        		<a id="A2" href="#" class="navi_head" runat ="server">Employees</a>
            	<a id="A3" href="view_task.aspx" class="side_navi" runat ="server">view tasks</a>
                <a id="A4" href="create_task .aspx" class="side_navi" runat ="server">create task</a>
                <a id="A5" href="view_task_status.aspx" class="side_navi" runat ="server"> view task status</a> 
                <a id="A6" href="create_daily_report.aspx" class="side_navi" runat ="server">create daily report</a>
                <a id="A7" href="view_daily_report.aspx" class="side_navi" runat ="server">view daily report</a>          
                <a id="A8" href="#" class="navi_head" runat ="server">projects</a>
                <a id="A9" href="view_cars.aspx" class="side_navi" runat ="server">view cars</a>
                <a id="A10" href="view_car_reply.aspx" class="side_navi" runat ="server"> view car reply</a>
                <a id="A11" href="projects_levels_status.aspx" class="side_navi"> project levels status</a>
                <a id="A12" href="view_project_status.aspx" class="side_navi" runat ="server"> view project status</a> 
                <a id="A13" href="view_orders.aspx" class="side_navi" runat ="server"> view orders</a> 
                <a id="A14" href="purchase_requisition.aspx" class="side_navi" runat ="server"> purchase requisition</a>  
                <a id="A15" href="view purchase_requisition.aspx" class="side_navi" runat ="server"> view purchase requisition</a> 
                <a id="A16" href="pretty_expencess.aspx" class="side_navi" runat ="server"> pretty expenses</a>
               <a id="A17" href="view_expences.aspx" class="side_navi">view pretty expenses</a>
                 <a id="A18" href="view_expences_status.aspx" class="side_navi">view expenses status</a></div>
      
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view images</div>
            </div>
             <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
            
          <%--<div id="form">--%>
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
            
                  <asp:Image ID="Image1" runat="server" Height="50" Width="50" ImageUrl='<%#"imagefile/"+Eval("report_image_name1")%>'/>
              </ItemTemplate>
                  <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image2">
              
              <ItemTemplate>
              <asp:Image ID="img2" runat="server"  Height="50" Width="50" ImageUrl='<%#"imagefile/"+Eval("report_image_name2")%>' />
             
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image3">
              
              <ItemTemplate>
              <asp:Image ID="img3" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"imagefile/"+Eval("report_image_name3")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image4">
              
              <ItemTemplate>
              <asp:Image ID="img4" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"imagefile/"+Eval("report_image_name4")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image5">
              
              <ItemTemplate>
              <asp:Image ID="img5" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"imagefile/"+Eval("report_image_name5")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
       
              </Columns>
                  <AlternatingRowStyle CssClass="grid_content_2" />
              
              </asp:GridView>
             </td>
          </tr>
          <tr>
          <td>
          
          </td>
                    
          </tr>
          
          </table>
          
    
</div>
    </div>
    </div>
    </form>
</body>
</html>
