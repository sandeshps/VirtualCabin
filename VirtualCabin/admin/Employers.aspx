<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Employers.aspx.cs" Inherits="admin_Employers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    .style3
    {
            width: 282px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server">Delete</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:GridView ID="grdEmployers" runat="server" 
                    RowStyle-HorizontalAlign="Center" AllowPaging="True"  HeaderStyle-HorizontalAlign="Center" 
                    AutoGenerateColumns="False" PageSize="3" OnPageIndexChanging="grdEmployers_PageIndexChanging">
                 <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                <asp:ImageMap ID="imgProfile" ImageUrl='<%#Eval("Logo")%>' Height="100px" Width="150px" runat="server" />
                </ItemTemplate>
                
                </asp:TemplateField>
                <asp:BoundField DataField="Username" />
                <asp:BoundField  HeaderText="Email" DataField="EmailId" />
                <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                
               
                <asp:TemplateField>
                <ItemTemplate>
                <%--<asp:LinkButton ID="lnkEmployees"  Text='<%#Eval("Username")%>' runat="server">
                
                </asp:LinkButton>--%>
                <asp:CheckBox ID="chkdelete" OnCheckedChanged="chkdelete_CheckedChanged" runat="server" />

                </ItemTemplate>
                </asp:TemplateField>

                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

