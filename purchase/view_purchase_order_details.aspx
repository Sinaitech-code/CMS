<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.purchase.purchases_view_purchase_order_details" Codebehind="view_purchase_order_details.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="includes/css/styles.css"  type="text/css" rel="stylesheet" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
            <span class="date">date:  <asp:Label ID="lbldate" runat="server" Text="Label"></asp:Label></span>
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
                <div id="form_head_text_area">view purchase order</div>
            </div>
            
            
          <div id="form">
          <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible ="false"></asp:Label>  
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <%--<tr>
                <td class="grid_head" style="width: 213px">item name</td>
                <td width="330" class="grid_head">description</td>
                <td width="93" class="grid_head">quantity</td>
              </tr>--%>
              <tr>
                <td valign="top" class="grid_content_indent_1" >
                
                    <asp:GridView ID="GridView1" runat="server" Width ="100%" AutoGenerateColumns ="false" CssClass="grid_content_1" AllowPaging="True" OnPageIndexChanging="gridview_paging"   >
                   <Columns >
                      <asp:BoundField HeaderText ="Order id" DataField ="order_id"  >
                          <HeaderStyle CssClass="grid_head" />
                      </asp:BoundField>
                   
                      <asp:BoundField HeaderText ="Accepted Quantity" DataField ="accepted_quantity"  >
                          <HeaderStyle CssClass="grid_head" />
                      </asp:BoundField>
                       
                       <asp:BoundField HeaderText ="description" DataField ="description"  >
                           <HeaderStyle CssClass="grid_head" />
                       </asp:BoundField>
                  
                                                 
               
                  
                   
                   
                   </Columns>
                   <AlternatingRowStyle CssClass="grid_content_2" />
                    </asp:GridView> 
              
                     
                    
                  </td> 
                    </tr>
                  <%--  <tr>
                    <td align ="center" ><asp:Button ID="btnsave" runat="server" Text="Save"  CssClass ="btn" OnClick="btnsave_Click"/>
                    <asp:Button ID="btnadd" runat="server" Text="Add New"  CssClass ="btn" OnClick="btnadd_Click" />
                    </td>
                    </tr>--%>
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
