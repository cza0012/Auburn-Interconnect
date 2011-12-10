<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="AUInterconnect.Events.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="Stylesheet" type="text/css" href="../Styles/smoothness/jquery-ui-1.8.15.custom.css" />
<link rel="Stylesheet" type="text/css" href="../Styles/jquery.qtip.min.css" />
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
<script type="text/javascript" src="../Scripts/jquery.maskedinput-1.3.min.js"></script>
<script type="text/javascript" src="../Scripts/jquery.qtip.min.js"></script>

<script language="javascript" type="text/javascript">
    $(function () {
        $('#<%= StartTime.ClientID %>').datetimepicker(
        {
            ampm: true,
            stepMinute: 15,
        });
        $('#<%= EndTime.ClientID %>').datetimepicker({ ampm: true, stepMinute: 15,
        });

        $('#<%= MeetTime.ClientID %>').datetimepicker({ ampm: true, stepMinute: 15 });
        $('#<%= HostPhone.ClientID %>').mask("(999) 999-9999");

        //qtip
        $('.fieldName').qtip(
        { 
            content: {attr: 'alt'},
            position: {my: 'left center', at: 'right center'}
        });
    });
</script>

<style type="text/css">
.catHeaderBox 
{
    border-bottom: 1px solid #808080;
    width:430px;
    margin-top:5px;
    margin-left:10px;
}

.catFieldBox
{
    margin-top:5px;
    margin-left:15px;
}
    .style1
    {
        color: #CCCCCC;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create Event</h2>
        <br />
        <div class="catHeaderBox">
        <strong>Host Info</strong></div>
        <table border="0" cellspacing="5" class="catFieldBox">
            <tr>
                    <td  style="width:100px">
                        <span class="fieldName"
                            alt="The name of the organization hosting this event. Ex: Bass Club."
                            >Organization</span><br />
                        <span class="style1">(optional)</span></td>
                    <td>
                        <asp:TextBox ID="HostOrg" runat="server" Width="300px" MaxLength="300"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            <tr>
                    <td><span class="fieldName"
                            alt="Description">Contact Name</span>
                        </td>
                    <td>
                        <asp:TextBox ID="HostName" runat="server" Width="300px" MaxLength="300"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="hostNameReq" runat="server" 
                        ErrorMessage="Host name is required" ControlToValidate="HostName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><span class="fieldName"
                            alt="Description">Contact Email</span></td>
                    <td>
                        <asp:TextBox ID="HostEmail" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="HostEmail" ErrorMessage="Host email is invalid" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="HostEmailReq" runat="server" 
                            ControlToValidate="HostEmail" Display="Dynamic" 
                            ErrorMessage="Host email is required"></asp:RequiredFieldValidator>
                    </td>
                 </tr>
                 <tr>
                    <td><span class="fieldName"
                            alt="Description">Contact Phone</span></td>
                    <td>
                        <asp:TextBox ID="HostPhone" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ErrorMessage="Host phone is required" ControlToValidate="HostPhone"></asp:RequiredFieldValidator>
                    </td>
                 </tr></table>
        <br />
        <div class="catHeaderBox">
            <strong>Event Info</strong></div>
            <table border="0" cellspacing="5" class="catFieldBox">
                <tr>
                    <td style="width:100px"><span class="fieldName"
                            alt="Description">Event Name</span></td>
                    <td>
                        <asp:TextBox ID="EventName" runat="server" Width="300px" MaxLength="255"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="EventNameReq" runat="server" 
                        ErrorMessage="Give this event a name" ControlToValidate="EventName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><span class="fieldName"
                            alt="Description">Time</span></td>
                    <td>
                        <asp:TextBox ID="StartTime" runat="server" Width="138px"></asp:TextBox>
                        to
                        <asp:TextBox ID="EndTime" runat="server" Width="138px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                 </tr>
                 <tr>
                    <td><span class="fieldName"
                            alt="Description">Location</span></td>
                    <td>
                        <asp:TextBox ID="Location" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="LocationReq" runat="server" 
                        ErrorMessage="Give this event a name" ControlToValidate="Location"></asp:RequiredFieldValidator>
                    </td>
                 </tr>
                 <tr>
                    <td><span class="fieldName"
                            alt="Description">Meeting Time</span></td>
                    <td>
                        <asp:TextBox ID="MeetTime" runat="server" Width="140px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="MeetTimeReq" runat="server" 
                        ErrorMessage="Meeting time is required" ControlToValidate="MeetTime"></asp:RequiredFieldValidator>
                    </td>
                 </tr>
                 <tr>
                    <td><span class="fieldName"
                            alt="Description">Meeting Location</span></td>
                    <td>
                        <asp:TextBox ID="MeetLocation" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="MeetLocReq" runat="server" 
                        ErrorMessage="Meet Location is required" ControlToValidate="MeetLocation"></asp:RequiredFieldValidator>
                    </td>
                 </tr>
                 <tr>
            <td><span class="fieldName"
                            alt="Description">Description</span></td>
            <td>
                <asp:TextBox ID="Desc" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="300px"></asp:TextBox>                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Give this event more info" ControlToValidate="Desc"></asp:RequiredFieldValidator>
            </td>
        </tr>
                 </table>       
<br />
        <div class="catHeaderBox">
            <strong><span class="fieldName"
                            alt="Description">Additional Info</span></strong></div>
            
<table border="0" cellspacing="5" class="catFieldBox">
                 <tr>
                    <td style="width:100px"><span class="fieldName"
                            alt="Description">Transportation</span></td>
                    <td>
                <asp:TextBox ID="Transport" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="300px"></asp:TextBox>                
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="TransportReq" runat="server" 
                        ErrorMessage="Transportation info is required" ControlToValidate="Transport"></asp:RequiredFieldValidator>
                    </td>
                 </tr>
                 <tr>
                    <td style="width:100px"><span class="fieldName"
                            alt="Description">Request Drivers</span></td>
                    <td>
                        <asp:CheckBox ID="RequestDrivers" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                 </tr>
                 <tr>
                    <td><span class="fieldName"
                            alt="Description">Costs</span></td>
                    <td>
                <asp:TextBox ID="Costs" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="300px"></asp:TextBox>                
                    </td>
                    <td>
                    </td>
                 </tr>
                 <tr>
                    <td><span class="fieldName"
                            alt="Description">Equipment</span></td>
                    <td>
                <asp:TextBox ID="Equipment" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="300px"></asp:TextBox>                
                    </td>
                    <td>
                    </td>
                 </tr>
                 <tr>
            <td><span class="fieldName"
                            alt="Description">Food</span></td>
            <td>
                <asp:TextBox ID="Food" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="300px"></asp:TextBox>                
            </td>
            <td>
                &nbsp;</td>
        </tr>
                 <tr>
            <td><span class="fieldName"
                            alt="Description">Other</span></td>
            <td>
                <asp:TextBox ID="Other" runat="server" TextMode="MultiLine" Height="95px" 
                    Width="300px"></asp:TextBox>                
            </td>
            <td>
                &nbsp;</td>
        </tr>
                 <tr>
            <td>Guest Limit</td>
            <td>
                <asp:TextBox ID="GuestLimit" runat="server" 
                    Width="59px"></asp:TextBox>                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="GuestLimit" ErrorMessage="This should be a positive number" 
                    ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>
                 </table>

    <br />
    <table border="0" cellspacing="5" class="catFieldBox">
        
        <tr>
            <td style="width:100px"></td>
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
