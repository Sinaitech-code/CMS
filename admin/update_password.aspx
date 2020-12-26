<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.admin.HR_update_password" Codebehind="update_password.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="includes/css/styles.css" rel="stylesheet" type="text/css" />
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
                <asp:Label ID="lblemp" runat="server" Text=""></asp:Label></span>
            <br />
            <span class="date">date:
                <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></span>
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
    	
          <uc1:AdminHeader ID="AdminHeader1" runat="server" />
        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
                <div id="form_head_text_area">Change password</div>
          </div>
             
            <div id="form">
            	 <p>
                 <label>username:</label>
                 <asp:TextBox ID="txtuname" runat="server" CssClass ="txt_box" ReadOnly="True"></asp:TextBox>
                </p>
               <%-- <p>
                <label>oldpassword :</label>
                <asp:TextBox ID="txtoldpwd" runat="server" CssClass ="txt_box" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter old password" ControlToValidate="txtoldpwd"></asp:RequiredFieldValidator>
                </p>--%>
                <p><label>newpassword :</label>
                <asp:TextBox ID="txtnewpwd" runat="server" CssClass ="txt_box" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter new password" ControlToValidate="txtnewpwd"></asp:RequiredFieldValidator>
                </p>
                 <p><label>conformpassword :</label>
                <asp:TextBox ID="txtcpwd" runat="server" CssClass ="txt_box" TextMode="Password" ></asp:TextBox>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="confirmpassword mismatch" ControlToCompare="txtnewpwd" ControlToValidate="txtcpwd"></asp:CompareValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="enter confirm password" ControlToValidate="txtcpwd"></asp:RequiredFieldValidator>
                </p>
                <p><label>&nbsp;</label> 
               <asp:Button ID="btnsave" runat="server" Text="save" CssClass="btn" OnClick="btnsave_Click" />&nbsp;
                    <asp:HyperLink ID="hback" runat="server" NavigateUrl ="../admin/reset_ password.aspx">back</asp:HyperLink>
                  
                   <%-- <asp:Label ID="lblmsg" runat="server" Visible="false" CssClass ="errmsg" ></asp:Label>--%></p>
              <p><label>&nbsp;</label> 
              <asp:Label ID="lblmsg" runat="server" Visible="false" CssClass ="errmsg" ></asp:Label>
               <asp:Label ID="lblerr_msg" runat="server" Visible="false" CssClass ="errmsg" ></asp:Label>
               </p>
                <p align ="center" ></p>
                 </div>
      </div>
       
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
    
</div>
       
    </form>
</body>
</html>
