<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="ProjectMessages.aspx.cs" Inherits="admin_ProjectMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="height: 507px">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table class="style1">
        <tr>
            <td class="style2">
                Username</td>
            <td>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Title</td>
            <td>
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Period</td>
            <td>
                <asp:Label ID="lblPeriod" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                PostDate</td>
            <td>
                <asp:Label ID="lblPostDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Message</td>
            <td>
                <asp:TextBox ID="txtMessage" runat="server" Height="165px" TextMode="MultiLine" 
                    Width="417px"></asp:TextBox>
                <br />
                <asp:Label ID="lblTextRequired" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSend" runat="server" Height="25px" Text="Send" 
                    Width="65px" onclick="btnSend_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMessageSent" runat="server"></asp:Label>
            </td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

