<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.Employees_view_daily_report_details" Codebehind="view_daily_report_details.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View daily report details</title>
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
            <span class="date">date: 
                <asp:Label ID="lbldate1" runat="server" Text="Label"></asp:Label></span>
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
                 <a id="A19" href="view_expences_status.aspx" class="side_navi">view expenses status</a></div>
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view daily report details</div>
            </div>
            
            
          <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td class="bold_text">Name: 
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
              </tr>
              
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="184" class="grid_content_2">client name:</td>
                    <td width="574" class="grid_content_2">
                        <asp:Label ID="lblclientname" runat="server" Text="Label"></asp:Label>
                     </td> 
                  </tr>
                  <tr>
                    <td class="grid_content_indent_1">project name:</td>
                    <td class="grid_content_indent_1">  <asp:Label ID="lblproj_name" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_2">title:</td>
                    <td class="grid_content_indent_2">  <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_1">date:</td>
                    <td class="grid_content_indent_1">  <asp:Label ID="lbldate" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_2">description:</td>
                    <td class="grid_content_indent_2">  <asp:Label ID="lbldescription" runat="server" Text="Label"></asp:Label> </td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_1">resources used:</td>
                    <td class="grid_content_indent_1">  <asp:Label ID="lblresourcesused" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_2">no of workers:</td>
                    <td class="grid_content_indent_2">  <asp:Label ID="lblnoofworkers" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_1">money paid for workers:</td>
                    <td class="grid_content_indent_1">  <asp:Label ID="lblmoneypaid" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="grid_content_indent_2">remarks:</td>
                    <td class="grid_content_indent_2">  <asp:Label ID="lblremarks" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                    
                </table></td>
              </tr>
              <tr>
                <td>
                
              <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="send_car.aspx">Send CAR</asp:HyperLink>  
                
                <a id="A18" href="view_daily_report.aspx" class="grid_delete align_right" runat ="server">back</a>
                <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label></td>
              </tr>
            </table>
          </div>
      </div>
    </div>
    
    
    <div id="footer">
    	
    </div>
    
</div>
<!-- end #main_container -->
    </form>
</body>
</html>
