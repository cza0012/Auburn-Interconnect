<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="EventsSandbox.Events.EventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
td{vertical-align:top}
td.fldLbl{font-weight:bold}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
    <asp:Literal ID="titleLit" runat="server"></asp:Literal></h2>
    <table border="0" cellspacing="5">
        <tr>
            <td class="fldLbl">Created By:</td>
            <td>
                <asp:Literal ID="hostLit" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="fldLbl">
                Start:
            </td>
            <td>
                <asp:Literal ID="startLit" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="fldLbl">
                End:
            </td>
            <td>
                <asp:Literal ID="endLit" runat="server"></asp:Literal>
            </td>
        </tr>
                <tr>
            <td class="fldLbl">
                Location:
            </td>
            <td>
                <asp:Literal ID="locLit" runat="server"></asp:Literal>
            </td>
        </tr>
                <tr>
            <td class="fldLbl">
                More Info:
            </td>
            <td>
                <asp:Literal ID="descLit" runat="server"></asp:Literal>
                <br /><br />
                <asp:Literal ID="spaceLit" runat="server"></asp:Literal>              
            </td>
        </tr>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="regBtn" runat="server" Text="Sign Up" onclick="regBtn_Click" /></td>
        </tr>
    </table>
</asp:Content>
