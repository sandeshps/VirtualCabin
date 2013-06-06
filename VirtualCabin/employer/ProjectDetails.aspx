<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="ProjectDetails.aspx.cs" Inherits="employer_ProjectDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 279px;
        height: 503px;
    }
    .style5
    {
        height: 503px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/project details.png" 
                    Height="294px" Width="271px" />
            </td>
            <td class="style5">
                <table class="style1">
        <tr>
            <td colspan="25" class="style3">
                <asp:Label ID="lblProjectTitle" runat="server"></asp:Label>
               </td>
        </tr>
        <tr>
            <td colspan="25">
                <asp:Label ID="lblProjectDescription" runat="server"></asp:Label>
               </td>
        </tr>
        <tr>
            <td colspan="25">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
               </td>
        </tr>
        <tr>
            <td colspan="25">
            <asp:GridView ID="grdProjectDetails" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center"
                    Width="580px" Height="43px">
        <Columns>
        <asp:TemplateField HeaderText="SL No">
        <ItemTemplate>
        <%# Container.DataItemIndex+1 %>
        
        </ItemTemplate>
              
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Employee">
        <ItemTemplate>
        <asp:Label ID="lblUsername" Text='<%# Eval("Username") %>' runat="server"></asp:Label>
        
        </ItemTemplate>
        
        </asp:TemplateField>--%>
        <asp:BoundField HeaderText="Employee" DataField="Username" />
        <asp:BoundField HeaderText="Message" DataField="Message" />
        <asp:BoundField HeaderText="Status" DataField="Status" />
        <asp:TemplateField HeaderText="Select">
        <ItemTemplate>
        <asp:CheckBox ID="chkSelect" OnCheckedChanged="chkSelect_CheckedChanged" runat="server"/>
        
        
        </ItemTemplate>
        
        
        </asp:TemplateField>
        
        </Columns>




                <RowStyle HorizontalAlign="Center" />




        </asp:GridView>
               </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnSelect" runat="server" Text="Select" 
                    onclick="btnSelect_Click" />
                </td>
            <td class="style2">
                <asp:Button ID="btnReject" runat="server" onclick="btnReject_Click" 
                    Text="Reject" />
                </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

