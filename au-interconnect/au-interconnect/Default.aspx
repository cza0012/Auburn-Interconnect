﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/AULayout1.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AUInterconnect._Default" %>

<asp:Content ID="Title" runat="server" ContentPlaceHolderID="title">Auburn Interconnect</asp:Content>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Breadcrumb" runat="server" ContentPlaceHolderID="breadcrumb">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <!-- Facebook API -->
    <div id="fb-root"></div>
    <script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>

    <h1>Welcome!</h1>
    <p>
    Welcome to Auburn Interconnect. This site connects “local know how” of Auburn
    residents, students and faculty with “need to know how” of many international
    students at Auburn University.
    </p>
    <p>
    Did you know that there are people from more than 80 nations right here on the
    Auburn campus? Think about it... Auburn is home to one-third of all the cultures
    in the world. What an exciting place to be. So whether you are a local resident
    or a visiting international student…read on and see how you can get plugged in!
    Learn how to start an community event <a href="Events/Create.aspx">here</a>!
    </p>
    <p>
    As a local resident, you already know where to go, what to do and how to do it
    in the Alabama environment. So why not share it with others? Become a local guide
    to life in Auburn. It could be a back yard barbeque, cooking American desserts…or
    hiking. It could be moms taking their kids to the Atlanta zoo, a pic-nick at Chewacla,
    or kayaking on the Coosa River. Or it could be as simple as bowling in Auburn…anything
    that would involve 5 or more people. You decide!
    See a list of upcomming events <a href="Events/UpcomingEvents.aspx">here</a>!
    </p>

    <!-- Like button -->
    <div class="fb-like" data-send="true" data-width="450" data-show-faces="true"></div>

    <h1>Contacts</h1>
    <table border="1" style="width:100%">
    <tr>
    <td><!-- column 1 -->
        <table cellspacing="5px">
        <tr><td><img src="http://grad.auburn.edu/general/AUP_3804.JPG" /></td>
        <td style="vertical-align:top; line-height: 15px;">
            <b><a href="mailto:vininlj@auburn.edu">Leonard Vining</a></b><br />
            Interconnect Coordinator<br />
            Graduate School <br />
            844-2143
        </td></tr>
        </table>
    </td>
    <td><!-- column 2 -->
    <table cellspacing="5px">
        <tr><td><img src="images/no_pic.jpg" /></td>
        <td style="vertical-align:top; line-height: 15px;">
            <b><a href="mailto:vininlj@auburn.edu">Joanne Li</a></b><br />
            Events Coordinator<br />
            333-3333
        </td></tr>
        </table>
    </td>
    </tr>
    </table>
</asp:Content>
