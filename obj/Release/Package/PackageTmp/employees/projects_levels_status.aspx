<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.projects_projects_levels_status" Codebehind="projects_levels_status.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Project levels status</title>
    <link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
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
                <asp:Label ID="lblemp" runat="server" Text=""></asp:Label></span>
            <br />
            <span class="date">date:<asp:Label ID="lbldate" runat="server" Text=""></asp:Label> </span>
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
                 <a id="A18" href="view_expences_status.aspx" class="side_navi">view expenses status</a>
               </div>
        
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">project status</div>
            </div>
          
            <div id="form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><table width="100%" border="0" cellspacing="4" cellpadding="0">
                  <tr>
                    <td width="24%"><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>
                         select project:</td>
                    <td width="76%">
                        <asp:DropDownList ID="ddlprojectname" runat="server" CssClass="dropdown"  AutoPostBack="True" OnSelectedIndexChanged="ddlprojectname_SelectedIndexChanged">
                        </asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select project" ControlToValidate ="ddlprojectname"></asp:RequiredFieldValidator>                 </td>
                  </tr>
                   <tr>
                    <td width="24%">&nbsp; sub project:</td>
                    <td width="76%">
                        <asp:DropDownList ID="ddlsubproject" runat="server" CssClass="dropdown" AutoPostBack="True"  >
                        </asp:DropDownList>                  </td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnsearch" runat="server" Text="search"  CssClass="btn" OnClick="btnsearch_Click1" /></td>
                  </tr>
                  
                </table></td>
              </tr>
            
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="184" class="grid_content_2">client name:
                     
                    </td>
                    <td   width="574" class="grid_content_2">
                      <asp:Label ID="lblclient" runat="server" Text=""></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <td class="grid_content_1">project name:</td>
                    <td class="grid_content_1"> <asp:Label ID="lblprojectname" runat="server" Text=""></asp:Label></td>
                                                 
                  </tr>
                  <tr>
                  <td class="grid_content_1" style="height: 27px">subproject name:</td>
                  <td class="grid_content_1" style="height: 27px"> <asp:Label ID="lblsubprojectname" runat="server" Text=""></asp:Label></td></tr>
                   </table></td>
              </tr>
                <tr>
          <td>
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
             <td>
              <asp:GridView ID="GridView1" runat="server" CssClass="grid_content_1" width="100%"   AutoGenerateColumns="False" AllowPaging="True"  DataKeyNames="level_id">
              <Columns >
             <asp:BoundField  HeaderText ="Levels" DataField ="level_name" HeaderStyle-CssClass ="grid_head" />
           <asp:TemplateField HeaderText =" Status"  HeaderStyle-CssClass ="grid_head" >
            <ItemTemplate >
                <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSource ='<%# rblistbind() %>' DataTextField ="status_name" DataValueField ="status_id">--%>
                <asp:RadioButtonList ID="rblist1" runat="server" DataTextField ="status_name" DataValueField ="status_id">
                </asp:RadioButtonList>
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="grid_content_2" />
               </asp:GridView>
              </td>
             </tr>
       </table>
          </td>
          </tr>
           <tr>
             <td><table width="100%" border="0" cellspacing="4" cellpadding="0">
              <tr>
               <td width="24%">status changed by:<asp:Label ID="lblstatuschanged" runat="server" ></asp:Label>
               </td>
               
               <td width="76%">
                <asp:Button ID="btnsubmit" runat="server" Text="submit project status" CssClass="btn" OnClick="btnsubmit_Click"  />
                  <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
                  <p align ="center" ><asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label></p>
                </td>
               </tr>
               </table></td>
              </tr>
            </table>
          </div>
      </div>
    </div>
    <div id="footer">
    &nbsp;
    </div>
    </div>
    
    </div>
    </form>
</body>
</html>
