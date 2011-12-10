<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="AUInterconnect.Events.EventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
td{vertical-align:top}
td.fldLbl{font-weight:bold}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
    <asp:Literal ID="EventName" runat="server"></asp:Literal></h2>
        Hosted by <asp:Literal ID="HostName" runat="server"></asp:Literal><br />
        <asp:Literal ID="BigEventTime" runat="server"></asp:Literal>
        
    <p>
        <strong>Date and time:</strong>
        <asp:Literal ID="StartTime" runat="server"></asp:Literal>
&nbsp;-
        <asp:Literal ID="EndTime" runat="server"></asp:Literal>
    </p>
    <p>
        <strong>Description:</strong>
        <asp:Literal ID="Desc" runat="server"></asp:Literal>
    </p>
    <p>
        <strong>Location: </strong>
        <asp:Literal ID="Location" runat="server"></asp:Literal>
    </p>
        <hr />
    <p>
        <strong>Meeting Time:</strong>
        <asp:Literal ID="MeetTime" runat="server"></asp:Literal>
    </p>
    <p>
        <strong>Meeting Location:</strong>
        <asp:Literal ID="MeetLocation" runat="server"></asp:Literal>
    </p>
    <p>
        <strong>Transportation:</strong>
        <asp:Literal ID="Transportation" runat="server"></asp:Literal>
    </p>
    <p>
        <strong>Equipments:</strong>
        <asp:Literal ID="Equipments" runat="server"></asp:Literal>
    </p>
    <p>
        <strong>Costs: </strong>
        <asp:Literal ID="Costs" runat="server"></asp:Literal>
    </p>
    <p>
                <asp:Button ID="regBtn" runat="server" Text="Sign Up" onclick="regBtn_Click" />
    </p>
</asp:Content>
