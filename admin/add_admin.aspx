<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.admin.admin_add_admin" Codebehind="add_admin.aspx.cs" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="AdminHeader" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../HR/includes/css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div >
    <div id="main_container">

	<!-- start #header -->
	<div id="header">
    
    	<!-- start #logo -->
    	<div id="logo"></div>
        <!-- end #logo -->
        
        <!-- start #login_details -->
        <div id="login_details">
        	<span class="welcome">welcome:</span>
        	<span class="loged_name">
            <asp:Label ID="lblempname" runat="server" ></asp:Label></span> 
             <br />
            <span class="date">date:  <asp:Label ID="lbldate" runat="server" ></asp:Label></span>
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
     <a href="view_expences_status.aspx" class="side_navi">viewexpenses status</a>
     <a href="view_daily_report.aspx" class="side_navi">view emp daily report</a>
     <a href="#" class="navi_head">Projects</a>
     <a href="view_underprocess_project_status.aspx" class="side_navi">view under process projects</a>
     <a href="view_pending_projects.aspx" class="side_navi">view pending projects</a>
     <a href="view_completed_projects.aspx" class="side_navi">view completed projects</a>
     <asp:HyperLink ID="HyperLink1" runat="server" CssClass ="navi_head" NavigateUrl="../changepassword.aspx">change password</asp:HyperLink>
     <asp:HyperLink ID="HyperLink2" runat="server" CssClass ="navi_head" NavigateUrl="../admin/reset_ password.aspx">reset password</asp:HyperLink>
     </div>
    <uc1:adminheader id="AdminHeader1" runat="server"></uc1:adminheader>
    <div id="form_area">
    <div id="form_head">
    <div id="left_corner">&nbsp;</div>                
   <div id="right_corner">&nbsp;</div>
   <div id="form_head_text_area">add admin details</div>
  </div>
   <div id="form">
    <p>
    <label><asp:label id="Label11" runat="server"  Text="*"  ForeColor="red"></asp:label>select grade:</label>
     <asp:DropDownList ID="ddlemp_grade" runat="server" CssClass="dropdown">
     </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
      ErrorMessage="select grade" ControlToValidate="ddlemp_grade"></asp:RequiredFieldValidator>
      </p>
      <p>
      <label><asp:label id="Label12" runat="server"  Text="*"  ForeColor="red"></asp:label>select emp type:</label>
      <asp:DropDownList ID="ddlemp_type" runat="server" CssClass="dropdown">
       </asp:DropDownList>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="select employee type" ControlToValidate="ddlemp_type"></asp:RequiredFieldValidator>
      </p>
       <p><label>emp id:</label>
       <asp:TextBox ID="txtemp_id" runat="server" CssClass ="txt_box" ReadOnly="True"></asp:TextBox>
       </p>
       <p><label><asp:label id="Label9" runat="server"  Text="*"  ForeColor="red"></asp:label>first name:</label> 
       <asp:TextBox ID="txtempf_name" runat="server" CssClass ="txt_box"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvemp_fname" runat="server" ErrorMessage="first name should not be empty" ControlToValidate="txtempf_name"></asp:RequiredFieldValidator>&nbsp;
       </p>
       <p><label>middle name:</label> 
       <asp:TextBox ID="txtempm_name" runat="server" CssClass ="txt_box"></asp:TextBox>
       </p>
       <p><label><asp:label id="Label1" runat="server"  Text="*"  ForeColor="red"></asp:label>last name:</label> 
        <asp:TextBox ID="txtempl_name" runat="server" CssClass ="txt_box"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvempm_name" runat="server" ErrorMessage="Last name should not be empty" ControlToValidate="txtempl_name"></asp:RequiredFieldValidator>&nbsp;
        </p>
        <label>gender:</label>
        <asp:RadioButtonList ID="rbtngender" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem>M</asp:ListItem>
         <asp:ListItem>F</asp:ListItem>
         </asp:RadioButtonList>
         <p>
         <label>date of birth:</label>
         <asp:DropDownList ID="ddldate" runat="server" >
                 <asp:ListItem >date</asp:ListItem>
                <asp:ListItem >01</asp:ListItem>
                <asp:ListItem >02</asp:ListItem>
                <asp:ListItem >03</asp:ListItem>
                <asp:ListItem >04</asp:ListItem>
                <asp:ListItem >05</asp:ListItem>
                <asp:ListItem >06</asp:ListItem>
                <asp:ListItem >07</asp:ListItem>
                <asp:ListItem >08</asp:ListItem>
                <asp:ListItem >09</asp:ListItem>
                <asp:ListItem >10</asp:ListItem>
                <asp:ListItem >11</asp:ListItem>
                <asp:ListItem >12</asp:ListItem>
                <asp:ListItem >13</asp:ListItem>
                <asp:ListItem >14</asp:ListItem>
                <asp:ListItem >15</asp:ListItem>
                <asp:ListItem >16</asp:ListItem>
                <asp:ListItem >17</asp:ListItem>
                <asp:ListItem >18</asp:ListItem>
                <asp:ListItem >19</asp:ListItem>
                <asp:ListItem >20</asp:ListItem>
                <asp:ListItem >21</asp:ListItem>
                <asp:ListItem >22</asp:ListItem>
                <asp:ListItem >23</asp:ListItem>
                <asp:ListItem >24</asp:ListItem>
                <asp:ListItem >25</asp:ListItem>
                <asp:ListItem >26</asp:ListItem>
                <asp:ListItem >27</asp:ListItem>
                <asp:ListItem >28</asp:ListItem>
                <asp:ListItem >29</asp:ListItem>
                <asp:ListItem >30</asp:ListItem>
                <asp:ListItem >31</asp:ListItem>
               </asp:DropDownList>
             <asp:DropDownList ID="ddlmonth" runat="server" >
            <asp:ListItem >month</asp:ListItem>
            <asp:ListItem >january</asp:ListItem>
            <asp:ListItem >february</asp:ListItem>
            <asp:ListItem >march</asp:ListItem>
            <asp:ListItem >april</asp:ListItem>
            <asp:ListItem >may</asp:ListItem>
            <asp:ListItem >june</asp:ListItem>
            <asp:ListItem >july</asp:ListItem>
            <asp:ListItem >august</asp:ListItem>
            <asp:ListItem >september</asp:ListItem>
            <asp:ListItem >october</asp:ListItem>
             <asp:ListItem >november</asp:ListItem>
           <asp:ListItem >december</asp:ListItem>
           </asp:DropDownList>
           <asp:DropDownList ID="ddlyear" runat="server" >
            <asp:ListItem >year</asp:ListItem>
            <asp:ListItem >1950</asp:ListItem>
            <asp:ListItem >1951</asp:ListItem>
            <asp:ListItem >1952</asp:ListItem>
            <asp:ListItem >1953</asp:ListItem>
            <asp:ListItem >1954</asp:ListItem>
            <asp:ListItem >1955</asp:ListItem>
            <asp:ListItem >1956</asp:ListItem>
            <asp:ListItem >1957</asp:ListItem>
            <asp:ListItem >1958</asp:ListItem>
            <asp:ListItem >1959</asp:ListItem>
            <asp:ListItem >1960</asp:ListItem>
            <asp:ListItem >1961</asp:ListItem>
            <asp:ListItem >1962</asp:ListItem>
            <asp:ListItem >1963</asp:ListItem>
            <asp:ListItem >1964</asp:ListItem>
            <asp:ListItem >1965</asp:ListItem>
            <asp:ListItem >1966</asp:ListItem>
            <asp:ListItem >1967</asp:ListItem>
            <asp:ListItem >1968</asp:ListItem>
            <asp:ListItem >1969</asp:ListItem>
            <asp:ListItem >1970</asp:ListItem>
            <asp:ListItem >1971</asp:ListItem>
            <asp:ListItem >1972</asp:ListItem>
            <asp:ListItem >1973</asp:ListItem>
            <asp:ListItem >1974</asp:ListItem>
            <asp:ListItem >1975</asp:ListItem>
            <asp:ListItem >1976</asp:ListItem>
            <asp:ListItem >1977</asp:ListItem>
            <asp:ListItem >1978</asp:ListItem>
            <asp:ListItem >1979</asp:ListItem>
            <asp:ListItem >1980</asp:ListItem>
            <asp:ListItem >1981</asp:ListItem>
            <asp:ListItem >1982</asp:ListItem>
            <asp:ListItem >1983</asp:ListItem>
            <asp:ListItem >1984</asp:ListItem>
            <asp:ListItem >1985</asp:ListItem>
            <asp:ListItem >1986</asp:ListItem>
            <asp:ListItem >1987</asp:ListItem>
            <asp:ListItem >1988</asp:ListItem>
            <asp:ListItem >1989</asp:ListItem>
            <asp:ListItem >1990</asp:ListItem>
            <asp:ListItem >1991</asp:ListItem>
            <asp:ListItem >1992</asp:ListItem>
            <asp:ListItem >1993</asp:ListItem>
            <asp:ListItem >1994</asp:ListItem>
            <asp:ListItem >1995</asp:ListItem>
            <asp:ListItem >1996</asp:ListItem>
            <asp:ListItem >1997</asp:ListItem>
            <asp:ListItem >1998</asp:ListItem>
            <asp:ListItem >1999</asp:ListItem>
            <asp:ListItem >2000</asp:ListItem>
            <asp:ListItem >2001</asp:ListItem>
            <asp:ListItem >2002</asp:ListItem>
            <asp:ListItem >2003</asp:ListItem>
            <asp:ListItem >2004</asp:ListItem>
            <asp:ListItem >2005</asp:ListItem>
            <asp:ListItem >2006</asp:ListItem>
            <asp:ListItem >2007</asp:ListItem>
            <asp:ListItem >2008</asp:ListItem>
            <asp:ListItem >2009</asp:ListItem>
            <asp:ListItem >2010</asp:ListItem>
            <asp:ListItem >2011</asp:ListItem>
            <asp:ListItem >2012</asp:ListItem>
            <asp:ListItem >2013</asp:ListItem>
            <asp:ListItem >2014</asp:ListItem>
            <asp:ListItem >2015</asp:ListItem>
            <asp:ListItem >2016</asp:ListItem>
            <asp:ListItem >2017</asp:ListItem>
            <asp:ListItem >2018</asp:ListItem>
            <asp:ListItem >2019</asp:ListItem>
            <asp:ListItem >2020</asp:ListItem>
            <asp:ListItem >2021</asp:ListItem>
            <asp:ListItem >2022</asp:ListItem>
            <asp:ListItem >2023</asp:ListItem>
            <asp:ListItem >2024</asp:ListItem>
            <asp:ListItem >2025</asp:ListItem>
            <asp:ListItem >2026</asp:ListItem>
            <asp:ListItem >2027</asp:ListItem>  
            <asp:ListItem >2028</asp:ListItem>
            <asp:ListItem >2029</asp:ListItem>
            <asp:ListItem >2030</asp:ListItem>
            <asp:ListItem >2031</asp:ListItem>
            <asp:ListItem >2032</asp:ListItem>
            <asp:ListItem >2033</asp:ListItem>
            <asp:ListItem >2034</asp:ListItem>
            <asp:ListItem >2035</asp:ListItem>
            <asp:ListItem >2036</asp:ListItem>
            <asp:ListItem >2037</asp:ListItem>
            <asp:ListItem >2038</asp:ListItem>
            <asp:ListItem >2039</asp:ListItem>
            <asp:ListItem >2040</asp:ListItem>
            <asp:ListItem >2041</asp:ListItem>
            <asp:ListItem >2042</asp:ListItem>
            <asp:ListItem >2043</asp:ListItem>
            <asp:ListItem >2044</asp:ListItem>
            <asp:ListItem >2045</asp:ListItem>
            <asp:ListItem >2046</asp:ListItem>
            <asp:ListItem >2047</asp:ListItem>
            <asp:ListItem >2048</asp:ListItem>
            <asp:ListItem >2049</asp:ListItem>
            <asp:ListItem >2050</asp:ListItem>       
                            
                  </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="select date" ControlToValidate="ddldate"></asp:RequiredFieldValidator>  
            </p>
            <p id="P1" runat="server"><label><asp:label id="Label2" runat="server"  Text="*"  ForeColor="red"></asp:label>qualification:</label> 
            <asp:TextBox ID="txtqualif" runat="server" CssClass ="txt_box"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter qualification" ControlToValidate="txtqualif"></asp:RequiredFieldValidator></p>
            <p><label><asp:label id="Label3" runat="server"  Text="*"  ForeColor="red"></asp:label>experiance:</label>
            <asp:TextBox ID="txtexp" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter experience" ControlToValidate="txtexp"></asp:RequiredFieldValidator></p>
            <p>
                 <label>joining date:</label> 
                 <asp:TextBox ID="txtjoin_date" runat="server" CssClass ="txt_box"></asp:TextBox>
                 <a href="javascript:;" onclick="window.open('../calnder.aspx?textbox=txtjoin_date','cal','width=250,height=225,left=270,top=180')">
      <img src="../imgs/icon_calendar.jpg" border="0"></a></p>
                 <p id="P2" runat="server"><label><asp:label id="Label4" runat="server"  Text="*"  ForeColor="red"></asp:label>address1:</label> 
               
                <asp:TextBox ID="txtaddress1" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="enter address" ControlToValidate="txtaddress1"></asp:RequiredFieldValidator></p>
                 <p id="P3" runat="server"><label>address2:</label> 
               
                <asp:TextBox ID="txtaddress2" runat="server" CssClass ="txt_box"></asp:TextBox></p>
                 <p id="P4" runat="server"><label><asp:label id="Label5" runat="server"  Text="*"  ForeColor="red"></asp:label>city:</label> 
               
                <asp:TextBox ID="txtcity" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="enter city" ControlToValidate="txtcity"></asp:RequiredFieldValidator></p>
                 <p id="P5" runat="server"><label><asp:label id="Label6" runat="server"  Text="*"  ForeColor="red"></asp:label>state:</label> 
               
                <asp:TextBox ID="txtstate" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="enter state" ControlToValidate="txtstate"></asp:RequiredFieldValidator></p>
                 <p id="P6" runat="server"><label>mobile no:</label> 
               
                <asp:TextBox ID="txtphone1" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ErrorMessage="enter valid mobile number" ControlToValidate="txtphone1" ValidationExpression="^[\d\-]{10,11}$"></asp:RegularExpressionValidator></p>
                 
                 <p id="P7" runat="server"><label>phone:</label> 
               
                <asp:TextBox ID="txtphone2" runat="server" CssClass ="txt_box"></asp:TextBox>
                <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator2" runat="server" ErrorMessage="enter valid phone number" ControlToValidate="txtphone2" ValidationExpression="^[\d\-]{10,13}$"></asp:RegularExpressionValidator></p>
                 <p id="P8" runat="server"><label>email:</label> 
               
                <asp:TextBox ID="txtemail" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator3" runat="server" ErrorMessage="enter proper email" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></p>
                <h5>create user account</h5>
                <p><label><asp:label id="Label8" runat="server"  Text="*"  ForeColor="red"></asp:label>username:</label> 
                 <asp:TextBox ID="txtuser_name" runat="server" CssClass ="txt_box"></asp:TextBox><asp:RequiredFieldValidator
                     ID="RequiredFieldValidator6" runat="server" ErrorMessage="enter user name" ControlToValidate ="txtuser_name"></asp:RequiredFieldValidator>   <asp:Label ID="lblcheckavaliable" runat="server" Text="" CssClass ="errmsg"></asp:Label> </p>
                     
             <p><label><asp:label id="Label7" runat="server"  Text="*"  ForeColor="red"></asp:label>password:</label>
              
               <asp:TextBox ID="txtpwd" runat="server" CssClass ="txt_box" TextMode="Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtpwd"
                     ErrorMessage="Enter password"></asp:RequiredFieldValidator>
               </p>
                <p><label><asp:label id="Label10" runat="server"  Text="*"  ForeColor="red"></asp:label>confirm password:</label> 
                <asp:TextBox ID="txtcpwd" runat="server" CssClass ="txt_box" TextMode="Password"></asp:TextBox><asp:CompareValidator
                    ID="CompareValidator1" runat="server" ErrorMessage="password mismatch" ControlToCompare="txtpwd" ControlToValidate ="txtcpwd"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="enter confirm password" ControlToValidate="txtcpwd"></asp:RequiredFieldValidator>
               </p>
              
              
                
                <p><label>&nbsp;</label> 
                    <asp:Button ID="btnsave" runat="server" Text="save" CssClass="btn" OnClick="btnsave_Click" />
                    <asp:Label ID="lblerr_msg" runat="server" CssClass ="errmsg" Visible="False"></asp:Label>
                    <asp:Label ID="lblmessage" runat="server" CssClass ="errmsg" Visible="False"></asp:Label>
                    </p>
                    
                            
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
