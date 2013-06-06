<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="MyProjects.aspx.cs" Inherits="employee_MyProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">
    window.histor.forward(1);

</script>
    <style type="text/css">
         
    .style3
    {
        width: 412px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style3">
                <asp:Image ID="Image2" runat="server" Height="470px" 
                    ImageUrl="~/images/myprojects.jpg" Width="410px" />
            </td>
            <td>
                <table class="style1">
        <tr>
            <td class="style2">
                <asp:DropDownList ID="drpStatusTypeProjects" runat="server" AutoPostBack="True" 
                    Height="16px" 
                    onselectedindexchanged="drpStatusTypeProjects_SelectedIndexChanged" 
                    Width="172px">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Selected</asp:ListItem>
                    <asp:ListItem>Rejected</asp:ListItem>
                    <asp:ListItem>Finished</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInfo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdMyProjects" runat="server" Width="503px" RowStyle-HorizontalAlign="Center"
                    AutoGenerateColumns="False">
                <Columns>
                <asp:TemplateField HeaderText="SL No">
                <ItemTemplate>
                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Project">
                <ItemTemplate>
                <asp:LinkButton ID="lnkProject" OnClick="lnkProject_Click" Text='<%#Eval("Title")%>' runat="server">
                </asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="Description" HeaderText="Description" />

                <asp:BoundField HeaderText="Status" DataField="Status" />
                <%--<asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                <asp:LinkButton Text="Delete" ID="lnkdelete" OnClick="lnkdelete_Click" runat="server"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>




                </asp:GridView>
            </td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

