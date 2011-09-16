<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="EventsSandbox.admin.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
    function clearFilterText() {
        
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-bottom: 10px">User Management</h2>
    <asp:Literal ID="errorLit" runat="server" EnableViewState="False"></asp:Literal>
    <div id="identCont1" style="margin-left: 10px">
    <table style="border-style: 1; border-collapse: collapse; border-color: #C0C0C0; "><tr><td>
    Filter by 
        <asp:DropDownList ID="filterLst" runat="server">
            <asp:ListItem>Last Name</asp:ListItem>
            <asp:ListItem>First Name</asp:ListItem>
            <asp:ListItem>Email</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:TextBox ID="filterTxb" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="filterBtn" runat="server" Text="Filter" />
        &nbsp;<asp:Button ID="clearBtn" runat="server" Text="Clear" Visible="False" />
    </td></tr>
    </table>

    <asp:Table ID="userTbl" runat="server" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="5" CellSpacing="5" GridLines="Both">
        <asp:TableRow ID="headerRow" runat="server" BackColor="#EBEBEB" 
            Font-Bold="True">
            <asp:TableCell runat="server">First Name</asp:TableCell>
            <asp:TableCell runat="server">Last Name</asp:TableCell>
            <asp:TableCell runat="server">Email Address</asp:TableCell>
            <asp:TableCell runat="server">Approved</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
    </asp:Content>
