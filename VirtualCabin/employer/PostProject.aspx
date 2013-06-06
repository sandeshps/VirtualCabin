<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="PostProject.aspx.cs" Inherits="employer_PostProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="height: 492px">
        <tr>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
              <table class="style1" style="height: 478px; width: 100%;">
        <tr>
            <td class="style5">
                Title</td>
            <td class="style3" colspan="2">
                <asp:TextBox ID="txtTitle" runat="server" Width="504px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtTitle" ErrorMessage="* Title required" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
            <td class="style4" rowspan="7" valign="bottom">
                <asp:ListBox ID="lstSkills" runat="server" Height="174px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Description</td>
            <td class="style3" colspan="2">
                <asp:TextBox ID="txtDescription" runat="server" Height="226px" TextMode="MultiLine" 
                    width="504px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDescription" ErrorMessage="* Description required" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Period</td>
            <td class="style3" colspan="2">
                <asp:DropDownList ID="drpPeriod" runat="server" 
                    onselectedindexchanged="drpPeriod_SelectedIndexChanged" 
                    AutoPostBack="True">
                <asp:ListItem>Day(s)</asp:ListItem>
                <asp:ListItem>Week(s)</asp:ListItem>
                <asp:ListItem>Month(s)</asp:ListItem>
                <asp:ListItem>Year(s)</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drpPeriodList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Salary</td>
            <td class="style3" colspan="2">
                <asp:DropDownList ID="drpSalary" runat="server">
                <asp:ListItem>100-500</asp:ListItem>
                <asp:ListItem>500-1000</asp:ListItem>
                <asp:ListItem>1000-5000</asp:ListItem>
                <asp:ListItem>5000-10000</asp:ListItem>
                <asp:ListItem>10000 and above</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Skills required</td>
            <td class="style3">
                <asp:DropDownList ID="drpSkillsRequired" runat="server" AutoPostBack="True" 
                    Height="19px" 
                    Width="184px" 
                    onselectedindexchanged="drpSkillsRequired_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CheckBoxList ID="chkSkillsRequired" runat="server" 
                    RepeatDirection="Horizontal" onselectedindexchanged="chkSkillsRequired_SelectedIndexChanged" 
                    >
                </asp:CheckBoxList>
            </td>
            <td class="style6">
                <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
                    Width="71px" />
            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td colspan="2">
                <asp:Button ID="btnPost" runat="server" Height="27px" Text="Post" 
                    Width="77px" onclick="btnPost_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblInfo" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
    </table> </td>
        </tr>
    </table>
</asp:Content>

