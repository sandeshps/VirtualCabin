<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Home.master" AutoEventWireup="true" CodeFile="Reply.aspx.cs" Inherits="admin_Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/reply.png" 
                    Width="484px" />
            </td>
            <td>
                <table class="style3">
                    <tr>
                        <td>
                            
                        <table class="style6">
                            <tr>
                                <td class="style5">
                                    From</td>
                                <td class="style5">
                                    <asp:TextBox ID="txtFrom" runat="server" Height="22px" Width="170px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    To</td>
                                <td>
                                    <asp:TextBox ID="txtTo" runat="server" Height="22px" Width="173px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Title</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Height="19px" width="503px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Subject</td>
                                <td>
                                    <asp:TextBox ID="txtSubject" runat="server" Height="151px" TextMode="MultiLine" 
                                        Width="503px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    </td>
                                <td class="style4">
                                    <asp:Button ID="btnSend" runat="server" Text="Send" Width="64px" 
                                        onclick="btnSend_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="73px" 
                                        onclick="btnClear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblInfo" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                   </td>
                    </tr>
                </table></td>
        </tr>
    </table>
</asp:Content>

