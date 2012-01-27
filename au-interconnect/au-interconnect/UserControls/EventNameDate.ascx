<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventNameDate.ascx.cs"
    Inherits="AUInterconnect.UserControls.EventNameDate" %>
<%@ Register TagPrefix="uc" TagName="DateIcon" Src="~/UserControls/DateIcon.ascx" %>

<div style="margin-bottom:5px">
<asp:HyperLink ID="EventNameLink" runat="server" Font-Size="Large" CssClass="ShortEventInfo_EventName">[EventNameLink]</asp:HyperLink>
</div>
<div style="margin-bottom:5px">
<asp:Literal ID="EventTime" runat="server"></asp:Literal>
</div>

