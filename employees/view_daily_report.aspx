<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.Employees_view_daily_report" Codebehind="view_daily_report.aspx.cs" %>

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
                 <a id="A18" href="view_expences_status.aspx" class="side_navi">view expenses status</a></div>
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view daily report</div>
            </div>
            
          <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td style="height: 133px"><table width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td width="184">select employee:</td>
                    <td width="574">
                        <asp:DropDownList ID="ddlempname" runat="server" CssClass="txt_box" OnSelectedIndexChanged="ddlempname_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                              </td>
                  </tr>
                  <tr>
                    <td>select project:</td>
                    <td>
                    <asp:DropDownList ID="ddlprojname" runat="server" CssClass="txt_box" AutoPostBack="True" >
                        </asp:DropDownList>
                 </td>
                  </tr>
                  <tr>
                    <td>select date:</td>
                    <td>
                        <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                       <a href="javascript:;" onclick="window.open('../calnder.aspx?textbox=txtfromdate','cal','width=210,height=190,left=220,top=180')">
      <img src="../imgs/icon_calendar.jpg" border="0"></a>
                    to
                      <asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
                     <a href="javascript:;" onclick="window.open('../calnder.aspx?textbox=txttodate','cal','width=210,height=190,left=220,top=180')">
      <img src="../imgs/icon_calendar.jpg" border="0"></a>
                    </td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnsearch" runat="server" Text="search"  CssClass="btn" OnClick="btnsearch_Click"/>
                        <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
                   </td>
                  </tr>


                </table></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
              
              <tr>
                <td class="bold_text">&nbsp;</td>
              </tr>
              <tr>
                <td style="height: 157px">
                
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td>
              <asp:GridView ID="GridView2" runat="server" width="100%" AutoGenerateColumns="False"   CssClass="grid_content_1" AllowPaging="True" OnPageIndexChanging="grid_paginging">
              <Columns>
               <asp:BoundField  HeaderText="daliy report title" DataField="report_title" >
                   <HeaderStyle CssClass="grid_head" />
                  
              </asp:BoundField>
              <asp:BoundField  HeaderText="project Name" DataField="project_name">
                  <ControlStyle CssClass="grid_head" />
                  <HeaderStyle CssClass="grid_head" />
              </asp:BoundField>
              
               <asp:BoundField  HeaderText="date" DataField="report_date">
                  <ControlStyle CssClass="grid_head" />
                  <HeaderStyle CssClass="grid_head" />
              </asp:BoundField>
             <asp:HyperLinkField  Text="View" HeaderText="view" DataNavigateUrlFields="report_id"  DataNavigateUrlFormatString='view_daily_report_details.aspx?report_id={0}'>
                 <HeaderStyle CssClass="grid_head" />
             </asp:HyperLinkField>
              <asp:HyperLinkField  Text="view" HeaderText="image" DataNavigateUrlFields="report_id"   DataNavigateUrlFormatString='view_images.aspx?report_id={0}' >
                 <HeaderStyle CssClass="grid_head" />
             </asp:HyperLinkField>
              </Columns>
                  <AlternatingRowStyle CssClass="grid_content_2" />
              
              </asp:GridView>
          
          </td>
          </tr>
          
          </table>
                               
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
