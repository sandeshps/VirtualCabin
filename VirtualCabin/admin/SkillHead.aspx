<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="SkillHead.aspx.cs" Inherits="admin_SkillHead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 16px;
    }
    .style3
    {
            width: 72px;
        }
    .style5
    {
        width: 415px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style5">
                <asp:Image ID="Image2" runat="server" Height="323px" 
                    ImageUrl="~/images/select skills.jpg" Width="412px" />
            </td>
            <td>
                <table class="style1">
        <tr>
            <td class="style3">
                Skill Head</td>
            <td class="style2">
                <asp:TextBox ID="txtSkillHead" runat="server" Width="191px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
                    Width="59px" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

