<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="employer_EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
    .style4
    {
        width: 509px;
    }
    .style5
    {
        width: 372px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3">
        <tr>
            <td class="style5">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/edit.png" 
                    Width="378px" />
            </td>
            <td>
                <table class="style2">
        <tr>
            <td class="style4">
                Username</td>
            <td>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                First name</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" width="217px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Last name</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" width="217px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Mail id</td>
            <td>
                <asp:TextBox ID="txtMailId" runat="server" width="217px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Address
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Height="58px" TextMode="MultiLine" 
                    width="217px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Country</td>
            <td>
                <asp:DropDownList ID="drpCountry" runat="server" Width="176px" 
                    AutoPostBack="True" onselectedindexchanged="drpCountry_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                State</td>
            <td>
                <asp:DropDownList ID="drpState" runat="server" height="22px" width="176px" 
                    AutoPostBack="True" onselectedindexchanged="drpState_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                City</td>
            <td>
                <asp:DropDownList ID="drpCity" runat="server" height="22px" width="176px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Phone</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" width="217px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Photo</td>
            <td class="style3">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Label ID="lblPhoto" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                    Text="Update" Width="83px" style="margin-left: 40px" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

