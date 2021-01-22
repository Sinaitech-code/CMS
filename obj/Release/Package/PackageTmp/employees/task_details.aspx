<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.Employees_task_details" Codebehind="task_details.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task details</title>
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
                <asp:Label ID="lblemp" runat="server" ></asp:Label></span>
            <br />
            <span class="date">date
                <asp:Label ID="lbldate1" runat="server" ></asp:Label></span>
        </div>
        <!-- end #login_details -->
        
    </div>
    <!-- end #header -->
    
    <!-- start #header_bg -->
    <div id="header_bg">
    	<a href="../Default.aspx" class="logout">logout</a>
    </div>
    <!-- end #header_bg -->
    
    <div id="content_holder">
    	<div id="left_navi_holder">
        	<div class="side_navi_gap">&nbsp;</div>
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
                <a id="A16" href="daily_report_expencess.aspx" class="side_navi" runat ="server"> pretty expenses</a>
              <a id="A17" href="view_expences.aspx" class="side_navi">view pretty expenses</a>
                 <a id="A18" href="view_expences_status.aspx" class="side_navi">view expenses status</a></div>
        
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view task details</div>
            </div>
            
          <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="184" class="grid_content_2">task title:</td>
                <td width="574" class="grid_content_2"> 
                <asp:Label ID="lbltasktitle" runat="server" Text="" ></asp:Label></td>
              </tr>
              <tr>
                <td class="grid_content_1" style="height: 27px">project:</td>
                <td class="grid_content_1" style="height: 27px"> <asp:Label ID="lblproj_client_name" runat="server" Text="" >  </asp:Label>
               </td>
              </tr>
              <tr>
                <td class="grid_content_2">task created date:</td>
                <td class="grid_content_2"> <asp:Label ID="lbldate" runat="server" Text="" ></asp:Label></td>
              </tr>
              <tr>
                <td class="grid_content_1">task created by:</td>
                <td class="grid_content_1"> <asp:Label ID="lblemp_name" runat="server" Text="" ></asp:Label>
                </td>
              </tr>
              <tr>
                <td class="grid_content_2" style="height: 27px">description:</td>
                <td class="grid_content_2" style="height: 27px"> <asp:Label ID="lbldesc" runat="server" Text="" ></asp:Label> </td>
              </tr>
              <tr>
                <td class="grid_content_1">progress:</td>
                <td class="grid_content_1">
                
                  
                    <asp:RadioButtonList ID="rbtnprogress" runat="server">
                     </asp:RadioButtonList>
                  </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td><input name="button" type="submit" class="btn" id="btnsubmit" value="submit"  runat ="server" onserverclick="btnsubmit_ServerClick"/>
                <input name="button2" type="submit" class="btn" id="btnback" value="back"  runat ="server" onserverclick="btnback_ServerClick" />
                <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
                <asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
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
