<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Employees.aspx.cs" Inherits="admin_Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
        }
    .style3
    {
        width: 255px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
     <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
     <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="lblMessages" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
                </td>
        </tr>
     <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:LinkButton ID="lnkDelete" runat="server" onclick="lnkDelete_Click">Delete</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                <asp:GridView ID="grdEmployees" runat="server" AllowPaging="True"  HeaderStyle-HorizontalAlign="Center"
                    AutoGenerateColumns="False" PageSize="3" OnPageIndexChanging="grdEmployees_PageIndexChanging" RowStyle-HorizontalAlign="Center">
                 <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                <asp:Image ID="imgProfile" AlternateText="Photo not set" ImageUrl='<%#Eval("Logo")%>' Height="100px" Width="150px" runat="server" />
                </ItemTemplate>
                
                    <ItemStyle Height="100px" Width="100px" />
                
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

