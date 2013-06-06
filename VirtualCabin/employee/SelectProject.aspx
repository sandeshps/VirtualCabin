<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="SelectProject.aspx.cs" Inherits="employee_SelectProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            z-index: 1;
            left: 505px;
            top: 216px;
            position: absolute;
            height: 162px;
            width: 648px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" Height="468px" 
                    ImageUrl="~/images/select project.jpg" Width="288px" />
            </td>
            <td>
                <table class="style2" align="center">
            <tr>
                <td colspan="9">
                    <asp:Label ID="lblWarning" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="9">
                   <asp:GridView ID="grdSelectProject" 
                     runat="server" AutoGenerateColumns="False" 
                        HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                    Width="642px" AllowPaging="True" PageSize="7" OnPageIndexChanging="grdSelectProject_PageIndexChanging">
                    <Columns>
                        <%--<asp:BoundField HeaderText="SI No" />--%>
                        <asp:TemplateField HeaderText="SI No">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>              
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                        <asp:LinkButton ID="lnkProjectTitle" Text='<%#Eval("Title")%>' runat="server" 
                                onclick="lnkProjectTitle_Click"></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                       <%-- <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                        <%# Eval("Description").ToString().Length>20 ? Eval("Description").ToString().Substring(0,20) : Eval("Description") %>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="Description" HeaderText="Description"/>
                        <asp:BoundField DataField="PostDate" HeaderText="Post Date" 
                            SortExpression="PostDate" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<RowStyle HorizontalAlign="Center"></RowStyle>
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
            </tr>
        </table></td>
        </tr>
    </table>
</asp:Content>

