<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="employee_Mail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
    .style3
    {
        width: 100%;
    }
    .style4
    {
        height: 23px;
    }
    .style5
    {
        width: 462px;
    }
    .style6
    {
        height: 23px;
        width: 173px;
    }
    .style7
    {
        width: 173px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="style3">
    <tr>
        <td class="style5">
            <asp:Image ID="Image2" runat="server" Height="371px" 
                ImageUrl="~/images/mail.jpg" Width="401px" />
        </td>
        <td>
            <table class="style3">
                <tr>
                    <td class="style6">
                        From</td>
                    <td class="style4">
                        <asp:Label ID="lblFrom" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Title</td>
                    <td>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Subject</td>
                    <td>
                        <asp:Label ID="lblSubject" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnReply" runat="server" onclick="btnReply_Click" 
                            Text="Reply" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

