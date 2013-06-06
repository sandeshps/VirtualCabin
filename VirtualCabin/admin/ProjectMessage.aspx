<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="ProjectMessage.aspx.cs" Inherits="admin_ProjectMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 504px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:GridView ID="grdProjects" runat="server" 
                    HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" 
            DataKeyNames="Id,UserName"  
            
            
            
            
            style="height: 136px; width: 691px; z-index: 1; left: 335px; top: 319px; position: absolute;"  
            >
            <Columns>
            <asp:TemplateField HeaderText="SL No">
            <ItemTemplate>
            
            <%# Container.DataItemIndex+1 %>
           
            </ItemTemplate>
            </asp:TemplateField>
                <%--<asp:BoundField HeaderText="SI No" ControlStyle-ForeColor="BurlyWood" />--%> <%--<%# Container.DataItemIndex+1 %>--%>
                <asp:BoundField DataField="UserName" HeaderText="Username" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Period" HeaderText="Period" />
                <asp:BoundField DataField="PostDate" HeaderText="PostDate" />
                <asp:TemplateField HeaderText="Message">
                <ItemTemplate>
                <asp:LinkButton ID="lnkSend" runat="server" onclick="lnkSend_Click">Send</asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView></td>
        </tr>
    </table>
    
</asp:Content>

