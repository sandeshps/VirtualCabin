<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Sent.aspx.cs" Inherits="admin_Sent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style3
        {
            width: 100%;
        }
    .style4
    {
        width: 429px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="style3">
        <tr>
            <td class="style4">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/sent.png" 
                    Width="322px" />
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            <asp:Label ID="lblInfo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkDelete" runat="server" onclick="lnkDelete_Click">Delete</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdSent" runat="server" AutoGenerateColumns="False" 
                                AllowPaging="True" OnPageIndexChanging="grdSent_PageIndexChanging" 
                                PageSize="5" >
                            <Columns>
                       <asp:TemplateField>
                       <ItemTemplate>
                       <asp:CheckBox ID="chkSentSelect" runat="server" />
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField HeaderText="To" DataField="MessageTo" />
                       <asp:BoundField DataField="Title" HeaderText="Title"  />
                       <asp:BoundField DataField="Subject" HeaderText="Subject" />
                       <asp:BoundField HeaderText="Date" DataField="MessageDate" DataFormatString="{0:d}" />
                       
                       </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

