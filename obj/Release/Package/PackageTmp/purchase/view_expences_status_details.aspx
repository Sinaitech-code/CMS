<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.purchase.Employees_view_expences_status_details" Codebehind="view_expences_status_details.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View expences status details</title>
     <link href="../HR/includes/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <!-- start #main_container -->
<div id="main_container">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo" runat ="server"></div>
        <!-- end #logo -->
        
        <!-- start #login_details -->
        <div id="login_details">
        	<span class="welcome">welcome:</span> <span class="loged_name">
                <asp:Label ID="lblemp" runat="server" Text=""></asp:Label></span>
            <br />
            <span class="date">date: 
                <asp:Label ID="lbldate1" runat="server" Text=""></asp:Label></span>
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
        	    <a href="#" class="navi_head">purchase</a>
            	<a href="add_material.aspx" class="side_navi">add material</a>
                <a href="manage_materials.aspx" class="side_navi">manage material</a>
                <a href="add_material_cat.aspx" class="side_navi">add material catagory</a>
                <a href="manage_material_cat.aspx" class="side_navi">manage material catagory </a>
                <a href="view_purchase_requisition.aspx" class="side_navi">view purchase requisition</a>
                <a href="view_pending_orders.aspx" class="side_navi">view pending orders</a>
                <a href="view_completed_orders.aspx" class="side_navi">view completed orders</a>
                <a href="view_accepted_orders.aspx" class="side_navi">view accepted orders</a>
                <a href="view_rejected_orders.aspx" class="side_navi">view rejected orders</a>
                <a id="A17" href="view_expences_status.aspx" class="side_navi">view expenses</a>
                </div>
        <uc1:AdminHeader ID="AdminHeader1" runat="server" />
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view  expenses status details</div>
            </div>
            <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
            <br />expences created by :&nbsp;<asp:Label ID="lbluserid" runat="server" Text=""></asp:Label>
         <br /> status :&nbsp;<asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
            <br />status changed by :&nbsp;<asp:Label ID="lblstatus_changedby" runat="server" Text=""></asp:Label>
          <div id="form">
          
           <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td >
          <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">--%>
              <asp:GridView ID="GridView1" runat="server" CssClass="grid_content_1" width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grid_paging"   >
              <Columns>
                <asp:BoundField  HeaderText="description" DataField="description">
                  <ControlStyle CssClass="grid_head" />
                  <HeaderStyle CssClass="grid_head" />
              </asp:BoundField>
               <asp:BoundField  HeaderText="expences" DataField="expenses">
                   <HeaderStyle CssClass="grid_head" />
                  
              </asp:BoundField>
            
              </Columns>
                  <AlternatingRowStyle CssClass="grid_content_2" />
              
              </asp:GridView>
          
          <%--</table>--%>
          </td>
          </tr>
          <tr >
          <td align="center" >
              <asp:Button ID="btnback" runat="server" Text="back"  CssClass="btn" OnClick="btnback_Click" /></td>
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
</div>
    </form>
</body>
</html>
