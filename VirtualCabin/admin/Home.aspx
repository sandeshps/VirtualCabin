<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            height: 170px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            height: 23px;
            width: 615px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" Height="497px" 
                    ImageUrl="~/images/admin.png" Width="591px" />
            </td>
            <td class="style3">
                <table class="style2">
                    <tr>
                        <td valign="top">
                            Welcome
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue" 
                                Text="Admin"></asp:Label>
                            <br />
                            You have
                            <asp:Label ID="lblMessages" runat="server" ForeColor="Blue"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

