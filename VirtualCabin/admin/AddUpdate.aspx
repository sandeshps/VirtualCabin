<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddUpdate.aspx.cs" Inherits="admin_AddUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 100%;
    }
    .style3
    {
            width: 89px;
        }
    .style4
    {
        width: 322px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
    <tr>
        <td class="style4">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/updates.png" 
                Width="309px" />
        </td>
        <td>
            <table class="style2">
                <tr>
                    <td class="style3">
                        Add
                    </td>
                    <td>
                        <asp:TextBox ID="txtUpdate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

