<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.noprivilise" Codebehind="noprivilise.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>No privilege</title>
       <link href="includes/css/styles.css" type="text/css" rel="stylesheet" />
</head>


<body>
    <form id="form1" runat="server">
    
    <div id="main_container" style="color: #ae192b">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo"></div>
        <!-- end #logo -->
        
       
        
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
     
   
    <p style ="height :100px"></p>
    <table width ="100%" cellpadding="0" cellspacing="0"  >
    <tr  >
    <td align="center" style="color:#ae192b; font-size :15px; font-weight:bold">
        <asp:Label ID="lbl" runat="server" Text=""  ></asp:Label>
    
    </td>
    </tr>
    </table>
    <p style ="height :320px">&nbsp;</p>
    
    
 
</div>
       
    </form>
</body>

</html>
