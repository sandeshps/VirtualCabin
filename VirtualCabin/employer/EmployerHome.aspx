<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="EmployerHome.aspx.cs" Inherits="employer_EmployerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
    .style3
    {
        height: 461px;
    }
    .style4
    {
        height: 461px;
        width: 507px;
    }
    .style5
    {
        height: 461px;
        width: 216px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="margin-bottom: 0px; height: 456px;">
    <tr>
        <td class="style4">
            <asp:Image ID="Image2" runat="server" Height="497px" 
                ImageUrl="~/gif/employer.gif" Width="348px" />
        </td>
        <td class="style5">
            Welcome
            <asp:Label ID="lblUsername" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
            <br />
            You have
            <asp:Label ID="lblMessages" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
            <br />
            </td>
        <td class="style3">
            <asp:ImageMap ID="imgProfilePhoto" runat="server" Height="150px" Width="150px">
            </asp:ImageMap>
            </td>
    </tr>
</table>
</asp:Content>

