<%@ Page Title="" Language="C#" MasterPageFile="~/employee/Employee.master" AutoEventWireup="true" CodeFile="EmployeeHome.aspx.cs" Inherits="employee_EmployeeHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style2
        {
            width: 267px;
        }
        .style3
        {
            width: 258px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
    window.histor.forward(1);

</script>
    <table class="style1" border="2">
        <tr>
            <td class="style2">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/gif/home.gif" 
                    Height="473px" />
            </td>
            </tr>
            </table>
                <table class="style1" 
                    
                    
        style="z-index: 1; left: 692px; top: 297px; position: absolute; height: 280px; width: 47%" 
        align="left">
                    <tr>
                        <td valign="top" class="style3">
                            Welcome
                            <asp:Label ID="lblUsername" runat="server" Font-Size="Medium" Font-Bold="True" 
                                ForeColor="#0033CC"></asp:Label>
                            .<br />
                            You have
                            <asp:Label ID="lblMessages" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                            <br />
                            You have
                            <asp:Label ID="lblPendingCount" runat="server" Font-Bold="True" 
                                ForeColor="Blue"></asp:Label>
                            <br />
                            </td>
                        <td valign="top">
                            <asp:ImageMap ID="imgProfilePhoto" runat="server" Height="100px" Width="100px">
                            </asp:ImageMap>
                        </td>
                    </tr>
                </table>
           
   
</asp:Content>

