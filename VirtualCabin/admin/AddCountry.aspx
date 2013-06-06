<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddCountry.aspx.cs" Inherits="admin_AddCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 525px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Image ID="Image2" runat="server" Height="499px" 
                    ImageUrl="~/images/country.jpg" Width="525px" />
            </td>
            <td>
                <table class="style1">
            <tr>
                <td class="style4">
                    Add Country</td>
                <td class="style3">
                    <asp:TextBox ID="txtCountry" runat="server" Height="22px" Width="175px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
                        Width="65px" />
                </td>
            </tr>
            </table></td>
        </tr>
    </table>
</asp:Content>

