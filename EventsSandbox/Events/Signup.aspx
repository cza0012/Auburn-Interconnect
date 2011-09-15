<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="EventsSandbox.Events.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2><asp:Literal ID="titleLit" runat="server"></asp:Literal></h2>

    <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>

    <p>
        Number of additional friends I plan to bring <asp:TextBox ID="addTxb" runat="server" Width="41px"></asp:TextBox>
    </p>
<div style="padding: 5px; width: 524px; background-color: #FFFFCC;">Registration
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


Printable Privacy Statement and Terms of Use</div>

    <br />

    <asp:Button ID="regBtn" runat="server" Text="I Agree! Sign Me Up!" 
        onclick="regBtn_Click" />
</asp:Content>
