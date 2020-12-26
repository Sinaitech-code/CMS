<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.accounts.Employees_view_expences_status" Codebehind="view_expences_status.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
        		<a href="#" class="navi_head">Accounts</a>	
              <a href="view_purchase_orders.aspx" class="side_navi">view purchase order</a>
                <a href="view_expences_status.aspx" class="side_navi">view prettyexpences</a>
                <a href="view_accounts.aspx" class="side_navi">view accounts</a>
                
                </div>
        <uc1:adminheader id="AdminHeader2" runat="server"></uc1:adminheader>
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">view expenses status</div>
            </div>
            <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
            
          <div id="form">
          
           <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td >
          <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">--%>
              <asp:GridView ID="GridView1" runat="server" CssClass="grid_content_1" width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grid_paging"   >
              <Columns>
              
              <asp:BoundField  HeaderText="employee name" DataField="user_id">
                  <ControlStyle CssClass="grid_head" />
                  <HeaderStyle CssClass="grid_head" />
              </asp:BoundField>
            <asp:BoundField  HeaderText="date" DataField="date">
                  <ControlStyle CssClass="grid_head" />
                  <HeaderStyle CssClass="grid_head" />
              </asp:BoundField>
               
           <asp:HyperLinkField  Text="view" DataNavigateUrlFields ="sno"  HeaderText="Manage" DataNavigateUrlFormatString ='view_expences_status_details.aspx?sno={0}'  >
                   <HeaderStyle CssClass="grid_head" />
               </asp:HyperLinkField>
              </Columns>
                  <AlternatingRowStyle CssClass="grid_content_2" />
              
              </asp:GridView>
          
          <%--</table>--%>
          </td>
          </tr>
          
          </table>
         
          </div>
      </div>
        
    </div>
    
    
    <div id="footer">
    	&nbsp;
    &nbsp;</div>
    
</div></div>
<!-- end #main_container -->
    </form>
</body>
</html>
