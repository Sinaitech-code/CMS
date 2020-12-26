<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.accounts.accounts_view_account_details" Codebehind="view_account_details.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

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
                <asp:Label ID="lblemp" runat="server" ></asp:Label></span>
            <br />
            <span class="date">date: 
                <asp:Label ID="lblorderdate" runat="server" ></asp:Label></span>
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
        		<a href="#" class="navi_head">Accounts</a>	
              <a href="view_purchase_orders.aspx" class="side_navi">view purchase order</a>
                <a href="view_expences_status.aspx" class="side_navi">view prettyexpences</a>
                <a href="view_accounts.aspx" class="side_navi">view accounts</a>
                </div>
         <uc1:adminheader id="AdminHeader1" runat="server"></uc1:adminheader>
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                     <div id="form_head_text_area">view purchase accounts details
                         </div>
            
            </div>
            
            <div id="indent_form_heads">
                                  
            </div>
           <%-- <div id="form">--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
             
              <tr>
                <td valign="top"  Width ="100%" >
                
                    <asp:GridView ID="GridView1" runat="server" Width ="100%" AutoGenerateColumns ="false" CssClass="grid_content_1"   >
                   <Columns >
                   <asp:BoundField HeaderText ="order  id" DataField ="order_id" >
                       <HeaderStyle CssClass="grid_head" />
                   </asp:BoundField>
                   <asp:BoundField  DataField ="accepted_quantity" HeaderText ="Accepted Quantity" >
                       <HeaderStyle CssClass="grid_head" />
                   </asp:BoundField>
                    <asp:BoundField  DataField ="amount" HeaderText ="Amount" >
                        <HeaderStyle CssClass="grid_head" />
                    </asp:BoundField>
                    <asp:BoundField  DataField ="description" HeaderText ="Description" >
                        <HeaderStyle CssClass="grid_head" />
                    </asp:BoundField>
                    </Columns>
                   <AlternatingRowStyle CssClass="grid_content_2" />
                   </asp:GridView> 
                    </td> 
                    </tr>
                    
                   <tr>
                   <td>
                       <asp:Label ID="lblerr_msg" runat="server" CssClass ="errmsg" ></asp:Label>
                       <asp:Label ID="lblmessage" runat="server" CssClass ="errmsg" ></asp:Label></td></tr>
                     <tr><td align ="center"> <asp:Button ID="btnsubmit" runat="server" Text="back"  CssClass="btn" OnClick="btnsubmit_Click"  /></td></tr>
                       
                  
                </table>
         <%-- </div>--%>
        </div>
       
    </div>
        
    
  <div id="footer">
    	
    </div>
    
    </div>
    </form>
</body>
</html>
