<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="RateProjects.aspx.cs" Inherits="employer_RateProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
            height: 505px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3">
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" Height="324px" 
                    ImageUrl="~/images/rate.jpg" Width="244px" />
            </td>
            <td>
                <table class="style1">
        <tr>
            <td colspan="10" class="style2">
                <asp:Label ID="lblNoProjects" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <asp:GridView ID="grdRateProjects" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                    Width="642px">

                    <Columns>
                
                
                    <asp:TemplateField HeaderText="SL No">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Username" HeaderText="Employee" />
                    <asp:BoundField DataField="Title" HeaderText="Project" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Justify" >
                    <ItemTemplate>
                    <asp:RadioButtonList ID="rdbtnRateList" OnSelectedIndexChanged="rdbtnRateList_SelectedIndexChanged" runat="server">
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Bad</asp:ListItem>
                    </asp:RadioButtonList>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click" />
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

