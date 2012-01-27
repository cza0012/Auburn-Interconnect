<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HostEvent.ascx.cs" Inherits="AUInterconnect.UserControls.HostEvent" %>
<%@ Register TagPrefix="uc" TagName="EventNameDate" Src="~/UserControls/EventNameDate.ascx" %>
<table style="width:100%; border-collapse: separate; vertical-align: middle;" border="1">
<tr>
<td style="vertical-align: middle">
<uc:EventNameDate ID="NameDate" runat="server" />
</td>
<td align="right" valign="middle">
    <asp:HyperLink ID="RosterLink" class="eventActionImageLink" runat="server"><img src="../images/1326915758_alacarte.png" height="24" alt="View Roster"/></asp:HyperLink>
</td></tr>
</table>