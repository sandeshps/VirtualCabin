<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="ViewProject.aspx.cs" Inherits="employee_ViewProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 263px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Image ID="Image2" runat="server" Height="470px" 
                    ImageUrl="~/images/project icon.jpg" Width="299px" BorderStyle="None" 
                    BorderWidth="1px" />
            </td>
            <td>
                <table class="style4" frame="box">
        <tr>
            <td>
                <table class="style1">
        <tr>
            <td class="style2">
                Title</td>
            <td colspan="2">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Description</td>
            <td colspan="2">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Number of bids</td>
            <td colspan="2">
                <asp:Label ID="lblBids" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Posted Date</td>
            <td colspan="2">
                <asp:Label ID="lblPostDate" Text='<%# Eval("PostDate", "{0:M-dd-yyyy}") %>'  runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Skills Required</td>
            <td class="style3">
                <asp:Label ID="lblSkills" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSkillsMessage" runat="server" ForeColor="#FF3300" 
                    style="text-align: right"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Message</td>
            <td class="style3" colspan="2">
                <asp:TextBox ID="txtComment" runat="server" Height="164px" TextMode="MultiLine" 
                    Width="386px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtComment" ErrorMessage="* This field is a must" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btnPostBid" runat="server" onclick="btnPostBid_Click" 
                    Text="Post Bid" />
                <asp:Label ID="lblBidStatus" runat="server"></asp:Label>
            </td>
        </tr>
    </table></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdProjects" runat="server" 
        
        
        style="height: 133px; width: 624px" RowStyle-HorizontalAlign="Center"
        AutoGenerateColumns="False">
        <Columns>
        <asp:TemplateField HeaderText="SL No">
        <ItemTemplate>
        
         <%# Container.DataItemIndex+1 %>
       
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Username" HeaderText="Employee" />
        <%--<asp:BoundField DataField="Skills" HeaderText="Skills" />--%>
        <asp:BoundField DataField="Message" HeaderText="Comment" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        
        </Columns>


    </asp:GridView></td>
        </tr>
    </table></td>
        </tr>
    </table>
</asp:Content>

