<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateIcon.ascx.cs" Inherits="AUInterconnect.UserControls.DateIcon" %>

<div style="margin: 0px; background-image:url(../images/calendar40.png);
    background-repeat:no-repeat;
    width:40px;
    height:40px; overflow: hidden; display: block;">
    <div style=" font-family: Arial, Helvetica, sans-serif; font-size: 8px; font-weight: bold; text-align: center; color: #FFFFFF; position: relative; top: 4px;">
        <asp:Label ID="MonthLabel" runat="server" Text="DEC"></asp:Label>
    </div>
    <div style="text-align:center; font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position: relative; top: 8px;">
        <asp:Label ID="DayLabel" runat="server" Text="30"></asp:Label>
        </div>
</div>


