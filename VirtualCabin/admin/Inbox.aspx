<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="admin_Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 408px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/inbox.png" />
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" 
                                oncheckedchanged="chkSelectAll_CheckedChanged" Text="Select all" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkDelete" runat="server" onclick="lnkDelete_Click">Delete</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdInbox" runat="server" AutoGenerateColumns="False" 
                                AllowPaging="True" PageSize="5">
                            <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" OnCheckedChanged="chkSelect_CheckedChanged" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="From" DataField="MessageFrom" />
                        <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                        
                        <asp:LinkButton ID="lnkTitle" Text='<%# Eval("Title")%>' OnClick="lnkTitle_Click" runat="server">
                        
                        </asp:LinkButton>
                        
                        </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:BoundField DataField="Subject" />
                        <%--<asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                        <%# Eval("Subject")%>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField HeaderText="Date" DataField="MessageDate" DataFormatString="{0:d}"/>
                        </Columns>

                            </asp:GridView>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


