<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserIdentity.ascx.cs" Inherits="AUInterconnect.UserControls.UserIdentity" %>
<div style="border: 1px solid #FFFFFF; height:40px; font-size: small;">
    <asp:HyperLink ID="LoginLink" runat="server" EnableViewState="False" 
        Font-Bold="True" ForeColor="White" NavigateUrl="~/User/Login.aspx">Log In</asp:HyperLink>
    
    <asp:Label ID="UserNameLabel" runat="server" Text="Label">Guest</asp:Label>

    <table id="usermenu" style="display:none">
    <tr><td><a href="">My Events</a></td></tr>
    <tr><td><a href="">Account</a></td></tr>
    <tr><td><a href="">Log Out</a></td></tr>
    </table>

</div>
