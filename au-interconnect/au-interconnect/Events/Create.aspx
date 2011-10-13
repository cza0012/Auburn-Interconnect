<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="AUInterconnect.Events.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" type="text/css" href="../Styles/smoothness/jquery-ui-1.8.15.custom.css" />
<style type="text/css">
/* css for timepicker */
.ui-timepicker-div .ui-widget-header{ margin-bottom: 8px; }
.ui-timepicker-div dl{ text-align: left; }
.ui-timepicker-div dl dt{ height: 25px; }
.ui-timepicker-div dl dd{ margin: -25px 0 10px 65px; }
.ui-timepicker-div td { font-size: 90%; }
</style>
<script type="text/javascript" src="../Scripts/jquery-1.5.1.min.js"></script>
<script type="text/javascript" src="../Scripts/jquery-ui-1.8.15.custom.min.js"></script>
<script type="text/javascript" src="../Scripts/jquery-ui-timepicker-addon.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        $('#<%= startDate.ClientID %>').datetimepicker({ ampm: true });
        $('#<%= endDate.ClientID %>').datetimepicker({ ampm: true });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create Event</h2>
    <table border="0" cellspacing="5">
        <tr>
            <td>What</td>
            <td>
                <asp:TextBox ID="titleTxb" runat="server" Width="400px" MaxLength="255"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="titleReq" runat="server" 
                    ErrorMessage="Give this event a name" ControlToValidate="titleTxb"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Start</td>
            <td>
                <asp:TextBox ID="startDate" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    End 
                <asp:TextBox ID="endDate" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>Where</td>
            <td>
                
                <asp:TextBox ID="locTxb" runat="server" MaxLength="255" Width="400px"></asp:TextBox>
                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="locReq" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ControlToValidate="locTxb"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>More Info</td>
            <td>
                <asp:TextBox ID="descTxb" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="400px"></asp:TextBox>                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="descReq" runat="server" 
                    ErrorMessage="Give this event more info" ControlToValidate="descTxb"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Max Registrations</td>
            <td>
                <asp:TextBox ID="maxRegTxb" runat="server" 
                    Width="59px"></asp:TextBox>                
                <asp:RegularExpressionValidator ID="maxRegRegex" runat="server" 
                    ControlToValidate="maxRegTxb" ErrorMessage="This should be a positive number" 
                    ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>Guest per Reg</td>
            <td>
                <asp:TextBox ID="guestTxb" runat="server" 
                    Width="59px"></asp:TextBox>                
                <asp:RegularExpressionValidator ID="guestRegex" runat="server" 
                    ControlToValidate="guestTxb" ErrorMessage="This should be a positive number" 
                    ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="agreeChk" runat="server" EnableViewState="False" /> I agree to
                the conditions of hosting a community event
                 
            </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="msgLbl" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="createBtn" runat="server" Text="Create" 
                    onclick="createBtn_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
