<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.Employees.Employees_create_daily_report" Codebehind="create_daily_report.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create daily reply</title>
    <link href="includes/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <!-- start #main_container -->
        <div id="main_container">
            <!-- start #header -->
            <div id="header">
                <!-- start #logo -->
                <div id="logo" runat="server">
                    </div>
                <!-- end #logo -->
                <!-- start #login_details -->
                <div id="login_details" runat="server">
                    <span id="Span1" class="welcome" runat="server">welcome:</span> <span class="loged_name">
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
                        <div id="left_corner">
                            &nbsp;</div>
                        <div id="right_corner">
                            &nbsp;</div>
                        <div id="form_head_text_area" runat="server">
                            create daily report</div>
                    </div>
                    <div id="form">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="184" class="grid_content_2"><asp:label id="Label7" runat="server"  Text="*"  ForeColor="red"></asp:label>
                                    client name:</td>
                                <td class="grid_content_2" style="width: 717px">
                                    <asp:DropDownList ID="ddlclient1" runat="server" CssClass="txt_box" AutoPostBack ="true" OnSelectedIndexChanged="ddlclient1_selectedchanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select client" ControlToValidate ="ddlclient1"></asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_1"><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>
                                    project name:</td>
                                <td class="grid_content_indent_1" style="width: 717px">
                                    <asp:DropDownList ID="ddlprojectname" runat="server" CssClass="txt_box" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select project" ControlToValidate ="ddlprojectname"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_2">
                                    title:</td>
                                <td class="grid_content_indent_2" style="width: 717px">
                                    <input name="textfield22" type="text" class="txt_box_other" id="txttitle" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_1">
                                    date:</td>
                                <td class="grid_content_indent_1" style="width: 717px">
                                    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_2">
                                    description:</td>
                                <td class="grid_content_indent_2" style="width: 717px">
                                    <textarea name="textarea" cols="45" rows="5" class="text_area_indent" id="txtdesc"
                                        runat="server"></textarea></td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_1">
                                    resources used:</td>
                                <td class="grid_content_indent_1" style="width: 717px">
                                    <textarea name="textarea2" cols="45" rows="5" class="text_area_indent" id="txtres_used"
                                        runat="server"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_2">
                                    no of workers:</td>
                                <td class="grid_content_indent_2" style="width: 717px">
                                    <textarea name="textarea3" cols="45" rows="5" class="text_area_indent" id="txtno_workers"
                                        runat="server"></textarea></td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_2" style="height: 86px">
                                    money paid:</td>
                                <td class="grid_content_indent_2" style="width: 717px; height: 86px">
                                    <textarea name="textarea3" cols="45" rows="5" class="text_area_indent" id="txtmoneypaid"
                                        runat="server"></textarea></td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_1">
                                    remarks:</td>
                                <td class="grid_content_indent_1" style="width: 717px">
                                    <textarea name="textarea4" cols="45" rows="5" class="text_area_indent" id="txtremarks"
                                        runat="server"></textarea>
                                </td>
                            </tr>
                         <tr>
                <td class="grid_content_indent_2">add image 1:</td>
                <td class="grid_content_indent_2">
                
                           <asp:fileupload id="fileupload1" runat="server"  cssclass="fileupload"/></td>
              </tr>
                 
                           <tr>
                <td class="grid_content_indent_1">add image 2:</td>
                <td class="grid_content_indent_1">
                           <asp:fileupload id="fileupload2" runat="server"  cssclass="fileupload"/></td>
              </tr>
                         
                           <tr>
                <td class="grid_content_indent_2">add image 3:</td>
                <td class="grid_content_indent_2">
                          <asp:fileupload id="fileupload3" runat="server"  cssclass="fileupload"/></td>
              </tr>
                          
                            <tr>
                                <td class="grid_content_indent_1">
                                    add image 4:</td>
                                <td class="grid_content_indent_1">
                                   
                                   <asp:fileupload id="fileupload4" runat="server"  cssclass="fileupload"/></td>
              </tr>
         
            <tr>
                <td class="grid_content_indent_2">add image 5:</td>
                <td class="grid_content_indent_2">
                                    <asp:FileUpload ID="fileupload5" runat="server" CssClass="fileupload" /></td>
                            </tr>
                            <tr>
                                <td class="grid_content_indent_2">
                                    visible to client:</td>
                                <td class="grid_content_indent_2">
                                    <asp:RadioButtonList ID="rbtnvisible5" runat="server">
                                        <asp:ListItem> yes</asp:ListItem>
                                        <asp:ListItem>no</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        
                          
                            
                            <tr>
                                <td class="grid_content_indent_1">
                                
                                </td>
                                <td class="grid_content_indent_1">
                                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" OnClick="Button1_Click" />
                                    <asp:Label ID="lblerr_msg" runat="server" CssClass ="errmsg" Visible="False"></asp:Label>
                                
                                <p align ="center" > <asp:Label ID="lblmessage" runat="server" CssClass ="errmsg" Visible="False"></asp:Label></p></td>
                                
                                
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
