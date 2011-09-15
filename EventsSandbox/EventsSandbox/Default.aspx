<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="EventsSandbox._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome!
    </h2>
    <p>
        Welcome to this site. This site helps to connect people in the community.
        Please feel free to browse and sign up for events</p>
    <p>
    <h2>Upcoming Community Events</h2>
        <asp:Table ID="eventTbl" runat="server" BorderStyle="None" CellSpacing="5" 
            EnableViewState="False" Width="400px">
        </asp:Table>
        <asp:Label ID="msgLbl" runat="server"></asp:Label>
    </p>
</asp:Content>
