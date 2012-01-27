<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShortEventInfo.ascx.cs"
    Inherits="AUInterconnect.UserControls.ShortEventInfo" %>
<%@ Register TagPrefix="uc" TagName="DateIcon" Src="~/UserControls/DateIcon.ascx" %>

<table cellspacing="5px">
<tr style="vertical-align:top">
<td style="vertical-align:top">
    <uc:DateIcon ID="Cal" runat="server" />
    </td>
<td>
    <div style="margin-bottom:5px">
    <asp:HyperLink ID="EventNameLink" runat="server" Font-Size="Large" CssClass="ShortEventInfo_EventName">[EventNameLink]</asp:HyperLink>
    </div>
    <div style="margin-bottom:5px">
    <asp:Literal ID="EventTime" runat="server"></asp:Literal>
    </div>
    <div style="margin-bottom:10px;line-height:normal; text-align: justify;">
    <asp:Literal ID="EventDesc" runat="server"></asp:Literal>
    </div>
</td>
</tr>
</table>