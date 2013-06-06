<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="CancelProjects.aspx.cs" Inherits="admin_CancelProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Image ID="Image2" runat="server" Height="499px" 
                    ImageUrl="~/images/cancel.jpg" Width="347px" />
            </td>
            <td>
                <table class="style1">
        <tr>
            <td colspan="8">
                <asp:Label ID="lblInfo" runat="server"></asp:Label>
    
            </td>
        </tr>
        <tr>
            <td colspan="8">
    <div style="height: 19px; width: 285px">
        <asp:DropDownList ID="drpProjectCategory" runat="server" Height="17px" 
            onselectedindexchanged="drpProjectCategory_SelectedIndexChanged" 
            Width="185px" AutoPostBack="True">
            <asp:ListItem>Cancelled</asp:ListItem>
            <asp:ListItem>Time Out</asp:ListItem>
        </asp:DropDownList>
    </div>
    
            </td>
        </tr>
        <tr>
            <td colspan="8">
    
        <asp:GridView ID="grdCancelProjects" runat="server" AutoGenerateColumns="False" 
            
            
            
            style="height: 133px; width: 288px">
            <Columns>
            <asp:TemplateField HeaderText="SI No">
            <ItemTemplate>
            <asp:Label ID="lblSn" runat="server"> <%# Container.DataItemIndex+1 %> </asp:Label>
            </ItemTemplate>  
            </asp:TemplateField>
                      
                <asp:BoundField DataField="UserName" HeaderText="Username" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Period" HeaderText="Period" />
                <asp:BoundField DataField="PostDate" HeaderText="Post date" />
                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                <asp:CheckBox ID="chkdelete" OnCheckedChanged="chkdelete_CheckedChanged" runat="server"/>
                
                </ItemTemplate>
                </asp:TemplateField>
                      
            </Columns>



        </asp:GridView>
    
            </td>
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
        <asp:Button ID="btnDelete" runat="server" Height="29px" 
            onclick="btnDelete_Click" Text="Delete" Width="83px" />
            </td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

