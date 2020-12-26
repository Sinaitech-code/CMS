<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.clientdisplay" Codebehind="clientdisplay.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
            <span class="date">date: 
                <asp:Label ID="lbldate1" runat="server" Text=""></asp:Label></span>
        </div>
       
        <!-- end #login_details -->
        
    </div>
    <!-- end #header -->
    
    <!-- start #header_bg -->
    <div id="header_bg">
    	<a id="A1" href="Default.aspx" class="logout" runat="server">logout</a>
    </div>
    <!-- end #header_bg -->
    
   <div id="content_holder">
    	<div id="left_navi_holder">
        	<div class="side_navi_gap">&nbsp;</div>
  
    	      <asp:HyperLink ID="HyperLink1" runat="server" CssClass ="navi_head" NavigateUrl="../changepassword.aspx">change password</asp:HyperLink>
    	      </div> </div>

        <div id="form_area">
        	<div id="form_head">
            	<div id="left_corner">&nbsp;</div>                
                <div id="right_corner">&nbsp;</div>
              <div id="form_head_text_area">view images to client</div>
                
            </div>
            <asp:Label ID="lblerr_msg" runat="server" CssClass="errmsg" Visible="False"></asp:Label>
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
          <td>
           <asp:GridView ID="GridView1" runat="server" width="100%" AutoGenerateColumns="False"  CssClass="grid_content_1" AllowPaging="True" OnPageIndexChanging="gridview_pageindexchange"  >
              <Columns>
               <asp:BoundField  HeaderText="report id" DataField="report_id">
                   <HeaderStyle CssClass="grid_head" />
                  
              </asp:BoundField>
              <asp:BoundField  HeaderText="image id" DataField="report_image_id">
                   <HeaderStyle CssClass="grid_head" />
                  
              </asp:BoundField>
              <asp:TemplateField HeaderText="image1">
              
              <ItemTemplate>
            
                  <asp:Image ID="Image1" runat="server" Height="50" Width="50" ImageUrl='<%#"Employees/imagefile/"+Eval("report_image_name1")%>'/>
              </ItemTemplate>
                  <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image2">
              
              <ItemTemplate>
              <asp:Image ID="img2" runat="server"  Height="50" Width="50" ImageUrl='<%#"Employees/imagefile/"+Eval("report_image_name2")%>' />
             
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image3">
              
              <ItemTemplate>
              <asp:Image ID="img3" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"Employees/imagefile/"+Eval("report_image_name3")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image4">
              
              <ItemTemplate>
              <asp:Image ID="img4" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"Employees/imagefile/"+Eval("report_image_name4")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
               <asp:TemplateField HeaderText="image5">
              
              <ItemTemplate>
              <asp:Image ID="img5" runat="server"  Height="50px" Width="50px" ImageUrl='<%#"Employees/imagefile/"+Eval("report_image_name5")%>' />
              
              </ItemTemplate>
                   <HeaderStyle CssClass="grid_head" />
              </asp:TemplateField>
       
              </Columns>
                  <AlternatingRowStyle CssClass="grid_content_2" />
              
              </asp:GridView>
             </td>
          </tr>
          </table>
        
        </div>
    </div>
    
    
    <div id="footer">
    	&nbsp;
    </div>
    
    </div>
    </form>
</body>
</html>
