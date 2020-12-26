<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS._Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
 <link href="includes/css/login.css" type="text/css" rel="stylesheet" />
  <link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
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
        	<br />
            <br />
        </div>
        <!-- end #login_details -->
        
    </div>
    <!-- end #header -->
    
    <!-- start #header_bg -->
    <div id="header_bg">
    	
  </div>
    <!-- end #header_bg -->
    
    <div id="content_holder">
    
    	<div id="login">
        	<div id="login_head">login</div>
            <div id="login_form">
            	<div id="message_area">
                	<%--message area--%>
                	 <asp:Label ID="lblmsg" runat="server"  Visible="false" CssClass ="errmsg"></asp:Label>
                </div>
              
                  <div class="left_lable">username:</div>
                    <div class="right_lable">
                        
                        <asp:TextBox ID="txtuname" CssClass="txt_box" runat="server"></asp:TextBox>
                        </div>
               
             
                    <div class="left_lable">password:</div>
                    <div class="right_lable"><asp:TextBox ID="txtpassword" CssClass="txt_box" runat="server" TextMode="Password"></asp:TextBox></div>
               
          
                    <div class="left_lable"></div>
                    <div class="right_lable">
                        <asp:Button ID="btnlogin" runat="server" Text="login" CssClass="btn" OnClick="btnlogin_Click" />
                        <br />
                        <br />
                        </div>
          
           
              
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
