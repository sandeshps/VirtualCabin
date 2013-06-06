<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="EditProjects.aspx.cs" Inherits="employer_EditProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 501px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/edit project 1.jpg" 
                    Width="154px" />
            </td>
            <td class="style4">
                <table class="style1">
        <tr>
            <td colspan="12">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="12">
                <asp:GridView ID="grdEditProjects" runat="server" HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center" AutoGenerateColumns="False" 
                    RowStyle-HorizontalAlign="Center" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdEditProjects_PageIndexChanging" >
                <Columns>
                <asp:TemplateField HeaderText="SL No">
                <ItemTemplate>
                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Title" HeaderText="Project" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Bids" HeaderText="Bids" />
                <asp:BoundField DataField="PostDate" HeaderText="Posted Date" SortExpression="PostDate" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Justify">
                <ItemTemplate>
                <asp:RadioButtonList  ID="rdbtnStatus" AutoPostBack="true" OnSelectedIndexChanged="rdbtnStatus_SelectedIndexChanged" runat="server">
                <asp:ListItem>Cancelled</asp:ListItem>
                <asp:ListItem>Sealed</asp:ListItem>
                </asp:RadioButtonList>
                </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Confirm">
                <ItemTemplate>
                <asp:Button ID="btnSC" Text="Ok" OnClick="btnSC_Click" runat="server" />                
                </ItemTemplate>
                </asp:TemplateField>--%>

               
                
                
                </Columns>







                </asp:GridView></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnOk" runat="server" Height="27px" Text="OK" Width="60px" 
                    onclick="btnOk_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

