<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.Employees_goods_recepit_note" Codebehind="goods_recepit_note.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                <div id="form_head_text_area">goods receipt note</div>
            </div>
            
             
            
            <div id="indent_form_heads">
            	<h6>EMP NAME:
                    <asp:Label ID="lblempname" runat="server" ></asp:Label></h6>
            	<span class="form_no">Order No :
                    <asp:Label ID="lblformno" runat="server" ></asp:Label></span>
                     <span  class ="requistion_id">receipt id:<asp:Label ID="lblreceiptid" runat="server" ></asp:Label>     </span>
                    <span class="form_date">Order date:<asp:Label
                        ID="lbldate" runat="server" ></asp:Label></span>
                      
            </div>
            	 
             
            
         
                      
          <div id="form">
          <p align ="center" >
          <asp:Label ID="lblerr_msg" runat="server" CssClass="errmsg"  Visible="False"></asp:Label></p>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
             
              <tr>
                <td valign="top" class="grid_content_indent_1"   >
                 <asp:GridView ID="GridView1" runat="server" Width ="100%" AutoGenerateColumns ="false" CssClass="grid_content_1"  PageSize="2" DataKeyNames ="material_id">
                   <Columns >
                 <asp:BoundField HeaderText ="Item Name" DataField ="material_name"  HeaderStyle-CssClass ="grid_head"  />
                  <asp:BoundField HeaderText ="requested quantity" DataField ="quantity"  HeaderStyle-CssClass ="grid_head"  />
                  <asp:BoundField HeaderText ="Received Quantity" DataField ="accepted_quantity" HeaderStyle-CssClass ="grid_head"  />
                   <asp:TemplateField  HeaderText ="Rejected Quantity"  >
                   <ItemTemplate >
                     <asp:TextBox ID="txtrejected_qty" runat="server" CssClass ="text_area_indent1"  ></asp:TextBox>
                       </ItemTemplate>
                       <HeaderStyle CssClass="grid_head" />
                   
                   </asp:TemplateField>
                    <asp:TemplateField  HeaderText ="Description"  >
                   <ItemTemplate >
                     <asp:TextBox ID="txtdesc" runat="server" CssClass ="text_area_indent1" TextMode ="MultiLine"  ></asp:TextBox>
                       </ItemTemplate>
                       <HeaderStyle CssClass="grid_head" />
                   
                   </asp:TemplateField>
                   
                    <%--<asp:TemplateField  HeaderText ="Status"  >
                   <ItemTemplate >
                        <asp:RadioButtonList ID="rbtnstatus" runat="server" DataSource ='<%# rblistbind() %>' DataTextField ="status_name" DataValueField ="status_id" RepeatDirection ="Horizontal" >
                       </asp:RadioButtonList>
                       </ItemTemplate>
                       <HeaderStyle CssClass="grid_head" />
                   
                   </asp:TemplateField>--%>
                   </Columns>
                   <AlternatingRowStyle CssClass="grid_content_2" />
                    </asp:GridView> 
                  
                    
                  </td> 
                  
                    </tr>
                    <tr>
                    <td style="height: 53px">
                        <asp:RadioButtonList ID="rbtnstatus" runat="server" >
                       </asp:RadioButtonList>
                    </td>
                    </tr>
                   <tr>
                   <td >
                   
                       <asp:Button ID="btnsave" runat="server" Text="save" CssClass="btn" OnClick="btnsave_Click" />
                       
                           <asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible ="false" ></asp:Label></td>
                   </tr>
                </table>
          </div>
        </div>
    </div>
    
  <div id="footer">
    	
    </div>
    
    
    
    </div>
    </form>
</body>
</html>
