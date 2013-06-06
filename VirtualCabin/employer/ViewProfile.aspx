<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="employer_ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style5
        {
            width: 318px;
        }
        .style6
        {
            width: 59%;
        }
        .style7
        {
            width: 311px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3">
        <tr>
            <td class="style5">
                <asp:Image ID="Image2" runat="server" Height="256px" 
                    ImageUrl="~/images/profile.jpg" Width="272px" />
            </td>
            <td class="style7">
                <table class="style1" style="width: 89%; height: 280px;">
        <tr>
            <td class="style2">
                Username</td>
            <td class="style6">
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                First name</td>
            <td class="style6">
                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Last name</td>
            <td class="style6">
                <asp:Label ID="lblLastName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Mail Id</td>
            <td class="style6">
                <asp:Label ID="lblMailId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Address</td>
            <td class="style6">
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Country</td>
            <td class="style6">
                <asp:Label ID="lblCountry" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                State</td>
            <td class="style6">
                <asp:Label ID="lblState" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                City</td>
            <td class="style6">
                <asp:Label ID="lblCity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Phone</td>
            <td class="style6">
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </td>
            <td>
                <asp:ImageMap ID="ImgProfile" runat="server" Height="310px" Width="296px">
                </asp:ImageMap>
            </td>
        </tr>
    </table>
</asp:Content>

