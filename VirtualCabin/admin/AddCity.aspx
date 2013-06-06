<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddCity.aspx.cs" Inherits="admin_AddCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 397px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Image ID="Image2" runat="server" Height="501px" 
                    ImageUrl="~/images/city.jpg" Width="393px" />
            </td>
            <td>
                <table class="style1">
        <tr>
            <td class="style3">
                Country</td>
            <td class="style2">
                <asp:DropDownList ID="drpCountry" runat="server" Width="230px" 
                    onselectedindexchanged="drpCountry_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                State</td>
            <td>
                <asp:DropDownList ID="drpState" runat="server" height="22px" width="230px" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Add City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" height="22px" width="230px"></asp:TextBox>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="80px" 
                    onclick="btnAdd_Click" />
            </td>
        </tr>
        </table></td>
        </tr>
    </table>
</asp:Content>

