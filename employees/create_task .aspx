<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.Employees_create_task_" Codebehind="create_task .aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../HR/includes/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" method ="post" >
   
<!-- start #main_container -->
<div id="main_container">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo" runat ="server"></div>
        <!-- end #logo -->
        
        <!-- start #login_details -->
        <div id="login_details" runat ="server">
       <span id="Span1" class="welcome" runat ="server">welcome:</span> <span id="Span2" class="loged_name" runat ="server">
                <asp:Label ID="lblemp" runat="server" Text="Label"></asp:Label></span>
            <br />
            date:<span class="date">
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
                 <a id="A18" href="view_expences_status.aspx" class="side_navi">view expenses status</a></div> 
        <div id="form_area" runat ="server">
        	<div id="form_head" runat ="server">
            	<div id="left_corner" runat ="server">&nbsp;</div>                
                <div id="right_corner" runat ="server">&nbsp;</div>
                <div id="form_head_text_area" runat ="server">create task</div>
            </div>
            
          <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="grid_content_1"><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>assign task to:</td>
                <td class="grid_content_1">
                <asp:ListBox ID="listemp" runat="server" SelectionMode="Multiple" CssClass="listbox" AutoPostBack="true" ></asp:ListBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="select employees" ControlToValidate ="listemp"></asp:RequiredFieldValidator>
                </td>
              </tr>
             
              <tr>
                <td width="184" class="grid_content_2"><asp:label id="Label2" runat="server"  Text="*"  ForeColor="red"></asp:label>task title:</td>
                <td width="574" class="grid_content_2">
                    <asp:TextBox ID="txttasktitle" runat="server" CssClass="txt_box"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_title" runat="server" ErrorMessage="Task title should not be empty" ControlToValidate="txttasktitle"></asp:RequiredFieldValidator>
               </td>
              </tr>
              <tr>
                <td class="grid_content_1"><asp:label id="Label3" runat="server"  Text="*"  ForeColor="red"></asp:label>project:</td>
                <td class="grid_content_1">
                 <asp:DropDownList ID="ddlproject" runat="server" CssClass="txt_box" AutoPostBack="True">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator_projid" runat="server"
                     ErrorMessage="Select Project" ControlToValidate="ddlproject"></asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr>
                <td class="grid_content_1">description:</td>
                <td class="grid_content_1">
                    <asp:TextBox ID="txtdescription" runat="server" CssClass="txt_box" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_desc" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtdescription"></asp:RequiredFieldValidator></td>
               </tr>
               <tr>
                <td class="grid_content_1">task created date:</td>
                <td class="grid_content_1">
                    <asp:TextBox ID="txtdate" runat="server" CssClass="txt_box"></asp:TextBox>
                                
                    </td>
               </tr>
              <tr>
                <td class="grid_content_2">priority:</td>
                <td class="grid_content_2">
                    <asp:RadioButtonList ID="rbtnpriority" runat="server">
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    </asp:RadioButtonList>
                
               </td>
              </tr>
              <tr>
                <td class="grid_content_1">&nbsp;</td>
                <td class="grid_content_1">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit"  CssClass="btn" OnClick="btnsubmit_Click"/>
                     <asp:Label ID="lblerr_msg" runat="server" CssClass ="errmsg" Visible="False"></asp:Label>
                     <p align ="center" > <asp:Label ID="lblmessage" runat="server" CssClass ="errmsg" Visible="False"></asp:Label></p> 
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
