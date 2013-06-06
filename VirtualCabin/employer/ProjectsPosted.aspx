<%@ Page Title="" Language="C#" MasterPageFile="~/employer/Employer.master" AutoEventWireup="true" CodeFile="ProjectsPosted.aspx.cs" Inherits="employer_ProjectsPosted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 223px;
        height: 501px;
    }
    .style5
    {
        height: 501px;
    }
    </style>
</asp:Content>

<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="style3">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/images/my projects employer.png" Width="331px" />
            </td>
            <td class="style5">
                <table class="style1">
            <tr>
                <td>
    
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
        
    
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="grdPostedProjects" runat="server" AutoGenerateColumns="False" 
                        RowStyle-HorizontalAlign="Center" Width="469px">
            <Columns>
            <asp:TemplateField HeaderText="SL No">
            <ItemTemplate>
            
            <%# Container.DataItemIndex+1 %>     
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Project">
            <ItemTemplate>
            <asp:LinkButton ID="lnkProject"  Text='<%# Eval("Title") %>' onClick="lnkProject_Click" runat="server">
            
            </asp:LinkButton>
            
            </ItemTemplate>
            
            </asp:TemplateField>
           <%-- <asp:BoundField DataField="Title" HeaderText="Project" />--%>
           <%--<asp:TemplateField HeaderText="Description">
           <ItemTemplate>
           <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server">
           
           </asp:Label>
           
           </ItemTemplate>
           
           
           </asp:TemplateField>--%>
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>



        </asp:GridView>
    
        
    
                </td>
            </tr>
        </table></td>
        </tr>
    </table>
    
</asp:Content>


