<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.admindefault"  Debug="true" Codebehind="admindefault.aspx.cs" %>

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
    	<a id="A1" href="Default.aspx" class="logout" runat="server">logout</a>
    </div>
    <!-- end #header_bg -->
    
        <div id="footer">
    	&nbsp;
    </div>
     <div>
         <uc1:AdminHeader ID="AdminHeader1" runat="server" />
            </div>
</div>
       
    </form>
</body>

</html>
