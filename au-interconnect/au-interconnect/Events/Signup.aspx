<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="AUInterconnect.Events.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style>
.fieldName
{
    font-weight:bold;
}
    .style1
    {
        color: #C0C0C0;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Event Sign Up</h2>

    <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>

    <table cellspacing="5">
        <tr>
            <td class="fieldName">Event Name</td>
            <td>
                <asp:Literal ID="EventName" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="fieldName">Hosted By</td>
            <td>
                <asp:Literal ID="EventHost" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="fieldName">Date</td>
            <td>
                <asp:Literal ID="Date" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="fieldName">Time</td>
            <td>
                <asp:Literal ID="Time" runat="server"></asp:Literal></td>
        </tr>
    </table>

    <br />

    <table cellspacing="5">
        <tr>
            <td>Number of guests<br />
                <span class="style1">(Include yourself)</span></td>
            <td>
                <asp:TextBox ID="HeadCount" runat="server" Width="80px">1</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Number of person
                <br />
                I can take<br />
                <span class="style1">(Include yourself)</span></td>
            <td>
                <asp:TextBox ID="VehicleCap" runat="server" Width="80px">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="AgreeCheckbox" runat="server" 
                    Text="I agree the term and conditions." />
            </td>
        </tr>
    </table>

<!-- div style="padding: 5px; width: 524px; background-color: #FFFFCC;">Registration
<p>
Please read the following information about Conference Management Service
(CMT) so that you can better decide whether you wish to participate. 
</p>
<p>
You must review this registration page and agree to its terms and to the Terms Of Use and Privacy Statement shown at the bottom of this page in order to participate. After you do so, you will be asked to fill-in registration information. If you have questions or problems, please email CMT at cmt@microsoft.com.
</p>
<p>
Reviewers may submit their reviews of these documents to CMT.

What kinds of information will I be providing to CMT?

You will be asked to provide registration information as a pre-requisite to using CMT, including name, e-mail address, phone and organization. In addition, you may also submit documents and other files that may be reviewed by other participants.
</p>
<p>

Will my personal information be kept private?
The personal information you provide as part of registering for CMT will be treated as confidential, except as otherwise provided in the Privacy Statement  . You must review the Privacy Statement and agree to its terms before registering to participate in CMT.

What are my rights as a user of CMT?

Any action you take is completely voluntary. Even after you start participating in CMT, you may stop or withdraw at any time. You may simply exit or stop visiting the CMT web site. There are no continuing obligations or expectations placed on you. There is no penalty for stopping use of CMT.


Who can I contact if I have questions or problems?

For questions about CMT, e-mail cmt@microsoft.com.


Printable Privacy Statement and Terms of Use</div -->

    <br />

    <asp:Button ID="regBtn" runat="server" Text="Sign Me Up!" 
        onclick="regBtn_Click" />
</asp:Content>
