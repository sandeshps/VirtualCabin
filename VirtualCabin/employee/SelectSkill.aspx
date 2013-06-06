<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="SelectSkill.aspx.cs" Inherits="employee_SelectSkill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    window.histor.forward(1);

</script>
    <table class="style1">
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" Height="474px" 
                    ImageUrl="~/images/select skills.jpg" Width="390px" />
            </td>
            <td>
                <table class="style1">
            <tr>
                <td class="style4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Skill Head</td>
                <td>
                    <asp:DropDownList ID="drpSkillHead" runat="server" AutoPostBack="True" 
                        Height="17px" onselectedindexchanged="drpSkillHead_SelectedIndexChanged" 
                        Width="149px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Skill</td>
                <td class="style2">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <asp:CheckBoxList ID="chkskillset" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="btnSubmit" runat="server" Height="28px" 
                        onclick="btnSubmit_Click" Text="Submit" Width="80px" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
               
            </td>
        </tr>
    </table>
</asp:Content>

