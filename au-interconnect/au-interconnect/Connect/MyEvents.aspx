<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyEvents.aspx.cs" Inherits="AUInterconnect.Connect.MyEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<h2>Events I Participate</h2>
    <asp:Table ID="partTbl" runat="server" CellSpacing="10">
    </asp:Table>
    <asp:GridView ID="partGrid" runat="server">
    </asp:GridView>
<h2>Events I Created</h2>
    <asp:Table ID="hostTbl" runat="server" CellSpacing="10">
    </asp:Table>
</asp:Content>
