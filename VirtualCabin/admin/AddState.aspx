<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="AddState.aspx.cs" Inherits="admin_AddState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 429px;
        }
        .style3
        {
            width: 158px;
            height: 26px;
        }
        .style4
        {
            height: 26px;
        }
        .style5
        {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Image ID="Image2" runat="server" Height="499px" 
                    ImageUrl="~/images/state.jpg" Width="427px" />
            </td>
            <td>
                <table class="style1">
            <tr>
                <td class="style3">
                    Country</td>
                <td class="style4">
                    <asp:DropDownList ID="drpCountry" runat="server" height="23px" width="203px" 
                        onselectedindexchanged="drpCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    State</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" Height="23px" Width="203px"></asp:TextBox>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Height="26px" onclick="btnAdd_Click" 
                        Text="Add" Width="82px" />
                </td>
            </tr>
            </table></td>
        </tr>
    </table>
</asp:Content>

