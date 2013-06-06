<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="employee_ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
        width: 134px;
        font-weight: bold;
    }
        
        .style3
        {
            width: 169px;
        }
        
    .style4
    {
        width: 330px;
    }
        
        .style5
        {
            width: 325px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <tr>
    <td></td>
    </tr>
    <tr>
    <td></td>
    </tr>
    <tr>
    <td></td>
    </tr>
    <tr>
    <td></td>
    </tr>
    </table>
    <table class="style1">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" Height="244px" 
                    ImageUrl="~/images/profile.jpg" Width="274px" />
            </td>
            <td class="style5">
                <table class="style1" style="width: 98%; height: 280px;">
        <tr>
            <td class="style2">
                Username</td>
            <td class="style3">
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                First name</td>
            <td class="style3">
                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Last name</td>
            <td class="style3">
                <asp:Label ID="lblLastName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Mail Id</td>
            <td class="style3">
                <asp:Label ID="lblMailId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Address</td>
            <td class="style3">
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Country</td>
            <td class="style3">
                <asp:Label ID="lblCountry" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                State</td>
            <td class="style3">
                <asp:Label ID="lblState" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                City</td>
            <td class="style3">
                <asp:Label ID="lblCity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Phone</td>
            <td class="style3">
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
            </td>
        </tr>
    </table></td>
            <td valign="top">
                <asp:ImageMap ID="ImgProfile" runat="server" Height="200px" Width="200px">
                </asp:ImageMap>
            </td>
        </tr>
    </table>


    

    
</asp:Content>

