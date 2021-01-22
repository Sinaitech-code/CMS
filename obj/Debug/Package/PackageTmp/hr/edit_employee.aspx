<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.HR.HR_edit_employee" Codebehind="edit_employee.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit employee</title>
     <link href="includes/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" method="post">
   
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
    	<a id="A1" href="../Default.aspx" class="logout" runat="server">logout</a>
    </div>
    <!-- end #header_bg -->
    
    <div id="content_holder">
    	<div id="left_navi_holder">
        	<div class="side_navi_gap">&nbsp;</div>
        <a href="#" class="navi_head">HR</a>
            	
               
                <a href="create_employee .aspx" class="side_navi">add  employee</a>
                <a href="manage _employee.aspx" class="side_navi">manage employee</a> 
                <a id="A17" href="user_access_permissions_hr.aspx" class="side_navi">User Permissions</a>      
   </div>
       <uc1:AdminHeader id="AdminHeader1" runat="server">
        </uc1:AdminHeader>
        <div id="form_area">
          
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">edit employee details</div>
            </div>
            
            <div id="form">
               
                <p><label>select department name:</label>
                	
                    <asp:DropDownList ID="ddldept_name" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
              </p>
              <p>
                <label>select grade:</label>
                	
               	    <asp:DropDownList ID="ddlemp_grade" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
              </p>
               <p>
                <label>select emp type:</label>
                
               	    <asp:DropDownList ID="ddlemp_type" runat="server" CssClass="dropdown">
               	   
                    </asp:DropDownList>
              </p>
            <p><label>employee ID:</label> 
                <asp:TextBox ID="txtempid" runat="server" CssClass="txt_box" ReadOnly="True"></asp:TextBox></p>      
              
                <p><label><asp:label id="Label11" runat="server"  Text="*"  ForeColor="red"></asp:label>first name:</label> 
              
                    <asp:TextBox ID="txtempf_name" runat="server" CssClass ="txt_box"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvemp_fname" runat="server" ErrorMessage="first name should not be empty" ControlToValidate="txtempf_name"></asp:RequiredFieldValidator>
                    </p>
                <p><label>middle name:</label> 
               
                    <asp:TextBox ID="txtempm_name" runat="server" CssClass ="txt_box"></asp:TextBox>
                  
                    </p>
                <p><label><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>last name:</label> 
                    <asp:TextBox ID="txtempl_name" runat="server" CssClass ="txt_box"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvempm_name" runat="server" ErrorMessage="last name should not be empty" ControlToValidate="txtempl_name"></asp:RequiredFieldValidator>
                    </p>
                <p><label>gender:</label>
                
                    <asp:RadioButtonList ID="rbtngender" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </p>
              
                <p id="P1" runat="server"><label><asp:label id="Label2" runat="server"  Text="*"  ForeColor="red"></asp:label>qualification:</label> 
               
                <asp:TextBox ID="txtqualif" runat="server" CssClass ="txt_box"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter qualification" ControlToValidate="txtqualif"></asp:RequiredFieldValidator>
                </p>
                <p><label><asp:label id="Label3" runat="server"  Text="*"  ForeColor="red"></asp:label>experiance:</label>
                 <asp:TextBox ID="txtexp" runat="server" CssClass ="txt_box"></asp:TextBox>
                 <asp:RequiredFieldValidator
                     ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter experience" ControlToValidate="txtexp"></asp:RequiredFieldValidator>
                 </p>
                <p>
                 <label>joining date:</label> 
                 <asp:TextBox ID="txtjoin_date" runat="server" CssClass ="txt_box"></asp:TextBox>
                <a href="javascript:;" onclick="window.open('../calnder.aspx?textbox=txtjoin_date','cal','width=210,height=190,left=220,top=180')">
                <img src="../imgs/icon_calendar.jpg" border="0"></a> </p>
                 <p><label><asp:label id="Label4" runat="server"  Text="*"  ForeColor="red"></asp:label>address1:</label> 
               
                <asp:TextBox ID="txtaddress1" runat="server" CssClass ="txt_box"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="enter address" ControlToValidate="txtaddress1"></asp:RequiredFieldValidator>
                </p>
                 <p ><label>address2:</label> 
               
                <asp:TextBox ID="txtaddress2" runat="server" CssClass ="txt_box"></asp:TextBox></p>
                 <p id="P4" runat="server"><label><asp:label id="Label5" runat="server"  Text="*"  ForeColor="red"></asp:label>city:</label> 
               
                <asp:TextBox ID="txtcity" runat="server" CssClass ="txt_box"></asp:TextBox>
                 <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="enter city" ControlToValidate="txtcity"></asp:RequiredFieldValidator>
                </p>
                 <p id="P5" runat="server"><label><asp:label id="Label6" runat="server"  Text="*"  ForeColor="red"></asp:label>state:</label> 
               
                <asp:TextBox ID="txtstate" runat="server" CssClass ="txt_box"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="enter state" ControlToValidate="txtstate"></asp:RequiredFieldValidator>
                </p>
                 <p id="P6" runat="server"><label>mobile</label> 
               
                <asp:TextBox ID="txtphone1" runat="server" CssClass ="txt_box"></asp:TextBox>
                 <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ErrorMessage="enter  mobile number" ControlToValidate="txtphone1" ValidationExpression="^[\d\-]{10,11}$"></asp:RegularExpressionValidator>           
                </p>
                 
                 <p id="P7" runat="server"><label>phone</label> 
               
                <asp:TextBox ID="txtphone2" runat="server" CssClass ="txt_box"></asp:TextBox>
                 <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator2" runat="server" ErrorMessage="enter phone number" ControlToValidate="txtphone2" ValidationExpression="^[\d\-]{10,13}$"></asp:RegularExpressionValidator>
                </p>
                 <p id="P8" runat="server"><label>email</label> 
               
                <asp:TextBox ID="txtemail" runat="server" CssClass ="txt_box"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Email Address" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </p>
                <p><label>&nbsp;</label> 
                    <asp:Button ID="btnsave" runat="server" Text="save" CssClass="btn" OnClick="btnsave_Click" />
                    <asp:Label ID="lblerr_msg" runat="server"  CssClass ="errmsg" Visible="false"></asp:Label>  
                </p>
                <p  align ="center" ><asp:Label ID="lblmessage" runat="server"  CssClass ="errmsg" Visible="false"></asp:Label></p>
             
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
