<%@ Control Language="C#" AutoEventWireup="True" Inherits="CMS.AdminHeader" Codebehind="AdminHeader.ascx.cs" %>
<style>
    .headerlinks{
        width:120px; !important;
    }
</style>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<%--<script>
    $(document).ready(function () {
            $("td").removeAttr("style");
        });
  
</script>--%>
<table   border="1" align="center" cellpadding="0" cellspacing="0" style="height: 25px">
    <tr>
        <td  align="center" id="tdHR" class="headerlinks" runat="server" >
            <asp:HyperLink ID="hypHr" runat="server" NavigateUrl="HR/hrdefault.aspx" >HR</asp:HyperLink>
      </td>
        <td   align="center" id="tdProject" class="headerlinks" runat="server">
      <asp:HyperLink ID="hypproject" runat="server" NavigateUrl="projects/projectdefault.aspx" >Project</asp:HyperLink></td>
        <td  align="center" id="tdPurchase" class="headerlinks" runat="server">
      <asp:HyperLink ID="hyppurchase" runat="server" NavigateUrl="purchase/purchasedefault.aspx" >Purchase</asp:HyperLink></td>
        <td  align="center" id="tdAccounts" class="headerlinks" runat="server">
      <asp:HyperLink ID="hypaccounts" runat="server" NavigateUrl="accounts/accountsdefault.aspx" >Accounts</asp:HyperLink></td>
            <td id="tdAdmin" runat="server"  class="headerlinks" align="center">
            <asp:HyperLink ID="hypadmin" runat="server" NavigateUrl="admin/add_admin.aspx" >Admin</asp:HyperLink></td>
    </tr>
</table>
