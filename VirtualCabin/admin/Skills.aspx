<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Skills.aspx.cs" Inherits="admin_Skill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 550px;
    }
    .style3
    {
        width: 547px;
    }
    .style4
    {
        width: 541px;
    }
    .style5
    {
        width: 491px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style5">
                <asp:Image ID="Image2" runat="server" Height="446px" 
                    ImageUrl="~/images/select skills.jpg" Width="488px" />
            </td>
            <td>
                <table class="style1">
            <tr>
                <td class="style3">
                    Skill Head</td>
                <td class="style4">
                    <asp:DropDownList ID="drpSkillHead" runat="server" height="22px" width="157px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Skill Name</td>
                <td>
                    <asp:TextBox ID="txtSkillName" runat="server" height="22px" width="157px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Height="26px" Text="Add" Width="89px" 
                        onclick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table></td>
        </tr>
    </table>
</asp:Content>

