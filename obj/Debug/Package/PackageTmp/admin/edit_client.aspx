<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.admin.admin_edit_client" Codebehind="edit_client.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit client</title>
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
                <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></span>
            <br />
            <span class="date">date: 
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
      <a href="#" class="navi_head">Admin</a>
      <a href="add_client.aspx" class="side_navi">add client</a>
      <a href="add_admin.aspx" class="side_navi">add admin</a>
      <a href="add_department.aspx" class="side_navi">add department</a>
      <a href="add_emp_grade.aspx" class="side_navi">add employee grade</a>
       <a href="assign_modules_to_admin.aspx" class="side_navi">assign modules to admin</a>
      <a href="manage_client.aspx" class="side_navi">manage clients</a>
      <a href="manage_department.aspx" class="side_navi">manage department</a>
      <a href="manage_admin.aspx" class="side_navi">manage admin</a>
      <a href="manage_emp_grade.aspx" class="side_navi">manage employee grade</a>
       <a href="user_accs_permissions.aspx" class="side_navi">user permissions</a>
      <a href="#" class="navi_head">Employee</a>
      <a href="view_pending_tasks.aspx" class="side_navi">view pending tasks</a>
      <a href="virew_underprocess_tasks.aspx" class="side_navi">view underprocess tasks</a>
      <a href="view_completed_tasks1.aspx" class="side_navi">view completed tasks</a>
      <a href="view_cars.aspx" class="side_navi">view cars</a>
      <a href="view_expences_status.aspx" class="side_navi">view expenses status</a>
       <a href="view_daily_report.aspx" class="side_navi">view emp daily report</a>
      <a href="#" class="navi_head">Projects</a>
       <a href="view_underprocess_project_status.aspx" class="side_navi">view under process projects</a>
       <a href="view_pending_projects.aspx" class="side_navi">view pending projects</a>
        <a href="view_completed_projects.aspx" class="side_navi">view completed projects</a>
     </div>
         <uc1:adminheader id="AdminHeader1" runat="server"></uc1:adminheader>
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">edit client</div>
            </div>
           <div id="form">
            	
                <p><label>Client Id:</label><asp:TextBox ID="txtclientid" runat="server" CssClass="txt_box"  ReadOnly="True"></asp:TextBox></p>
                <p><label><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>Client Name:</label> <asp:TextBox ID="txtclientname" runat="server" CssClass="txt_box"></asp:TextBox>
                <asp:Label ID="lblcheckavaliable" runat="server" Text="" CssClass ="errmsg"></asp:Label>
                
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name should not be empty" ControlToValidate="txtclientname"></asp:RequiredFieldValidator>
                 
                </p>
               
               
                <p><label><asp:label id="Label7" runat="server"  Text="*"  ForeColor="red"></asp:label> Address1:</label> 
                <asp:TextBox ID="txtaddress1" runat="server" CssClass="txt_box"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="enter address" ControlToValidate="txtaddress1"></asp:RequiredFieldValidator>
                </p>
                <p><label> Address2:</label> 
                <asp:TextBox ID="txtaddress2" runat="server" CssClass="txt_box"></asp:TextBox>
                </p>
               
               
                <p><label>Contact Person:</label> 
                <asp:TextBox ID="txtcperson" runat="server" CssClass="txt_box"></asp:TextBox>
                </p>
                <p><label>City:</label> 
                <asp:TextBox ID="txtcity" runat="server" CssClass="txt_box"></asp:TextBox>
                </p>
                <p><label>State:</label> 
                <asp:TextBox ID="txtstate" runat="server" CssClass="txt_box"></asp:TextBox>
                </p>
               
                <p><label>mobile:</label> 
                    <asp:TextBox ID="txtphone1" runat="server" CssClass="txt_box" ></asp:TextBox>
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator4" runat="server" ErrorMessage="enter  mobile number" ControlToValidate="txtphone1" ValidationExpression="^[\d\-]{10,11}$"></asp:RegularExpressionValidator>
                    </p>
                    <p><label>Phone2:</label>  
                    <asp:TextBox ID="txtphone2" runat="server" CssClass="txt_box" ></asp:TextBox>
                  
                    </p>
                <p><label>Fax:</label> <asp:TextBox ID="txtfax" runat="server" CssClass="txt_box"></asp:TextBox></p>
                <p><label>Website:</label><asp:TextBox ID="txtwebsite" runat="server" CssClass="txt_box"></asp:TextBox> <%--<input name="textfield" type="text" class="txt_box" id="txtwebsite" runat="server" />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Website Name" ControlToValidate="txtwebsite" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                </p>
                <p><label>Email:</label> 
                <asp:TextBox ID="txtemail" runat="server" CssClass="txt_box"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Email Address" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></p>
                <p><label>&nbsp;</label>
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnsubmit_Click" />
                    <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
                    <asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible="False"></asp:Label>
                </p>
                 </div>
              
          </div>
       
        </div>
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
    

<!-- end #main_container -->
    </form>
</body>
</html>
