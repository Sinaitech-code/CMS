<%@ Page Language="C#" AutoEventWireup="True" Inherits="CMS.calnder" Codebehind="calnder.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calender</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"
            Style="z-index: 100; left: 0px; position: absolute; top: 0px"></asp:Calendar>
        &nbsp;
    
    <input type ="hidden" id="calender" runat ="server" style="z-index: 101; left: 72px; position: absolute; top: 248px" />
    </div>
    </form>
</body>
</html>
